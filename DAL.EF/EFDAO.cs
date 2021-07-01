using System.Linq;
using System.Threading.Tasks;
using DAO.Interfaces;
using DTO.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;

namespace EFDAO
{
    public class DAO : IDAO
    {
        private EFDBContext _context;
        private readonly UserManager<EUser> _userManager;
        private readonly SignInManager<EUser> _signInManager;

        public DAO(EFDBContext context, UserManager<EUser> userManager, SignInManager<EUser> signInManager)
        {
            _context = context;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public async Task<IdentityResult> AddUserAsync(EUser user,string password)
        {
            return await _userManager.CreateAsync(user, password);
        }

        public async Task SignInUserAsync(EUser user, bool isPersistent)
        {
            await _signInManager.SignInAsync(user, isPersistent);
        }
    }
}