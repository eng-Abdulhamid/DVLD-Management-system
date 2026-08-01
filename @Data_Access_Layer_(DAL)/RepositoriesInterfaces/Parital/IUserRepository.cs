using Entities;

namespace RepositoriesInterfaces
{
    public partial interface IUserRepository
    {
        User FindUserByUsername(string Username);
        User FindUserByUsernameAndPassword(string Username, string Password);
    }
}
