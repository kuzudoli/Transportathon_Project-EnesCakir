using Transportathon_Project_EnesCakir.Entity;
using Transportathon_Project_EnesCakir.Repository.Interfaces;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class RequestRepository : GenericRepository<Request>, IRequestRepository
    {
        public RequestRepository(AppDbContext context) : base(context)
        {
        }
    }
}
