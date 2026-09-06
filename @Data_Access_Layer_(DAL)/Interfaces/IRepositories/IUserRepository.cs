using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;
namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
        Task<bool> DeleteAsync(int UserID);
        Task<User?> FindByUsernameAsync(string username);
        Task<bool> ChangePasswordAsync(string UserName, string newPassword);
        Task<bool> ChangePasswordAsync(int UserID, string newPassword);

    }
}
