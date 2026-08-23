using DTOs;
using DVLD.BLL;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class DetainedLicenseServices : IDetainedLicenseServices
    {
        public enum enFields
        {
            None = 0,
            DetainID,
            LicenseID,
            DetainDate,
            FineFees,
            CreatedByUserID,
            IsReleased,
            ReleaseDate,
            ReleasedByUserID,
            ReleaseApplicationID
        }
        #region Properties
        private IDetainedLicenseRepository repo;
        #endregion
        #region Constructors
        public DetainedLicenseServices()
        {
            this.repo = new DetainedLicenseRepository();
        }
        #endregion 
        #region Maps
        private DetainedLicenseReadDTO _MapEntityToReadDTO(Entities.DetainedLicense Entity)
        {
            if (Entity == null) return null;
            return new DetainedLicenseReadDTO()
            {
                DetainID = Entity.DetainID,
                LicenseID = Entity.LicenseID,
                DetainDate = Entity.DetainDate,
                FineFees = Entity.FineFees,
                CreatedByUserID = Entity.CreatedByUserID,
                IsReleased = Entity.IsReleased,
                ReleaseDate = Entity.ReleaseDate,
                ReleasedByUserID = Entity.ReleasedByUserID,
                ReleaseApplicationID = Entity.ReleaseApplicationID,
            };
        }

        private Entities.DetainedLicense _MapAddDTOToEntity(DetainedLicenseAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.DetainedLicense()
            {
                LicenseID = AddDTO.LicenseID,
                DetainDate = AddDTO.DetainDate,
                FineFees = AddDTO.FineFees,
                CreatedByUserID = AddDTO.CreatedByUserID,
                IsReleased = AddDTO.IsReleased,
                ReleaseDate = AddDTO.ReleaseDate,
                ReleasedByUserID = AddDTO.ReleasedByUserID,
                ReleaseApplicationID = AddDTO.ReleaseApplicationID,
            };
        }

        private Entities.DetainedLicense _MapUpdateDTOToEntity(DetainedLicenseUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.DetainedLicense()
            {
                DetainID = UpdateDTO.DetainID,
                LicenseID = UpdateDTO.LicenseID,
                DetainDate = UpdateDTO.DetainDate,
                FineFees = UpdateDTO.FineFees,
                IsReleased = UpdateDTO.IsReleased,
                ReleaseDate = UpdateDTO.ReleaseDate,
                ReleasedByUserID = UpdateDTO.ReleasedByUserID,
                ReleaseApplicationID = UpdateDTO.ReleaseApplicationID,
            };
        }


        private List<DetainedLicenseReadDTO> _MapEntitiesTOReadDTOs(List<Entities.DetainedLicense> EntitiesList)
        {
            List<DetainedLicenseReadDTO> Results = new List<DetainedLicenseReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enDetainedLicenseField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.DetainID:
                    return Repositories.enDetainedLicenseField.DetainID;
                case enFields.LicenseID:
                    return Repositories.enDetainedLicenseField.LicenseID;
                case enFields.DetainDate:
                    return Repositories.enDetainedLicenseField.DetainDate;
                case enFields.FineFees:
                    return Repositories.enDetainedLicenseField.FineFees;
                case enFields.CreatedByUserID:
                    return Repositories.enDetainedLicenseField.CreatedByUserID;
                case enFields.IsReleased:
                    return Repositories.enDetainedLicenseField.IsReleased;
                case enFields.ReleaseDate:
                    return Repositories.enDetainedLicenseField.ReleaseDate;
                case enFields.ReleasedByUserID:
                    return Repositories.enDetainedLicenseField.ReleasedByUserID;
                case enFields.ReleaseApplicationID:
                    return Repositories.enDetainedLicenseField.ReleaseApplicationID;
                default:
                    return Repositories.enDetainedLicenseField.DetainID;
            }
        }

        private DetainedLicenseRepository.DetainedLicensesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new DetainedLicenseRepository.DetainedLicensesSearchCriteria()
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
        public OperationResults<DetainedLicenseReadDTO> GetPeople(SearchCriteria<DetainedLicenseServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetDetainedLicensesList(repo.GetDetainedLicenses(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<DetainedLicenseReadDTO> GetAllPeople()
        {
            return _GetResultFromGetDetainedLicensesList(repo.GetAllDetainedLicenses());
        }
        public int AddNew(DetainedLicenseAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewDetainedLicense(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<DetainedLicenseServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfDetainedLicensesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllDetainedLicenses();
        }
        public OperationResult<DetainedLicenseReadDTO> FindByDetainID(int DetainID)
        {
            var data = repo.FindDetainedLicenseByDetainID(DetainID);
            if (data == null) return OperationResult<DetainedLicenseReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.DetainID <= 0) notFound = true;
            if (notFound) return OperationResult<DetainedLicenseReadDTO>.Failure(ErrorCode.rNotFound, "No DetainedLicense Data Found.");
            return OperationResult<DetainedLicenseReadDTO>.Success(_MapEntityToReadDTO(data), "DetainedLicense Data Retrieved Successfully.");
        }
        public bool DeleteByDetainID(int DetainID)
        {
            if (repo.DeleteDetainedLicenseByDetainID(DetainID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByDetainID(DetainedLicenseUpdateDTO UpdatedData)
        {
            return repo.UpdateDetainedLicenseByDetainID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(DetainedLicenseAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<DetainedLicenseReadDTO> _GetResultFromGetDetainedLicensesList(List<Entities.DetainedLicense> Data)
        {
            if (Data == null) return OperationResults<DetainedLicenseReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<DetainedLicenseReadDTO>.Failure(ErrorCode.rNoData, "No DetainedLicenses Data Found.");
            return OperationResults<DetainedLicenseReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "DetainedLicenses Data Retrieved Successfully.");
        }
        #endregion
    }
}
