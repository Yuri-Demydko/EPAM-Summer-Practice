using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface ITechDAO
    {
        public Task PrefillDatabaseWithTestDataAsync();
    }
}