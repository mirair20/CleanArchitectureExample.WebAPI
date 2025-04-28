using CleanArchitectureExample.Application.Interfaces;
using CleanArchitectureExample.WebAPI.model;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchitectureExample.WebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class GreetingController : ControllerBase
    {
        private readonly IGreetingService _greetingService;

        public GreetingController(IGreetingService greetingService)
        {
            _greetingService = greetingService;
        }

        [HttpGet("{name}")]
        public ActionResult<string> Get(string name)
        {
            var greeting = _greetingService.Greet(name);
            return Ok(greeting);
        }
    }

    [ApiController]
    [Route("[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserRegistrationService _userRegistrationService;
        public UserController(IUserRegistrationService userRegistrationService) 
        {
            _userRegistrationService = userRegistrationService;
        }


        [HttpPost("USerAsync")]
        public async Task<IActionResult> RegisterUserAsync([FromBody] UserRegistrationRequest request)
        {
            //if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email))
            //{
            //    return BadRequest("Nimi ja Sähköpostin ovat pakollisia tietoja.");
            //}
            var IsExistingEmail = await _userRegistrationService.EmailExistsAsync(request.Email);

            if (IsExistingEmail)
            {
                return BadRequest("Sähköposti on jo käytössä");
            }
            var success = await _userRegistrationService.RegisterUserAsync(request.Name, request.Email);
            if (!success)
            {
                return BadRequest("Rekisteröinti epäonnistui");
            }
            return Created();
        }


    }

}
