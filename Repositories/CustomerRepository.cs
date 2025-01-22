using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Repositories
{
    public class CustomerRepository(ApplicationDbContext dbContext) : BaseRepository<Customer>(dbContext), ICustomerRepository
    {
        public async Task<Customer?> GetWithDetails(int id)
        {
            Customer? customer = await dbSet.FindAsync(id);

            if (customer == null)
            {
                return null;
            }
            await dbContext.Entry(customer)
                .Collection(c => c.Insurances)
                .LoadAsync();
            return customer;
        }
    }
}
