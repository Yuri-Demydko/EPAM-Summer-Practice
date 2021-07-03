using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication.Models;
using WebApplication.Models.Books;

namespace WebApplication.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IBLO _blo;
        

        public HomeController(ILogger<HomeController> logger, IBLO blo)
        {
            _logger = logger;
            _blo = blo;
        }

        public async Task<IActionResult> Index()
        {
         //  var ex= _blo.GetExampleUserFromDAO();
         var model = new BooksGalleryViewModel 
             {Books = await _blo.GetBooksGallery()};
         return View(model);
        }
        
        

        public IActionResult Privacy()
        {
            return View();
        }
        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel {RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier});
        }
    }
}