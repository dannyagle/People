using People.Common.Models;

namespace People.Common.Interfaces
{
    public interface IPeopleResource
    {
        Person GetPerson(Gender gender, string familyName);
    }
}
