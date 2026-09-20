using System.Collections.Generic;
using System.Threading.Tasks;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ITestAppointmentRepository : IWriteRepository<TestAppointment>, IReadRepository<TestAppointment>
    {
        Task<bool> DeleteAsync(int testAppointmentID);
        Task<List<TestAppointment>> GetApplicationTestAppointmentsPerTestTypeAsync(int localDrivingLicenseApplicationID, int testTypeID);
        Task<TestAppointment?> GetLastTestAppointmentAsync(int localDrivingLicenseApplicationID, int testTypeID);
        Task<bool> LockAsync(int testAppointmentID);
    }
}