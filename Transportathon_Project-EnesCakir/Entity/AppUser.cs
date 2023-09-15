using Microsoft.AspNetCore.Identity;

namespace Transportathon_Project_EnesCakir.Entity
{
    public class AppUser : IdentityUser
    {
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public bool IsCompany { get; set; }
        public DateTime BirthDate { get; set; }

        public Company? Company { get; set; }
        public Request? Request { get; set; }
    }
}