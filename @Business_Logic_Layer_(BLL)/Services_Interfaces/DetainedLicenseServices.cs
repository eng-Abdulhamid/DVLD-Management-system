using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface IDetainedLicenseServices : IServices<DetainedLicenseReadDTO, DetainedLicenseAddDTO, DetainedLicenseUpdateDTO, DetainedLicenseServices.enFields>
    {
        public OperationResult<DetainedLicenseReadDTO> FindByDetainID(int DetainID);
        public bool DeleteByDetainID(int DetainID);
        public bool UpdateByDetainID(DetainedLicenseUpdateDTO UpdatedData);
    }
}
