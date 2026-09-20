using DVLD.DAL.Entities;
using System.Threading.Tasks;
using DVLD.DAL.Interfaces.Common;
using DVLD.DAL.Enums;

namespace DVLD.DAL.Interfaces.IRepositories
{
    public interface IPersonRepository : IWriteRepository<Person>, IReadRepository<Person>
    {
        Task<Person?> FindByNationalNoAsync(string NationalNo);
        Task<bool> UpdateByNationalNoAsync(Person UpdatedPerson);
        Task<bool> ExistsByNationalNoAsync(string NationalNo);
        Task<bool> ExistsByNationalityCountryIDAsync(int NationalityCountryID);
        Task<PersonDeletionResult> DeleteAsync(int PersonID);
        Task<PersonDeletionResult> DeleteByNationalNoAsync(string NationalNo);
        Task<List<Person>> SearchPagedAsync(string filterColumn, string searchValue, string letter, byte? gendor, int pageNumber, int pageSize);
        Task<int> GetSearchCountAsync(string filterColumn, string searchValue, string letter, byte? gendor);
    }
}
