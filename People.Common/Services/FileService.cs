using People.Common.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace People.Common.Services;

public class FileService : IFileService
{
    public async Task<string[]> GetFileContentsAsync<T>(string path)
    {
        var fileContents = await File.ReadAllTextAsync(path);
        return JsonSerializer
            .Deserialize<List<T>>(fileContents)
            .Select(x => ((INameRecord)x).Name)
            .ToArray();
    }
}
