using System.Collections.Generic;
using System.Reflection;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Ninject;

namespace BLL.Library
{
    public class LibraryBLO : IBLO
    {
        private IDAO DAO;

        public LibraryBLO(IDAO dao)
        {
            DAO = dao;
        }


        public async Task<IdentityResult> AddUserAsync(EUser user, string password)
        {
            return await DAO.AddUserAsync(user, password);
        }

        public async Task SignInUserAsync(EUser user, bool isPersistent)
        {
            await DAO.SignInUserAsync(user, isPersistent);
        }

        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember,
            bool lockOnFailure)
        {
            return await DAO.PasswordSignInAsync(login, password, remember, lockOnFailure);
        }

        public async Task SignOutAsync()
        {
            await DAO.SignOutAsync();
        }

        public Task<EUser> GetUserByUserNameAsync(string username) => DAO.GetUserByUserNameAsync(username);
        public async Task<bool> UpdateUserDataAsync(EUser user) => await DAO.UpdateUserDataAsync(user);
        public async Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user) => await DAO.GetFavoriteBooksByUserAsync(user);

        public async Task<IdentityResult> UpdatePasswordAsync(EUser user, string oldPassword, string newPassword) =>
            await DAO.UpdatePasswordAsync(user, oldPassword, newPassword);

        public async Task UploadBook(EBook book, string ownerUserName) => await DAO.UploadBook(book, ownerUserName);
        public async Task<IList<EBook>> GetBooksGallery() => await DAO.GetBooksGallery();
        public async Task<EBook> GetBookById(string Id) => await DAO.GetBookById(Id);

    }
}