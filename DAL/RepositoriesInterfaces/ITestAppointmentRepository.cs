using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ITestAppointmentRepository
    {
        List<TestAppointment> GetAllTestAppointments();
        int GetCountOfAllTestAppointments();
        int GetCountOfTestAppointmentsByFilter(TestAppointmentRepository.TestAppointmentsSearchCriteria SearchCriteria);
        List<TestAppointment> GetTestAppointments(TestAppointmentRepository.TestAppointmentsSearchCriteria SearchCriteria);
        int AddNewTestAppointment(TestAppointment TestAppointmentDeatils);

        TestAppointment FindTestAppointmentByTestAppointmentID(int TestAppointmentID);
        bool DeleteTestAppointmentByTestAppointmentID(int TestAppointmentID);
        bool UpdateTestAppointmentByTestAppointmentID(TestAppointment UpdatedTestAppointment);
        bool IsTestAppointmentExistByTestAppointmentID(int TestAppointmentID);






    }
}
