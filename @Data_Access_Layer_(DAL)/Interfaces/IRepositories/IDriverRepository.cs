using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;
namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IDriverRepository : IWriteRepository<Driver>, IReadRepository<Driver>
    {
    }
}