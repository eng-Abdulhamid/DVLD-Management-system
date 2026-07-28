using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IApplicationTypeRepository
    {
        List<ApplicationType> GetAllApplicationTypes();
        int GetCountOfAllApplicationTypes();
        int GetCountOfApplicationTypesByFilter(ApplicationTypeRepository.ApplicationTypesSearchCriteria SearchCriteria);
        List<ApplicationType> GetApplicationTypes(ApplicationTypeRepository.ApplicationTypesSearchCriteria SearchCriteria);
        int AddNewApplicationType(ApplicationType ApplicationTypeDeatils);

        ApplicationType FindApplicationTypeByApplicationTypeID(int ApplicationTypeID);
        bool DeleteApplicationTypeByApplicationTypeID(int ApplicationTypeID);
        bool UpdateApplicationTypeByApplicationTypeID(ApplicationType UpdatedApplicationType);
        bool IsApplicationTypeExistByApplicationTypeID(int ApplicationTypeID);


    }
}
