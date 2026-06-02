using Microsoft.AspNetCore.Mvc;
using VetClinicAPI.Data;
using VetClinicAPI.DTO;

namespace VetClinicAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;

        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginDTO loginDTO)
        {
            var user = _context.Veterinarians.FirstOrDefault(v => v.Name == loginDTO.Username);

            if (user == null) {
                return Unauthorized("Invalid username or password");
            }

            bool isPassValid = BCrypt.Net.BCrypt.Verify(loginDTO.Password, user.PassHash);

            if (!isPassValid) {
                return Unauthorized("Invalid username or password");
            }

            return Ok( new {Id = user.Id, Username = user.Name });
        }
    }
}
