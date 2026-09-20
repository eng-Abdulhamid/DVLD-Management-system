using System.Threading.Tasks;

namespace DVLD.DAL.Interfaces.Common
{
    public interface IWriteRepository<T> where T : class 
    {
        Task<int> AddAsync(T entity);
        Task<bool> UpdateAsync(T entity);
    }
}
