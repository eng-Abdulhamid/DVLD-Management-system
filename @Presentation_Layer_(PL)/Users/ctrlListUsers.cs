using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLD_BusinessLogicLayer.ServicesInterfaces;
using DVLDPL.Properties;
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

namespace DVLDPL
{
    public partial class ctrlListUsers : ctrlListItemsPagenation
    {
        public event Action<int> OnNextPage_Click;
        public event Action<int> OnPreviousPage_Click;
        public event Action<int> OnPageSizeChanged;
        public event Action<int> OnPageNumberChanged;
        IUserServices Services { get; set; } = new UserServices();
        //UsersContextMenuStripItems Items = new UsersContextMenuStripItems();
        public ctrlListUsers()
        {
            InitializeComponent();
            btnNextPage.Click += Next_Click;
            btnPreviousPage.Click += Previous_Click;
            btnApplyPageSize.Click += ApplyPageSize_Click;
            //_FillContextMenuStrip(Items.UsersMenuStripItems());
            //Items.OnUpdatedSucessfully += UpdateRowInfoByFirstCellTo;
            //Items.OnDeletedSucessfully += DeleteUserHaveUserID;
            //Items.OnAddedSucessfully += AddNewRowInfoToDataGrid;
            dgItemsList.CellDoubleClick += CellDoubleClick;
        }

        private void CellDoubleClick(object sender, EventArgs e)
        {
            if (int.TryParse(dgItemsList.CurrentRow.Cells[0].Value.ToString(), out int UserID))
            {
                //Items.UserDetails(UserID);
            }
        }

        private void ApplyPageSize_Click(object sender, EventArgs e)
        {
            PageSize = SelectedPageSize;
            btnApplyPageSize.Enabled = false;
            cbPagesNumber.SelectedIndex = 0;
            CurrentPage = 1;
            btnApplyPage.Enabled = false;
            OnPageSizeChanged?.Invoke(PageSize);
        }
        private void ApplyPage_Click(object sender, EventArgs e)
        {
            CurrentPage = SelectedPage;
            OnPageNumberChanged?.Invoke(CurrentPage);
            btnApplyPage.Enabled = false;
        }

        void Next_Click(object sender, EventArgs e)
        {
            OnNextPage_Click?.Invoke(CurrentPage);
        }
        void Previous_Click(object sender, EventArgs e)
        {
            OnPreviousPage_Click?.Invoke(CurrentPage);
        }

        protected int _TotalPagesNumber = -1;
        public void LoadUsers(List<UserReadDTO> Users, int TotalRows, int PageNumber)
        {
            if (dgItemsList.Rows.Count > 0)
                dgItemsList.Rows.Clear();
            if (Users == null) return;

            foreach (var User in Users)
            {
                dgItemsList.Rows.Add(_MapUserReadDTOToObjectArray(User));
            }
            _TotalPagesNumber = (int)Math.Ceiling((decimal)TotalRows / PageSize);

            CurrentPage = PageNumber;
            lblItemsCountValue.Text = TotalRows.ToString();
            lblPagesNumberValue.Text = _TotalPagesNumber.ToString();
            UpdatePaginationButtons(_TotalPagesNumber, PageNumber);
            FillPagesNumberInComboBox(_TotalPagesNumber);
        }
        public virtual void UpdateRowInfoByFirstCellTo(int UserID)
        {
            IUserServices Services = new UserServices();
            OperationResult<UserReadDTO> Result = Services.FindByUserID(UserID);
            if (Result.IsSuccess)
            {
                object[] UserObject = _MapUserReadDTOToObjectArray(Result.Data);
                if (UserObject.Length != dgItemsList.Columns.Count) return;
                foreach (DataGridViewRow dgvRow in dgItemsList.Rows)
                {
                    if (dgvRow.Cells[0].Value.ToString() == UserID.ToString())
                    {
                        for (int i = 0; i < dgvRow.Cells.Count; i++)
                        {
                            dgvRow.Cells[i].Value = UserObject[i];
                        }
                        break;
                    }
                }
            }
        }
        public void DeleteUserHaveUserID(int UserID)
        {
            if (UserID <= 0) return;
            foreach (DataGridViewRow dgvRow in dgItemsList.Rows)
            {
                if (dgvRow.Cells[0].Value.ToString() == UserID.ToString())
                {
                    dgItemsList.Rows.Remove(dgvRow);
                    if (int.TryParse(lblItemsCountValue.Text, out int count))
                    {
                        count--;
                        lblItemsCountValue.Text = count.ToString();
                    }
                    break;
                }
            }
        }
        public void AddNewRowInfoToDataGrid(int UserID)
        {
            IUserServices Services = new UserServices();
            OperationResult<UserReadDTO> Result = Services.FindByUserID(UserID);
            if (Result.IsSuccess)
            {
                UserReadDTO NewUserInfo = Result.Data;
                object[] User = _MapUserReadDTOToObjectArray(NewUserInfo);
                if (CurrentPage == 1)
                {
                    if (NewUserInfo == null) return;

                    if (User.Length != dgItemsList.Columns.Count)
                        return;
                    dgItemsList.Rows.Add(NewUserInfo);
                    if (int.TryParse(lblItemsCountValue.Text, out int count))
                    {
                        lblItemsCountValue.Text = count++.ToString();
                    }
                }
            }
        }
        protected void _OnAddSuccessfully(int ID)
        {
            OperationResult<UserReadDTO> result = Services?.FindByUserID(ID);
            if (result.IsSuccess)
            {
                AddNewRowInfoToDataGrid(result.Data.UserID);
            }
        }


        #region Not same methods
        protected void _OnAddNewClicked()
        {
            //frmSaveUser frmSaveUser = new frmSaveUser(-1);
            //frmSaveUser.onSaveSuccessfully += _OnAddSuccessfully;
            //frmSaveUser.ShowDialog();
        }
        protected object[] _MapUserReadDTOToObjectArray(UserReadDTO User)
        {
            ICountryServices countryServices = new CountryServices();
            return new object[]
            {
                (object)User.UserID,
                (object)User.PersonID,
                (object)$"{User.UserName}",
                (object)(User.IsActive ? "Active" : "Not Active")
            };
        }
        #endregion
    }
}
