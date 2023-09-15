using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;
using Transportathon_Project_EnesCakir.Services.Interfaces;

namespace Transportathon_Project_EnesCakir.Services
{
    public class RequestTypeService : GenericService<RequestType>, IRequestTypeService
    {
        public RequestTypeService(IGenericRepository<RequestType> repository, IUnitOfWork unitOfWork) : base(repository, unitOfWork)
        {
        }
    }
}