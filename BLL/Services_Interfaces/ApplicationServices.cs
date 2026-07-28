using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface IApplicationServices : IServices<ApplicationReadDTO, ApplicationAddDTO, ApplicationUpdateDTO, ApplicationServices.enFields>
    {
        public OperationResult<ApplicationReadDTO> FindByApplicationID(int ApplicationID);
        public bool DeleteByApplicationID(int ApplicationID);
        public bool UpdateByApplicationID(ApplicationUpdateDTO UpdatedData);
    }
}
