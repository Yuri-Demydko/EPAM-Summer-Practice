using System.Reflection;
using BLL.Interfaces;
using DAO.Interfaces;
using DTO.Entities;
using Ninject;

namespace BLL.Library
{
    public class LibraryBLO:IBLO
    {
        private IDAO DAO;
        public LibraryBLO(IDAO dao)
        {
            DAO = dao;
        }
        public EUser GetExampleUserFromDAO()
        {
            throw new System.NotImplementedException();
        }
    }
}