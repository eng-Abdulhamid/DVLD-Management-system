using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class LocalDrivingLicenseApplicationServices : ILocalDrivingLicenseApplicationServices
    {
        public enum enFields
        {
            None = 0,
            LocalDrivingLicenseApplicationID,
            ApplicationID,
            LicenseClassID
        }
        #region Properties
        private ILocalDrivingLicenseApplicationRepository repo;
        #endregion
        #region Constructors
        public LocalDrivingLicenseApplicationServices()
        {
            this.repo = new LocalDrivingLicenseApplicationRepository();
        }
        #endregion 
        #region Maps
        private LocalDrivingLicenseApplicationReadDTO _MapEntityToReadDTO(Entities.LocalDrivingLicenseApplication Entity)
        {
            if (Entity == null) return null;
            return new LocalDrivingLicenseApplicationReadDTO()
            {
                LocalDrivingLicenseApplicationID = Entity.LocalDrivingLicenseApplicationID,
                ApplicationID = Entity.ApplicationID,
                LicenseClassID = Entity.LicenseClassID,
            };
        }

        private Entities.LocalDrivingLicenseApplication _MapAddDTOToEntity(LocalDrivingLicenseApplicationAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.LocalDrivingLicenseApplication()
            {
                ApplicationID = AddDTO.ApplicationID,
                LicenseClassID = AddDTO.LicenseClassID,
            };
        }

        private Entities.LocalDrivingLicenseApplication _MapUpdateDTOToEntity(LocalDrivingLicenseApplicationUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.LocalDrivingLicenseApplication()
            {
                LocalDrivingLicenseApplicationID = UpdateDTO.LocalDrivingLicenseApplicationID,
                ApplicationID = UpdateDTO.ApplicationID,
                LicenseClassID = UpdateDTO.LicenseClassID,
            };
        }


        private List<LocalDrivingLicenseApplicationReadDTO> _MapEntitiesTOReadDTOs(List<Entities.LocalDrivingLicenseApplication> EntitiesList)
        {
            List<LocalDrivingLicenseApplicationReadDTO> Results = new List<LocalDrivingLicenseApplicationReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enLocalDrivingLicenseApplicationField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.LocalDrivingLicenseApplicationID:
                    return Repositories.enLocalDrivingLicenseApplicationField.LocalDrivingLicenseApplicationID;
                case enFields.ApplicationID:
                    return Repositories.enLocalDrivingLicenseApplicationField.ApplicationID;
                case enFields.LicenseClassID:
                    return Repositories.enLocalDrivingLicenseApplicationField.LicenseClassID;
                default:
                    return Repositories.enLocalDrivingLicenseApplicationField.LocalDrivingLicenseApplicationID;
            }
        }

        private LocalDrivingLicenseApplicationRepository.LocalDrivingLicenseApplicationsSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new LocalDrivingLicenseApplicationRepository.LocalDrivingLicenseApplicationsSearchCriteria()
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
        public OperationResults<LocalDrivingLicenseApplicationReadDTO> GetPeople(SearchCriteria<LocalDrivingLicenseApplicationServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetLocalDrivingLicenseApplicationsList(repo.GetLocalDrivingLicenseApplications(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<LocalDrivingLicenseApplicationReadDTO> GetAllPeople()
        {
            return _GetResultFromGetLocalDrivingLicenseApplicationsList(repo.GetAllLocalDrivingLicenseApplications());
        }
        public int AddNew(LocalDrivingLicenseApplicationAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewLocalDrivingLicenseApplication(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<LocalDrivingLicenseApplicationServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfLocalDrivingLicenseApplicationsByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllLocalDrivingLicenseApplications();
        }
        public OperationResult<LocalDrivingLicenseApplicationReadDTO> FindByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            var data = repo.FindLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID);
            if (data == null) return OperationResult<LocalDrivingLicenseApplicationReadDTO>.FailureDBAError(enResult.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.LocalDrivingLicenseApplicationID <= 0) notFound = true;
            if (notFound) return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Failure(enResult.rNotFound, "No LocalDrivingLicenseApplication Data Found.");
            return OperationResult<LocalDrivingLicenseApplicationReadDTO>.Success(_MapEntityToReadDTO(data), "LocalDrivingLicenseApplication Data Retrieved Successfully.");
        }
        public bool DeleteByLocalDrivingLicenseApplicationID(int LocalDrivingLicenseApplicationID)
        {
            if (repo.DeleteLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByLocalDrivingLicenseApplicationID(LocalDrivingLicenseApplicationUpdateDTO UpdatedData)
        {
            return repo.UpdateLocalDrivingLicenseApplicationByLocalDrivingLicenseApplicationID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(LocalDrivingLicenseApplicationAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<LocalDrivingLicenseApplicationReadDTO> _GetResultFromGetLocalDrivingLicenseApplicationsList(List<Entities.LocalDrivingLicenseApplication> Data)
        {
            if (Data == null) return OperationResults<LocalDrivingLicenseApplicationReadDTO>.FailureDBAError(enResult.rDBAError);
            if (Data.Count == 0) return OperationResults<LocalDrivingLicenseApplicationReadDTO>.Failure(enResult.rNoData, "No LocalDrivingLicenseApplications Data Found.");
            return OperationResults<LocalDrivingLicenseApplicationReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "LocalDrivingLicenseApplications Data Retrieved Successfully.");
        }
        #endregion
    }
}
