using Case.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Case.Controllers
{
    [ApiController]
    public class User : ControllerBase
    {

        private readonly MyWebApiContext _MyWebApiContext;

        private Functions.Functions functions = new Functions.Functions();
        public User(MyWebApiContext MyWebApiContext)
        {
            _MyWebApiContext = MyWebApiContext;
        }

        [HttpGet]
        [Route("user/profile/{guid}")]
        public IActionResult profile(string guid)
        {
            return Ok(_MyWebApiContext.Users.Find(guid));
        }


        [HttpGet]
        [Route("user/allusers")]
        public IActionResult allUsers()
        {
            return Ok(_MyWebApiContext.Users.ToList());
        }



        [HttpPost]
        [Route("user/create")]
        public IActionResult create([FromBody] JsonElement data)
        {
            _MyWebApiContext.Users.Add(functions.fillUserModel(data));
            _MyWebApiContext.SaveChanges();
            return Ok(_MyWebApiContext.Users.ToList());
        }


    }
}
