using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ILocalDrivingLicenseApplicationRepository
    {
        List<LocalDrivingLicenseApplication> GetAllLocalDrivingLicenseApplications();
        int GetCountOfAllLocalDrivingLicenseApplications();
        int GetCountOfLocalDrivingLicenseApplicationsByFilter(LocalDrivingLicenseApplicationRepository.LocalDrivingLicenseApplicationsSearchCriteria SearchCriteria);
        List<LocalDrivingLicenseApplication> GetLocalDrivingLicenseApplications(LocalDrivingLicenseApplicationRepository.LocalDrivingLicenseApplicationsSearchCriteria SearchCriteria);
        int AddNewLocalDrivingLicenseApplication(LocalDrivingLicenseApplication LocalDrivingLicenseApplicationDeatils);

        LocalDrivingLicenseApplication FindLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID);
        bool DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID);
        bool UpdateLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplication UpdatedLocalDrivingLicenseApplication);
        bool IsLocalDrivingLicenseApplicationExistByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID);


    }
}
