using Microsoft.EntityFrameworkCore;
using Transportathon_Project_EnesCakir.Entity;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Vehicle> Vehicles { get; set; }

        public DbSet<Request> Requests { get; set; }
        public DbSet<RequestType> RequestTypes { get; set; }
        public DbSet<RejectedRequest> RejectedRequests { get; set; }
    }
}