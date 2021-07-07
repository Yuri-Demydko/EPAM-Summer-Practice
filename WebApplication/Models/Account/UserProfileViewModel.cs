
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Entities.Entities;
using Microsoft.AspNetCore.Http;

namespace WebApplication.Models.Account
{
    public class UserProfileViewModel
    {
        public EUser User { get; set; }
        public bool EditingMode { get; set; }
        public IList<EBook> FavoriteBooks { get; set; }

        public bool StrangerMode = false;

        public bool IsErrorModel = false;
        //-----IF EDITING
        [Display(Name = "Additional info")]
        public string AdditionalInfo { get; set; } = "There aren't any info :(";
        [Display(Name = "First name")] 
        public string FName { get; set; } = "Unknown";

        [Display(Name = "Last name")] 
        public string LName { get; set; } = "Unknown";

        [Display(Name = "Date of birth")]
        public string DateOfBirth { get; set; } = "Unknown";
        [Display(Name = "City")] 
        public string City { get; set; } = "Unknown";
        
        [Display(Name = "User name")] 
        public string Username { get; set; }
        
        [Display(Name = "Email")] 
        public string Email { get; set; }
        
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Current password")]
        public string OldPassword { get; set; }

        
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

       
        [Compare("Password", ErrorMessage = "Passwords don't match")]
        [DataType(DataType.Password)]
        [Display(Name = "Confirm your password")]
        public string PasswordConfirm { get; set; }

        public IFormFile NewAvatar { get; set; }
    }
}