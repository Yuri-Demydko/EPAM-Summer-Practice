using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFDAO
{
    public class DAO : IDAO
    {
        private EFDBContext _context;
        private readonly UserManager<EUser> _userManager;
        private readonly SignInManager<EUser> _signInManager;
        private ClaimsIdentity _currentUserCP;

        public DAO(EFDBContext context, UserManager<EUser> userManager, SignInManager<EUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(EUser user,string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        private void AddAuthClaims(EUser user)
        {
            // создаем один claim
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                new Claim(ClaimTypes.Email, user.Email),
            };
            // создаем объект ClaimsIdentity
            _currentUserCP = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
        }
        public async Task SignInUserAsync(EUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
            AddAuthClaims(user);
        }

        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember, bool lockOnFailure)
        {
            var res = await _signInManager.PasswordSignInAsync(login, password, remember, lockOnFailure);
            if (res.Succeeded)
            {
                var user = await (from u in _context.Users where u.UserName == login select u).FirstOrDefaultAsync();
                AddAuthClaims(user);
                
            }
            return res;
        }

        public async Task SignOutAsync()
        {
            
            await _signInManager.SignOutAsync();
        }

        public object GetUserCP() => _currentUserCP;

    }
}