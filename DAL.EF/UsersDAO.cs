using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entities.Entities;
using DAL.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace DAL.EF
{
    public class UsersDAO:IUsersDAO
    {
        private readonly EFDBContext _context;
        private readonly UserManager<EUser> _userManager;
        private readonly SignInManager<EUser> _signInManager;
        
        public UsersDAO(EFDBContext context, UserManager<EUser> userManager, SignInManager<EUser> signInManager)
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
        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember, bool lockOnFailure)
                {
                    return await _signInManager.PasswordSignInAsync(login, password, remember, lockOnFailure);
                }
        public async Task SignOutAsync()
                {
                    await _signInManager.SignOutAsync();
                }
        public async Task<EUser> GetUserByUserNameAsync(string username,bool includeHeavyData=true)
                {
                    EUser user;
                    if(includeHeavyData)
                    {
                         user = (await (from u
                                in _context.Users
                                    //.Include(u => u.OwnBooks)
                            // .Include(u=>u.Avatar)
                            where u.UserName == username
                            select u).FirstOrDefaultAsync());
                         user.OwnBooks = await _context.Books
                             .Where(b => b.Owner.Id == user.Id)
                             .Select(b => new EBook()
                             {
                                 Id = b.Id,
                                 Title = b.Title,
                                 Author = b.Author,
                                 Genre = b.Genre,
                                 LikesCount = b.LikesCount,
                                 CardBg = b.CardBg,
                             }).ToListAsync();
                    }
                    else
                    {
                        user = await _context.Users
                            .Where(u => u.UserName == username)
                            .Select(u => new EUser()
                            {
                                Id=u.Id,
                                FirstName = u.FirstName,
                                LastName = u.LastName,
                                City = u.City,
                                DateOfBirth = u.DateOfBirth,
                                //AdditionalInfo = u.AdditionalInfo,
                                UserName = u.UserName,
                                Email = u.Email
                            }).FirstOrDefaultAsync();
                    }
                    return user ?? throw new ArgumentException("User with that username not exists");
                }
        public async Task<bool> CheckBookInFavoritesOfUser(EBook book, string userName)
                {
                    var uId = (await GetUserByUserNameAsync(userName,false)).Id;
                    return await (from fbtu
                            in _context.FavoriteBooksToUsers
                        where (fbtu.BookId == book.Id && fbtu.UserId == uId)
                        select fbtu).AnyAsync();
                }
        public async Task<bool> UpdateUserDataAsync(EUser user)
                {
                    if (user == null)
                        throw new ArgumentNullException("User can't be null");
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
        public async Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user)
                {
                    if (user == null)
                        throw new ArgumentNullException($"User can't be null");
                    var booksId = await (from fbtu
                            in _context.FavoriteBooksToUsers
                        where fbtu.UserId == user.Id
                        select fbtu.BookId).ToListAsync();
        
                    return await _context.Books
                        .Where(b => booksId.Contains(b.Id))
                        .Select(b => new EBook()
                        {
                            Id = b.Id,
                            Title = b.Title,
                            Author = b.Author,
                            Genre = b.Genre,
                            LikesCount = b.LikesCount,
                            CardBg = b.CardBg,
                            Owner = b.Owner,
                        }).ToListAsync();
                }
    }
}