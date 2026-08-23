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
            return new PersonReadDTO()
            {
                PersonID = Entity.PersonID,
                NationalNo = Entity.NationalNo,
                FirstName = Entity.FirstName,
                SecondName = Entity.SecondName,
                ThirdName = Entity.ThirdName,
                LastName = Entity.LastName,
                Address = Entity.Address,
                Phone = Entity.Phone,
                DateOfBirth = Entity.DateOfBirth,
                Email = Entity.Email,
                NationalityCountryID = Entity.NationalityCountryID,
                ImagePath = Entity.ImagePath,
                Gender = (DVLD.BLL.Enums.Gender)Entity.Gender,
                CountryName = Entity.CountryName
            };
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
                Gender = (DVLD.DAL.Enums.Gender)dto.Gender,
                CountryName = dto.CountryName
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
                Gender = (DVLD.DAL.Enums.Gender)dto.Gender,
                CountryName = dto.CountryName
            };
        }
    }
}
