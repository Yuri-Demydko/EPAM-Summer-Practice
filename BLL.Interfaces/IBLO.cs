using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using DTO.Entities;
using Microsoft.AspNetCore.Identity;

namespace BLL.Interfaces
{
    public interface IBLO
    {
        //public EUser GetExampleUserFromDAO();
        
        //Calls to DAL
        public Task<IdentityResult> AddUserAsync(EUser user, string password);
        public Task SignInUserAsync(EUser user, bool isPersistent);
        public Task<SignInResult> PasswordSignInAsync(string login, string password, bool remember, bool lockOnFailure);
        public Task SignOutAsync();
        public Task<EUser> GetUserByUserName(string username);
        public  Task<IList<EBook>> GetFavoriteBooksByUser(EUser user);
    }
}