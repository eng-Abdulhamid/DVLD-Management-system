using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.Common;
namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface ICountryRepository : IWriteRepository<Country>, IReadRepository<Country>
    {
        Task<Country?> FindByNameAsync(string countryName);
        Task<bool> ExistsByNameAsync(string countryName);
        Task<bool> DeleteAsync(int countryID);
    }
}