using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
namespace Services
{

    public interface ILicenseServices : IServices<LicenseReadDTO, LicenseAddDTO, LicenseUpdateDTO, LicenseServices.enFields>
    {
        public OperationResult<LicenseReadDTO> FindByLicenseID(int LicenseID);
        public bool DeleteByLicenseID(int LicenseID);
        public bool UpdateByLicenseID(LicenseUpdateDTO UpdatedData);
    }
}
