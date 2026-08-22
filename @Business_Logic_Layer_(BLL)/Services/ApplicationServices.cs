using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class ApplicationServices : IApplicationServices
    {
        public enum enFields
        {
            None = 0,
            ApplicationID,
            ApplicantPersonID,
            ApplicationDate,
            ApplicationTypeID,
            ApplicationStatus,
            LastStatusDate,
            PaidFees,
            CreatedByUserID
        }
        #region Properties
        private IApplicationRepository repo;
        #endregion
        #region Constructors
        public ApplicationServices()
        {
            this.repo = new ApplicationRepository();
        }
        #endregion 
        #region Maps
        private ApplicationReadDTO _MapEntityToReadDTO(Entities.Application Entity)
        {
            if (Entity == null) return null;
            return new ApplicationReadDTO()
            {
                ApplicationID = Entity.ApplicationID,
                ApplicantPersonID = Entity.ApplicantPersonID,
                ApplicationDate = Entity.ApplicationDate,
                ApplicationTypeID = Entity.ApplicationTypeID,
                ApplicationStatus = Entity.ApplicationStatus,
                LastStatusDate = Entity.LastStatusDate,
                PaidFees = Entity.PaidFees,
                CreatedByUserID = Entity.CreatedByUserID,
            };
        }

        private Entities.Application _MapAddDTOToEntity(ApplicationAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.Application()
            {
                ApplicantPersonID = AddDTO.ApplicantPersonID,
                ApplicationDate = AddDTO.ApplicationDate,
                ApplicationTypeID = AddDTO.ApplicationTypeID,
                ApplicationStatus = AddDTO.ApplicationStatus,
                LastStatusDate = AddDTO.LastStatusDate,
                PaidFees = AddDTO.PaidFees,
                CreatedByUserID = AddDTO.CreatedByUserID,
            };
        }

        private Entities.Application _MapUpdateDTOToEntity(ApplicationUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.Application()
            {
                ApplicationID = UpdateDTO.ApplicationID,
                ApplicantPersonID = UpdateDTO.ApplicantPersonID,
                ApplicationDate = UpdateDTO.ApplicationDate,
                ApplicationTypeID = UpdateDTO.ApplicationTypeID,
                ApplicationStatus = UpdateDTO.ApplicationStatus,
                LastStatusDate = UpdateDTO.LastStatusDate,
                PaidFees = UpdateDTO.PaidFees
            };
        }


        private List<ApplicationReadDTO> _MapEntitiesTOReadDTOs(List<Entities.Application> EntitiesList)
        {
            List<ApplicationReadDTO> Results = new List<ApplicationReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enApplicationField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.ApplicationID:
                    return Repositories.enApplicationField.ApplicationID;
                case enFields.ApplicantPersonID:
                    return Repositories.enApplicationField.ApplicantPersonID;
                case enFields.ApplicationDate:
                    return Repositories.enApplicationField.ApplicationDate;
                case enFields.ApplicationTypeID:
                    return Repositories.enApplicationField.ApplicationTypeID;
                case enFields.ApplicationStatus:
                    return Repositories.enApplicationField.ApplicationStatus;
                case enFields.LastStatusDate:
                    return Repositories.enApplicationField.LastStatusDate;
                case enFields.PaidFees:
                    return Repositories.enApplicationField.PaidFees;
                case enFields.CreatedByUserID:
                    return Repositories.enApplicationField.CreatedByUserID;
                default:
                    return Repositories.enApplicationField.ApplicationID;
            }
        }

        private ApplicationRepository.ApplicationsSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new ApplicationRepository.ApplicationsSearchCriteria()
            {
                SearchBy = _MapToRepoFieldEmum(SearchCriteria.SearchBy),
                OrderBy = _MapToRepoFieldEmum(SearchCriteria.OrderBy),
                SearchText = SearchCriteria.SearchString,
                Sorting = (Repositories.enSorting)SearchCriteria.SortingBy,
                SearchType = (Repositories.enSearchType)SearchCriteria.SearchType
            };
        }
        #endregion

        #region CRUD METHODS 
        public OperationResults<ApplicationReadDTO> GetPeople(SearchCriteria<ApplicationServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetApplicationsList(repo.GetApplications(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<ApplicationReadDTO> GetAllPeople()
        {
            return _GetResultFromGetApplicationsList(repo.GetAllApplications());
        }
        public int AddNew(ApplicationAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewApplication(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<ApplicationServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfApplicationsByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllApplications();
        }
        public OperationResult<ApplicationReadDTO> FindByApplicationID(int ApplicationID)
        {
            var data = repo.FindApplicationByApplicationID(ApplicationID);
            if (data == null) return OperationResult<ApplicationReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.ApplicationID <= 0) notFound = true;
            if (notFound) return OperationResult<ApplicationReadDTO>.Failure(ErrorCode.rNotFound, "No Application Data Found.");
            return OperationResult<ApplicationReadDTO>.Success(_MapEntityToReadDTO(data), "Application Data Retrieved Successfully.");
        }
        public bool DeleteByApplicationID(int ApplicationID)
        {
            if (repo.DeleteApplicationByApplicationID(ApplicationID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByApplicationID(ApplicationUpdateDTO UpdatedData)
        {
            return repo.UpdateApplicationByApplicationID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(ApplicationAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<ApplicationReadDTO> _GetResultFromGetApplicationsList(List<Entities.Application> Data)
        {
            if (Data == null) return OperationResults<ApplicationReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<ApplicationReadDTO>.Failure(ErrorCode.rNoData, "No Applications Data Found.");
            return OperationResults<ApplicationReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Applications Data Retrieved Successfully.");
        }
        #endregion
    }
}
