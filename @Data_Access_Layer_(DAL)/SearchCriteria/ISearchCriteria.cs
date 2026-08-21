using DVLD.DAL.Enums;
using System;

namespace DVLD.DAL.SearchCriteria
{
    public interface ISearchCriteria<TColumns> where TColumns : Enum
    {
        TColumns FilterBy { get; set; }
        enSearchType SearchType { get; set; }
        string SearchText { get; set; }
    }
}