using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class CreateRequestViewModel
    {
        [Required]
        public string UserId { get; set; } = null!;

        [Required]
        public int CompanyId { get; set; }

        [Required(ErrorMessage = "Adres alanı zorunludur!")]
        public string FromAdress { get; set; } = null!;

        [Required(ErrorMessage = "Kat alanı zorunludur!")]
        public int FromFloor { get; set; }

        [Required(ErrorMessage = "Adres alanı zorunludur!")]
        public string ToAdress { get; set; } = null!;

        [Required(ErrorMessage = "Kat alanı zorunludur!")]
        public int ToFloor { get; set; }

        [Required(ErrorMessage = "Talep tipi alanı zorunludur!")]
        public int RequestTypeId { get; set; }

        public string? ExtraMessage { get; set; }

        [Required(ErrorMessage = "Taşınma tarihi alanı zorunludur")]
        public DateTime TransportDate { get; set; }
    }
}
