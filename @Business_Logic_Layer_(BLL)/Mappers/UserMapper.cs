using System.Collections.Generic;
using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;

namespace DVLD.BLL.Mappers
{
    internal static class UserMapper
    {
        public static OperationResults<UserReadDTO> MapToOperationResult(List<User> data)
        {
            if (data == null || data.Count == 0)
            {
                return OperationResults<UserReadDTO>.Failure(ErrorCode.NotFound, "There is no user data found.");
            }

            return OperationResults<UserReadDTO>.Success(MapToReadDTOs(data), "Users retrieved successfully.");
        }

        public static UserReadDTO MapToReadDTO(User entity)
        {
            if (entity == null) return null!;

            return new UserReadDTO
            {
                UserID = entity.UserID,
                PersonID = entity.PersonID,
                UserName = entity.UserName,
                Password = entity.Password,
                IsActive = entity.IsActive
            };
        }

        public static List<UserReadDTO> MapToReadDTOs(List<User> entitiesList)
        {
            var results = new List<UserReadDTO>();
            if (entitiesList == null) return results;

            foreach (var entity in entitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) results.Add(dto);
            }

            return results;
        }

        public static User MapToEntity(UserUpdateDTO dto)
        {
            if (dto == null) return null!;

            return new User
            {
                UserID = dto.UserID,
                PersonID = dto.PersonID,
                UserName = dto.UserName,
                Password = dto.Password,
                IsActive = dto.IsActive
            };
        }

        public static User MapToEntity(UserAddDTO dto)
        {
            if (dto == null) return null!;

            return new User
            {
                PersonID = dto.PersonID,
                UserName = dto.UserName,
                Password = dto.Password,
                IsActive = dto.IsActive
            };
        }
    }
}