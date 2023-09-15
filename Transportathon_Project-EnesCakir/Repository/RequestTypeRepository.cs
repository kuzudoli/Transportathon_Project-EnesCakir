using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class RequestTypeRepository : GenericRepository<RequestType>, IRequestTypeRepository
    {
        public RequestTypeRepository(AppDbContext context) : base(context)
        {
        }
    }
}
