using System.Collections.Generic;
using System.Threading.Tasks;
namespace DVLD.DAL.Interfaces.Common
{
    public interface IReadRepository<T> where T : class
    {
        Task<int> CountAsync();
        Task<List<T>> GetAllAsync();
        Task<T?> FindAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
