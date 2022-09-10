using EmployeeAPI.Models.Domain;
using EmployeeAPI.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        //Step 1 of Data Injection
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        //Step 2 of DI
        public AccountController(IJwtAuthenticationManager jwtAuthenticationManager)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
        }

        //Action method to be called in UI
        [HttpPost]
        public IActionResult Authenticate([FromBody] User user)   //Model Binding (here model class)
        {
            var token = jwtAuthenticationManager.Authenticate(user.Username, user.Password);
            if(token == null)
            {
                return Unauthorized();
            }
            return Ok(token);

        }
    }
}
