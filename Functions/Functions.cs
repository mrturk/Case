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
            user.email = data.GetProperty("email").GetString();
            return user;
        }
    }
}
