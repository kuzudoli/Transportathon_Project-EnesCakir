namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class CompanyViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public DateTime EstablishmentDate { get; set; }
        public string Owner { get; set; } = null!;
        public string? Location { get; set; }
        public int VehicleCount { get; set; }
        public int EmployeeCount { get; set; }
        public int DriverCount { get; set; }
    }
}
