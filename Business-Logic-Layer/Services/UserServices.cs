using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
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

        public async Task<bool> IsPersonLinkedToUserAsync(int personId)
        {
            return await _userRepo.IsPersonLinkedToUserAsync(personId);
        }
        public async Task<bool> IsUsernameAvailableAsync(string username, int? currentUserId = null)
        {
            if (string.IsNullOrWhiteSpace(username)) return false;

            if (currentUserId.HasValue && currentUserId.Value > 0)
            {
                return !await _userRepo.IsUsernameExistForOtherUserAsync(username.Trim(), currentUserId.Value);
            }

            return !await _userRepo.IsUsernameExistAsync(username.Trim());
        }
        public async Task<OperationResult<bool>> IsUsernameAvailableForUserAsync(string username, int userId)
        {
            if (string.IsNullOrWhiteSpace(username)) return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Username cannot be null or empty.");
            bool isAvailable = !await _userRepo.IsUsernameExistForOtherUserAsync(username.Trim(), userId);
            return OperationResult<bool>.Success(isAvailable, isAvailable ? "Username is available." : "Username is already taken by another user.");
        }
        public async Task<OperationResult<int>> AddAsync(UserAddDTO dto)
        {
            var validationResults = await CheckFieldsBeforeAdd(dto);
            if (!validationResults.IsSuccess)
                return validationResults;
            
            dto.Password = ComputeHash(dto.Password);
            
            int addResult = await _userRepo.AddAsync(MapToEntity(dto));

            if (addResult > 0)
            {
                return OperationResult<int>.Success(addResult, "User added successfully.");
            }

            return OperationResult<int>.Failure(ErrorCode.Conflict, "Failed to add user.");
        }
        private async Task<OperationResult<int>> CheckFieldsBeforeAdd(UserAddDTO dto)
        {
            if (dto == null)
                return OperationResult<int>.Failure(ErrorCode.ValidationError, "User data cannot be null.");
            if (!string.IsNullOrEmpty(dto.Password))
                return OperationResult<int>.Failure(ErrorCode.BadRequest, "New password cannot be null or empty.");

            if (!IsPasswordValid(dto.Password))
                return OperationResult<int>.Failure(ErrorCode.ValidationError, "New password does not meet requirment.");
            if (await _userRepo.IsPersonLinkedToUserAsync(dto.PersonID))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "This person is already linked to another user.");
            }
            if (await _userRepo.IsUsernameExistAsync(dto.UserName))
            {
                return OperationResult<int>.Failure(ErrorCode.Conflict, "Username already exists.");
            }
            return OperationResult<int>.Success(-1);
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
            UserDeletionResult deletionResult = await _userRepo.DeleteAsync(id);

            if (deletionResult == UserDeletionResult.Successful)
            {
                return OperationResult<bool>.Success(true, "User deleted successfully.");
            }

            if (deletionResult == UserDeletionResult.NotFound)
            {
                return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");
            }

            return OperationResult<bool>.Failure(ErrorCode.Conflict, SelectErrorMessage(deletionResult));
        }
        private string SelectErrorMessage(UserDeletionResult deletionResult)
        {
            return deletionResult switch
            {
                UserDeletionResult.HasApplications => "Cannot delete this user because they created application records.",
                UserDeletionResult.HasTestAppointments => "Cannot delete this user because they scheduled test appointments.",
                UserDeletionResult.HasTests => "Cannot delete this user because they conducted test records.",
                UserDeletionResult.HasLicenses => "Cannot delete this user because they issued driver licenses.",
                UserDeletionResult.HasDrivers => "Cannot delete this user because they created driver profiles.",
                UserDeletionResult.HasDetainedLicenses => "Cannot delete this user because they handled detained license records.",
                _ => "An unexpected error occurred while deleting the user."
            };

        }
        private async Task<OperationResult<bool>> ChangePasswordAsync(User user, string currentPassword, string newPassword)
        {
            if (user.Password != ComputeHash(currentPassword))
            {
                return OperationResult<bool>.Failure(ErrorCode.ValidationError, "Last password is incorrect.");
            }
            if (!IsPasswordValid(newPassword))
            {
                return OperationResult<bool>.Failure(ErrorCode.ValidationError, "New password does not meet the requirment.");
            }

            string hashedNewPassword = ComputeHash(newPassword);
            bool isUpdated = await _userRepo.ChangePasswordAsync(user.UserID, hashedNewPassword);

            if (!isUpdated)
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Failed to update password.");
            }

            return OperationResult<bool>.Success(true, "Password updated successfully.");
        }
        private static bool IsSpecialCharacter(char character)
        {
            return char.IsPunctuation(character) ||
                   char.IsSymbol(character);
        }
        private bool IsPasswordValid(string password)
        {
            if (!password.Any(char.IsUpper) ||
                !password.Any(char.IsLower) ||
                !password.Any(char.IsNumber) ||
                !password.Any(IsSpecialCharacter))
                return false;

            if (password.Length < 8 || password.Length > 128)
                return false;

            return true;
        }
        public async Task<OperationResult<bool>> ChangePasswordAsync(string userName, string currentPassword, string newPassword)
        {
            var user = await _userRepo.FindByUsernameAsync(userName);
            if (user == null) return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");

            return await ChangePasswordAsync(user, currentPassword, newPassword);
        }

        public async Task<OperationResult<bool>> ChangePasswordAsync(int userId, string currentPassword, string newPassword)
        {
            var user = await _userRepo.FindAsync(userId);
            if (user == null) return OperationResult<bool>.Failure(ErrorCode.NotFound, "User not found.");

            return await ChangePasswordAsync(user, currentPassword, newPassword);
        }
        public async Task<OperationResult<bool>> UpdateAsync(UserUpdateDTO dto)
        {
            if (dto == null)
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "User data cannot be null.");

            if (dto.UserID <= 0)
                return OperationResult<bool>.Failure(ErrorCode.BadRequest, "Invalid user ID.");

            if (await _userRepo.IsUsernameExistForOtherUserAsync(dto.UserName, dto.UserID))
            {
                return OperationResult<bool>.Failure(ErrorCode.Conflict, "Username already exists for another user.");
            }

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