
using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class SignUpViewModel
    {
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz!")]
        public string Surname { get; set; }

        [Required(ErrorMessage = "Email alanı boş bırakılamaz!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Telefon alanı boş bırakılamaz!")]
        public string Phone { get; set; }

        [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılamaz!")]
        public DateTime BirthDate { get; set; }

        [Required(ErrorMessage = "Kullanıcı tipi alanı boş bırakılamaz!")]
        public bool IsCompany { get; set; }

        [Required(ErrorMessage = "Şifre alanı boş bırakılamaz!")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Şifre onay alanı boş bırakılamaz!")]
        [Compare(nameof(Password), ErrorMessage = "Parolanız uyuşmuyor!")]
        public string PasswordConfirm { get; set; }
    }
}