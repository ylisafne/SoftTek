using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.JsonWebTokens;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SoftTek_Reto.Helper;
using SoftTek_Reto.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SoftTek_Reto.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        private readonly APPContext _context;
        private readonly IConfiguration _config;
        public LoginController(APPContext context, IConfiguration config)
        {
            _context = context;
            _config = config;
        }

        [HttpPost]
        public IActionResult login([FromBody] User user) {

            var Asesor = _context.Asesors.Where(x => x.UserName == user.UserName && x.Password == user.Password).FirstOrDefault();
            if (Asesor == null)
            {
                return Ok(new
                {
                    Success = false,
                    Message = "Credenciales Incorrectas",
                    result = "",
                });
            }

            var jwt = _config.GetSection("Jwt").Get<Jwt>();

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwt.key));
            var credentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new[] {
                new Claim(ClaimTypes.NameIdentifier, Asesor.UserName),
                new Claim(ClaimTypes.GivenName, Asesor.Nombre),
                new Claim(ClaimTypes.Surname, Asesor.Apellido),
                new Claim(ClaimTypes.Role, Asesor.Rol),
                new Claim("IdAsesor", Asesor.IdAsesor.ToString())
            };

            var token = new JwtSecurityToken(
                jwt.Issuer,
                jwt.Audience,
                claims,
                expires: DateTime.UtcNow.AddDays(60),
                signingCredentials: credentials
                );
            return Ok(new {
                Success = true,
                Message = "",
                result = new JwtSecurityTokenHandler().WriteToken(token)
            });
        }
    }
}
