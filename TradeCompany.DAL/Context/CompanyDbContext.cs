
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TradeCompany.Domain.Model;

namespace TradeCompany.DAL.Context
{
    public class CompanyDbContext : DbContext
    {

        public virtual DbSet<Structure> Structures { get; set; }

        public virtual DbSet<Right> Rights { get; set; }

        public virtual DbSet<User> Users { get; set; }

        public virtual DbSet<AccountingUnit> AccountingUnits { get; set; }

        public virtual DbSet<Bank> Banks { get; set; }

        public virtual DbSet<Invoice> Invoices { get; set; }

        public virtual DbSet<Partner> Partners { get; set; }

        public virtual DbSet<Country> Countries { get; set; }

        public virtual DbSet<Group> Groups { get; set; }

        public virtual DbSet<HeadPerson> HeadPersons { get; set; }

       // public virtual DbSet<Image> Images { get; set; }

        public virtual DbSet<Manufacturer> Manufacturers { get; set; }

        public virtual DbSet<Order> Orders { get; set; }

        public virtual DbSet<Product> Products { get; set; }

        public virtual DbSet<SoldProduct> SoldProducts { get; set; }

        public virtual DbSet<Store> Stores { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<SoldProduct>()
                .HasOne(s => s.Store)
                .WithMany(st => st!.SoldProducts)
                .OnDelete(DeleteBehavior.Restrict); // Или DeleteBehavior.NoAction

            // Или

            modelBuilder.Entity<SoldProduct>()
                .HasOne(s => s.Order)
                .WithMany(o => o!.SoldProducts)
                .OnDelete(DeleteBehavior.Restrict);

          /*  modelBuilder.Entity<User>()
                .HasOne(u => u.Right)
                .WithOne(r => r.User)
                .HasForeignKey<Right>(r => r.UserId);
          */

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<DateTime>().HaveConversion<UtcValueConverter>();
            configurationBuilder.Properties<DateTime?>().HaveConversion<UtcValueConverter>();
            base.ConfigureConventions(configurationBuilder);
        }

        private class UtcValueConverter : ValueConverter<DateTime, DateTime>
        {
            public UtcValueConverter()
                : base(v => v, v => DateTime.SpecifyKind(v, DateTimeKind.Utc))
            {
            }


        }

        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }

    }
}
