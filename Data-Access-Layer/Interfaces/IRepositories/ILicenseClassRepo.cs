using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ILicenseClassRepository : IWriteRepository<LicenseClass>, IReadRepository<LicenseClass>
    {
        Task<bool> DeleteAsync(int licenseClassID);
        Task<LicenseClass?> FindByNameAsync(string className);
        Task<bool> ExistsByNameAsync(string className);
    }
}