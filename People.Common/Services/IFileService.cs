using System.Threading.Tasks;

namespace People.Common.Services;

public interface IFileService
{
    Task<string[]> GetFileContentsAsync<T>(string path);
}
