using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class TestServices : ITestServices
    {
        public enum enFields
        {
            None = 0,
            TestID,
            TestAppointmentID,
            TestResult,
            Notes,
            CreatedByUserID
        }
        #region Properties
        private ITestRepository repo;
        #endregion
        #region Constructors
        public TestServices()
        {
            this.repo = new TestRepository();
        }
        #endregion 
        #region Maps
        private TestReadDTO _MapEntityToReadDTO(Entities.Test Entity)
        {
            if (Entity == null) return null;
            return new TestReadDTO()
            {
                TestID = Entity.TestID,
                TestAppointmentID = Entity.TestAppointmentID,
                TestResult = Entity.TestResult,
                Notes = Entity.Notes,
                CreatedByUserID = Entity.CreatedByUserID,
            };
        }

        private Entities.Test _MapAddDTOToEntity(TestAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.Test()
            {
                TestAppointmentID = AddDTO.TestAppointmentID,
                TestResult = AddDTO.TestResult,
                Notes = AddDTO.Notes,
                CreatedByUserID = AddDTO.CreatedByUserID,
            };
        }

        private Entities.Test _MapUpdateDTOToEntity(TestUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.Test()
            {
                TestID = UpdateDTO.TestID,
                TestAppointmentID = UpdateDTO.TestAppointmentID,
                TestResult = UpdateDTO.TestResult,
                Notes = UpdateDTO.Notes
            };
        }


        private List<TestReadDTO> _MapEntitiesTOReadDTOs(List<Entities.Test> EntitiesList)
        {
            List<TestReadDTO> Results = new List<TestReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enTestField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.TestID:
                    return Repositories.enTestField.TestID;
                case enFields.TestAppointmentID:
                    return Repositories.enTestField.TestAppointmentID;
                case enFields.TestResult:
                    return Repositories.enTestField.TestResult;
                case enFields.Notes:
                    return Repositories.enTestField.Notes;
                case enFields.CreatedByUserID:
                    return Repositories.enTestField.CreatedByUserID;
                default:
                    return Repositories.enTestField.TestID;
            }
        }

        private TestRepository.TestsSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new TestRepository.TestsSearchCriteria()
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
        public OperationResults<TestReadDTO> GetPeople(SearchCriteria<TestServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetTestsList(repo.GetTests(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<TestReadDTO> GetAllPeople()
        {
            return _GetResultFromGetTestsList(repo.GetAllTests());
        }
        public int AddNew(TestAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewTest(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<TestServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfTestsByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllTests();
        }
        public OperationResult<TestReadDTO> FindByTestID(int TestID)
        {
            var data = repo.FindTestByTestID(TestID);
            if (data == null) return OperationResult<TestReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.TestID <= 0) notFound = true;
            if (notFound) return OperationResult<TestReadDTO>.Failure(ErrorCode.rNotFound, "No Test Data Found.");
            return OperationResult<TestReadDTO>.Success(_MapEntityToReadDTO(data), "Test Data Retrieved Successfully.");
        }
        public bool DeleteByTestID(int TestID)
        {
            if (repo.DeleteTestByTestID(TestID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByTestID(TestUpdateDTO UpdatedData)
        {
            return repo.UpdateTestByTestID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(TestAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<TestReadDTO> _GetResultFromGetTestsList(List<Entities.Test> Data)
        {
            if (Data == null) return OperationResults<TestReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<TestReadDTO>.Failure(ErrorCode.rNoData, "No Tests Data Found.");
            return OperationResults<TestReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Tests Data Retrieved Successfully.");
        }
        #endregion
    }
}
