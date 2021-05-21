using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Case.Model
{
    public class BasketProduct
    {

        [Key]
        public int Id { get; set; }

        //required
        [Required]
        public int SepetId { get; set; }

        //required
        [Required]
        public float Tutar { get; set; }

        //required
        [Required]
        public string Aciklama { get; set; }
    }
}
