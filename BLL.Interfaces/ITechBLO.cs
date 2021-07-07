using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface ITechBLO
    {
        public Task PrefillDatabaseWithTestDataAsync();
    }
}