using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required(ErrorMessage = "Email boş bırakılamaz!")]
        [EmailAddress(ErrorMessage = "Email formatı yanlış!")]
        public string Email { get; set; }
    }
}
