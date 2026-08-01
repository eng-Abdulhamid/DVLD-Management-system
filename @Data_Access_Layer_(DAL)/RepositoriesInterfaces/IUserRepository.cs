using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public partial interface IUserRepository
    {
        List<User> GetAllUsers();
        int GetCountOfAllUsers();
        int GetCountOfUsersByFilter(UserRepository.UsersSearchCriteria SearchCriteria);
        List<User> GetUsers(UserRepository.UsersSearchCriteria SearchCriteria);
        int AddNewUser(User UserDeatils);
        User FindUserByUserID(int UserID);
        bool DeleteUserByUserID(int UserID);
        bool UpdateUserByUserID(User UpdatedUser);
        bool IsUserExistByUserID(int UserID);

        
    }
}
