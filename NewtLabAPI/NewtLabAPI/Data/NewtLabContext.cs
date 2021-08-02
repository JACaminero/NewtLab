using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NewtlabAPI.Models;

namespace NewtlabAPI.Data
{
    public class NewtLabContext : DbContext
    {
        public NewtLabContext() : base()
        { }

        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Profile> Profiles { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=.;Database=NewtLab;Trusted_Connection=True;");
        }

    }
}
