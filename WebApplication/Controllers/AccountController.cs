using System.Threading.Tasks;
using BLL.Interfaces;
using DTO.Entities;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IBLO _blo;
        public AccountController(IBLO blo)
        {
            _blo = blo;
        }
        
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<IActionResult> Register(RegistrationViewModel model)
        {
            if(ModelState.IsValid)
            {
                EUser user = new EUser { Email = model.Email, UserName = model.Username};
                // добавляем пользователя
                var result = await _blo.AddUserAsync(user, model.Password);
                if (result.Succeeded)
                {
                    // установка куки
                    await _blo.SignInUserAsync(user, false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
    }
}