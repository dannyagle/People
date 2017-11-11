using Microsoft.AspNetCore.Mvc;
using People.Common.Interfaces;
using People.Common.Models;

namespace PeopleStatelessWebApi.Controllers
{
    [Produces("application/json")]
    [Route("api/people")]
    public class PeopleController : Controller
    {
        private readonly IPeopleManager _manager;

        public PeopleController(IPeopleManager manager)
        {
            _manager = manager;
        }
        

        // GET api/values
        [HttpGet()]
        public IActionResult Get([FromQuery] int quantity = 1, string familyName = "", int gender = 0)
        {
            var persons = _manager.GetPersons(quantity, (Gender)gender, familyName);
            return Ok(persons);
        }

    }
}
