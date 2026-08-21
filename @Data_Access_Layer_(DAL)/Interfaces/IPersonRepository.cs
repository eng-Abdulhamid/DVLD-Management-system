using DVLD.DAL.Entities;
namespace DVLD.DAL.Interfaces
{
    public interface IPersonRepository : IWriteRepository<Person>, IReadRepository<Person>
    {
        Person FindByNationalNo(string NationalNo);
        bool DeleteByNationalNo(string NationalNo);
        bool UpdateByNationalNo(Person UpdatedPerson);
        bool ExistsByNationalNo(string NationalNo);
        //int Count(PeopleSearchCriteria SearchCriteria);
        //List<Person> GetAll(PeopleSearchCriteria SearchCriteria);

    }
}
