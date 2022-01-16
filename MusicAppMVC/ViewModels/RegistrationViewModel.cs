using System.ComponentModel.DataAnnotations;

namespace MusicAppMVC.ViewModels
{
    public class RegistrationViewModel
    {
        [Required]
        [DataType(DataType.Text)]
        [Display(Name = "Įveskite savo vardą")]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Įveskite elektrinį paštą")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Display(Name = "Įveskite slaptažodį")]
        public string Password { get; set; }

        [Required(ErrorMessage = "Confirm Password is required")]
        [StringLength(255, ErrorMessage = "Must be between 5 and 255 characters", MinimumLength = 5)]
        [DataType(DataType.Password)]
        [Compare("Password")]
        [Display(Name = "Pakartokita slaptažodį")]
        public string ConfirmPassword { get; set; }
    }
}
