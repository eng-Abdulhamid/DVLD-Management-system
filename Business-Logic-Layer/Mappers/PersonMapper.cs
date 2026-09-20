using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.DAL.Entities;
using DVLD.DAL.Enums;
namespace DVLD.BLL.Mappers
{
    internal static class PersonMapper
    {
        public static OperationResults<PersonReadDTO> MapToOperationResult(List<DVLD.DAL.Entities.Person> data)
        {
            if (data.Count == 0) return OperationResults<PersonReadDTO>.Failure(ErrorCode.NotFound, "There is no people data found.");
            return OperationResults<PersonReadDTO>.Success(MapToReadDTOs(data), "People Data Retrieved Successfully.");
        }
        public static PersonReadDTO MapToReadDTO(Person Entity)
        {
            //if (Entity == null) return null;
            return new PersonReadDTO
                (
                Entity.PersonID,
                Entity.NationalNo,
                Entity.FirstName,
                Entity.SecondName,
                Entity.ThirdName,
                Entity.LastName,
                Entity.Age,
                Entity.DateOfBirth,
                (Enums.Gendor)Entity.Gendor,
                Entity.Address,
                Entity.Phone,
                Entity.Email,
                Entity.NationalityCountryID,
                Entity.ImagePath,
                Entity.CountryName,
                Entity.FullName
                );
        }
        public static List<PersonReadDTO> MapToReadDTOs(List<DVLD.DAL.Entities.Person> EntitiesList)
        {
            var Results = new List<PersonReadDTO>();
            if (EntitiesList == null) return Results;
            foreach (var entity in EntitiesList)
            {
                var dto = MapToReadDTO(entity);
                if (dto != null) Results.Add(dto);
            }
            return Results;
        }

        public static Person MapToEntity(PersonUpdateDTO dto)
        {
            //if (dto == null) return null;
            return new Person()
            {
                PersonID = dto.PersonID,
                NationalNo = dto.NationalNo,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                ThirdName = dto.ThirdName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                NationalityCountryID = dto.NationalityCountryID,
                ImagePath = dto.ImagePath,
                Gendor = (DVLD.DAL.Enums.Gendor)dto.Gendor
            };
        }
        public static Person MapToEntity(PersonAddDTO dto)
        {
            //if (dto == null) return null;
            return new Person()
            {
                NationalNo = dto.NationalNo,
                FirstName = dto.FirstName,
                SecondName = dto.SecondName,
                ThirdName = dto.ThirdName,
                LastName = dto.LastName,
                DateOfBirth = dto.DateOfBirth,
                Address = dto.Address,
                Phone = dto.Phone,
                Email = dto.Email,
                NationalityCountryID = dto.NationalityCountryID,
                ImagePath = dto.ImagePath,
                Gendor = (DVLD.DAL.Enums.Gendor)dto.Gendor
            };
        }
    }
}
