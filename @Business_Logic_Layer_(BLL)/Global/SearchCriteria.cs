using System;

namespace Services
{
    public class SearchCriteria<enFields> where enFields : Enum
    {
        public enGender GenderFilter { get; set; } = enGender.Both;
        public enFields FilterBy { get; set; }
        public string SearchString { get; set; } = string.Empty;
        public enSearchType SearchType { get; set; } = enSearchType.None;
    }
}
