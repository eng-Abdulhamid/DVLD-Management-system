using DTOs;
using DVLD_BusinessLogicLayer;
using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using Repositories;
using RepositoriesInterfaces;
namespace Services
{

    public partial class UserServices
    {
        public OperationResult<UserReadDTO> FindUserByUsername(string Username)
        {
            var data = repo.FindUserByUsername(Username);
            if (data == null) return OperationResult<UserReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.UserID <= 0) notFound = true;
            if (notFound) return OperationResult<UserReadDTO>.Failure(ErrorCode.rNotFound, "No User Data Found.");
            return OperationResult<UserReadDTO>.Success(_MapEntityToReadDTO(data), "User Data Retrieved Successfully.");
        }
        public OperationResult<UserReadDTO> FindUserByUsernameAndPassword(string Username, string Password)
        {
            var data = repo.FindUserByUsernameAndPassword(Username, Password);
            if (data == null) return OperationResult<UserReadDTO>.FailureDBAError(ErrorCode.rDBAError);
            // simple not-found check: if primary numeric and <=0 treat as not found else if all default treat not found
            bool notFound = false;
            if (data.UserID <= 0) notFound = true;
            if (notFound) return OperationResult<UserReadDTO>.Failure(ErrorCode.rNotFound, "No User Data Found.");
            return OperationResult<UserReadDTO>.Success(_MapEntityToReadDTO(data), "User Data Retrieved Successfully.");
        }

    }
}
