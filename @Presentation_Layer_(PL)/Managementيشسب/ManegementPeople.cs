using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLD.PL.Properties;
using Services;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL
{
    public class ManegementPeople : absMangement<PersonReadDTO>
    {
        //frmListItems<PersonReadDTO, PersonAddDTO, PersonUpdateDTO, PersonServices.enFields> _peopleListForm;
        #region Initialize Componanets
        public ManegementPeople()
        {
            _InitializeItemsListForm(enListMode.List);
        }
        private ToolStripItem _PersonDetailsMenuStripItem()

        {
            ToolStripItem item = new ToolStripMenuItem("Person details", Resources.contacts, _PersonDetailsClicked);
            item.AutoSize = true;
            item.MouseEnter += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.ToolTipText = "Edit selected user information";
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            item.MouseLeave += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            return item;
        }
        protected override ToolStripItem[] _GetToolStripItemsInArray()
        {
            ToolStripItem[] items = new ToolStripItem[3];
            items[0] = _EditPersonMenuStrip();
            items[1] = _DeletePersonMenuStripItem();
            items[2] = _PersonDetailsMenuStripItem();
            return items;
        }
        protected override void _InitializeItemsListForm(enListMode Mode)
        {
            //_peopleListForm =
            // new frmListItems<PersonReadDTO, PersonAddDTO, PersonUpdateDTO, PersonServices.enFields>
            // (FormTitle: "People management",
            // FormIcon: null,
            // Mode,
            // Services: new PersonServices(),
            // _MapListOfReadDTOToDataTable,
            // 20,
            // _GetToolStripItemsInArray(),
            // _OnAddNewClicked);
        }
        #endregion
        #region Open people list
        public override void OpenItemsListDialogInListMode()
        {
            //_peopleListForm.ShowDialog();
        }
        public override void OpenItemsListInListMode()
        {
            //_peopleListForm.Show();
        }
        public override void OpenItemsListDialogInSelectMode(Action<DataGridViewRow> onSelected)
        {
            _InitializeItemsListForm(enListMode.Select);
            _peopleListForm.OnSelect += onSelected;
            _peopleListForm.ShowDialog();
        }
        public override void OpenItemsListInSelectMode(Action<DataGridViewRow> onSelected)
        {
            _InitializeItemsListForm(enListMode.Select);
            _peopleListForm.OnSelect = onSelected;
            _peopleListForm.Show();
        }
        #endregion
        #region Map Methods
        protected override object[] _MapReadDTOToObjectArray(PersonReadDTO person)
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
        protected override DataTable _MapListOfReadDTOToDataTable(List<PersonReadDTO> People)
        {
            DataTable dt = new DataTable();
            List<string> ColumnsName = new List<string>()
            {
                "PersonID",
                "National No",
                "Full Name",
                "Age",
                "Gendor",
                "Date Of Birth",
                "Address",
                "Phone",
                "Email",
                "Country"
            };
            foreach (string str in ColumnsName)
            {
                dt.Columns.Add(str);
            }
            foreach (var person in People)
            {
                dt.Rows.Add(_MapReadDTOToObjectArray(person));
            }
            return dt;
        }
        #endregion
        #region People Management
        #region Update Methods
        protected override void _OnUpdateSuccessfully(int PersonID)
        {
            IPersonServices PersonService = new PersonServices();
            OperationResult<PersonReadDTO> result = PersonService.FindByPersonID(PersonID);
            if (result.IsSuccess)
            {
                _peopleListForm.UpdateRowInfoByFirstCellTo(PersonID.ToString(), _MapReadDTOToObjectArray(result.Data));
            }
        }
        private void EditPersonInformationToolStripClicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonByToolStripSender(sender);
            if (PersonID != -1)
            {
                frmSavePerson frmSavePerson = new frmSavePerson(PersonID);
                frmSavePerson.onSaveSuccessfully += _OnUpdateSuccessfully;
                frmSavePerson.ShowDialog();
            }
        }
        private ToolStripItem _EditPersonMenuStrip()
        {
            ToolStripItem item = new ToolStripMenuItem("Edit Person", Resources.user_add_21995, EditPersonInformationToolStripClicked);
            item.AutoSize = true;
            item.MouseEnter += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.ToolTipText = "Edit selected user information";
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            item.MouseLeave += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            return item;
        }

        #endregion
        #region Add Methods
        protected override void _OnAddSuccessfully(int PersonID)
        {
            IPersonServices PersonService = new PersonServices();
            OperationResult<PersonReadDTO> result = PersonService.FindByPersonID(PersonID);
            if (result.IsSuccess)
            {
                _peopleListForm.AddNewRowInfoToDataGrid(_MapReadDTOToObjectArray(result.Data));
            }
        }
        protected override void _OnAddNewClicked()
        {
            frmSavePerson frmSavePerson = new frmSavePerson(-1);
            frmSavePerson.onSaveSuccessfully += _OnAddSuccessfully;
            frmSavePerson.ShowDialog();
        }
        #endregion
        #region Delete Methods
        protected override void _OnDeleteSuccessfully(int PersonID)
        {
            if (PersonID > 0)
            {
                _peopleListForm.DeleteRowFromDataGridFirstCellIs(PersonID);
            }
        }
        private void _DeletePersonToolStripClicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonByToolStripSender(sender);
            if (PersonID != -1)
            {
                IPersonServices PServ = new PersonServices();
                if (PServ.DeleteByPersonID(PersonID))
                {
                    _OnDeleteSuccessfully(PersonID);
                    Notification.Show("Person deleted successfully!", type: IconType.Success, 1);
                }
                else
                {
                    Notification.Show("Person can't delete!", type: IconType.Error, 1);
                }
            }
        }
        private ToolStripItem _DeletePersonMenuStripItem()
        {
            ToolStripItem item = new ToolStripMenuItem("Delete Person", Resources.delete_4361629, _DeletePersonToolStripClicked);
            item.AutoSize = true;
            item.MouseEnter += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.ToolTipText = "Edit selected user information";
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            item.MouseLeave += (s, e) =>
            {
                if (s is ToolStripItem item)
                {
                    item.BackColor = System.Drawing.Color.White;
                }
            };
            return item;
        }
        #endregion
        #region PersonDetails
        private void _PersonDetailsClicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonByToolStripSender(sender);
            if (PersonID != -1)
            {
                IPersonServices PServ = new PersonServices();
                OperationResult<PersonReadDTO> result = PServ.FindByPersonID(PersonID);
                if (result.IsSuccess)
                {
                    frmShowPersonInformation personDetails = new frmShowPersonInformation(PersonID, null);
                    personDetails.ShowDialog();
                }
            }
        }

        #endregion
        #region Helper Methods
        private int _GetPersonByToolStripSender(object sender)
        {
            if (sender is ToolStripItem item &&
                item.Owner is ContextMenuStrip cms &&
                cms.SourceControl is DataGridView dgv)
            {
                if (int.TryParse(dgv.CurrentRow.Cells[0].Value?.ToString(), out int result))
                {
                    return result;
                }
            }
            return -1;
        }
        #endregion
        #endregion

    }
}
