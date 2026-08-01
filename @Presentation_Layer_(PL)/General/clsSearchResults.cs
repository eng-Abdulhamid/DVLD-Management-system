using DVLD_BusinessLogicLayer;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DVLDPL
{
    public class SearchResults<ReadDTO> where ReadDTO : class, new()
    {
        public int PageSize { get; set; } = 0;
        public int TotalCount { get; set; } = 0;
        public int CurrentPage { get; set; } = 0;
        public OperationResults<ReadDTO> DataResults { get; set; } = new OperationResults<ReadDTO>();
    }
}
