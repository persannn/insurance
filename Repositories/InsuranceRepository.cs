using Insurance_Final_Version.Data;
using Insurance_Final_Version.Interfaces;
using Insurance_Final_Version.Models;

namespace Insurance_Final_Version.Repositories
{
    public class InsuranceRepository(ApplicationDbContext dbContext) : BaseRepository<Insurance>(dbContext), IInsuranceRepository
    {
    }
}
