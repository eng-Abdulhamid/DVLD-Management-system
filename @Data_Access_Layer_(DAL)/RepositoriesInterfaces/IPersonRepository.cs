using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IPersonRepository
    {
        List<Person> GetAllPeople();
        int GetCountOfAllPeople();
        int GetCountOfPeopleByFilter(PersonRepository.PeopleSearchCriteria SearchCriteria);
        List<Person> GetPeople(PersonRepository.PeopleSearchCriteria SearchCriteria);
        int AddNewPerson(Person PersonDeatils);

        Person FindPersonByPersonID(int PersonID);
        bool DeletePersonByPersonID(int PersonID);
        bool UpdatePersonByPersonID(Person UpdatedPerson);
        bool IsPersonExistByPersonID(int PersonID);

        Person FindPersonByNationalNo(string NationalNo);
        bool DeletePersonByNationalNo(string NationalNo);
        bool UpdatePersonByNationalNo(Person UpdatedPerson);
        bool IsPersonExistByNationalNo(string NationalNo);











    }
}
