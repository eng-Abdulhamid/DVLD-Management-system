using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface ITestAppointmentServices : IServices<TestAppointmentReadDTO, TestAppointmentAddDTO, TestAppointmentUpdateDTO, TestAppointmentServices.enFields>
    {
        public OperationResult<TestAppointmentReadDTO> FindByTestAppointmentID(int TestAppointmentID);
        public bool DeleteByTestAppointmentID(int TestAppointmentID);
        public bool UpdateByTestAppointmentID(TestAppointmentUpdateDTO UpdatedData);
    }
}
