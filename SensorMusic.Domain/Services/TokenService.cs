using Microsoft.IdentityModel.Tokens;
using SensorMusic.Domain.Entities;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace SensorMusic.Domain.Services
{
    public static class TokenService
    {
        public static string GenerateToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Settings.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, user.IdUser.ToString()),
                    new Claim("Hometown", user.Hometown),
                    new Claim("IdUser", user.IdUser.ToString()),

                }),
                Expires = DateTime.UtcNow.AddDays(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }

        public static string ReadTokenReturnValue(string jwtInput, string claimToken)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtInput);
            var tokenS = handler.ReadToken(jwtInput) as JwtSecurityToken;
            var jti = tokenS.Claims.First(claim => claim.Type == claimToken).Value;
            return jti;
        }

        public static string ReadTokenReturnValueEncodedRawSignature(string jwtInput)
        {
            var handler = new JwtSecurityTokenHandler();
            var jsonToken = handler.ReadToken(jwtInput);
            var tokenS = handler.ReadToken(jwtInput) as JwtSecurityToken;

            return tokenS.RawSignature;
        }
    }
}
