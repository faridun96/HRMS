using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebUI.Models;

namespace WebUI.Data
{
    public class CardsDataContext : DbContext
    {
        public CardsDataContext(DbContextOptions<CardsDataContext> options) : base(options)
        {
        }

        public DbSet<Card> Cards { get; set; }
        public DbSet<Vacation> Vacations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>().ToTable("Cards");
            modelBuilder.Entity<Vacation>().ToTable("Vacations");
            modelBuilder.Entity<Vacation>()
          .HasOne(p => p.Card)
          .WithMany(b => b.Vacations).OnDelete(DeleteBehavior.Cascade);
        }
    }

}
