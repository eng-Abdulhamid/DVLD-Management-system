using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IInternationalLicenseRepository
    {
        List<InternationalLicense> GetAllInternationalLicenses();
        int GetCountOfAllInternationalLicenses();
        int GetCountOfInternationalLicensesByFilter(InternationalLicenseRepository.InternationalLicensesSearchCriteria SearchCriteria);
        List<InternationalLicense> GetInternationalLicenses(InternationalLicenseRepository.InternationalLicensesSearchCriteria SearchCriteria);
        int AddNewInternationalLicense(InternationalLicense InternationalLicenseDeatils);

        InternationalLicense FindInternationalLicenseByInternationalLicenseID(int InternationalLicenseID);
        bool DeleteInternationalLicenseByInternationalLicenseID(int InternationalLicenseID);
        bool UpdateInternationalLicenseByInternationalLicenseID(InternationalLicense UpdatedInternationalLicense);
        bool IsInternationalLicenseExistByInternationalLicenseID(int InternationalLicenseID);







    }
}
