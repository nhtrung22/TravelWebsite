using TravelWebsite.Jwt;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace TravelWebsite.Jwt
{
    public class JWTManagerRepository : IJWTManagerRepository
    {

        private readonly IConfiguration iconfiguration;
        public JWTManagerRepository(IConfiguration iconfiguration)
        {
            this.iconfiguration = iconfiguration;
        }
        public Tokens Authenticate(LoginModel users)
        {
<<<<<<< HEAD
            // Else we generate JSON Web Token
            // check user
=======

            // Else we generate JSON Web Token
>>>>>>> TrungNH
            var tokenHandler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.UTF8.GetBytes(iconfiguration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
              {
                    new Claim(ClaimTypes.Name, users.UserName),
<<<<<<< HEAD
                    new Claim(ClaimTypes.Role, users.UserName),
                    //todo
                    new Claim("Id", "123")
=======
                    new Claim(ClaimTypes.Role, users.UserName)
>>>>>>> TrungNH
              }),
                Expires = DateTime.UtcNow.AddMinutes(10),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(tokenKey), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new Tokens { Token = tokenHandler.WriteToken(token) };

        }
    }
}
