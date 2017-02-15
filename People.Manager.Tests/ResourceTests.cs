using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using FluentAssertions;
using System.Linq;

namespace People.Manager.Tests
{
    [TestClass]
    public class ResourceTests
    {
        [TestMethod]
        public void GetPerson_SexFamily_ValidPerson()
        {
            var resource = new People.Manager.PeopleResource();
            var person = resource.GetPerson(Gender.Male, "Smith");
            Assert.IsNotNull(person, "Person should not be null when provided male and Smith.");
            Assert.IsTrue(person.IsMale, "IsMale should be true since we passed in Male.");
            Assert.AreEqual("Smith", person.LastName, "LastName should be Smith.");
        }

        [TestMethod]
        public void GetPersons_NoParams_ValidPeople()
        {
            var resource = new People.Manager.PeopleResource();
            var people = resource.GetPersons(10);
            Assert.IsNotNull(people, "People should not be null");
            Assert.IsTrue(people.Count == 10, "There should be 10 people.");
        }

        [TestMethod]
        public void GetPersons_NoParams_NoRepeats()
        {
            var resource = new People.Manager.PeopleResource();
            var people = resource.GetPersons(10);
            Assert.IsNotNull(people, "People should not be null");
            //people.Should().OnlyHaveUniqueItems();
            Assert.IsFalse(people.GroupBy(x => new { x.FirstName, x.LastName }).Where(x => x.Skip(1).Any()).Any(), "There are duplicates.");
        }

        [TestMethod]
        public void GetPersons_Gender_OnlyMales()
        {
            var resource = new People.Manager.PeopleResource();
            var people = resource.GetPersons(10, Gender.Male);
            Assert.IsNotNull(people, "People should not be null");
            Assert.IsFalse(people.Any(p => p.IsMale == false), "There are some non-male people in this list but should not be.");
        }


    }
}
