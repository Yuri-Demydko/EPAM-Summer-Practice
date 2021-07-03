using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using BLL.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
//using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication.Models;
using WebApplication.Models.Account;
using static System.String;

namespace WebApplication.Controllers
{
    public class AccountController : Controller
    {
        private IBLO _blo;
        public AccountController(IBLO blo)
        {
            _blo = blo;
        }

        [HttpPost]
        public async Task<IActionResult> EditProfile(UserProfileViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user= await  _blo.GetUserByUserNameAsync(User.Identity.Name);
                model.User = user;
                if (IsNullOrWhiteSpace(model.FName))
                    model.FName = "Unknown";
                model.User.FirstName = model.FName;
                if (IsNullOrWhiteSpace(model.LName))
                    model.LName= "Unknown";
                model.User.LastName = model.LName;
                if (IsNullOrWhiteSpace(model.City))
                    model.City= "Unknown";
                model.User.City = model.City;
                if (IsNullOrWhiteSpace(model.AdditionalInfo))
                    model.AdditionalInfo= "Unknown";
                model.User.AdditionalInfo = model.AdditionalInfo;
                if (IsNullOrWhiteSpace(model.DateOfBirth))
                    model.DateOfBirth= "Unknown";
                model.User.DateOfBirth = model.DateOfBirth;

                if (model.NewAvatar != null)
                {
                    using var reader = new BinaryReader(model.NewAvatar.OpenReadStream());
                    model.User.Avatar = reader.ReadBytes((int)model.NewAvatar.Length);
                }

                if (!IsNullOrWhiteSpace(model.Password) && Equals(model.Password, model.PasswordConfirm))
                {
                    var result = await _blo.UpdatePasswordAsync(model.User, model.OldPassword, model.Password);
                    if(!result.Succeeded)
                        foreach (var err in result.Errors)
                        {
                            ModelState.AddModelError("err",err.Description);
                        }

                    model.IsErrorModel = true;
                }
                
                if(await _blo.UpdateUserDataAsync(model.User))
                    return RedirectToAction("Index", "Account");
            }
            return RedirectToAction("Index", controllerName: "Account", new {editMode=true,errModel=model});
        }

        public async Task<IActionResult> Index(bool editMode=false,UserProfileViewModel errModel=null)
        {
            var model = new UserProfileViewModel()
            {
                User=await _blo.GetUserByUserNameAsync(User.Identity.Name),
                EditingMode = editMode,
            };
           // model.User.Avatar ??= new byte[] { };
            model.FavoriteBooks = await _blo.GetFavoriteBooksByUserAsync(model.User);
            if (editMode)
            {
                model.Username = model.User.UserName;
                model.FName = model.User.FirstName;
                model.LName = model.User.LastName;
                model.Email = model.User.Email;
                model.City = model.User.City;
                model.AdditionalInfo = model.User.AdditionalInfo;
                model.DateOfBirth = model.User.DateOfBirth;
            }

            if(errModel.IsErrorModel)
                return View(errModel);
            return View(model);
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
                EUser user = new EUser 
                    { 
                        Email = model.Email,
                        UserName = model.Username,
                        DateOfBirth=model.DateOfBirth,
                        FirstName = model.FName,
                        LastName = model.LName,
                        City = model.City,
                        AdditionalInfo = model.AdditionalInfo
                    };
                if (model.Avatar != null)
                {
                    using var reader = new BinaryReader(model.Avatar.OpenReadStream());
                    user.Avatar = reader.ReadBytes((int)model.Avatar.Length);
                }
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
                        ModelState.AddModelError(Empty, error.Description);
                    }
                }
            }
            return View(model);
        }
        
        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            var model = new LoginViewModel() {ReturnUrl = returnUrl};
            return View(model);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = 
                    await _blo.PasswordSignInAsync(model.Login, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    // проверяем, принадлежит ли URL приложению
                    if (!IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Home");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }
 
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // удаляем аутентификационные куки
            await _blo.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
    }
}