using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface IPersonServices : IServices<PersonReadDTO, PersonAddDTO, PersonUpdateDTO, PersonServices.enFields>
    {
        public OperationResult<PersonReadDTO> FindByPersonID(int PersonID);
        public bool DeleteByPersonID(int PersonID);
        public bool UpdateByPersonID(PersonUpdateDTO UpdatedData);
        public OperationResult<PersonReadDTO> FindByNationalNo(string NationalNo);
        public bool DeleteByNationalNo(string NationalNo);
        public bool UpdateByNationalNo(PersonUpdateDTO UpdatedData);
    }
}
