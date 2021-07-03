using System.IO;
using System.Threading.Tasks;
using BLL.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Books;

namespace WebApplication.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBLO _blo;

        public BooksController(IBLO blo)
        {
            _blo = blo;
        }
        
        public async Task<IActionResult> BookPage(string Id)
        {
            var book = await _blo.GetBookById(Id);
            
            return View(book);
        }
        
        // GET
        public IActionResult UploadBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBook(UploadBookViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var book = new EBook()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Genre = model.Genre
            };
            //TEST CONVERTING
            using var reader = new BinaryReader(model.BookFile.OpenReadStream());
            book.Data = reader.ReadBytes((int)model.BookFile.Length);

            await _blo.UploadBook(book, User.Identity.Name);
                
            return RedirectToAction("Index", "Home");
        }

    }
}