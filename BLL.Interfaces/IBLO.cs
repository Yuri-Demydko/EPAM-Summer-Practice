using System;
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
    }
}