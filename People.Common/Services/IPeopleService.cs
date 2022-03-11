using People.Common.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Common.Services;

public interface IPeopleService
{
    Task<Person> GetPersonAsync();
    Task<Person> GetPersonAsync(Gender gender);
    Task<Person> GetPersonAsync(string familyName);
    Task<Person> GetPersonAsync(Gender gender, string familyName);
    Task<List<Person>> GetPersonsAsync(int quantity);
    Task<List<Person>> GetPersonsAsync(int quantity, Gender gender);
    Task<List<Person>> GetPersonsAsync(int quantity, string familyName);
    Task<List<Person>> GetPersonsAsync(int quantity, Gender gender, string familyName);
}
