using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models.Books;

namespace WebApplication.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBLO _blo;
        public BooksController(IBLO blo )
        {
            _blo = blo;
        }
        
        public async Task<IActionResult> BookPage(string id)
        {
            var book = await _blo.GetBookById(id,false);
            var model = new Tuple<EBook, bool>(book, await _blo.CheckBookInFavoritesOfUser(book, User.Identity.Name));

            return View(model);
        }
        
        public async Task<FileContentResult> ReadBook(string id)
        {
            var book = await _blo.GetBookById(id,true);
            var content = new FileContentResult(book.Data, "application/pdf");
            return content;
        }

        public async Task<IActionResult> UpdateBookInFavorites(int bookId,bool removingMode=false)
        {
            await _blo.UpdateBookInFavorites(bookId, User.Identity.Name,removingMode);
            return RedirectToAction("BookPage", new {id = bookId});
        }

        public async Task<IActionResult> EditBookData(string bookId)
        {
            var book = await _blo.GetBookById(bookId,false);
            var model = new UploadOrEditBookViewModel()
            {
                Id = book.Id.ToString(),
                Title = book.Title,
                Description = book.Description,
                Author = book.Author,
                Genre = book.Genre,
            };
            return View(model);
        }
        public string GetRandomBg() => _gradients[new Random().Next(4)];

        private readonly IList<string> _gradients = new List<string>()
        {
            "background: rgb(59,34,0); background: linear-gradient(180deg, rgba(59,34,0,1) 0%, rgba(163,96,3,1) 100%);",
            "background: rgb(2,0,36); background: linear-gradient(180deg, rgba(2,0,36,1) 0%, rgba(123,149,154,1) 100%)",
            "background: rgb(3,51,3); background: linear-gradient(180deg, rgba(3,51,3,1) 0%, rgba(0,166,0,1) 100%);",
            "background: rgb(51,3,3); background: linear-gradient(180deg, rgba(51,3,3,1) 0%, rgba(166,0,0,1) 100%);"
        };

        [HttpPost]
        public async Task<IActionResult> EditBookData(UploadOrEditBookViewModel model)
        {
            var book = await _blo.GetBookById(model.Id,false);
            book.Title = model.Title;
            book.Author = model.Author;
            book.Description = model.Description;
            book.Genre = model.Genre;
            book.CardBg = GetRandomBg();
            await _blo.EditBookData(book);
            return RedirectToAction("BookPage", new {id = model.Id});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(string bookId)
        {
            await _blo.DeleteBook(bookId);
            return RedirectToAction("Index", "Home");
        }
        // GET
        public IActionResult UploadBook()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> UploadBook(UploadOrEditBookViewModel model)
        {
            if (!ModelState.IsValid) return View(model);
            var book = new EBook()
            {
                Title = model.Title,
                Author = model.Author,
                Description = model.Description,
                Genre = model.Genre,
                CardBg = GetRandomBg()
            };
            using var reader = new BinaryReader(model.BookFile.OpenReadStream());
            book.Data = reader.ReadBytes((int)model.BookFile.Length);
            await _blo.UploadBook(book, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }

    }
}