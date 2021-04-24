using Case.Model;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Case.Controllers
{

    [ApiController]
    public class LeaderBoard : ControllerBase
    {
        private readonly MyWebApiContext _MyWebApiContext;

        private Functions.Functions functions;
        public LeaderBoard(MyWebApiContext MyWebApiContext)
        {
            _MyWebApiContext = MyWebApiContext;
        } 
        [HttpGet]
        [Route("leaderboard/{country_iso_code}")]
        public IActionResult getLeaderBoardForCic(string country_iso_code)
        {
            return Ok(_MyWebApiContext.LeaderBoards.Where(model=>model.countr== country_iso_code).ToList());
        }


        [HttpGet]
        [Route("leaderboard")]
        public IActionResult addLeaderBoard()
        {
            return Ok(_MyWebApiContext.LeaderBoards.ToList());
        }
    }
}
