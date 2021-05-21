using Case.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Case.Functions
{
    public class Functions
    {
        public Users fillUserModel([FromBody] JsonElement data)
        {
            Users user = new Users();
            user.username = data.GetProperty("username").GetString();
            user.password = data.GetProperty("password").GetString();
            return user;
        }

        public string randomString()
        {
            var chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            var stringChars = new char[8];
            var random = new Random();

            for (int i = 0; i < stringChars.Length; i++)
            {
                stringChars[i] = chars[random.Next(chars.Length)];
            }

            string finalString = new String(stringChars);

            return finalString;
        }
        
    }
}
