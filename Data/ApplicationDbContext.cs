using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Data
{
    public class ApplicationDbContext : DbContext
    {
        

        public ApplicationDbContext (DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Customer>()
                .HasOne(e => e.Address)
                .WithOne(e => e.Customer)
                .HasForeignKey<Address>(e => e.CustomerId)
                .IsRequired();

            modelBuilder.Entity<Customer>()
                .HasMany(e => e.Insurance)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Insurance_Two_Tables.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Insurance_Two_Tables.Models.Address> Address { get; set; } = default!;
        public DbSet<Insurance_Two_Tables.Models.AddressViewModel> AddressViewModel { get; set; } = default!;
        public DbSet<Insurance_Two_Tables.Models.CustomerViewModel> CustomerViewModel { get; set; } = default!;
    }
}
