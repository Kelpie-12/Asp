using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using MVC.Model.DTO;

namespace MVC.Services.Implementation
{
    public class JwtServices : IJwtServices
    {
        public string GenerateToken(UserDTO user)
        {
            List<Claim> claims = new List<Claim>()
            {
                new Claim("userEmail",user.Email)
                //new Claim("FirstName",user.FirstName),
                //new Claim("LastName",user.LastName),
            };
            var date = DateTime.UtcNow.Add((new TimeSpan(1, 0, 0)));
            var token = new JwtSecurityToken(
                expires:date,
                claims:claims,
                signingCredentials: 
                new Microsoft.IdentityModel.Tokens.SigningCredentials(
                    new SymmetricSecurityKey(Encoding.UTF8.GetBytes("SecretString1234SecretString1234")), SecurityAlgorithms.HmacSha256));
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
