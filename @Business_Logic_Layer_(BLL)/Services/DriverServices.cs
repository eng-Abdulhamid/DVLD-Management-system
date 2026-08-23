using DTOs;
using DVLD.BLL;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class DriverServices : IDriverServices
    {
        public enum enFields
        {
            None = 0,
            DriverID,
            PersonID,
            CreatedByUserID,
            CreatedDate
        }
        #region Properties
        private IDriverRepository repo;
        #endregion
        #region Constructors
        public DriverServices()
        {
            this.repo = new DriverRepository();
        }
        #endregion 
        #region Maps
        private DriverReadDTO _MapEntityToReadDTO(Entities.Driver Entity)
        {
            if (Entity == null) return null;
            return new DriverReadDTO()
            {
                DriverID = Entity.DriverID,
                PersonID = Entity.PersonID,
                CreatedByUserID = Entity.CreatedByUserID,
                CreatedDate = Entity.CreatedDate,
            };
        }

        private Entities.Driver _MapAddDTOToEntity(DriverAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.Driver()
            {
                PersonID = AddDTO.PersonID,
                CreatedByUserID = AddDTO.CreatedByUserID
            };
        }

        private Entities.Driver _MapUpdateDTOToEntity(DriverUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.Driver()
            {
                DriverID = UpdateDTO.DriverID,
                PersonID = UpdateDTO.PersonID,
                CreatedByUserID = UpdateDTO.CreatedByUserID
            };
        }


        private List<DriverReadDTO> _MapEntitiesTOReadDTOs(List<Entities.Driver> EntitiesList)
        {
            List<DriverReadDTO> Results = new List<DriverReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enDriverField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.DriverID:
                    return Repositories.enDriverField.DriverID;
                case enFields.PersonID:
                    return Repositories.enDriverField.PersonID;
                case enFields.CreatedByUserID:
                    return Repositories.enDriverField.CreatedByUserID;
                case enFields.CreatedDate:
                    return Repositories.enDriverField.CreatedDate;
                default:
                    return Repositories.enDriverField.DriverID;
            }
        }

        private DriverRepository.DriversSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new DriverRepository.DriversSearchCriteria()
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
        public OperationResults<DriverReadDTO> GetPeople(SearchCriteria<DriverServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetDriversList(repo.GetDrivers(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<DriverReadDTO> GetAllPeople()
        {
            return _GetResultFromGetDriversList(repo.GetAllDrivers());
        }
        public int AddNew(DriverAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewDriver(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<DriverServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfDriversByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllDrivers();
        }
        public OperationResult<DriverReadDTO> FindByDriverID(int DriverID)
        {
            var data = repo.FindDriverByDriverID(DriverID);
            if (data == null) return OperationResult<DriverReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.DriverID <= 0) notFound = true;
            if (notFound) return OperationResult<DriverReadDTO>.Failure(ErrorCode.rNotFound, "No Driver Data Found.");
            return OperationResult<DriverReadDTO>.Success(_MapEntityToReadDTO(data), "Driver Data Retrieved Successfully.");
        }
        public bool DeleteByDriverID(int DriverID)
        {
            if (repo.DeleteDriverByDriverID(DriverID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByDriverID(DriverUpdateDTO UpdatedData)
        {
            return repo.UpdateDriverByDriverID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(DriverAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<DriverReadDTO> _GetResultFromGetDriversList(List<Entities.Driver> Data)
        {
            if (Data == null) return OperationResults<DriverReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<DriverReadDTO>.Failure(ErrorCode.rNoData, "No Drivers Data Found.");
            return OperationResults<DriverReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Drivers Data Retrieved Successfully.");
        }
        #endregion
    }
}
