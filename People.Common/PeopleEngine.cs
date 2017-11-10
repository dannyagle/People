using People.Common.Interfaces;
using People.Common.Models;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace People.Common
{
    public class PeopleEngine : IPeopleEngine
    {
        private readonly IPeopleResource _peopleResource;

        public PeopleEngine(IPeopleResource peopleResource)
        {
            _peopleResource = peopleResource;
        }

        public Person GetPerson()
        {
            return GetPerson(Gender.Any, string.Empty);
        }

        public Person GetPerson(Gender gender)
        {
            return GetPerson(gender, string.Empty);
        }

        public Person GetPerson(string familyName)
        {
            return GetPerson(Gender.Unknown, familyName);
        }

        public Person GetPerson(Gender gender, string familyName)
        {
            return _peopleResource.GetPerson(gender, familyName);
        }

        public List<Person> GetPersons(int quantity)
        {
            return GetPersons(quantity, Gender.Any, string.Empty);
        }

        public List<Person> GetPersons(int quantity, Gender gender)
        {
            return GetPersons(quantity, gender, string.Empty);
        }

        public List<Person> GetPersons(int quantity, string familyName)
        {
            return GetPersons(quantity, Gender.Any, familyName);
        }

        public List<Person> GetPersons(int quantity, Gender gender, string familyName)
        {
            var people = new ConcurrentBag<Person>();
            Parallel.For(0, quantity, p =>
            {
                people.Add(GetPerson(gender, familyName));
            });

            return people.ToList();
        }
    }
}
