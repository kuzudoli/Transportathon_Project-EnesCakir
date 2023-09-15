using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models;

namespace Transportathon_Project_EnesCakir.Services.Interfaces
{
    public interface IRequestService : IGenericService<Request>
    {
        Task<List<RequestsWithCompanyName>> GetRequestListWithCompanyName(string userId);
    }
}