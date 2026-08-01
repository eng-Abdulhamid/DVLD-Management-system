using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public partial interface IUserServices : IServices<UserReadDTO, UserAddDTO, UserUpdateDTO, UserServices.enFields>
    {
        public OperationResult<UserReadDTO> FindByUserID(int UserID);
        public bool DeleteByUserID(int UserID);
        public bool UpdateByUserID(UserUpdateDTO UpdatedData);
    }
}
