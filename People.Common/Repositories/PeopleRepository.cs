using People.Common.Models;
using People.Common.Repositories;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace People.Common.Services;

public class PeopleRepository : IPeopleRepository
{
    private readonly IFileService _fileService;

    private readonly (string[] Male, string[] Female, string[] Family) _names;

    private static readonly Random _random = new Random();
    private TextInfo _textInfo = null;

    public PeopleRepository(IFileService fileService)
    {
        _textInfo = new CultureInfo("en-US").TextInfo;
        _fileService = fileService;
        _names = LoadDataAsync().Result;
    }

    public async Task<string> GetFemaleNameAsync() =>
        await Task.Run(() => _textInfo.ToTitleCase(_names.Female[_random.Next(1, _names.Female.Length) - 1].ToLower()));

    public async Task<string> GetMaleNameAsync() =>
        await Task.Run(() => _textInfo.ToTitleCase(_names.Male[_random.Next(1, _names.Male.Length) - 1].ToLower()));

    public async Task<string> GetFamilyNameAsync() =>
        await Task.Run(() => _textInfo.ToTitleCase(_names.Family[_random.Next(1, _names.Family.Length) - 1].ToLower()));


    private async Task<(string[] Male, string[] Female, string[] Family)> LoadDataAsync()
    {
        var femaleTask = _fileService.GetFileContentsAsync<GivenName>("female.json");
        var maleTask = _fileService.GetFileContentsAsync<GivenName>("male.json");
        var familyTask = _fileService.GetFileContentsAsync<FamilyName>("family.json");

        await Task.WhenAll(femaleTask, maleTask, familyTask);

        return (await maleTask, await femaleTask, await familyTask);
    }
}
