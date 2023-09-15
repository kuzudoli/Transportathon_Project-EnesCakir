using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Transportathon_Project_EnesCakir.Entity;

namespace Transportathon_Project_EnesCakir.Repository
{
    public class IdentityManagementDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public IdentityManagementDbContext(DbContextOptions<IdentityManagementDbContext> options) : base(options)
        {

        }
    }
}