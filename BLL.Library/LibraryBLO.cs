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

        public object GetUserCP() => DAO.GetUserCP();
    }
}