using Insurance_Two_Tables.Data;
using Insurance_Two_Tables.Interfaces;
using Insurance_Two_Tables.Models;

namespace Insurance_Two_Tables.Repositories
{
    public class AddressRepository(ApplicationDbContext dbContext) : BaseRepository<Address>(dbContext), IAddressRepository
    {
    }
}
