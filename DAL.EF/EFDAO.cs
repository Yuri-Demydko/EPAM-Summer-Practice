using System.Linq;
using DAO.Interfaces;
using DTO.Entities;

namespace EFDAO
{
    public class DAO:IDAO
    {
        private EFDBContext _context;

        public DAO()
        {
            _context = new EFDBContext();
        }
        public EUser GetExampleUser()
        {
            return _context.Users.First();
            //throw new System.NotImplementedException();
        }
    }
}