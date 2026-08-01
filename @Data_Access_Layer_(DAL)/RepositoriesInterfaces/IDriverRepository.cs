using Entities;
using Repositories;
using System.Collections.Generic;
namespace RepositoriesInterfaces
{
    public interface IDriverRepository
    {
        List<Driver> GetAllDrivers();
        int GetCountOfAllDrivers();
        int GetCountOfDriversByFilter(DriverRepository.DriversSearchCriteria SearchCriteria);
        List<Driver> GetDrivers(DriverRepository.DriversSearchCriteria SearchCriteria);
        int AddNewDriver(Driver DriverDeatils);

        Driver FindDriverByDriverID(int DriverID);
        bool DeleteDriverByDriverID(int DriverID);
        bool UpdateDriverByDriverID(Driver UpdatedDriver);
        bool IsDriverExistByDriverID(int DriverID);



    }
}
