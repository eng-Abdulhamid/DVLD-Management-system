using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ITestRepository : IWriteRepository<Test>, IReadRepository<Test>
    {
        Task<bool> DeleteAsync(int testID);
        Task<Test?> FindByTestAppointmentIdAsync(int testAppointmentID);
        Task<byte> GetPassedTestCountAsync(int localDrivingLicenseApplicationID);
        Task<bool> PassedAllTestsAsync(int localDrivingLicenseApplicationID);
    }
}