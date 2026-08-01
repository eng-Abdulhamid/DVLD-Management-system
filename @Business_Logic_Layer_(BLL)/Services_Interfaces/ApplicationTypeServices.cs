using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface IApplicationTypeServices : IServices<ApplicationTypeReadDTO, ApplicationTypeAddDTO, ApplicationTypeUpdateDTO, ApplicationTypeServices.enFields>
    {
        public OperationResult<ApplicationTypeReadDTO> FindByApplicationTypeID(int ApplicationTypeID);
        public bool DeleteByApplicationTypeID(int ApplicationTypeID);
        public bool UpdateByApplicationTypeID(ApplicationTypeUpdateDTO UpdatedData);
    }
}
