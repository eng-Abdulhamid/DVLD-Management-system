using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
using DVLD.DAL.Interfaces.Common;
namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
        Task<UserDeletionResult> DeleteAsync(int userID);
        Task<User?> FindByUsernameAsync(string username);
        Task<bool> ChangePasswordAsync(string UserName, string newPassword);
        Task<bool> ChangePasswordAsync(int UserID, string newPassword);
        Task<bool> IsUsernameExistAsync(string username);
        Task<bool> IsUsernameExistForOtherUserAsync(string username, int userId);
        Task<bool> IsPersonLinkedToUserAsync(int personId);
    }
}
