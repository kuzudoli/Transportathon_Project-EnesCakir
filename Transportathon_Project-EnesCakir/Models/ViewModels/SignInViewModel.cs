
using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class SignInViewModel
    {
        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        public string Email { get; set; } = null!;

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string Password { get; set; } = null!;

        public bool RememberMe { get; set; }
    }
}