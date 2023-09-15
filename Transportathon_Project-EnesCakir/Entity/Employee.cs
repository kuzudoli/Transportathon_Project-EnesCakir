namespace Transportathon_Project_EnesCakir.Entity
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; } = null!;
        public string Surname { get; set; } = null!;
        public DateTime BirthDate { get; set; }
        public string? Phone { get; set; }
        public string Type { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public Vehicle? Vehicle { get; set; }
    }
}