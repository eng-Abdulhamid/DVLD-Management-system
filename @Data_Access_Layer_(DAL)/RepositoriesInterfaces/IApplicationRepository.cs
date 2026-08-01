using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IApplicationRepository
    {
        List<Application> GetAllApplications();
        int GetCountOfAllApplications();
        int GetCountOfApplicationsByFilter(ApplicationRepository.ApplicationsSearchCriteria SearchCriteria);
        List<Application> GetApplications(ApplicationRepository.ApplicationsSearchCriteria SearchCriteria);
        int AddNewApplication(Application ApplicationDeatils);

        Application FindApplicationByApplicationID(int ApplicationID);
        bool DeleteApplicationByApplicationID(int ApplicationID);
        bool UpdateApplicationByApplicationID(Application UpdatedApplication);
        bool IsApplicationExistByApplicationID(int ApplicationID);







    }
}
