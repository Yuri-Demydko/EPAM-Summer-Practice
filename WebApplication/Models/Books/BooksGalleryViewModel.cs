using System.Collections.Generic;
using DTO.Entities;

namespace WebApplication.Models.Books
{
    public class BooksGalleryViewModel
    {
        public IList<EBook> Books { get; set; } = new List<EBook>();
        // public 
    }
}