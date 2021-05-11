using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public class Users
    {
        //Creating identity and primary key
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key, Required]
        public string user_id { get; set; }

        //required
        [Required]
        public string username { get; set; }

        //required
        [Required]
        public string password { get; set; }

        //required
        [Required]
        public string email { get; set; }
    }
}
