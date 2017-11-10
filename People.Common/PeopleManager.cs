using People.Common.Interfaces;
using People.Common.Models;
using System.Collections.Generic;

namespace People.Common
{
    public class PeopleManager : IPeopleManager
    {
        private readonly IPeopleEngine _peopleEngine;

        public PeopleManager(IPeopleEngine peopleEngine)
        {
            _peopleEngine = peopleEngine;
        }

        public Person GetPerson()
        {
            return _peopleEngine.GetPerson();
        }

        public Person GetPerson(Gender gender)
        {
            return _peopleEngine.GetPerson(gender);
        }

        public Person GetPerson(string familyName)
        {
            return _peopleEngine.GetPerson(familyName);
        }

        public Person GetPerson(Gender gender, string familyName)
        {
            return _peopleEngine.GetPerson(gender, familyName);
        }

        public List<Person> GetPersons(int quantity)
        {
            return _peopleEngine.GetPersons(quantity);
        }

        public List<Person> GetPersons(int quantity, Gender gender)
        {
            return _peopleEngine.GetPersons(quantity, gender);
        }

        public List<Person> GetPersons(int quantity, string familyName)
        {
            return _peopleEngine.GetPersons(quantity, familyName);
        }

        public List<Person> GetPersons(int quantity, Gender gender, string familyName)
        {
            return _peopleEngine.GetPersons(quantity, gender, familyName);
        }
    }
}
