using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonAPI_Mysql.Service;

namespace PersonAPI_Mysql.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PersonController : ControllerBase
    {

        private readonly ILogger<PersonController> _logger;
        private IPersonService _personService;
        
        public PersonController(ILogger<PersonController> logger, IPersonService personService)
        {
            _logger = logger;   
            _personService = personService;       
        }

        [HttpGet]
        public IActionResult Get()
        {
            var persons = _personService.FindAll();
            return Ok(persons);
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok();
        }
        
    }
}