using System.Collections.Generic;
using System.Threading.Tasks;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace DAL.Interfaces
{
    public interface IUsersDAO
    {
         public Task<IdentityResult> AddUserAsync(EUser user, string password);
         public Task SignInUserAsync(EUser user, bool isPersistent);
         public Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember, bool lockOnFailure);
         public Task SignOutAsync();
         public Task<EUser> GetUserByUserNameAsync(string username,bool includeHeavyData=false);
         public  Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user);
         public Task<bool> UpdateUserDataAsync(EUser user);
         public Task<IdentityResult> UpdatePasswordAsync(EUser user,string oldPassword, string newPassword);
         public Task<bool> CheckBookInFavoritesOfUser(EBook book, string userName);
    }
}