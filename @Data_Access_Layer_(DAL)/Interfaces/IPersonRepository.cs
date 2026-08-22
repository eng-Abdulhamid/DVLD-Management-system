using DVLD.DAL.Entities;
using System.Threading.Tasks;
namespace DVLD.DAL.Interfaces
{
    public interface IPersonRepository : IWriteRepository<Person>, IReadRepository<Person>
    {
        Task<Person?> FindByNationalNoAsync(string NationalNo);
        Task<bool> DeleteByNationalNoAsync(string NationalNo);
        Task<bool> UpdateByNationalNoAsync(Person UpdatedPerson);
        Task<bool> ExistsByNationalNoAsync(string NationalNo);
        //int Count(PeopleSearchCriteria SearchCriteria);
        //List<Person> GetAll(PeopleSearchCriteria SearchCriteria);

    }
}
