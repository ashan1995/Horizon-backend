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
        public DbSet<Item> Items { get; set; }
        public DbSet<Bill> Bills { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
            .HasIndex(u => u.username)
            .IsUnique(); ;

            modelBuilder.Entity<BillItem>()
            .HasKey(t => new { t.BillId, t.ItemId });

            modelBuilder.Entity<BillItem>()
                .HasOne(pt => pt.Item)
                .WithMany(p => p.BillItems)
                .HasForeignKey(pt => pt.ItemId);

            modelBuilder.Entity<BillItem>()
                .HasOne(pt => pt.Bill)
                .WithMany(t => t.BillItems)
                .HasForeignKey(pt => pt.BillId);
        }
    
    }
}
