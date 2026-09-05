using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ILocalDrivingLicenseApplicationRepository : IWriteRepository<LocalDrivingLicenseApplication>, IReadRepository<LocalDrivingLicenseApplication>
    {
        Task<bool> DeleteAsync(int localDrivingLicenseApplicationID);
        Task<LocalDrivingLicenseApplication?> FindByApplicationIdAsync(int applicationID);
    }
}