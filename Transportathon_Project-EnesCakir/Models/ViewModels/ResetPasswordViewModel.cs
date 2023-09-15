using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class ResetPasswordViewModel
    {
        [Required(ErrorMessage = "Şifre boş bırakılamaz!")]
        public string Password { get; set; } = null!;

        [Compare(nameof(Password), ErrorMessage = "Şifreler aynı değil!")]
        [Required(ErrorMessage = "Şifre Tekrar boş bırakılamaz!")]
        public string PasswordConfirm { get; set; } = null!;
    }
}
