using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ILicenseRepository : IWriteRepository<License>, IReadRepository<License>
    {
        Task<bool> DeleteAsync(int licenseID);
        Task<List<License>> GetDriverLicensesAsync(int driverID);
        Task<int?> GetActiveLicenseIdByPersonIdAsync(int personID, int licenseClassID);
        Task<bool> DeactivateLicenseAsync(int licenseID);
    }
}