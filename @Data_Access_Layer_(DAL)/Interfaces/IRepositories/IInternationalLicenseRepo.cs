using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IInternationalLicenseRepository : IWriteRepository<InternationalLicense>, IReadRepository<InternationalLicense>
    {
        Task<bool> DeleteAsync(int internationalLicenseID);
        Task<List<InternationalLicense>> GetDriverInternationalLicensesAsync(int driverID);
        Task<int?> GetActiveInternationalLicenseIdByDriverIdAsync(int driverID);
    }
}