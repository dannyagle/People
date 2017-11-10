using Microsoft.VisualStudio.TestTools.UnitTesting;
using People.Common;
using People.Common.Models;

namespace People.Manager.Tests
{
    [TestClass]
    public class ResourceTests
    {
        [TestMethod]
        public void GetPerson_GenderFamily_ValidPerson()
        {
            var resource = new PeopleResource();
            var person = resource.GetPerson(Gender.Male, "Smith");
            Assert.IsNotNull(person, "Person should not be null when provided male and Smith.");
            Assert.IsFalse(string.IsNullOrEmpty(person.FirstName), "FirstName should not be null or empty.");
            Assert.AreEqual("Smith", person.LastName, "LastName should be Smith.");
            Assert.IsTrue(person.Gender == Gender.Male, "Gender should be male since we passed in Male.");
        }
    }
}
