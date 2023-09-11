using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using MicroServiceAuthentication.Services.IServices;
using MicroServiceAuthentication.Utilities;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace MicroServiceAuthentication.Services
{
    
    
        public class JWTServices : IJWtTokenGenerator
        {
            private readonly JWTOptions _jwtOptions;
            public JWTServices(IOptions<JWTOptions> jWTOptions)
            {
                _jwtOptions = jWTOptions.Value;
            }
            public string GenerateToken(IdentityUser user, IEnumerable<string> roles)
            {
                var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.SecretKey));
                //Signing Credentials
                var cred = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                //payload-data
                List<Claim> claims = new List<Claim>();
                claims.Add(new Claim(JwtRegisteredClaimNames.Name, user.Email));
                claims.Add(new Claim(JwtRegisteredClaimNames.Sub, user.Id));
                claims.Add(new Claim(JwtRegisteredClaimNames.Email, user.Email));

                //add Roles
                claims.AddRange(roles.Select(r => new Claim(ClaimTypes.Role, r)));

                var tokenDescriptor = new SecurityTokenDescriptor()
                {
                    Issuer = _jwtOptions.Issuer,
                    Audience = _jwtOptions.Audience,
                    Expires = DateTime.UtcNow.AddHours(3),
                    Subject = new ClaimsIdentity(claims),
                    SigningCredentials = cred
                };

                var token = new JwtSecurityTokenHandler().CreateToken(tokenDescriptor);
                return new JwtSecurityTokenHandler().WriteToken(token);
            }


        }
}
