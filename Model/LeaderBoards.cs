using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public class LeaderBoards: UsersAndLeaderBoards
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Required]
        public string id { get; set; }

        [Required]
        public string countr { get; set; }

        [Required]
        public string display_name { get; set; }

        [Required]
        public int points { get; set; }

        [Required]
        public int rank { get; set; }
    }
}
