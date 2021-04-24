using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public class Scores
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Required]
        public string id { get; set; }

        [Required]
        public float score_worth { get; set; }

        [Required]
        public string user_id { get; set; }

        [Required]
        public int timestamp { get; set; }
    }
}
