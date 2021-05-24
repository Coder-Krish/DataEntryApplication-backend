using DataEntryApplication.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataEntryApplication.DataAccess
{
    public class DataEntryDbContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=KRISHNA;Initial Catalog=DataEntryApplicationDb;Integrated Security=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>()
                        .ToTable("tblCountry");
            modelBuilder.Entity<Country>()
                        .HasKey(country => country.id);

            modelBuilder.Entity<District>()
                        .ToTable("tblDistrict");
            modelBuilder.Entity<District>()
                        .HasKey(district => district.id);


            modelBuilder.Entity<Labor>()
                        .ToTable("tblLabor");
            modelBuilder.Entity<Labor>()
                        .HasKey(labor => labor.id);
        }

        public DbSet<Country> countries { get; set; }

        public DbSet<District> districts { get; set; }

        public DbSet<Labor> labors { get; set; }

    }
}
