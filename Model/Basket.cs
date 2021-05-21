using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public class Basket
    {

        [Key]
        public int Id { get; set; }

        //required
        [Required]
        public string MusterId { get; set; }

    }
}
