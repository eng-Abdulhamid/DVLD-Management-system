using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IApplicationTypeRepository : IWriteRepository<ApplicationType>, IReadRepository<ApplicationType>
    {
        Task<bool> DeleteAsync(int applicationTypeID);
        Task<ApplicationType?> FindByTitleAsync(string title);
        Task<bool> ExistsByTitleAsync(string title);
    }
}