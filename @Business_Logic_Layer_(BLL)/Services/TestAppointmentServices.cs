using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class TestAppointmentServices : ITestAppointmentServices
    {
        public enum enFields
        {
            None = 0,
            TestAppointmentID,
            TestTypeID,
            LocalDrivingLicenseApplicationID,
            AppointmentDate,
            PaidFees,
            CreatedByUserID,
            IsLocked
        }
        #region Properties
        private ITestAppointmentRepository repo;
        #endregion
        #region Constructors
        public TestAppointmentServices()
        {
            this.repo = new TestAppointmentRepository();
        }
        #endregion 
        #region Maps
        private TestAppointmentReadDTO _MapEntityToReadDTO(Entities.TestAppointment Entity)
        {
            if (Entity == null) return null;
            return new TestAppointmentReadDTO()
            {
                TestAppointmentID = Entity.TestAppointmentID,
                TestTypeID = Entity.TestTypeID,
                LocalDrivingLicenseApplicationID = Entity.LocalDrivingLicenseApplicationID,
                AppointmentDate = Entity.AppointmentDate,
                PaidFees = Entity.PaidFees,
                CreatedByUserID = Entity.CreatedByUserID,
                IsLocked = Entity.IsLocked,
            };
        }

        private Entities.TestAppointment _MapAddDTOToEntity(TestAppointmentAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.TestAppointment()
            {
                TestTypeID = AddDTO.TestTypeID,
                LocalDrivingLicenseApplicationID = AddDTO.LocalDrivingLicenseApplicationID,
                AppointmentDate = AddDTO.AppointmentDate,
                PaidFees = AddDTO.PaidFees,
                CreatedByUserID = AddDTO.CreatedByUserID,
                IsLocked = AddDTO.IsLocked,
            };
        }

        private Entities.TestAppointment _MapUpdateDTOToEntity(TestAppointmentUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.TestAppointment()
            {
                TestAppointmentID = UpdateDTO.TestAppointmentID,
                TestTypeID = UpdateDTO.TestTypeID,
                LocalDrivingLicenseApplicationID = UpdateDTO.LocalDrivingLicenseApplicationID,
                AppointmentDate = UpdateDTO.AppointmentDate,
                PaidFees = UpdateDTO.PaidFees,
                IsLocked = UpdateDTO.IsLocked,
            };
        }


        private List<TestAppointmentReadDTO> _MapEntitiesTOReadDTOs(List<Entities.TestAppointment> EntitiesList)
        {
            List<TestAppointmentReadDTO> Results = new List<TestAppointmentReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enTestAppointmentField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.TestAppointmentID:
                    return Repositories.enTestAppointmentField.TestAppointmentID;
                case enFields.TestTypeID:
                    return Repositories.enTestAppointmentField.TestTypeID;
                case enFields.LocalDrivingLicenseApplicationID:
                    return Repositories.enTestAppointmentField.LocalDrivingLicenseApplicationID;
                case enFields.AppointmentDate:
                    return Repositories.enTestAppointmentField.AppointmentDate;
                case enFields.PaidFees:
                    return Repositories.enTestAppointmentField.PaidFees;
                case enFields.CreatedByUserID:
                    return Repositories.enTestAppointmentField.CreatedByUserID;
                case enFields.IsLocked:
                    return Repositories.enTestAppointmentField.IsLocked;
                default:
                    return Repositories.enTestAppointmentField.TestAppointmentID;
            }
        }

        private TestAppointmentRepository.TestAppointmentsSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new TestAppointmentRepository.TestAppointmentsSearchCriteria()
            {
                PageNumber = SearchCriteria.PageNumber,
                PageSize = SearchCriteria.SizeInEveryPage,
                SearchBy = _MapToRepoFieldEmum(SearchCriteria.SearchBy),
                OrderBy = _MapToRepoFieldEmum(SearchCriteria.OrderBy),
                SearchText = SearchCriteria.SearchString,
                Sorting = (Repositories.enSorting)SearchCriteria.SortingBy,
                SearchType = (Repositories.enSearchType)SearchCriteria.SearchType
            };
        }
        #endregion

        #region CRUD METHODS 
        public OperationResults<TestAppointmentReadDTO> GetPeople(SearchCriteria<TestAppointmentServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetTestAppointmentsList(repo.GetTestAppointments(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<TestAppointmentReadDTO> GetAllPeople()
        {
            return _GetResultFromGetTestAppointmentsList(repo.GetAllTestAppointments());
        }
        public int AddNew(TestAppointmentAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewTestAppointment(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<TestAppointmentServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfTestAppointmentsByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllTestAppointments();
        }
        public OperationResult<TestAppointmentReadDTO> FindByTestAppointmentID(int TestAppointmentID)
        {
            var data = repo.FindTestAppointmentByTestAppointmentID(TestAppointmentID);
            if (data == null) return OperationResult<TestAppointmentReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.TestAppointmentID <= 0) notFound = true;
            if (notFound) return OperationResult<TestAppointmentReadDTO>.Failure(ErrorCode.rNotFound, "No TestAppointment Data Found.");
            return OperationResult<TestAppointmentReadDTO>.Success(_MapEntityToReadDTO(data), "TestAppointment Data Retrieved Successfully.");
        }
        public bool DeleteByTestAppointmentID(int TestAppointmentID)
        {
            if (repo.DeleteTestAppointmentByTestAppointmentID(TestAppointmentID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByTestAppointmentID(TestAppointmentUpdateDTO UpdatedData)
        {
            return repo.UpdateTestAppointmentByTestAppointmentID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(TestAppointmentAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<TestAppointmentReadDTO> _GetResultFromGetTestAppointmentsList(List<Entities.TestAppointment> Data)
        {
            if (Data == null) return OperationResults<TestAppointmentReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<TestAppointmentReadDTO>.Failure(ErrorCode.rNoData, "No TestAppointments Data Found.");
            return OperationResults<TestAppointmentReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "TestAppointments Data Retrieved Successfully.");
        }
        #endregion
    }
}
