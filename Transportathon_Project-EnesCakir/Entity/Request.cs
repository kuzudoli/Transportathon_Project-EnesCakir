namespace Transportathon_Project_EnesCakir.Entity
{
    public class Request : BaseEntity
    {
        public string FromAdress { get; set; } = null!;
        public int FromFloor { get; set; }
        public string ToAdress { get; set; } = null!;
        public int ToFloor { get; set; }
        public DateTime TransportDate { get; set; }
        public string? ExtraMessage { get; set; }
        public bool IsApproved { get; set; }

        public string UserId { get; set; } = null!;
        public AppUser User { get; set; } = null!;

        public int CompanyId { get; set; }
        public Company Company { get; set; } = null!;

        public int RequestTypeId { get; set; }
        public RequestType RequestType { get; set; } = null!;

        public RejectedRequest? RejectedRequest { get; set; }
    }
}