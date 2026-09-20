using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ITestTypeRepository : IWriteRepository<TestType>, IReadRepository<TestType>
    {
        Task<bool> DeleteAsync(int testTypeID);
        Task<TestType?> FindByTitleAsync(string testTypeTitle);
        Task<bool> ExistsByTitleAsync(string testTypeTitle);
    }
}