using DVLD.DAL.Entities;

namespace DVLD.DAL.Interfaces
{
    public interface ICountryRepository : IWriteRepository<Country>, IReadRepository<Country>
    {
        Task<Country?> FindByNameAsync(string countryName);
        Task<bool> ExistsByNameAsync(string countryName);
    }
}