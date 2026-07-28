using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IDetainedLicenseRepository
    {
        List<DetainedLicense> GetAllDetainedLicenses();
        int GetCountOfAllDetainedLicenses();
        int GetCountOfDetainedLicensesByFilter(DetainedLicenseRepository.DetainedLicensesSearchCriteria SearchCriteria);
        List<DetainedLicense> GetDetainedLicenses(DetainedLicenseRepository.DetainedLicensesSearchCriteria SearchCriteria);
        int AddNewDetainedLicense(DetainedLicense DetainedLicenseDeatils);

        DetainedLicense FindDetainedLicenseByDetainID(int DetainID);
        bool DeleteDetainedLicenseByDetainID(int DetainID);
        bool UpdateDetainedLicenseByDetainID(DetainedLicense UpdatedDetainedLicense);
        bool IsDetainedLicenseExistByDetainID(int DetainID);








    }
}
