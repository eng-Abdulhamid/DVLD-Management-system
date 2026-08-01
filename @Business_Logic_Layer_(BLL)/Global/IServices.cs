using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.Global;
using DVLD_BusinessLogicLayer.ServicesInterfaces;
using System;
using System.Net;

namespace Services
{
    public interface IServices<ReadDTO, AddDTO, UpdateDTO, enFields> : IReadServices<ReadDTO, enFields>, IAddServices<AddDTO>  where ReadDTO : class, new() where enFields : Enum 
    {
        //OperationResults<ReadDTO> GetByFilter(SearchCriteria<enFields> criteria);
        //OperationResults<ReadDTO> GetAllWithoutFilter();
        //int AddNew(AddDTO AddDTO);
        //int GetCountApplyFilter(SearchCriteria<enFields> SearchCriteria);
        //int GetCountOfAllWithoutFilter();
    }
}
