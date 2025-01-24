using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Repositories
{
    public class CustomerRepository(ApplicationDbContext dbContext) : BaseRepository<Customer>(dbContext), ICustomerRepository
    {
    }
}
