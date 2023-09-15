using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
