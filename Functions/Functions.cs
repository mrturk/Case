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
            user.display_name = data.GetProperty("display_name").GetString();
            user.points = data.GetProperty("points").GetInt32();
            user.rank = data.GetProperty("rank").GetInt32();
            return user;
        }

        public Scores fillScoreModel([FromBody] JsonElement data)
        {
            Scores scores = new Scores();

            scores.score_worth = float.Parse(Convert.ToString(data.GetProperty("score_worth").GetDouble()));
            scores.user_id = data.GetProperty("user_id").GetString();
            scores.timestamp = data.GetProperty("timestamp").GetInt32();
            return scores;
        }
    }
}
