using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class CompanyRepository : GenericRepository<Company>, ICompanyRepository
    {
        public CompanyRepository(AppDbContext context) : base(context)
        {
        }
    }
}
