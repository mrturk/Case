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

        public DbSet<Users> Users { get; set; }
        public DbSet<LeaderBoards> LeaderBoards { get; set; }
        public DbSet<Scores> Scores { get; set; }
    }
}
