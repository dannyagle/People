using People.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace People.Common.Services
{
    public interface IPeopleRepository
    {
        Task<Person> GetPersonAsync(Gender gender, string familyName);
    }
}
