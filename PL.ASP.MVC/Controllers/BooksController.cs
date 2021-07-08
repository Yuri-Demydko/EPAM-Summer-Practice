using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities.Entities;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PL.ASP.MVC.Models.Books;

namespace PL.ASP.MVC.Controllers
{
    [Authorize]
    public class BooksController : Controller
    {
        private readonly IBooksBLO _booksBooksBlo;
        private readonly IUsersBLO _usersBlo;
        public BooksController(IBooksBLO booksBooksBlo,IUsersBLO usersBlo)
        {
            _booksBooksBlo = booksBooksBlo;
            _usersBlo = usersBlo;
        }
        
        public async Task<IActionResult> BookPage(string id)
        {
            var hasData = await _booksBooksBlo.CheckBookData(id);
            var book = await _booksBooksBlo.GetBookById(id,false);
            var model = new Tuple<EBook, bool,bool>(book, await _usersBlo.CheckBookInFavoritesOfUser(book, User.Identity.Name),hasData);

            return View(model);
        }
        
        public async Task<FileContentResult> ReadBook(string id)
        {
            var book = await _booksBooksBlo.GetBookById(id,true);
            var content = new FileContentResult(book.Data, "application/pdf");
            return content;
        }

        public async Task<IActionResult> UpdateBookInFavorites(int bookId,bool removingMode=false)
        {
            await _booksBooksBlo.UpdateBookInFavorites(bookId, User.Identity.Name,removingMode);
            return RedirectToAction("BookPage", new {id = bookId});
        }

        public async Task<IActionResult> EditBookData(string bookId)
        {
            var book = await _booksBooksBlo.GetBookById(bookId,false);
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
            "background: rgb(51,3,3); background: linear-gradient(180deg, rgba(51,3,3,1) 0%, rgba(166,0,0,1) 100%);",
            "background: rgb(6,39,74); background: linear-gradient(180deg, rgba(6,39,74,1) 0%, rgba(132,119,255,1) 100%);",
            "background: rgb(0,72,85); background: linear-gradient(180deg, rgba(0,72,85,1) 0%, rgba(17,93,0,1) 100%);",
            "background: rgb(77,0,85); background: linear-gradient(180deg, rgba(77,0,85,1) 0%, rgba(87,21,21,1) 100%);",
        };

        [HttpPost]
        public async Task<IActionResult> EditBookData(UploadOrEditBookViewModel model)
        {
            var book = await _booksBooksBlo.GetBookById(model.Id,false);
            book.Title = model.Title;
            book.Author = model.Author;
            book.Description = model.Description;
            book.Genre = model.Genre;
            book.CardBg = GetRandomBg();
            await _booksBooksBlo.EditBookData(book);
            return RedirectToAction("BookPage", new {id = model.Id});
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBook(string bookId)
        {
            await _booksBooksBlo.DeleteBook(bookId);
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
            await _booksBooksBlo.UploadBook(book, User.Identity.Name);
            return RedirectToAction("Index", "Home");
        }

    }
}