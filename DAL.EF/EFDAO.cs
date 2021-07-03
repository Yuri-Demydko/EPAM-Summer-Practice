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
        private readonly EFDBContext _context;
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

        public async Task<EUser> GetUserByUserNameAsync(string username)
        {
            var user = (await (from u
                    in _context.Users
                        .Include(u=>u.OwnBooks)
                       // .Include(u=>u.Avatar)
                where u.UserName==username
                select u).FirstOrDefaultAsync());
            return user ?? throw new ArgumentException("User with that username not exists");
        }

        public async Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user)
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

        public async Task<bool> UpdateUserDataAsync(EUser user)
        {
            if (user == null)
                throw new ArgumentNullException($"User can't be null");

            await _userManager.UpdateAsync(user);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IdentityResult> UpdatePasswordAsync(EUser user, string oldPassword, string newPassword)
        {
            if (await _userManager.CheckPasswordAsync(user, oldPassword))
                return await _userManager.ChangePasswordAsync(user, oldPassword, newPassword);
            return IdentityResult.Failed(new IdentityError(){Description = "Current password is invalid!"});
        }

        public async Task UploadBook(EBook book, string ownerUserName)
        {
            if (book == null)
                throw new ArgumentException("Book parameter can't be null");
            var user = await GetUserByUserNameAsync(ownerUserName);
            book.Owner = user;
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
        }

        public async Task<EBook> GetBookById(string Id)
        {
            var res= await (from b
                    in _context.Books
                where b.Id.ToString() == Id
                select b).FirstOrDefaultAsync();
            return res ?? throw new ArgumentException("Book with such id doesn't exist");
        }
        public async Task<IList<EBook>> GetBooksGallery()
        {
            //var gallery = new Dictionary<int, List<EBook>>();
            return await (from b
                    in _context.Books
                        .Include(bc=>bc.Owner)
                select b).ToListAsync();
        }
    }
}