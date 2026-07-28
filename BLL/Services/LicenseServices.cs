using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class LicenseServices : ILicenseServices
    {
        public enum enFields
        {
            None = 0,
            LicenseID,
            ApplicationID,
            DriverID,
            LicenseClass,
            IssueDate,
            ExpirationDate,
            Notes,
            PaidFees,
            IsActive,
            IssueReason,
            CreatedByUserID
        }
        #region Properties
        private ILicenseRepository repo;
        #endregion
        #region Constructors
        public LicenseServices()
        {
            this.repo = new LicenseRepository();
        }
        #endregion 
        #region Maps
        private LicenseReadDTO _MapEntityToReadDTO(Entities.License Entity)
        {
            if (Entity == null) return null;
            return new LicenseReadDTO()
            {
                LicenseID = Entity.LicenseID,
                ApplicationID = Entity.ApplicationID,
                DriverID = Entity.DriverID,
                LicenseClass = Entity.LicenseClass,
                IssueDate = Entity.IssueDate,
                ExpirationDate = Entity.ExpirationDate,
                Notes = Entity.Notes,
                PaidFees = Entity.PaidFees,
                IsActive = Entity.IsActive,
                IssueReason = Entity.IssueReason,
                CreatedByUserID = Entity.CreatedByUserID,
            };
        }

        private Entities.License _MapAddDTOToEntity(LicenseAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.License()
            {
                ApplicationID = AddDTO.ApplicationID,
                DriverID = AddDTO.DriverID,
                LicenseClass = AddDTO.LicenseClass,
                IssueDate = AddDTO.IssueDate,
                ExpirationDate = AddDTO.ExpirationDate,
                Notes = AddDTO.Notes,
                PaidFees = AddDTO.PaidFees,
                IsActive = AddDTO.IsActive,
                IssueReason = AddDTO.IssueReason,
                CreatedByUserID = AddDTO.CreatedByUserID,
            };
        }

        private Entities.License _MapUpdateDTOToEntity(LicenseUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.License()
            {
                LicenseID = UpdateDTO.LicenseID,
                ApplicationID = UpdateDTO.ApplicationID,
                DriverID = UpdateDTO.DriverID,
                LicenseClass = UpdateDTO.LicenseClass,
                IssueDate = UpdateDTO.IssueDate,
                ExpirationDate = UpdateDTO.ExpirationDate,
                Notes = UpdateDTO.Notes,
                PaidFees = UpdateDTO.PaidFees,
                IsActive = UpdateDTO.IsActive,
                IssueReason = UpdateDTO.IssueReason
            };
        }


        private List<LicenseReadDTO> _MapEntitiesTOReadDTOs(List<Entities.License> EntitiesList)
        {
            List<LicenseReadDTO> Results = new List<LicenseReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enLicenseField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.LicenseID:
                    return Repositories.enLicenseField.LicenseID;
                case enFields.ApplicationID:
                    return Repositories.enLicenseField.ApplicationID;
                case enFields.DriverID:
                    return Repositories.enLicenseField.DriverID;
                case enFields.LicenseClass:
                    return Repositories.enLicenseField.LicenseClass;
                case enFields.IssueDate:
                    return Repositories.enLicenseField.IssueDate;
                case enFields.ExpirationDate:
                    return Repositories.enLicenseField.ExpirationDate;
                case enFields.Notes:
                    return Repositories.enLicenseField.Notes;
                case enFields.PaidFees:
                    return Repositories.enLicenseField.PaidFees;
                case enFields.IsActive:
                    return Repositories.enLicenseField.IsActive;
                case enFields.IssueReason:
                    return Repositories.enLicenseField.IssueReason;
                case enFields.CreatedByUserID:
                    return Repositories.enLicenseField.CreatedByUserID;
                default:
                    return Repositories.enLicenseField.LicenseID;
            }
        }

        private LicenseRepository.LicensesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new LicenseRepository.LicensesSearchCriteria()
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
        public OperationResults<LicenseReadDTO> GetPeople(SearchCriteria<LicenseServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetLicensesList(repo.GetLicenses(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<LicenseReadDTO> GetAllPeople()
        {
            return _GetResultFromGetLicensesList(repo.GetAllLicenses());
        }
        public int AddNew(LicenseAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewLicense(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<LicenseServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfLicensesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllLicenses();
        }
        public OperationResult<LicenseReadDTO> FindByLicenseID(int LicenseID)
        {
            var data = repo.FindLicenseByLicenseID(LicenseID);
            if (data == null) return OperationResult<LicenseReadDTO>.FailureDBAError(enResult.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.LicenseID <= 0) notFound = true;
            if (notFound) return OperationResult<LicenseReadDTO>.Failure(enResult.rNotFound, "No License Data Found.");
            return OperationResult<LicenseReadDTO>.Success(_MapEntityToReadDTO(data), "License Data Retrieved Successfully.");
        }
        public bool DeleteByLicenseID(int LicenseID)
        {
            if (repo.DeleteLicenseByLicenseID(LicenseID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByLicenseID(LicenseUpdateDTO UpdatedData)
        {
            return repo.UpdateLicenseByLicenseID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(LicenseAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<LicenseReadDTO> _GetResultFromGetLicensesList(List<Entities.License> Data)
        {
            if (Data == null) return OperationResults<LicenseReadDTO>.FailureDBAError(enResult.rDBAError);
            if (Data.Count == 0) return OperationResults<LicenseReadDTO>.Failure(enResult.rNoData, "No Licenses Data Found.");
            return OperationResults<LicenseReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Licenses Data Retrieved Successfully.");
        }
        #endregion
    }
}
