using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IDetainedLicenseRepository : IWriteRepository<DetainedLicense>, IReadRepository<DetainedLicense>
    {
        Task<bool> DeleteAsync(int detainID);
        Task<DetainedLicense?> FindByLicenseIdAsync(int licenseID);
        Task<bool> IsLicenseDetainedAsync(int licenseID);
        Task<bool> ReleaseDetainedLicenseAsync(int detainID, int releasedByUserID, int releaseApplicationID);
    }
}