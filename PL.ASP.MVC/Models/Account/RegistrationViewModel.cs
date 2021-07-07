using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PL.ASP.MVC.Models.Account
{
    public class RegistrationViewModel
    {
        [Display(Name = "First name")] 
        public string FName { get; set; } = "Unknown";

        [Display(Name = "Last name")] 
        public string LName { get; set; } = "Unknown";

        [Display(Name = "Date of birth")]
        public string DateOfBirth { get; set; } = "Unknown";
        [Display(Name = "City")] 
        public string City { get; set; } = "Unknown";
        
        [Required] [Display(Name = "User name")] 
        public string Username { get; set; }
        
        [Required] [Display(Name = "Email")] 
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirm { get; set; }

        public string AdditionalInfo { get; set; } = "There aren't any additional info :(";
        public IFormFile Avatar { get; set; }
     
    }
}