using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ILicenseClassRepository
    {
        List<LicenseClass> GetAllLicenseClasses();
        int GetCountOfAllLicenseClasses();
        int GetCountOfLicenseClassesByFilter(LicenseClassRepository.LicenseClassesSearchCriteria SearchCriteria);
        List<LicenseClass> GetLicenseClasses(LicenseClassRepository.LicenseClassesSearchCriteria SearchCriteria);
        int AddNewLicenseClass(LicenseClass LicenseClassDeatils);

        LicenseClass FindLicenseClassByLicenseClassID(int LicenseClassID);
        bool DeleteLicenseClassByLicenseClassID(int LicenseClassID);
        bool UpdateLicenseClassByLicenseClassID(LicenseClass UpdatedLicenseClass);
        bool IsLicenseClassExistByLicenseClassID(int LicenseClassID);





    }
}
