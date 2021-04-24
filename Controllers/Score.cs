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
    public class Score : ControllerBase
    {
        private readonly MyWebApiContext _MyWebApiContext;

        private Functions.Functions functions = new Functions.Functions();
        public Score(MyWebApiContext MyWebApiContext)
        {
            _MyWebApiContext = MyWebApiContext;
        }


        [HttpPost]
        [Route("score/submit")]
        public IActionResult Submit([FromBody] JsonElement data)
        {
            _MyWebApiContext.Scores.Add(functions.fillScoreModel(data));
            _MyWebApiContext.SaveChanges();
            return Ok(_MyWebApiContext.Scores.ToList());
        }
    }
}
