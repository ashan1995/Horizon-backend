using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HorizonWebApi.Models
{
    public class HorizonWebApiContext : DbContext
    {
        public HorizonWebApiContext (DbContextOptions<HorizonWebApiContext> options)
            : base(options)
        {
        }

        public DbSet<HorizonWebApi.Models.Employee> Employee { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasIndex(u => u.username)
            .IsUnique(); ;
        }
    }
}
