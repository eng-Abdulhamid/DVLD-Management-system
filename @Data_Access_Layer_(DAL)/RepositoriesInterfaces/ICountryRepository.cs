using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface ICountryRepository
    {
        List<Country> GetAllCountries();
        int GetCountOfAllCountries();
        int GetCountOfCountriesByFilter(CountryRepository.CountriesSearchCriteria SearchCriteria);
        List<Country> GetCountries(CountryRepository.CountriesSearchCriteria SearchCriteria);
        int AddNewCountry(Country CountryDeatils);

        Country FindCountryByCountryID(int CountryID);
        bool DeleteCountryByCountryID(int CountryID);
        bool UpdateCountryByCountryID(Country UpdatedCountry);
        bool IsCountryExistByCountryID(int CountryID);

    }
}
