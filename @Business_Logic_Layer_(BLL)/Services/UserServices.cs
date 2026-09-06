using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Interfaces.IRepositories;
using DVLD.DAL.Repo.ADONet;
using System;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static DVLD.BLL.Mappers.UserMapper;

namespace DVLD.BLL.Services
{
    public class UserService
    {
        static string ComputeHash(string input)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(input));
                return BitConverter.ToString(hashBytes).Replace("-", "").ToLower();
            }
        }

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

            if (!string.IsNullOrEmpty(dto.Password))
                 // Hash the password before adding
                 dto.Password = ComputeHash(dto.Password);
            
            else
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "New password cannot be null or empty.");
            

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
        public async Task<OperationResult<UserReadDTO>> GetByUserNameAsync(string username)
        {
            var data = await _userRepo.FindByUsernameAsync(username);
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
        private async Task<OperationResult<bool>> ProcessPasswordChangeAsync(User user, string currentPassword, string newPassword)
        {
            if (user.Password != ComputeHash(currentPassword))
            {
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Last password is incorrect.");
            }

            string hashedNewPassword = ComputeHash(newPassword);
            bool isUpdated = await _userRepo.ChangePasswordAsync(user.UserID, hashedNewPassword);

            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update password.");
            }

            return OperationResult<bool>.Success(true, "Password updated successfully.");
        }

        public async Task<OperationResult<bool>> ChangePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            var user = await _userRepo.FindByUsernameAsync(userName);
            if (user == null) return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");

            return await ProcessPasswordChangeAsync(user, currentPassword, newPassword);
        }

        public async Task<OperationResult<bool>> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepo.FindAsync(userId);
            if (user == null) return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");

            return await ProcessPasswordChangeAsync(user, currentPassword, newPassword);
        }
        public async Task<OperationResult<bool>> UpdateAsync(UserUpdateDTO dto)
        {
            if (dto == null)
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "User data cannot be null.");

            if (dto.UserID <= 0)
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Invalid user ID.");

            bool isUpdated = await _userRepo.UpdateAsync(MapToEntity(dto));

            if (!isUpdated)
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update user.");

            return OperationResult<bool>.Success(true, "User updated successfully.");
        }
        public async Task<OperationResult<bool>> AuthenticateUserAsync(string username, string password)
        {
            var user = await _userRepo.FindByUsernameAsync(username);

            if (user == null)
            {
                return OperationResult<bool>.Failure(ErrorCode.Unauthorized, "Invalid username or password.");
            }

            if (!user.IsActive)
            {
                return OperationResult<bool>.Failure(ErrorCode.Unauthorized, "Invalid username or password.");
            }

            password = ComputeHash(password);

            if (user.Password != password)
            {
                return OperationResult<bool>.Failure(ErrorCode.Unauthorized, "Invalid username or password.");
            }

            return OperationResult<bool>.Success(true, "Login credentials are valid.");
        }
        #endregion
    }
}