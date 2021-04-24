using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public abstract class UsersAndLeaderBoards
    {
        [Required]
        public string display_name { get; set; }

        [Required]
        public int points { get; set; }

        [Required]
        public int rank { get; set; }
    }
}
