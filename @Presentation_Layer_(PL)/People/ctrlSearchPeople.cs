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
namespace DVLD.PL
{
    public partial class ctrlPeopleSearch :  ctrlSearchItems
    {
        private IPersonServices _PersonServices { get; set; } = new PersonServices();
        public event Action<SearchResults<PersonReadDTO>> OnSearch_Clicked;
        private int PageSize { get; set; } = 0;
        public ctrlPeopleSearch()
        {
            InitializeComponent();
            PageSize = 10;
            btnSearch.Click += btnSearch_Click;
            btnClearSearchFiltering.Click += btnRefresh_Click;
        }
        protected override void FillComboBoxSearchFiltering()
        {
            foreach (PersonServices.enFields en in Enum.GetValues(typeof(PersonServices.enFields)))
            {
                if (!(en.ToString() == "ImagePath"))
                {
                    if (en.ToString() == "DateOfBirth")
                    {
                        cbSearchFiltering.Items.Add("Age");
                    }
                    else if (en.ToString() == "None")
                        cbSearchFiltering.Items.Add("Please select");
                    else 
                        cbSearchFiltering.Items.Add(en.ToString());
                }
            }
            cbSearchFiltering.SelectedIndex = 0;
        }
        protected PersonServices.enFields _MapStringToSearchFilterFieldEnum(string SearchFiltering)
        {
            if (SearchFiltering == "Age")
            {
                SearchFiltering = "DateOfBirth";
            }
            return (PersonServices.enFields)(Enum.TryParse<PersonServices.enFields>(SearchFiltering.Replace(" ", ""), out PersonServices.enFields result) ? result : default(PersonServices.enFields));
        }
        protected SearchCriteria<PersonServices.enFields> ApplySearchCriteriaAtPage(int CurrentPage, int PageSize)
        {
            enSearchType eSearchType = MapSelectedSearchTypeTOSearchTypeEnum();
            return new SearchCriteria<PersonServices.enFields>()
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
        public SearchResults<PersonReadDTO> ApplySearchFilterForPageSize(int Page, int Size)
        {
            SearchResults<PersonReadDTO> SearchResults = new SearchResults<PersonReadDTO>();
            OperationResults<PersonReadDTO> Results = _PersonServices.GetByFilter(ApplySearchCriteriaAtPage(Page, Size));
            if (Results.IsSuccess)
            {
                SearchResults.TotalCount = _PersonServices.GetCountApplyFilter(ApplySearchCriteriaAtPage(Page, Size));
                //SearchResults.TotalPages = (int)Math.Ceiling((decimal)SearchResults.TotalCount / Size);
                SearchResults.CurrentPage = Page;
                SearchResults.PageSize = Size;
                SearchResults.DataResults = Results;
                return (SearchResults);
            }
            else
                return new SearchResults<PersonReadDTO>();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            OnSearch_Clicked?.Invoke(ApplySearchFilterForPageSize(0, PageSize));
        }
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            OnSearch_Clicked?.Invoke(ApplySearchFilterForPageSize(0, PageSize));
        }
    }
}
