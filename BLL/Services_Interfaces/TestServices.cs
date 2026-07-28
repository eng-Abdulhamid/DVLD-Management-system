using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface ITestServices : IServices<TestReadDTO, TestAddDTO, TestUpdateDTO, TestServices.enFields>
    {
        public OperationResult<TestReadDTO> FindByTestID(int TestID);
        public bool DeleteByTestID(int TestID);
        public bool UpdateByTestID(TestUpdateDTO UpdatedData);
    }
}
