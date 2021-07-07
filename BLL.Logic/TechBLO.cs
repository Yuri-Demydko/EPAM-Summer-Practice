using System.Threading.Tasks;
using BLL.Interfaces;
using DAL.Interfaces;

namespace BLL.Logic
{
    public class TechBLO:ITechBLO
    {
        private readonly ITechDAO _dao;
        public TechBLO(ITechDAO dao)
        {
            _dao = dao;
        }

        public async Task PrefillDatabaseWithTestDataAsync() => await _dao.PrefillDatabaseWithTestDataAsync();
    }
}