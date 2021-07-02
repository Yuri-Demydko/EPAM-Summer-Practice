using System.ComponentModel.DataAnnotations;
using BLL.Interfaces;

namespace WebApplication.Models
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "Login")]
        public string Login { get; set; }
         
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }
         
        [Display(Name = "Запомнить?")]
        public bool RememberMe { get; set; }
        public string ReturnUrl { get; set; }
        
    }
}