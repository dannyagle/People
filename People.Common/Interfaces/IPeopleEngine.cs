using People.Common.Models;
using System.Collections.Generic;

namespace People.Common.Interfaces
{
    public interface IPeopleEngine
    {
        Person GetPerson();
        Person GetPerson(Gender gender);
        Person GetPerson(string familyName);
        Person GetPerson(Gender gender, string familyName);
        List<Person> GetPersons(int quantity);
        List<Person> GetPersons(int quantity, Gender gender);
        List<Person> GetPersons(int quantity, string familyName);
        List<Person> GetPersons(int quantity, Gender gender, string familyName);
    }
}
