using System.Collections.Generic;

namespace People.Manager
{
    public interface IPeopleResource
    {
        Person GetPerson();
        Person GetPerson(Gender sex);
        Person GetPerson(Gender sex, string familyName);
        Person GetPerson(string familyName);
        List<Person> GetPersons(int quantity);
        List<Person> GetPersons(int quantity, Gender sex);
        List<Person> GetPersons(int quantity, Gender sex, string familyName);
    }
}
