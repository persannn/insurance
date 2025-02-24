using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Final_Version.Repositories
{
    /// <summary>
    /// Repository for Insurance class entities in the database.
    /// </summary>
    /// <param name="dbContext">dbContext</param>
    public class InsuranceRepository(ApplicationDbContext dbContext) : BaseRepository<Insurance>(dbContext), IInsuranceRepository
    {
        /// <summary>
        /// Returns a list of all Insurance entities in the database, ordered by CustomerId.
        /// </summary>
        /// <returns>List of all Insurance entities in the database, ordered by CustomerId.</returns>
        public override async Task<List<Insurance>> GetAll()
        {
            return await dbSet.OrderBy(x => x.CustomerId).ToListAsync();
        }
    }
}
