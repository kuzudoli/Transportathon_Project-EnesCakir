using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Models;
using Transportathon_Project_EnesCakir.Repository.Interfaces;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Services
{
    public class RequestService : GenericService<Request>, IRequestService
    {
        private readonly ICompanyService _companyService;

        public RequestService(IGenericRepository<Request> repository, IUnitOfWork unitOfWork, ICompanyService companyService) : base(repository, unitOfWork)
        {
            _companyService = companyService;
        }

        public Task<List<RequestsWithCompanyName>> GetRequestListWithCompanyName(string userId)
        {
            var requests = _repository.Where(x => x.UserId.Equals(userId)).ToList();
            var companies = _companyService.Where(x => requests.Select(r => r.CompanyId).Contains(x.Id)).ToList();

            var requestList = (from req in requests
                               join cmp in companies on req.CompanyId equals cmp.Id
                               select new RequestsWithCompanyName
                               {
                                   Id = req.Id,
                                   CompanyName = cmp.Name,
                                   TransportDate = req.TransportDate
                               }).ToList();

            return Task.FromResult(requestList);
        }
    }
}