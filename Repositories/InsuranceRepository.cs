using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;
using Microsoft.EntityFrameworkCore;

namespace Insurance_Final_Version.Repositories
{
    public class InsuranceRepository(ApplicationDbContext dbContext) : BaseRepository<Insurance>(dbContext), IInsuranceRepository
    {
        public override async Task<List<Insurance>> GetAll()
        {
            return await dbSet.OrderBy(x => x.CustomerId).ToListAsync();
        }
    }
}
