using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
namespace Services
{

    public interface ILicenseClassServices : IServices<LicenseClassReadDTO, LicenseClassAddDTO, LicenseClassUpdateDTO, LicenseClassServices.enFields>
    {
        public OperationResult<LicenseClassReadDTO> FindByLicenseClassID(int LicenseClassID);
        public bool DeleteByLicenseClassID(int LicenseClassID);
        public bool UpdateByLicenseClassID(LicenseClassUpdateDTO UpdatedData);
    }
}
