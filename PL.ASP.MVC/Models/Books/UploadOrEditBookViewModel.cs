using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace PL.ASP.MVC.Models.Books
{
    public class UploadOrEditBookViewModel
    {
        public string Id { get; set; }
        [Required]
        [Display(Name = "Book's title")]
        public string Title { get; set; }
        [Required]
        [Display(Name = "Book's author")]
        public string Author { get; set; }

        [Display(Name = "Book's genre")] 
        public string Genre { get; set; } = "Unknown genre";
        public string Description { get; set; } = "No description";
        [Required]
        [Display(Name = "Book's PDF file")]
        public IFormFile BookFile { get; set; }
        
        //public string OwnerUserName { get; set; }
    }
}