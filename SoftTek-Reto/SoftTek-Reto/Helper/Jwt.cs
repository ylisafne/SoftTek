using SoftTek_Reto.Models;
using System.Security.Claims;

namespace SoftTek_Reto.Helper
{
    public class Jwt
    {
        public string key { get; set; }
        public string Issuer { get; set; }
        public string Audience { get; set; }

    }
}
