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
using Ninject.Selection;

namespace EFDAO
{
    public class DAO : IDAO
    {
        private EFDBContext _context;
        private readonly UserManager<EUser> _userManager;
        private readonly SignInManager<EUser> _signInManager;

        public DAO(EFDBContext context, UserManager<EUser> userManager, SignInManager<EUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(EUser user, string password)
        {
            return await _userManager.CreateAsync(user, password);
        }


        public async Task SignInUserAsync(EUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }

        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember,
            bool lockOnFailure)
        {
            var res = await _signInManager.PasswordSignInAsync(login, password, remember, lockOnFailure);
            if (res.Succeeded)
            {
                var user = await (from u in _context.Users where u.UserName == login select u).FirstOrDefaultAsync();
            }

            return res;
        }

        public async Task SignOutAsync()
        {
            await _signInManager.SignOutAsync();
        }

        public async Task<EUser> GetUserByUserName(string username)
        {
            var user = (await (from u
                    in _context.Users
                        .Include(u=>u.OwnBooks)
                       // .Include(u=>u.Avatar)
                where u.UserName.ToUpper() == username.ToUpper()
                select u).FirstOrDefaultAsync());
            return user ?? throw new ArgumentException("User with that username not exists");
        }

        public async Task<IList<EBook>> GetFavoriteBooksByUser(EUser user)
        {
            if (user == null)
                throw new ArgumentNullException("User can't be null");
            var booksId = (await (from fbtu
                    in _context.FavoriteBooksToUsers
                where fbtu.UserId == user.Id
                select fbtu.BookId).ToListAsync());
            
            return await (from b in _context.Books
                where booksId.Contains(b.Id)
                select b).ToListAsync();
        }
    }
}