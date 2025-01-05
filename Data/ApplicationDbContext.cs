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

        public DbSet<Insurance_Two_Tables.Models.Customer> Customer { get; set; } = default!;
        public DbSet<Insurance_Two_Tables.Models.Address> Address { get; set; } = default!;
    }
}
