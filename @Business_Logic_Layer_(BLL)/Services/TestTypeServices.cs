using DTOs;
using DVLD.BLL;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class TestTypeServices : ITestTypeServices
    {
        public enum enFields
        {
            None = 0,
            TestTypeID,
            TestTypeTitle,
            TestTypeDescription,
            TestTypeFees
        }
        #region Properties
        private ITestTypeRepository repo;
        #endregion
        #region Constructors
        public TestTypeServices()
        {
            this.repo = new TestTypeRepository();
        }
        #endregion 
        #region Maps
        private TestTypeReadDTO _MapEntityToReadDTO(Entities.TestType Entity)
        {
            if (Entity == null) return null;
            return new TestTypeReadDTO()
            {
                TestTypeID = Entity.TestTypeID,
                TestTypeTitle = Entity.TestTypeTitle,
                TestTypeDescription = Entity.TestTypeDescription,
                TestTypeFees = Entity.TestTypeFees,
            };
        }

        private Entities.TestType _MapAddDTOToEntity(TestTypeAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.TestType()
            {
                TestTypeTitle = AddDTO.TestTypeTitle,
                TestTypeDescription = AddDTO.TestTypeDescription,
                TestTypeFees = AddDTO.TestTypeFees,
            };
        }

        private Entities.TestType _MapUpdateDTOToEntity(TestTypeUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.TestType()
            {
                TestTypeID = UpdateDTO.TestTypeID,
                TestTypeTitle = UpdateDTO.TestTypeTitle,
                TestTypeDescription = UpdateDTO.TestTypeDescription,
                TestTypeFees = UpdateDTO.TestTypeFees,
            };
        }


        private List<TestTypeReadDTO> _MapEntitiesTOReadDTOs(List<Entities.TestType> EntitiesList)
        {
            List<TestTypeReadDTO> Results = new List<TestTypeReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enTestTypeField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.TestTypeID:
                    return Repositories.enTestTypeField.TestTypeID;
                case enFields.TestTypeTitle:
                    return Repositories.enTestTypeField.TestTypeTitle;
                case enFields.TestTypeDescription:
                    return Repositories.enTestTypeField.TestTypeDescription;
                case enFields.TestTypeFees:
                    return Repositories.enTestTypeField.TestTypeFees;
                default:
                    return Repositories.enTestTypeField.TestTypeID;
            }
        }

        private TestTypeRepository.TestTypesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new TestTypeRepository.TestTypesSearchCriteria()
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
        public OperationResults<TestTypeReadDTO> GetPeople(SearchCriteria<TestTypeServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetTestTypesList(repo.GetTestTypes(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<TestTypeReadDTO> GetAllPeople()
        {
            return _GetResultFromGetTestTypesList(repo.GetAllTestTypes());
        }
        public int AddNew(TestTypeAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewTestType(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<TestTypeServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfTestTypesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllTestTypes();
        }
        public OperationResult<TestTypeReadDTO> FindByTestTypeID(int TestTypeID)
        {
            var data = repo.FindTestTypeByTestTypeID(TestTypeID);
            if (data == null) return OperationResult<TestTypeReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.TestTypeID <= 0) notFound = true;
            if (notFound) return OperationResult<TestTypeReadDTO>.Failure(ErrorCode.rNotFound, "No TestType Data Found.");
            return OperationResult<TestTypeReadDTO>.Success(_MapEntityToReadDTO(data), "TestType Data Retrieved Successfully.");
        }
        public bool DeleteByTestTypeID(int TestTypeID)
        {
            if (repo.DeleteTestTypeByTestTypeID(TestTypeID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByTestTypeID(TestTypeUpdateDTO UpdatedData)
        {
            return repo.UpdateTestTypeByTestTypeID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(TestTypeAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<TestTypeReadDTO> _GetResultFromGetTestTypesList(List<Entities.TestType> Data)
        {
            if (Data == null) return OperationResults<TestTypeReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<TestTypeReadDTO>.Failure(ErrorCode.rNoData, "No TestTypes Data Found.");
            return OperationResults<TestTypeReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "TestTypes Data Retrieved Successfully.");
        }
        #endregion
    }
}
