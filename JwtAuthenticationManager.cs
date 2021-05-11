using Case.Model;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace Case
{
    public class JwtAuthenticationManager : IJwtAuthenticationManager
    {

        //incoming reference key    
        private readonly string tokenKey;
        public JwtAuthenticationManager(string tokenKey)
        {
            //assign the incoming reference key to the value of tokenKey
            this.tokenKey = tokenKey;
        }


        //jwt key generator
        public string Authenticate(string username)
        {
            var tokenHandler = new JwtSecurityTokenHandler();

            //incoming reference key
            var key = Encoding.ASCII.GetBytes(tokenKey);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, username)
                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
