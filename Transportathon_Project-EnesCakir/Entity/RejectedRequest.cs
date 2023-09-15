namespace Transportathon_Project_EnesCakir.Entity
{
    public class RejectedRequest : BaseEntity
    {
        public string RejectReason { get; set; } = null!;

        public int RequestId { get; set; }
        public Request Request { get; set; } = null!;
    }
}
