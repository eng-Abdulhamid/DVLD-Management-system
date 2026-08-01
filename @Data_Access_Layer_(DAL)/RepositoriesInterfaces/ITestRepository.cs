using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ITestRepository
    {
        List<Test> GetAllTests();
        int GetCountOfAllTests();
        int GetCountOfTestsByFilter(TestRepository.TestsSearchCriteria SearchCriteria);
        List<Test> GetTests(TestRepository.TestsSearchCriteria SearchCriteria);
        int AddNewTest(Test TestDeatils);

        Test FindTestByTestID(int TestID);
        bool DeleteTestByTestID(int TestID);
        bool UpdateTestByTestID(Test UpdatedTest);
        bool IsTestExistByTestID(int TestID);




    }
}
