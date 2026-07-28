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
    public partial class ctrlListPeople : ctrlListItemsPagenation
    {
        public event Action<int> OnNextPage_Click;
        public event Action<int> OnPreviousPage_Click;
        public event Action<int> OnPageSizeChanged;
        public event Action<int> OnPageNumberChanged;
        private PeopleContextMenuStripItems Items = new PeopleContextMenuStripItems();
        public ctrlListPeople()
        {
            InitializeComponent();
            btnNextPage.Click += Next_Click;
            btnPreviousPage.Click += Previous_Click;
            btnApplyPageSize.Click += ApplyPageSize_Click;
            base.FillContextMenuStripWithItems(Items.PeopleMenuStripItems());
            Items.OnUpdatedSucessfully += UpdateRowInfoByFirstCellTo;
            Items.OnDeletedSucessfully += DeletePersonHavePersonID;
            Items.OnAddedSucessfully += AddNewRowInfoToDataGrid;
            lblItemsLabel.Text = "People";
            dgItemsList.CellDoubleClick += CellDoubleClick;
        }
        private void CellDoubleClick(object sender, EventArgs e)
        {
            if (int.TryParse(dgItemsList.CurrentRow.Cells[0].Value.ToString(), out int PersonID))
            {
                Items.PersonDetails(PersonID);
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
        protected object[] _MapPersonReadDTOToObjectArray(PersonReadDTO person)
        {
            ICountryServices countryServices = new CountryServices();
            OperationResult<CountryReadDTO> countryResult = countryServices.FindByCountryID(person.NationalityCountryID);
            return new object[]
            {
                (object)person.PersonID,
                (object)person.NationalNo,
                (object)$"{person.FirstName} {person.SecondName} {person.ThirdName} {person.LastName}",
                (object)person.Age,
                (object)(person.Gendor == enGendor.Male ? "Male" : "Female"),
                (object)person.DateOfBirth.Date,
                (object)person.Address,
                (object)person.Phone,
                (object)person.Email,
                (object)(countryResult.IsSuccess ? countryResult.Data.CountryName : "N/A")
            };
        }
        protected int _TotalPagesNumber = -1;
        public void LoadPeople(List<PersonReadDTO> People, int TotalRows, int PageNumber)
        {
            if (dgItemsList.Rows.Count > 0)
                dgItemsList.Rows.Clear();
            if (People == null) return;

            foreach (var person in People)
            {
                dgItemsList.Rows.Add(_MapPersonReadDTOToObjectArray(person));
            }
            _TotalPagesNumber = (int)Math.Ceiling((decimal)TotalRows / PageSize);

            CurrentPage = PageNumber;
            lblItemsCountValue.Text = TotalRows.ToString();
            lblPagesNumberValue.Text = _TotalPagesNumber.ToString();
            UpdatePaginationButtons(_TotalPagesNumber, PageNumber);
            FillPagesNumberInComboBox(_TotalPagesNumber);
        }
        public virtual void UpdateRowInfoByFirstCellTo(int PersonID)
        {
            IPersonServices Services = new PersonServices();
            OperationResult<PersonReadDTO> Result = Services.FindByPersonID(PersonID);
            if (Result.IsSuccess)
            {
                object[] PersonObject = _MapPersonReadDTOToObjectArray(Result.Data);
                if (PersonObject.Length != dgItemsList.Columns.Count) return;
                foreach (DataGridViewRow dgvRow in dgItemsList.Rows)
                {
                    if (dgvRow.Cells[0].Value.ToString() == PersonID.ToString())
                    {
                        for (int i = 0; i < dgvRow.Cells.Count; i++)
                        {
                            dgvRow.Cells[i].Value = PersonObject[i];
                        }
                        break;
                    }
                }
            }
        }
        public void DeletePersonHavePersonID(int PersonID)
        {
            if (PersonID <= 0) return;
            foreach (DataGridViewRow dgvRow in dgItemsList.Rows)
            {
                if (dgvRow.Cells[0].Value.ToString() == PersonID.ToString())
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
        public void AddNewRowInfoToDataGrid(int PersonID)
        {
            IPersonServices Services = new PersonServices();
            OperationResult<PersonReadDTO> Result = Services.FindByPersonID(PersonID);
            if (Result.IsSuccess)
            {
                PersonReadDTO NewPersonInfo = Result.Data;
                object[] Person = _MapPersonReadDTOToObjectArray(NewPersonInfo);
                if (CurrentPage == 1)
                {
                    if (NewPersonInfo == null) return;

                    if (Person.Length != dgItemsList.Columns.Count)
                        return;
                    dgItemsList.Rows.Add(NewPersonInfo);
                    if (int.TryParse(lblItemsCountValue.Text, out int count))
                    {
                        lblItemsCountValue.Text = count++.ToString();
                    }
                }
            }
        }
        protected void _OnAddSuccessfully(int PersonID)
        {
            IPersonServices PersonService = new PersonServices();
            OperationResult<PersonReadDTO> result = PersonService.FindByPersonID(PersonID);
            if (result.IsSuccess)
            {
                AddNewRowInfoToDataGrid(result.Data.PersonID);
            }
        }
        protected void _OnAddNewClicked()
        {
            frmSavePerson frmSavePerson = new frmSavePerson(-1);
            frmSavePerson.onSaveSuccessfully += _OnAddSuccessfully;
            frmSavePerson.ShowDialog();
        }
    }
}
