using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace IDAO
{
    public interface IDAO
    {
        public Task<IdentityResult> AddUserAsync(EUser user, string password);

        public Task SignInUserAsync(EUser user, bool isPersistent);

        public Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember, bool lockOnFailure);
        public Task SignOutAsync();

        public Task<EUser> GetUserByUserNameAsync(string username,bool includeHeavyData=false);
        public  Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user);

        public Task<bool> UpdateUserDataAsync(EUser user);
        public Task<IdentityResult> UpdatePasswordAsync(EUser user,string oldPassword, string newPassword);

        public Task UploadBook(EBook book, string ownerUserName);
        public Task<IList<EBook>> GetBooksGallery();
        public Task<EBook> GetBookById(string id,bool includeHeavyData=true);
        public Task<bool> CheckBookInFavoritesOfUser(EBook book, string userName);
        public Task UpdateBookInFavorites(int bookId, string userName, bool removingMode = false);
        public Task EditBookData(EBook updatedBook);
        public Task DeleteBook(string bookId);
        public Task<IList<EBook>> GetFilteredBooksGallery(Tuple<string,byte> searchParameters);

    }
}