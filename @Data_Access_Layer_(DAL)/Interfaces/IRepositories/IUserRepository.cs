using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;
namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IUserRepository : IWriteRepository<User>, IReadRepository<User>
    {
        Task<bool> DeleteAsync(int UserID);
    }
}
