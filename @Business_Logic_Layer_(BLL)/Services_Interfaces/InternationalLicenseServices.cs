using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
namespace Services
{

    public interface IInternationalLicenseServices : IServices<InternationalLicenseReadDTO, InternationalLicenseAddDTO, InternationalLicenseUpdateDTO, InternationalLicenseServices.enFields>
    {
        public OperationResult<InternationalLicenseReadDTO> FindByInternationalLicenseID(int InternationalLicenseID);
        public bool DeleteByInternationalLicenseID(int InternationalLicenseID);
        public bool UpdateByInternationalLicenseID(InternationalLicenseUpdateDTO UpdatedData);
    }
}
