namespace Transportathon_Project_EnesCakir.Entity
{
    public class Vehicle : BaseEntity
    {
        public string Brand { get; set; } = null!;
        public string Model { get; set; } = null!;
        public string? Year { get; set; }

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public int EmployeeId { get; set; }
        public Employee Employee { get; set; } = null!;
    }
}