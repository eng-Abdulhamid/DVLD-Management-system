using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class ApplicationTypeServices : IApplicationTypeServices
    {
        public enum enFields
        {
            None = 0,
            ApplicationTypeID,
            ApplicationTypeTitle,
            ApplicationFees
        }
        #region Properties
        private IApplicationTypeRepository repo;
        #endregion
        #region Constructors
        public ApplicationTypeServices()
        {
            this.repo = new ApplicationTypeRepository();
        }
        #endregion 
        #region Maps
        private ApplicationTypeReadDTO _MapEntityToReadDTO(Entities.ApplicationType Entity)
        {
            if (Entity == null) return null;
            return new ApplicationTypeReadDTO()
            {
                ApplicationTypeID = Entity.ApplicationTypeID,
                ApplicationTypeTitle = Entity.ApplicationTypeTitle,
                ApplicationFees = Entity.ApplicationFees,
            };
        }

        private Entities.ApplicationType _MapAddDTOToEntity(ApplicationTypeAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.ApplicationType()
            {
                ApplicationTypeTitle = AddDTO.ApplicationTypeTitle,
                ApplicationFees = AddDTO.ApplicationFees,
            };
        }

        private Entities.ApplicationType _MapUpdateDTOToEntity(ApplicationTypeUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.ApplicationType()
            {
                ApplicationTypeID = UpdateDTO.ApplicationTypeID,
                ApplicationTypeTitle = UpdateDTO.ApplicationTypeTitle,
                ApplicationFees = UpdateDTO.ApplicationFees,
            };
        }


        private List<ApplicationTypeReadDTO> _MapEntitiesTOReadDTOs(List<Entities.ApplicationType> EntitiesList)
        {
            List<ApplicationTypeReadDTO> Results = new List<ApplicationTypeReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enApplicationTypeField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.ApplicationTypeID:
                    return Repositories.enApplicationTypeField.ApplicationTypeID;
                case enFields.ApplicationTypeTitle:
                    return Repositories.enApplicationTypeField.ApplicationTypeTitle;
                case enFields.ApplicationFees:
                    return Repositories.enApplicationTypeField.ApplicationFees;
                default:
                    return Repositories.enApplicationTypeField.ApplicationTypeID;
            }
        }

        private ApplicationTypeRepository.ApplicationTypesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new ApplicationTypeRepository.ApplicationTypesSearchCriteria()
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
        public OperationResults<ApplicationTypeReadDTO> GetPeople(SearchCriteria<ApplicationTypeServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetApplicationTypesList(repo.GetApplicationTypes(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<ApplicationTypeReadDTO> GetAllPeople()
        {
            return _GetResultFromGetApplicationTypesList(repo.GetAllApplicationTypes());
        }
        public int AddNew(ApplicationTypeAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewApplicationType(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<ApplicationTypeServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfApplicationTypesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllApplicationTypes();
        }
        public OperationResult<ApplicationTypeReadDTO> FindByApplicationTypeID(int ApplicationTypeID)
        {
            var data = repo.FindApplicationTypeByApplicationTypeID(ApplicationTypeID);
            if (data == null) return OperationResult<ApplicationTypeReadDTO>.FailureDBAError(enResult.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.ApplicationTypeID <= 0) notFound = true;
            if (notFound) return OperationResult<ApplicationTypeReadDTO>.Failure(enResult.rNotFound, "No ApplicationType Data Found.");
            return OperationResult<ApplicationTypeReadDTO>.Success(_MapEntityToReadDTO(data), "ApplicationType Data Retrieved Successfully.");
        }
        public bool DeleteByApplicationTypeID(int ApplicationTypeID)
        {
            if (repo.DeleteApplicationTypeByApplicationTypeID(ApplicationTypeID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByApplicationTypeID(ApplicationTypeUpdateDTO UpdatedData)
        {
            return repo.UpdateApplicationTypeByApplicationTypeID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(ApplicationTypeAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<ApplicationTypeReadDTO> _GetResultFromGetApplicationTypesList(List<Entities.ApplicationType> Data)
        {
            if (Data == null) return OperationResults<ApplicationTypeReadDTO>.FailureDBAError(enResult.rDBAError);
            if (Data.Count == 0) return OperationResults<ApplicationTypeReadDTO>.Failure(enResult.rNoData, "No ApplicationTypes Data Found.");
            return OperationResults<ApplicationTypeReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "ApplicationTypes Data Retrieved Successfully.");
        }
        #endregion
    }
}
