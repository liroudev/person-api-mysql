using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PersonAPI_Mysql.Model;
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
        public IActionResult Get(string id)
        {
            if(!IsNumeric(id))
            {
                return BadRequest("Invalid input");
            }

            var idConvertido = ConvertToInt(id);
            var person = _personService.FindbyId(idConvertido);
            return Ok(person);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Person person)
        {
            try
            {
                var p = _personService.Create(person);
                return Ok(p);    
            }
            catch (System.Exception)
            {
                
                return BadRequest();
            }
            
        }

        [HttpPut()]
        public IActionResult Update([FromBody] Person person)
        {


            try
            {
                var p = _personService.Update(person);
                return Ok(p);
            }
            catch (System.Exception)
            {
                
                return BadRequest("Invalid request");
            }


        }


        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            if(!IsNumeric(id))
            {
                return BadRequest("Invalid input");
            }

            var idConvertido = ConvertToInt(id);

            _personService.Delete(idConvertido);

            return NoContent();

        }

        private bool IsNumeric(string number)
        {
            var isNumber = false;

            isNumber = int.TryParse(number,System.Globalization.NumberStyles.Any,
                                    System.Globalization.NumberFormatInfo.InvariantInfo,
                                    out int numeroConvertido);


            return isNumber;

        }

        private int ConvertToInt(string number)
        {
            if(int.TryParse(number,out int numeroConvertido))
            {
                return numeroConvertido;
            }

            return 0;

        }
        
    }
}