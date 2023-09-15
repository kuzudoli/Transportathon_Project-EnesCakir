using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models;
using Transportathon_Project_EnesCakir.Models.ViewModels;

namespace Transportathon_Project_EnesCakir.Services.Interfaces
{
    public interface ICompanyService : IGenericService<Company>
    {
        Task<List<CompanyWithEmployeeCount>> GetCompaniesForHomePage();
        Task<CompanyViewModel> GetCompanyWithDetails();
    }
}
