using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Rebar;
namespace DVLDPL
{
    public partial class ctrlUsersSearch :  ctrlSearchItems
    {
        private IUserServices _UserServices { get; set; } = new UserServices();
        public event Action<SearchResults<UserReadDTO>> OnSearch_Clicked;
        private int PageSize { get; set; } = 0;
        public ctrlUsersSearch()
        {
            InitializeComponent();
            PageSize = 10;
            btnSearch.Click += btnSearch_Click;
            btnClearSearchFiltering.Click += btnRefresh_Click;
        }
        protected override void FillComboBoxSearchFiltering()
        {
            foreach (UserServices.enFields en in Enum.GetValues(typeof(UserServices.enFields)))
            {
                 cbSearchFiltering.Items.Add(en.ToString());
            }
            cbSearchFiltering.SelectedIndex = 0;
        }
        protected UserServices.enFields _MapStringToSearchFilterFieldEnum(string SearchFiltering)
        {
            return (UserServices.enFields)(Enum.TryParse<UserServices.enFields>(SearchFiltering.Replace(" ", ""), out UserServices.enFields result) ? result : default(UserServices.enFields));
        }
        protected SearchCriteria<UserServices.enFields> ApplySearchCriteriaAtPage(int CurrentPage, int PageSize)
        {
            enSearchType eSearchType = MapSelectedSearchTypeTOSearchTypeEnum();
            return new SearchCriteria<UserServices.enFields>()
            {
                OrderBy = _MapStringToSearchFilterFieldEnum(cbSearchFiltering.Text),
                SearchBy = _MapStringToSearchFilterFieldEnum(cbSearchFiltering.Text),
                SearchString = txtSearch.Text,
                SearchType = eSearchType,
                SortingBy = MapSelectedSortingByToSortingEnum(),
                PageNumber = CurrentPage,
                SizeInEveryPage = PageSize
            };
        }
        public SearchResults<UserReadDTO> ApplySearchFilterForPageSize(int Page, int Size)
        {
            SearchResults<UserReadDTO> SearchResults = new SearchResults<UserReadDTO>();
            OperationResults<UserReadDTO> Results = _UserServices.GetByFilter(ApplySearchCriteriaAtPage(Page, Size));
            if (Results.IsSuccess)
            {
                SearchResults.TotalCount = _UserServices.GetCountApplyFilter(ApplySearchCriteriaAtPage(Page, Size));
                SearchResults.CurrentPage = Page;
                SearchResults.PageSize = Size;
                SearchResults.DataResults = Results;
                return (SearchResults);
            }
            else
                return new SearchResults<UserReadDTO>();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            OnSearch_Clicked?.Invoke(ApplySearchFilterForPageSize(0, PageSize));
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnSearch_Clicked?.Invoke(ApplySearchFilterForPageSize(0, PageSize));
        }

        private void btnSearch_Click_1(object sender, EventArgs e)
        {

        }
    }
}
