using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface ITestTypeServices : IServices<TestTypeReadDTO, TestTypeAddDTO, TestTypeUpdateDTO, TestTypeServices.enFields>
    {
        public OperationResult<TestTypeReadDTO> FindByTestTypeID(int TestTypeID);
        public bool DeleteByTestTypeID(int TestTypeID);
        public bool UpdateByTestTypeID(TestTypeUpdateDTO UpdatedData);
    }
}
