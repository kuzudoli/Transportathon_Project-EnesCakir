namespace Transportathon_Project_EnesCakir.Entity
{
    public class Company : BaseEntity
    {
        public string Name { get; set; } = null!;
        public DateTime EstablishmentDate { get; set; }
        public string Owner { get; set; } = null!;
        public string? Adress { get; set; }
        public string? Phone { get; set; }

        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;

        public List<Employee> Employees { get; } = new();
        public List<Vehicle> Vehicle { get; } = new();
    }
}