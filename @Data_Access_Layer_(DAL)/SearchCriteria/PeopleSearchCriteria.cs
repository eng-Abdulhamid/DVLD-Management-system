using DVLD.DAL.Enums;
using DVLD.DAL.SearchCriteria;
namespace DVLD.DAL.SearchCriteria
{
    public class PeopleSearchCriteria : ISearchCriteria<enPersonColumn>
    {
        public enPersonColumn FilterBy { get; set; }
        enSearchType ISearchCriteria<enPersonColumn>.SearchType { get; set; }
        public string SearchText { get; set; }
        public enSearchType SearchType;
    }

}
