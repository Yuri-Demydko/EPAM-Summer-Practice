using System.Collections.Generic;
using System.Threading.Tasks;
using BLL.Interfaces;
using Entities.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Logic
{
    public class UsersBLO:IUsersBLO
    {
        private readonly DAL.Interfaces.IUsersDAO _dao;
        public UsersBLO(DAL.Interfaces.IUsersDAO dao)
        {
            _dao = dao;
        }
        
        public async Task<IdentityResult> AddUserAsync(EUser user, string password) => await _dao.AddUserAsync(user, password);
        public async Task SignInUserAsync(EUser user, bool isPersistent) => await _dao.SignInUserAsync(user, isPersistent);
        public async Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember,
            bool lockOnFailure) =>
            await _dao.PasswordSignInAsync(login, password, remember, lockOnFailure);
        public async Task SignOutAsync() => await _dao.SignOutAsync();
        public Task<EUser> GetUserByUserNameAsync(string username,bool includeHeavyData=true) => _dao.GetUserByUserNameAsync(username,includeHeavyData);
        public async Task<bool> UpdateUserDataAsync(EUser user) => await _dao.UpdateUserDataAsync(user);
        public async Task<IList<EBook>> GetFavoriteBooksByUserAsync(EUser user) => await _dao.GetFavoriteBooksByUserAsync(user);
        public async Task<IdentityResult> UpdatePasswordAsync(EUser user, string oldPassword, string newPassword) =>
            await _dao.UpdatePasswordAsync(user, oldPassword, newPassword);
        public async Task<bool> CheckBookInFavoritesOfUser(EBook book, string userName) =>
            await _dao.CheckBookInFavoritesOfUser(book, userName);
    }
}