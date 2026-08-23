using DTOs;
using DVLD.BLL;
using Entities;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class LicenseClassServices : ILicenseClassServices
    {
        public enum enFields
        {
            None = 0,
            LicenseClassID,
            ClassName,
            ClassDescription,
            MinimumAllowedAge,
            DefaultValidityLength,
            ClassFees
        }
        #region Properties
        private ILicenseClassRepository repo;
        #endregion
        #region Constructors
        public LicenseClassServices()
        {
            this.repo = new LicenseClassRepository();
        }
        #endregion 
        #region Maps
        private LicenseClassReadDTO _MapEntityToReadDTO(Entities.LicenseClass Entity)
        {
            if (Entity == null) return null;
            return new LicenseClassReadDTO()
            {
                LicenseClassID = Entity.LicenseClassID,
                ClassName = Entity.ClassName,
                ClassDescription = Entity.ClassDescription,
                MinimumAllowedAge = Entity.MinimumAllowedAge,
                DefaultValidityLength = Entity.DefaultValidityLength,
                ClassFees = Entity.ClassFees,
            };
        }

        private Entities.LicenseClass _MapAddDTOToEntity(LicenseClassAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.LicenseClass()
            {
                ClassName = AddDTO.ClassName,
                ClassDescription = AddDTO.ClassDescription,
                MinimumAllowedAge = AddDTO.MinimumAllowedAge,
                DefaultValidityLength = AddDTO.DefaultValidityLength,
                ClassFees = AddDTO.ClassFees,
            };
        }

        private Entities.LicenseClass _MapUpdateDTOToEntity(LicenseClassUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.LicenseClass()
            {
                LicenseClassID = UpdateDTO.LicenseClassID,
                ClassName = UpdateDTO.ClassName,
                ClassDescription = UpdateDTO.ClassDescription,
                MinimumAllowedAge = UpdateDTO.MinimumAllowedAge,
                DefaultValidityLength = UpdateDTO.DefaultValidityLength,
                ClassFees = UpdateDTO.ClassFees,
            };
        }


        private List<LicenseClassReadDTO> _MapEntitiesTOReadDTOs(List<Entities.LicenseClass> EntitiesList)
        {
            List<LicenseClassReadDTO> Results = new List<LicenseClassReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enLicenseClassField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.LicenseClassID:
                    return Repositories.enLicenseClassField.LicenseClassID;
                case enFields.ClassName:
                    return Repositories.enLicenseClassField.ClassName;
                case enFields.ClassDescription:
                    return Repositories.enLicenseClassField.ClassDescription;
                case enFields.MinimumAllowedAge:
                    return Repositories.enLicenseClassField.MinimumAllowedAge;
                case enFields.DefaultValidityLength:
                    return Repositories.enLicenseClassField.DefaultValidityLength;
                case enFields.ClassFees:
                    return Repositories.enLicenseClassField.ClassFees;
                default:
                    return Repositories.enLicenseClassField.LicenseClassID;
            }
        }

        private LicenseClassRepository.LicenseClassesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new LicenseClassRepository.LicenseClassesSearchCriteria()
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
        public OperationResults<LicenseClassReadDTO> GetPeople(SearchCriteria<LicenseClassServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetLicenseClassesList(repo.GetLicenseClasses(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<LicenseClassReadDTO> GetAllPeople()
        {
            return _GetResultFromGetLicenseClassesList(repo.GetAllLicenseClasses());
        }
        public int AddNew(LicenseClassAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewLicenseClass(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<LicenseClassServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfLicenseClassesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllLicenseClasses();
        }
        public OperationResult<LicenseClassReadDTO> FindByLicenseClassID(int LicenseClassID)
        {
            var data = repo.FindLicenseClassByLicenseClassID(LicenseClassID);
            if (data == null) return OperationResult<LicenseClassReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.LicenseClassID <= 0) notFound = true;
            if (notFound) return OperationResult<LicenseClassReadDTO>.Failure(ErrorCode.rNotFound, "No LicenseClass Data Found.");
            return OperationResult<LicenseClassReadDTO>.Success(_MapEntityToReadDTO(data), "LicenseClass Data Retrieved Successfully.");
        }
        public bool DeleteByLicenseClassID(int LicenseClassID)
        {
            if (repo.DeleteLicenseClassByLicenseClassID(LicenseClassID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByLicenseClassID(LicenseClassUpdateDTO UpdatedData)
        {
            return repo.UpdateLicenseClassByLicenseClassID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(LicenseClassAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<LicenseClassReadDTO> _GetResultFromGetLicenseClassesList(List<Entities.LicenseClass> Data)
        {
            if (Data == null) return OperationResults<LicenseClassReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<LicenseClassReadDTO>.Failure(ErrorCode.rNoData, "No LicenseClasses Data Found.");
            return OperationResults<LicenseClassReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "LicenseClasses Data Retrieved Successfully.");
        }
        #endregion
    }
}
