using System.ComponentModel.DataAnnotations;

namespace WebApplication.Models
{
    public class RegistrationViewModel
    {
        [Required] [Display(Name = "Псевдоним")] 
        public string Username { get; set; }
        
        [Required] [Display(Name = "Email")] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }
    }
}