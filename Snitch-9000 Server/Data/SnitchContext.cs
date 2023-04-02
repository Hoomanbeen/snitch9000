using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using snitch_9000.Models;

namespace snitch_9000.Data
{
    public class SnitchContext : DbContext
    {
        public DbSet<User> USERS { get; set; }
        public DbSet<Notification> NOTIFICATIONS { get; set; }
        public DbSet<Hit> HITS { get; set; }
        public DbSet<Course> COURSES { get; set; }
        public DbSet<Question> QUESTIONS { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=snitch-9000.sqlite");
        }

        public SnitchContext(DbContextOptions<SnitchContext> options) : base(options) { }
    }
}