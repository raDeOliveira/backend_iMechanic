using backend_iMechanic.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace backend_iMechanic.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly iMechanicDbContext _context;

        public AuthController(iMechanicDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] User user)
        {
            if (user is null)
            {
                return BadRequest("Invalid client request");
            }

            // check if user exists in DB
            //var userExists = _context.Users.Where(u => u.Name.Equals(user.Name) && u.Password.Equals(user.Password)).FirstOrDefault();
            var userExists = _context.Users.Where(u => u.Name.Equals(user.Name)).FirstOrDefault();
            if (userExists != null)
            {
                var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("superSecretKey@345"));
                var signinCredentials = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);
                var tokeOptions = new JwtSecurityToken(
                    issuer: "https://localhost:7166",
                    audience: "https://localhost:7166",
                    claims: new List<Claim>(),
                    expires: DateTime.Now.AddMinutes(5),
                    signingCredentials: signinCredentials
                );

                var tokenString = new JwtSecurityTokenHandler().WriteToken(tokeOptions);

                return Ok(new AuthenticatedResponse { Token = tokenString });
            }
            return Unauthorized();
        }

        // signup
        [HttpPost("signup")]
        public IActionResult Signup([FromBody] User user)
        {
            if (_context.Users == null)
            {
                return Problem("Entity set 'iMechanicDbContext.Users'  is null.");
            }
            _context.Users.Add(user);
            _context.SaveChangesAsync();

            return Ok(user);
        }
    }
}
