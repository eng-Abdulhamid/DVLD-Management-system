using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ITestTypeRepository
    {
        List<TestType> GetAllTestTypes();
        int GetCountOfAllTestTypes();
        int GetCountOfTestTypesByFilter(TestTypeRepository.TestTypesSearchCriteria SearchCriteria);
        List<TestType> GetTestTypes(TestTypeRepository.TestTypesSearchCriteria SearchCriteria);
        int AddNewTestType(TestType TestTypeDeatils);

        TestType FindTestTypeByTestTypeID(int TestTypeID);
        bool DeleteTestTypeByTestTypeID(int TestTypeID);
        bool UpdateTestTypeByTestTypeID(TestType UpdatedTestType);
        bool IsTestTypeExistByTestTypeID(int TestTypeID);



    }
}
