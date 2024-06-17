using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using TrybeHotel.Models;
using TrybeHotel.Dto;

namespace TrybeHotel.Services
{
    public class TokenGenerator
    {
        private readonly TokenOptions _tokenOptions;
        public TokenGenerator()
        {
           _tokenOptions = new TokenOptions {
                Secret = "4d82a63bbdc67c1e4784ed6587f3730c",
                ExpiresDay = 1
           };

        }
         public string Generate(UserDto user)
        {
            var manipuladorToken = new JwtSecurityTokenHandler();
            var chaveCodificada = Encoding.ASCII.GetBytes(_tokenOptions.Secret);

            var descritorToken = new SecurityTokenDescriptor
            {
                Subject = AddClaims(user),
                Expires = DateTime.UtcNow.AddDays(_tokenOptions.ExpiresDay),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(chaveCodificada), SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenCriado = manipuladorToken.CreateToken(descritorToken);
            return manipuladorToken.WriteToken(tokenCriado);
        }

        private ClaimsIdentity AddClaims(UserDto user)
        {
            var identidadeClaims = new ClaimsIdentity();
            identidadeClaims.AddClaim(new Claim(ClaimTypes.Email, user.Email!));

            if (user.UserType == "admin")
            {
                identidadeClaims.AddClaim(new Claim(ClaimTypes.Role, "admin"));
            }

            return identidadeClaims;
        }
    }
}