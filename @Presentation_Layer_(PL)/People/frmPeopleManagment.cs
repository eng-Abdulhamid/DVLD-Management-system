using DTOs;
using DVLD_BusinessLogicLayer;
using Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;
namespace DVLDPL
{
    public partial class frmPeopleManagment : Form
    {
        private int CurrentPage
        {
            get;
            set;
        } = 1;
        private int PageSize
        {
            get;
            set;
        } = 10;
        public frmPeopleManagment()
        {
            InitializeComponent();
            CurrentPage = 1;
            ctrlPeopleSearch1.OnSearch_Clicked += onSearch_Clicked;
            ctrlListPeople1.OnNextPage_Click += OnNextPage_Click;
            ctrlListPeople1.OnPreviousPage_Click += OnPreviousPage_Click;
            List<string> strColumnsName = new List<string>()
            {
                "PersonID",
                "NationalNo",
                "Full name",
                "Age",
                "Gendor",
                "Date of birth",
                "Address",
                "Phone",
                "Email",
                "Country"
            };
            ctrlListPeople1.FillColumnsToDataGrid(strColumnsName);
            ctrlListPeople1.OnPageSizeChanged += OnPageSizeChanged;
            ctrlListPeople1.OnPageNumberChanged += OnPageNumberChanged;
            SearchResults<PersonReadDTO> Results = ctrlPeopleSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            ctrlListPeople1.LoadPeople(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void OnPageSizeChanged(int NewPageSize)
        {
            PageSize = NewPageSize;
            CurrentPage = 1;
            SearchResults<PersonReadDTO> Results = ctrlPeopleSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            ctrlListPeople1.LoadPeople(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void OnPageNumberChanged(int PageNumber)
        {
            CurrentPage = PageNumber;
            SearchResults<PersonReadDTO> Results = ctrlPeopleSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            ctrlListPeople1.LoadPeople(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void onSearch_Clicked(SearchResults<PersonReadDTO> results)
        {
            CurrentPage = results.CurrentPage;
            PageSize = results.PageSize;
            ctrlListPeople1.LoadPeople(results.DataResults.DataList, results.TotalCount, results.CurrentPage);
        }
        void OnNextPage_Click(int Page)
        {
            SearchResults<PersonReadDTO> Results = ctrlPeopleSearch1.ApplySearchFilterForPageSize(Page, PageSize);
            ctrlListPeople1.LoadPeople(Results.DataResults.DataList, Results.TotalCount, Page);
        }
        void OnPreviousPage_Click(int Page)
        {
            SearchResults<PersonReadDTO> Results = ctrlPeopleSearch1.ApplySearchFilterForPageSize(Page, PageSize);
            ctrlListPeople1.LoadPeople(Results.DataResults.DataList, Results.TotalCount, Page);
        }

        private void ctrlListPeople1_Load(object sender, EventArgs e)
        {

        }
    }
}
