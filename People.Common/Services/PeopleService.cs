using People.Common.Models;
using People.Common.Repositories;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace People.Common.Services;

public class PeopleService : IPeopleService
{
    private readonly IPeopleRepository _repository;
    private static readonly Random _random = new Random();

    public PeopleService(IPeopleRepository repository)
    {
        _repository = repository;
    }


    public async Task<Person> GetPersonAsync() =>
        await GetPersonAsync(Gender.Any, string.Empty);


    public async Task<Person> GetPersonAsync(Gender gender) =>
        await GetPersonAsync(gender, string.Empty);


    public async Task<Person> GetPersonAsync(string familyName) =>
        await GetPersonAsync(Gender.Unknown, familyName);


    public async Task<List<Person>> GetPersonsAsync(int quantity) =>
        await GetPersonsAsync(quantity, Gender.Any, string.Empty);


    public async Task<List<Person>> GetPersonsAsync(int quantity, Gender gender) =>
        await GetPersonsAsync(quantity, gender, string.Empty);


    public async Task<List<Person>> GetPersonsAsync(int quantity, string familyName) =>
        await GetPersonsAsync(quantity, Gender.Any, familyName);


    public async Task<Person> GetPersonAsync(Gender gender, string familyName)
    {
        if(gender == Gender.Unknown || gender == Gender.Any)
            gender = (Gender)_random.Next(0, 2) + 1;

        var lastNameTask = !string.IsNullOrEmpty(familyName)
            ? Task.FromResult(familyName)
            : _repository.GetFamilyNameAsync();

        var firstNameTask = gender == Gender.Female 
            ? _repository.GetFemaleNameAsync()
            : _repository.GetMaleNameAsync();

        return new Person(Guid.NewGuid(), await firstNameTask, await lastNameTask, gender);
    }

    public async Task<List<Person>> GetPersonsAsync(int quantity, Gender gender, string familyName)
    {
        var tasks = new List<Task<Person>>();
        for (int i = 0; i < quantity; i++)
        {
            tasks.Add(GetPersonAsync(gender, familyName));
        }

        var results = await Task.WhenAll(tasks);
        return new List<Person>(results);
    }
}
