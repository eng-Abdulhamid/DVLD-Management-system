using System;
using System.Threading.Tasks;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using static DVLD.BLL.Mappers.UserMapper;

namespace DVLD.BLL.Services
{
    public class UserService
    {
        #region Constructors

        private readonly IUserRepository _userRepo;

        public UserService()
        {
            _userRepo = new UserRepositoryADO();
        }

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        #endregion

        #region CRUD Methods

        public async Task<OperationResults<UserReadDTO>> GetAllAsync()
        {
            return MapToOperationResult(await _userRepo.GetAllAsync());
        }

        public async Task<bool> ExistsAsync(int id)
        {
            return await _userRepo.ExistsAsync(id);
        }

        public async Task<OperationResult<int>> AddAsync(UserAddDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "User data cannot be null.");
            }

            int addResult = await _userRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "User added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add user.");
        }

        public async Task<int> GetCountAsync()
        {
            return await _userRepo.CountAsync();
        }

        public async Task<OperationResult<UserReadDTO>> GetByIdAsync(int userId)
        {
            var data = await _userRepo.FindAsync(userId);
            if (data == null || data.UserID <= 0)
            {
                return OperationResult<UserReadDTO>.Failure(ErrorCode.NotFound, "No user data found.");
            }

            return OperationResult<UserReadDTO>.Success(MapToReadDTO(data), "User data retrieved successfully.");
        }

        public async Task<OperationResult<bool>> DeleteAsync(int id)
        {
            if (!await _userRepo.ExistsAsync(id))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");
            }

            bool isDeleted = await _userRepo.DeleteAsync(id);
            if (!isDeleted)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Cannot delete user because they are referenced by other system records.");
            }

            return OperationResult<bool>.Success(true, "User deleted successfully.");
        }

        public async Task<OperationResult<bool>> UpdateAsync(UserUpdateDTO dto)
        {
            if (dto == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "User data cannot be null.");
            }

            if (!await _userRepo.ExistsAsync(dto.UserID))
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, $"User with ID {dto.UserID} is not found.");
            }

            bool isUpdated = await _userRepo.UpdateAsync(MapToEntity(dto));
            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update user.");
            }

            return OperationResult<bool>.Success(true, "User updated successfully.");
        }

        #endregion
    }
}