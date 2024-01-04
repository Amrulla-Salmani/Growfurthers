using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace ProjectTracker.Models
{
    public class JwtService
    {
        public string SecretKey { get; set; }
        public int TokenDuration { get; set; }
        public string ValidIssuer { get; set; }
        public string ValidAudience { get; set; }

        private readonly IConfiguration config;

        public JwtService(IConfiguration _config)
        {
            config = _config;

            this.SecretKey = config.GetSection("jwtConfig").GetSection("key").Value;
            this.TokenDuration = Int32.Parse(config.GetSection("jwtConfig").GetSection("Duration").Value);
            this.ValidIssuer = config.GetSection("jwtConfig").GetSection("Issuer").Value;
            this.ValidAudience = config.GetSection("jwtConfig").GetSection("Audience").Value;
        }

        public string GenerateToken(string id, string firstname, string lastname, string email, string phoneNo, string membership,string userRole)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(this.SecretKey));

            var signature = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var payload = new[]
            {
                new Claim("id",id),
                new Claim("firstname",firstname),
                new Claim("lastname",lastname),
                new Claim("email",email),
                new Claim("phoneNo",phoneNo),
                new Claim("membership",membership),
                new Claim(ClaimTypes.Role,userRole)
            };

            var jwtToken = new JwtSecurityToken(
                issuer: ValidIssuer,
                audience: ValidAudience,
                claims: payload,
                expires: DateTime.Now.AddMinutes(TokenDuration),
                signingCredentials: signature
                );

            return new JwtSecurityTokenHandler().WriteToken(jwtToken);
        }
    }
}
