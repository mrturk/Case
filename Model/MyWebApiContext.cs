using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Case.Model
{
    public class MyWebApiContext:DbContext
    {
        public MyWebApiContext(DbContextOptions<MyWebApiContext> options) : base(options) { }


        //Model specification for migration
        public DbSet<Users> Users { get; set; }

        public DbSet<Customer> Customer { get; set; }


        public DbSet<Basket> Basket { get; set; }

        public DbSet<BasketProduct> BasketProduct { get; set; }
    }
}
