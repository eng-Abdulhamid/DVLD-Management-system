using DTOs;
using DVLD_BusinessLogicLayer;
namespace Services
{

    public interface ICountryServices : IServices<CountryReadDTO, CountryAddDTO, CountryUpdateDTO, CountryServices.enFields>
    {
        public OperationResult<CountryReadDTO> FindByCountryID(int CountryID);
        public bool DeleteByCountryID(int CountryID);
        public bool UpdateByCountryID(CountryUpdateDTO UpdatedData);
    }
}
