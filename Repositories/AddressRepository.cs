using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Repositories
{
    /// <summary>
    /// Repository for Address class entities in the database.
    /// </summary>
    /// <param name="dbContext">dbContext</param>
    public class AddressRepository(ApplicationDbContext dbContext) : BaseRepository<Address>(dbContext), IAddressRepository
    {
    }
}
