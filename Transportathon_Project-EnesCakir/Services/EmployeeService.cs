using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Services
{
    public class EmployeeService : GenericService<Employee>, IEmployeeService
    {
        public EmployeeService(IGenericRepository<Employee> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}
