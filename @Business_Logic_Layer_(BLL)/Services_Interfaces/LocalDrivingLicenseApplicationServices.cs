using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface ILocalDrivingLicenseApplicationServices : IServices<LocalDrivingLicenseApplicationReadDTO, LocalDrivingLicenseApplicationAddDTO, LocalDrivingLicenseApplicationUpdateDTO, LocalDrivingLicenseApplicationServices.enFields>
    {
        public OperationResult<LocalDrivingLicenseApplicationReadDTO> FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID);
        public bool DeleteByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID);
        public bool UpdateByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationUpdateDTO UpdatedData);
    }
}
