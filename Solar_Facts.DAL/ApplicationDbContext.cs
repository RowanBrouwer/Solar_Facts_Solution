using Microsoft.EntityFrameworkCore;
using Solar_Facts.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solar_Facts.DAL
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb; Database=SolarFactsDB; Trusted_Connection=True; MultipleActiveResultSets=true");
            }   
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SolarSystem>()
                .HasMany<Star>(ss => ss.Stars)
                .WithOne(s => s.solarSystem);

            modelBuilder.Entity<PlanetAndDwarfPlanet>()
                .HasOne<Star>(p => p.StarToOrbit)
                .WithMany(s => s.Planets)
                .HasForeignKey(p => p.StarId);

              ModelBuilderExtensions.Seed(modelBuilder);
        }
        public DbSet<SolarSystem> SolarSystems { get; set; }
        public DbSet<Star> Stars { get; set; }
        public DbSet<PlanetAndDwarfPlanet> PlntAndDPlnt { get; set; }

        
    }
}
