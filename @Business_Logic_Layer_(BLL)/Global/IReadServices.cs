using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLD_BusinessLogicLayer.ServicesInterfaces
{
    public interface IReadServices<ReadDTO, enFields> where enFields : Enum where ReadDTO : class, new()
    {
        OperationResults<ReadDTO> GetPeople(SearchCriteria<enFields> criteria);
        OperationResults<ReadDTO> GetAllPeople();
        int PeopleCount(SearchCriteria<enFields> SearchCriteria);
        int GetCountOfAllWithoutFilter();
    }
}
