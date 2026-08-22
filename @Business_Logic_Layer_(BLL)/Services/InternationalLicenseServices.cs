using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class InternationalLicenseServices : IInternationalLicenseServices
    {
        public enum enFields
        {
            None = 0,
            InternationalLicenseID,
            ApplicationID,
            DriverID,
            IssuedUsingLocalLicenseID,
            IssueDate,
            ExpirationDate,
            IsActive,
            CreatedByUserID
        }
        #region Properties
        private IInternationalLicenseRepository repo;
        #endregion
        #region Constructors
        public InternationalLicenseServices()
        {
            this.repo = new InternationalLicenseRepository();
        }
        #endregion 
        #region Maps
        private InternationalLicenseReadDTO _MapEntityToReadDTO(Entities.InternationalLicense Entity)
        {
            if (Entity == null) return null;
            return new InternationalLicenseReadDTO()
            {
                InternationalLicenseID = Entity.InternationalLicenseID,
                ApplicationID = Entity.ApplicationID,
                DriverID = Entity.DriverID,
                IssuedUsingLocalLicenseID = Entity.IssuedUsingLocalLicenseID,
                IssueDate = Entity.IssueDate,
                ExpirationDate = Entity.ExpirationDate,
                IsActive = Entity.IsActive,
                CreatedByUserID = Entity.CreatedByUserID,
            };
        }

        private Entities.InternationalLicense _MapAddDTOToEntity(InternationalLicenseAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.InternationalLicense()
            {
                ApplicationID = AddDTO.ApplicationID,
                DriverID = AddDTO.DriverID,
                IssuedUsingLocalLicenseID = AddDTO.IssuedUsingLocalLicenseID,
                IssueDate = AddDTO.IssueDate,
                ExpirationDate = AddDTO.ExpirationDate,
                IsActive = AddDTO.IsActive,
                CreatedByUserID = AddDTO.CreatedByUserID,
            };
        }

        private Entities.InternationalLicense _MapUpdateDTOToEntity(InternationalLicenseUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.InternationalLicense()
            {
                InternationalLicenseID = UpdateDTO.InternationalLicenseID,
                ApplicationID = UpdateDTO.ApplicationID,
                DriverID = UpdateDTO.DriverID,
                IssuedUsingLocalLicenseID = UpdateDTO.IssuedUsingLocalLicenseID,
                IssueDate = UpdateDTO.IssueDate,
                ExpirationDate = UpdateDTO.ExpirationDate,
                IsActive = UpdateDTO.IsActive
            };
        }


        private List<InternationalLicenseReadDTO> _MapEntitiesTOReadDTOs(List<Entities.InternationalLicense> EntitiesList)
        {
            List<InternationalLicenseReadDTO> Results = new List<InternationalLicenseReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enInternationalLicenseField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.InternationalLicenseID:
                    return Repositories.enInternationalLicenseField.InternationalLicenseID;
                case enFields.ApplicationID:
                    return Repositories.enInternationalLicenseField.ApplicationID;
                case enFields.DriverID:
                    return Repositories.enInternationalLicenseField.DriverID;
                case enFields.IssuedUsingLocalLicenseID:
                    return Repositories.enInternationalLicenseField.IssuedUsingLocalLicenseID;
                case enFields.IssueDate:
                    return Repositories.enInternationalLicenseField.IssueDate;
                case enFields.ExpirationDate:
                    return Repositories.enInternationalLicenseField.ExpirationDate;
                case enFields.IsActive:
                    return Repositories.enInternationalLicenseField.IsActive;
                case enFields.CreatedByUserID:
                    return Repositories.enInternationalLicenseField.CreatedByUserID;
                default:
                    return Repositories.enInternationalLicenseField.InternationalLicenseID;
            }
        }

        private InternationalLicenseRepository.InternationalLicensesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new InternationalLicenseRepository.InternationalLicensesSearchCriteria()
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
        public OperationResults<InternationalLicenseReadDTO> GetPeople(SearchCriteria<InternationalLicenseServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetInternationalLicensesList(repo.GetInternationalLicenses(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<InternationalLicenseReadDTO> GetAllPeople()
        {
            return _GetResultFromGetInternationalLicensesList(repo.GetAllInternationalLicenses());
        }
        public int AddNew(InternationalLicenseAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewInternationalLicense(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<InternationalLicenseServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfInternationalLicensesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllInternationalLicenses();
        }
        public OperationResult<InternationalLicenseReadDTO> FindByInternationalLicenseID(int InternationalLicenseID)
        {
            var data = repo.FindInternationalLicenseByInternationalLicenseID(InternationalLicenseID);
            if (data == null) return OperationResult<InternationalLicenseReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.InternationalLicenseID <= 0) notFound = true;
            if (notFound) return OperationResult<InternationalLicenseReadDTO>.Failure(ErrorCode.rNotFound, "No InternationalLicense Data Found.");
            return OperationResult<InternationalLicenseReadDTO>.Success(_MapEntityToReadDTO(data), "InternationalLicense Data Retrieved Successfully.");
        }
        public bool DeleteByInternationalLicenseID(int InternationalLicenseID)
        {
            if (repo.DeleteInternationalLicenseByInternationalLicenseID(InternationalLicenseID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByInternationalLicenseID(InternationalLicenseUpdateDTO UpdatedData)
        {
            return repo.UpdateInternationalLicenseByInternationalLicenseID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(InternationalLicenseAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<InternationalLicenseReadDTO> _GetResultFromGetInternationalLicensesList(List<Entities.InternationalLicense> Data)
        {
            if (Data == null) return OperationResults<InternationalLicenseReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<InternationalLicenseReadDTO>.Failure(ErrorCode.rNoData, "No InternationalLicenses Data Found.");
            return OperationResults<InternationalLicenseReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "InternationalLicenses Data Retrieved Successfully.");
        }
        #endregion
    }
}
