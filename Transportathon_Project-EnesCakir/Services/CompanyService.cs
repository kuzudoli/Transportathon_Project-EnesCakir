using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models;
using Transportathon_Project_EnesCakir.Models.ViewModels;
using Transportathon_Project_EnesCakir.Repository.Interfaces;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Services
{
    public class CompanyService : GenericService<Company>, ICompanyService
    {
        private readonly IEmployeeService _employeeService;
        private readonly IVehicleService _vehicleService;
        public CompanyService(
            IGenericRepository<Company> repository,
            IUnitOfWork unitOfWork,
            IEmployeeService employeeService,
            IVehicleService vehicleService) : base(repository, unitOfWork)
        {
            _employeeService = employeeService;
            _vehicleService = vehicleService;
        }

        public Task<List<CompanyWithEmployeeCount>> GetCompaniesForHomePage()
        {
            var companyList = new List<CompanyWithEmployeeCount>();

            var companies = _repository.Where(x => x.Vehicle.Count > 1).ToList();
            var employees = _employeeService.Where(x => companies.Select(c => c.Id).Contains(x.CompanyId)).ToList();

            companyList.AddRange(companies.Select(x => new CompanyWithEmployeeCount()
            {
                Id = x.Id,
                Name = x.Name,
                EstablishmentDate = x.EstablishmentDate,
                EmployeeCount = employees.Where(e => e.CompanyId == x.Id).Count()
            }));

            return Task.FromResult(companyList);
        }

        public async Task<CompanyViewModel> GetCompanyWithDetails(int companyId)
        {
            var company = await _repository.FirstOrDefaultAsync(x => x.Id == companyId);
            var employees = _employeeService.Where(x => x.CompanyId == companyId).ToList();
            var vehicles = _vehicleService.Where(x => x.CompanyId == companyId).ToList();

            var companyDetails = new CompanyViewModel
            {

            };
        }
    }
}