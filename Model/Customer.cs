    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using System.Threading.Tasks;

namespace Case.Model
{
    public class Customer
    {

        [Key]
        public int Id { get; set; }

        //required
        [Required]
        public string Ad { get; set; }

        //required
        [Required]
        public string Soyad { get; set; }

        //required
        [Required]
        public string Sehir { get; set; }

    }
}
