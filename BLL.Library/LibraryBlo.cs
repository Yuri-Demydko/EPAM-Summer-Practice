using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Library
{
    public class LibraryBlo : IBLO
    {
        private readonly IDAO _dao;
        public LibraryBlo(IDAO dao) => _dao = dao;
        public async Task<IdentityResult> AddUserAsync(EUser user, string password) => await _dao.AddUserAsync(user, password);
        public async Task SignInUserAsync(EUser user, bool isPersistent) => await _dao.SignInUserAsync(user, isPersistent);
        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember,
            bool lockOnFailure) =>
            await _dao.PasswordSignInAsync(login, password, remember, lockOnFailure);
        public async Task SignOutAsync() => await _dao.SignOutAsync();
        public Task<EUser> GetUserByUserNameAsync(string username,bool includeHeavyData=false) => _dao.GetUserByUserNameAsync(username,includeHeavyData);
        public async Task<bool> UpdateUserDataAsync(EUser user) => await _dao.UpdateUserDataAsync(user);
        public async Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user) => await _dao.GetFavoriteBooksByUserAsync(user);
        public async Task<IdentityResult> UpdatePasswordAsync(EUser user, string oldPassword, string newPassword) =>
            await _dao.UpdatePasswordAsync(user, oldPassword, newPassword);
        public async Task UploadBook(EBook book, string ownerUserName) => await _dao.UploadBook(book, ownerUserName);
        public async Task<IList<EBook>> GetBooksGallery() => await _dao.GetBooksGallery();
        public async Task<EBook> GetBookById(string id,bool includeData=true) => await _dao.GetBookById(id,includeData);
        public async Task<bool> CheckBookInFavoritesOfUser(EBook book, string userName) =>
            await _dao.CheckBookInFavoritesOfUser(book, userName);
        public async Task UpdateBookInFavorites(int bookId, string userName,bool removingMode=false) =>
            await _dao.UpdateBookInFavorites(bookId, userName,removingMode);
        public async Task EditBookData(EBook updatedBook) => await _dao.EditBookData(updatedBook);
        public async Task DeleteBook(string bookId) => await _dao.DeleteBook(bookId);

        public async Task<IList<EBook>> GetFilteredBooksGallery(Tuple<string,byte> searchParameters) =>
            await _dao.GetFilteredBooksGallery(searchParameters);
    }
}