using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ILicenseRepository
    {
        List<License> GetAllLicenses();
        int GetCountOfAllLicenses();
        int GetCountOfLicensesByFilter(LicenseRepository.LicensesSearchCriteria SearchCriteria);
        List<License> GetLicenses(LicenseRepository.LicensesSearchCriteria SearchCriteria);
        int AddNewLicense(License LicenseDeatils);

        License FindLicenseByLicenseID(int LicenseID);
        bool DeleteLicenseByLicenseID(int LicenseID);
        bool UpdateLicenseByLicenseID(License UpdatedLicense);
        bool IsLicenseExistByLicenseID(int LicenseID);










    }
}
