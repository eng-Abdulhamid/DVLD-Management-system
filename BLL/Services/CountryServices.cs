using DTOs;
using DVLD_BusinessLogicLayer;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class CountryServices : ICountryServices
    {
        public enum enFields
        {
            None = 0,
            CountryID,
            CountryName
        }
        #region Properties
        private ICountryRepository repo;
        #endregion
        #region Constructors
        public CountryServices()
        {
            this.repo = new CountryRepository();
        }
        #endregion 
        #region Maps
        private CountryReadDTO _MapEntityToReadDTO(Entities.Country Entity)
        {
            if (Entity == null) return null;
            return new CountryReadDTO()
            {
                CountryID = Entity.CountryID,
                CountryName = Entity.CountryName,
            };
        }

        private Entities.Country _MapAddDTOToEntity(CountryAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.Country()
            {
                CountryName = AddDTO.CountryName,
            };
        }

        private Entities.Country _MapUpdateDTOToEntity(CountryUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.Country()
            {
                CountryID = UpdateDTO.CountryID,
                CountryName = UpdateDTO.CountryName,
            };
        }


        private List<CountryReadDTO> _MapEntitiesTOReadDTOs(List<Entities.Country> EntitiesList)
        {
            List<CountryReadDTO> Results = new List<CountryReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enCountryField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.CountryID:
                    return Repositories.enCountryField.CountryID;
                case enFields.CountryName:
                    return Repositories.enCountryField.CountryName;
                default:
                    return Repositories.enCountryField.CountryID;
            }
        }

        private CountryRepository.CountriesSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new CountryRepository.CountriesSearchCriteria()
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
        public OperationResults<CountryReadDTO> GetPeople(SearchCriteria<CountryServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetCountriesList(repo.GetCountries(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<CountryReadDTO> GetAllPeople()
        {
            return _GetResultFromGetCountriesList(repo.GetAllCountries());
        }
        public int AddNew(CountryAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewCountry(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<CountryServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfCountriesByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllCountries();
        }
        public OperationResult<CountryReadDTO> FindByCountryID(int CountryID)
        {
            var data = repo.FindCountryByCountryID(CountryID);
            if (data == null) return OperationResult<CountryReadDTO>.FailureDBAError(enResult.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.CountryID <= 0) notFound = true;
            if (notFound) return OperationResult<CountryReadDTO>.Failure(enResult.rNotFound, "No Country Data Found.");
            return OperationResult<CountryReadDTO>.Success(_MapEntityToReadDTO(data), "Country Data Retrieved Successfully.");
        }
        public bool DeleteByCountryID(int CountryID)
        {
            if (repo.DeleteCountryByCountryID(CountryID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByCountryID(CountryUpdateDTO UpdatedData)
        {
            return repo.UpdateCountryByCountryID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(CountryAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<CountryReadDTO> _GetResultFromGetCountriesList(List<Entities.Country> Data)
        {
            if (Data == null) return OperationResults<CountryReadDTO>.FailureDBAError(enResult.rDBAError);
            if (Data.Count == 0) return OperationResults<CountryReadDTO>.Failure(enResult.rNoData, "No Countries Data Found.");
            return OperationResults<CountryReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Countries Data Retrieved Successfully.");
        }
        #endregion
    }
}
