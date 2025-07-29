using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Wallet.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest request)
        {
            if (request.Username != "admin" || request.Password != "1234")
                return Unauthorized();

            var claims = new[]
            {
            new Claim(ClaimTypes.Name, request.Username)
        };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("clave_super_secreta_para_prueba_tecnica_jwt_segura_long_xd_hola"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds,
                claims: claims
            );

            return Ok(new { token = new JwtSecurityTokenHandler().WriteToken(token) });
        }

        public class LoginRequest
        {
            public string Username { get; set; } = null!;
            public string Password { get; set; } = null!;
        }

    }
}
