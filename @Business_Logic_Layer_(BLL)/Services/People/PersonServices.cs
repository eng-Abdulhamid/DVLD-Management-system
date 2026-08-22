using DVLD_BusinessLogicLayer;

using System;
using System.Collections.Generic;
namespace Services
{

    public class PersonServices
    {
        public enum enFields
        {
            None = 0,
            PersonID,
            NationalNo,
            FirstName,
            SecondName,
            ThirdName,
            LastName,
            DateOfBirth,
            Address,
            Phone,
            Email,
            NationalityCountryID,
            ImagePath,
            Gender,
            CountryName
        }
        #region Properties
        private PersonRepository repo;
        #endregion
        #region Constructors
        public PersonServices()
        {
            this.repo = new PersonRepository();
        }
        #endregion

        #region CRUD METHODS 
        public OperationResults<PersonReadDTO> GetPeople(SearchCriteria<PersonServices.enFields> SearchCriteria = null)
        {
            return _GetResultFromGetPeopleList(repo.GetAll(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public bool IsPersonIDExists(int PersonID)
        {
            return repo.Exists(PersonID);
        }
        public int AddNew(PersonAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.Add(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<PersonServices.enFields> SearchCriteria = null)
        {
            return repo.Count(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public OperationResult<PersonReadDTO> FindByPersonID(int PersonID)
        {
            var data = repo.Find(PersonID);
            if (data == null) return OperationResult<PersonReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.PersonID <= 0) notFound = true;
            if (notFound) return OperationResult<PersonReadDTO>.Failure(ErrorCode.rNotFound, "No Person Data Found.");
            return OperationResult<PersonReadDTO>.Success(_MapEntityToReadDTO(data), "Person Data Retrieved Successfully.");
        }
        public bool DeleteByPersonID(int PersonID)
        {
            if (repo.Delete(PersonID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByPersonID(PersonUpdateDTO UpdatedData)
        {
            return repo.Update(_MapUpdateDTOToEntity(UpdatedData));
        }
        public OperationResult<PersonReadDTO> FindByNationalNo(string NationalNo)
        {
            var data = repo.FindByNationalNo(NationalNo);
            if (data == null) return OperationResult<PersonReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (notFound) return OperationResult<PersonReadDTO>.Failure(ErrorCode.rNotFound, "No Person Data Found.");
            return OperationResult<PersonReadDTO>.Success(_MapEntityToReadDTO(data), "Person Data Retrieved Successfully.");
        }
        public bool DeleteByNationalNo(string NationalNo)
        {
            if (repo.DeleteByNationalNo(NationalNo))
            {
                return true;
            }
            else
                return false;
        }
        public bool IsNationalNoExists(string NationalNo)
        {
            return repo.ExistsByNationalNo(NationalNo);
        }
        public bool UpdateByNationalNo(PersonUpdateDTO UpdatedData)
        {
            return repo.UpdateByNationalNo(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(PersonAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<PersonReadDTO> _GetResultFromGetPeopleList(List<Entities.Person> Data)
        {
            if (Data == null) return OperationResults<PersonReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<PersonReadDTO>.Failure(ErrorCode.rNoData, "No People Data Found.");
            return OperationResults<PersonReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "People Data Retrieved Successfully.");
        }
        #endregion
        private int CalculateAge(DateTime dateOfBirth)
        {
            var today = DateTime.Today;
            var age = today.Year - dateOfBirth.Year;
            if (dateOfBirth.Date > today.AddYears(-age)) age--;
            return age;
        }
        #region Maps

        private PersonReadDTO _MapEntityToReadDTO(Entities.Person Entity)
        {
            if (Entity == null) return null;
            return new PersonReadDTO()
            {
                PersonID = Entity.PersonID,
                NationalNo = Entity.NationalNo,
                FirstName = Entity.FirstName,
                SecondName = Entity.SecondName,
                ThirdName = Entity.ThirdName,
                LastName = Entity.LastName,
                Age = CalculateAge(Entity.DateOfBirth),
                Address = Entity.Address,
                Phone = Entity.Phone,
                DateOfBirth = Entity.DateOfBirth,
                Email = Entity.Email,
                NationalityCountryID = Entity.NationalityCountryID,
                ImagePath = Entity.ImagePath,
                Gender = (Entity.Gender == Repositories.enGender.Male) ? enGender.Male : enGender.Female,
                CountryName = Entity.CountryName
            };
        }

        private Entities.Person _MapAddDTOToEntity(PersonAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.Person()
            {
                NationalNo = AddDTO.NationalNo,
                FirstName = AddDTO.FirstName,
                SecondName = AddDTO.SecondName,
                ThirdName = AddDTO.ThirdName,
                LastName = AddDTO.LastName,
                DateOfBirth = AddDTO.DateOfBirth,
                Address = AddDTO.Address,
                Phone = AddDTO.Phone,
                Email = AddDTO.Email,
                NationalityCountryID = AddDTO.NationalityCountryID,
                ImagePath = AddDTO.ImagePath,
                Gender = (AddDTO.Gender == enGender.Male) ? Repositories.enGender.Male : Repositories.enGender.Female
                ,
                CountryName = AddDTO.CountryName
            };
        }

        private Entities.Person _MapUpdateDTOToEntity(PersonUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.Person()
            {
                PersonID = UpdateDTO.PersonID,
                NationalNo = UpdateDTO.NationalNo,
                FirstName = UpdateDTO.FirstName,
                SecondName = UpdateDTO.SecondName,
                ThirdName = UpdateDTO.ThirdName,
                LastName = UpdateDTO.LastName,
                DateOfBirth = UpdateDTO.DateOfBirth,
                Address = UpdateDTO.Address,
                Phone = UpdateDTO.Phone,
                Email = UpdateDTO.Email,
                NationalityCountryID = UpdateDTO.NationalityCountryID,
                ImagePath = UpdateDTO.ImagePath,
                Gender = (UpdateDTO.Gender == enGender.Male) ? Repositories.enGender.Male : Repositories.enGender.Female
                ,
                CountryName = UpdateDTO.CountryName
            };
        }


        private List<PersonReadDTO> _MapEntitiesTOReadDTOs(List<Entities.Person> EntitiesList)
        {
            List<PersonReadDTO> Results = new List<PersonReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enPersonField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.PersonID:
                    return Repositories.enPersonField.PersonID;
                case enFields.NationalNo:
                    return Repositories.enPersonField.NationalNo;
                case enFields.FirstName:
                    return Repositories.enPersonField.FirstName;
                case enFields.SecondName:
                    return Repositories.enPersonField.SecondName;
                case enFields.ThirdName:
                    return Repositories.enPersonField.ThirdName;
                case enFields.LastName:
                    return Repositories.enPersonField.LastName;
                case enFields.DateOfBirth:
                    return Repositories.enPersonField.DateOfBirth;
                case enFields.Address:
                    return Repositories.enPersonField.Address;
                case enFields.Phone:
                    return Repositories.enPersonField.Phone;
                case enFields.Email:
                    return Repositories.enPersonField.Email;
                case enFields.NationalityCountryID:
                    return Repositories.enPersonField.NationalityCountryID;
                case enFields.ImagePath:
                    return Repositories.enPersonField.ImagePath;
                case enFields.Gender:
                    return Repositories.enPersonField.Gender;
                case enFields.CountryName:
                    return Repositories.enPersonField.NationalityCountryName;
                default:
                    return Repositories.enPersonField.PersonID;
            }
        }

        private PersonRepository.PeopleSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new PersonRepository.PeopleSearchCriteria()
            {
                Gender = (Repositories.enGender)SearchCriteria.GenderFilter,
                FilterBy = _MapToRepoFieldEmum(SearchCriteria.FilterBy),
                SearchText = SearchCriteria.SearchString,
                SearchType = (Repositories.enSearchType)SearchCriteria.SearchType
            };
        }
        #endregion

    }
}
