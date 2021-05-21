using Case.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace Case.Controllers
{
    //Authorize required
    [Authorize]
    [ApiController]
    public class User : ControllerBase
    {
        //Model Acces
        private readonly MyWebApiContext _MyWebApiContext;

        //Jwt Acces
        private readonly IJwtAuthenticationManager jwtAuthenticationManager;

        private Functions.Functions functions = new Functions.Functions();


        // Constructor for jwt and model
        public User(IJwtAuthenticationManager jwtAuthenticationManager, MyWebApiContext MyWebApiContext)
        {
            this.jwtAuthenticationManager = jwtAuthenticationManager;
            this._MyWebApiContext = MyWebApiContext;
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
            Basket basket = new Basket();
            basket.MusterId = "denemetest";

            _MyWebApiContext.Basket.Add(basket);
            _MyWebApiContext.SaveChanges();
            return Ok(_MyWebApiContext.Basket.ToList());
        }

        //Allow Anonymity
        [AllowAnonymous]
        [HttpPost]
        [Route("user/login")]
        public IActionResult login([FromBody] JsonElement data)
        {
            var response = _MyWebApiContext.Users
                .Where(model => model.username == data.GetProperty("username").GetString())
                .Where(model => model.password == data.GetProperty("password").GetString()).ToList();
            if (response.Count == 0)
            {
                return Unauthorized();
            }

            var token = jwtAuthenticationManager.Authenticate(data.GetProperty("username").GetString());
            if (token == null)
            {
                return Unauthorized();
            }

            ResponseAuth responseAuth = new ResponseAuth
            {
                password = null,
                token = token,
                username = response[0].username,
                user_id = response[0].user_id
            };

            return Ok(responseAuth);
        }

        //Allow Anonymity
        [AllowAnonymous]
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
