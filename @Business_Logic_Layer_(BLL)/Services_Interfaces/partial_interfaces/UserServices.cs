using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public partial interface IUserServices : IServices<UserReadDTO, UserAddDTO, UserUpdateDTO, UserServices.enFields>
    {
        OperationResult<UserReadDTO> FindUserByUsername(string Username);
        OperationResult<UserReadDTO> FindUserByUsernameAndPassword(string Username, string Password);
    }
}
