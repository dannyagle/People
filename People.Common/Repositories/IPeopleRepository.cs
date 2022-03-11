using People.Common.Models;
using System.Threading.Tasks;

namespace People.Common.Repositories;

public interface IPeopleRepository
{
    Task<string> GetFemaleNameAsync();
    Task<string> GetMaleNameAsync();
    Task<string> GetFamilyNameAsync();
}
