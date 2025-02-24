using Insurance_Final_Version.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Final_Version.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() { }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
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
                .HasMany(e => e.Insurances)
                .WithOne(e => e.Customer)
                .HasForeignKey(e => e.CustomerId)
                .IsRequired();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseLazyLoadingProxies();
        }

        public DbSet<Customer> Customer { get; set; } = default!;
        public DbSet<Address> Address { get; set; } = default!;
        public DbSet<AddressViewModel> AddressViewModel { get; set; } = default!;
        public DbSet<CustomerViewModel> CustomerViewModel { get; set; } = default!;
        public DbSet<Insurance_Final_Version.Models.Insurance> Insurance { get; set; } = default!;
        public DbSet<Insurance_Final_Version.Models.InsuranceViewModel> InsuranceViewModel { get; set; } = default!;
    }
}
