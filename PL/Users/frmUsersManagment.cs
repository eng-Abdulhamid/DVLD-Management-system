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
    public partial class frmUsersManagment : Form
    {
        #region Same
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

        #endregion
        public frmUsersManagment()
        {
            InitializeComponent();
            CurrentPage = 1;
            List<string> strColumnsName = new List<string>()
            {
                "User ID",
                "Person ID",
                "Username",
                "Is Active?"
            };
            ctrlUsersSearch1.OnSearch_Clicked += onSearch_Clicked;
            ctrlListUsers1.OnNextPage_Click += OnNextPage_Click;
            ctrlListUsers1.OnPreviousPage_Click += OnPreviousPage_Click;
            ctrlListUsers1.FillColumnsToDataGrid(strColumnsName);
            ctrlListUsers1.OnPageSizeChanged += OnPageSizeChanged;
            ctrlListUsers1.OnPageNumberChanged += OnPageNumberChanged;
            SearchResults<UserReadDTO> Results = ctrlUsersSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            ctrlListUsers1.LoadUsers(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void OnPageSizeChanged(int NewPageSize)
        {
            PageSize = NewPageSize;
            CurrentPage = 1;
            SearchResults<UserReadDTO> Results = ctrlUsersSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            //ctrlListUsers1.LoadUsers(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void OnPageNumberChanged(int PageNumber)
        {
            CurrentPage = PageNumber;
            SearchResults<UserReadDTO> Results = ctrlUsersSearch1.ApplySearchFilterForPageSize(CurrentPage, PageSize);
            //ctrlListUsers1.LoadUsers(Results.DataResults.DataList, Results.TotalCount, Results.CurrentPage);
        }
        void onSearch_Clicked(SearchResults<UserReadDTO> results)
        {
            CurrentPage = results.CurrentPage;
            PageSize = results.PageSize;

            ctrlListUsers1.LoadUsers(results.DataResults.DataList, results.TotalCount, results.CurrentPage);
        }
        void OnNextPage_Click(int Page)
        {
            SearchResults<UserReadDTO> Results = ctrlUsersSearch1.ApplySearchFilterForPageSize(Page, PageSize);
            ctrlListUsers1.LoadUsers(Results.DataResults.DataList, Results.TotalCount, Page);
        }
        void OnPreviousPage_Click(int Page)
        {
            SearchResults<UserReadDTO> Results = ctrlUsersSearch1.ApplySearchFilterForPageSize(Page, PageSize);
            ctrlListUsers1.LoadUsers(Results.DataResults.DataList, Results.TotalCount, Page);
        }

        private void ctrlListPeople1_Load(object sender, EventArgs e)
        {

        }
    }
}
