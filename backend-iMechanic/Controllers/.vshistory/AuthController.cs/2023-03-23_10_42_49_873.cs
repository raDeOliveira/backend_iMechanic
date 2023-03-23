using backend_iMechanic.Model;
using Microsoft.AspNetCore.Mvc;

namespace backend_iMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] User User)
        {

        }
    }
}
