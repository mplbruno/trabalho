using System;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using Apicursos.Models;

namespace Apicursos.Helpers
{
    public class AuthenticationJwt
    {
        public static string GenerateToken(Users user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

          
            var key = Encoding.ASCII.GetBytes("HSJHDKSSinghgdrtuoomn129800=%%");

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Name.ToString()),
                    new Claim(ClaimTypes.Role, RoleFactory(user.Type))
                }),
                Expires = DateTime.UtcNow.AddHours(10),

                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }

        private static string RoleFactory(int roleNumber)
            
        {
            switch (roleNumber)
            {
                case 1:
                    return "Manager";

                case 2:
                    return "Secretary";

                case 3:
                    return "Colaborator";


                default:
                    throw new Exception();
            }
            
        }
    }
    
}
