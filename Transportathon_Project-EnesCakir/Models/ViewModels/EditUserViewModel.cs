using System.ComponentModel.DataAnnotations;

namespace Transportathon_Project_EnesCakir.Models.ViewModels
{
    public class EditUserViewModel
    {
        public string? UserName { get; set; }
        
        [Required(ErrorMessage = "Ad alanı boş bırakılamaz!")]
        public string Name { get; set; } = null!;

        [Required(ErrorMessage = "Soyad alanı boş bırakılamaz!")]
        public string Surname { get; set; } = null!;

        public string? Email { get; set; }

        public string? PhoneNumber { get; set; }

        [Required(ErrorMessage = "Doğum tarihi alanı boş bırakılamaz!")]
        public DateTime BirthDate { get; set; }
    }
}
