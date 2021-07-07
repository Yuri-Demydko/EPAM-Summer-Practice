using System;
using System.Diagnostics;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using PL.ASP.MVC.Models;
using PL.ASP.MVC.Models.Books;

namespace PL.ASP.MVC.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBooksBLO _booksBlo;
        private readonly ITechBLO _techBlo;
        
        public HomeController(ILogger<HomeController> logger, IBooksBLO booksBlo, ITechBLO techBlo)
        {
            _logger = logger;
            _booksBlo = booksBlo;
            _techBlo = techBlo;
        }
        
        public async Task<IActionResult> Index(int pageNum=0,string searchString="",byte searchMode=0)
        {
            var model = new BooksGalleryViewModel
            {
                PageNum = pageNum
            };
            if (searchMode==0||string.IsNullOrWhiteSpace(searchString))
                model.Books = await _booksBlo.GetBooksGallery();
            else
            {
                model.Books =
                    await _booksBlo.GetFilteredBooksGallery(
                        new Tuple<string, byte>(searchString, searchMode));
            }
            
            model.CalculatePagination();
            return View(model);
        }
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }

        [AllowAnonymous]
        public async Task<IActionResult> Start()
        {
            await _techBlo.PrefillDatabaseWithTestDataAsync();
            return View();
        }
        [HttpPost]
        public IActionResult SearchForBooks(BooksGalleryViewModel model)
        {
            if (string.IsNullOrWhiteSpace(model.SearchString))
                return RedirectToAction("Index", "Home");

            return RedirectToAction("Index", "Home",new
            {
                searchString=model.SearchString,
                searchMode=model.SearchMode
            });
        }
    }
}