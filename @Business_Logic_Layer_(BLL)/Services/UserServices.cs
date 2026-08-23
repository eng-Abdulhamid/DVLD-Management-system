using DTOs;
using DVLD.BLL;
using Repositories;
using RepositoriesInterfaces;
using System.Collections.Generic;
namespace Services
{

    public partial class UserServices : IUserServices
    {
        public enum enFields
        {
            None = 0,
            UserID,
            PersonID,
            UserName,
            Password,
            IsActive
        }
        #region Properties
        private IUserRepository repo;
        #endregion
        #region Constructors
        public UserServices()
        {
            this.repo = new UserRepository();
        }
        #endregion 
        #region Maps
        private UserReadDTO _MapEntityToReadDTO(Entities.User Entity)
        {
            if (Entity == null) return null;
            return new UserReadDTO()
            {
                UserID = Entity.UserID,
                PersonID = Entity.PersonID,
                UserName = Entity.UserName,
                Password = Entity.Password,
                IsActive = Entity.IsActive,
            };
        }

        private Entities.User _MapAddDTOToEntity(UserAddDTO AddDTO)
        {
            if (AddDTO == null) return null;
            return new Entities.User()
            {
                PersonID = AddDTO.PersonID,
                UserName = AddDTO.UserName,
                Password = AddDTO.Password,
                IsActive = AddDTO.IsActive,
            };
        }

        private Entities.User _MapUpdateDTOToEntity(UserUpdateDTO UpdateDTO)
        {
            if (UpdateDTO == null) return null;
            return new Entities.User()
            {
                UserID = UpdateDTO.UserID,
                PersonID = UpdateDTO.PersonID,
                UserName = UpdateDTO.UserName,
                Password = UpdateDTO.Password,
                IsActive = UpdateDTO.IsActive,
            };
        }


        private List<UserReadDTO> _MapEntitiesTOReadDTOs(List<Entities.User> EntitiesList)
        {
            List<UserReadDTO> Results = new List<UserReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = _MapEntityToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }
        private Repositories.enUserField _MapToRepoFieldEmum(enFields Field)
        {
            switch (Field)
            {
                case enFields.UserID:
                    return Repositories.enUserField.UserID;
                case enFields.PersonID:
                    return Repositories.enUserField.PersonID;
                case enFields.UserName:
                    return Repositories.enUserField.UserName;
                case enFields.Password:
                    return Repositories.enUserField.Password;
                case enFields.IsActive:
                    return Repositories.enUserField.IsActive;
                default:
                    return Repositories.enUserField.UserID;
            }
        }

        private UserRepository.UsersSearchCriteria _MapToRepoSearchCriteria(SearchCriteria<enFields> SearchCriteria)
        {
            if (SearchCriteria == null) return null;
            return new UserRepository.UsersSearchCriteria()
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
        public OperationResults<UserReadDTO> GetPeople(SearchCriteria<UserServices.enFields> SearchCriteria)
        {
            return _GetResultFromGetUsersList(repo.GetUsers(_MapToRepoSearchCriteria(SearchCriteria)));
        }
        public OperationResults<UserReadDTO> GetAllPeople()
        {
            return _GetResultFromGetUsersList(repo.GetAllUsers());
        }
        public int AddNew(UserAddDTO AddDTO)
        {
            if (!_ValidationBeforeAddNew(AddDTO)) return -1;
            int AddResult = repo.AddNewUser(_MapAddDTOToEntity(AddDTO));
            if (AddResult > 0)
            {
                return AddResult;
            }
            return AddResult;
        }
        public int PeopleCount(SearchCriteria<UserServices.enFields> SearchCriteria)
        {
            return repo.GetCountOfUsersByFilter(_MapToRepoSearchCriteria(SearchCriteria));
        }
        public int GetCountOfAllWithoutFilter()
        {
            return repo.GetCountOfAllUsers();
        }
        public OperationResult<UserReadDTO> FindByUserID(int UserID)
        {
            var data = repo.FindUserByUserID(UserID);
            if (data == null) return OperationResult<UserReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.UserID <= 0) notFound = true;
            if (notFound) return OperationResult<UserReadDTO>.Failure(ErrorCode.rNotFound, "No User Data Found.");
            return OperationResult<UserReadDTO>.Success(_MapEntityToReadDTO(data), "User Data Retrieved Successfully.");
        }
        public bool DeleteByUserID(int UserID)
        {
            if (repo.DeleteUserByUserID(UserID))
            {
                return true;
            }
            else
                return false;
        }
        public bool UpdateByUserID(UserUpdateDTO UpdatedData)
        {
            return repo.UpdateUserByUserID(_MapUpdateDTOToEntity(UpdatedData));
        }
        #endregion
        #region Validations
        private bool _ValidationBeforeAddNew(UserAddDTO AddDTO)
        {
            // Verification code (customize as needed)
            return true;
        }
        #endregion
        #region Private Methods
        private OperationResults<UserReadDTO> _GetResultFromGetUsersList(List<Entities.User> Data)
        {
            if (Data == null) return OperationResults<UserReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            if (Data.Count == 0) return OperationResults<UserReadDTO>.Failure(ErrorCode.rNoData, "No Users Data Found.");
            return OperationResults<UserReadDTO>.Success(_MapEntitiesTOReadDTOs(Data), "Users Data Retrieved Successfully.");
        }
        #endregion
    }
}
