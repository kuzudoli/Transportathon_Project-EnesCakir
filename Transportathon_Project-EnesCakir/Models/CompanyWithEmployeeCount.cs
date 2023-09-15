namespace Transportathon_Project_EnesCakir.Models
{
    public class CompanyWithEmployeeCount
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime EstablishmentDate { get; set; }
        public int EmployeeCount { get; set; }
    }
}
