using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface IDriverServices : IServices<DriverReadDTO, DriverAddDTO, DriverUpdateDTO, DriverServices.enFields>
    {
        public OperationResult<DriverReadDTO> FindByDriverID(int DriverID);
        public bool DeleteByDriverID(int DriverID);
        public bool UpdateByDriverID(DriverUpdateDTO UpdatedData);
    }
}
