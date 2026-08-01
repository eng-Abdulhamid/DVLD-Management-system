using CustomControls;
using DTOs;
using DVLD_BusinessLogicLayer;
using DVLDPL.Properties;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLDPL
{
    public class PeopleContextMenuStripItems
    {
        public event Action<int> OnUpdatedSucessfully;
        public event Action<int> OnDeletedSucessfully;
        public event Action<int> OnAddedSucessfully;
        #region Context Menu Strip Items
        #region Helper Methods
        private int _GetPersonIDByToolStripSender(object sender)
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
        #region Update Methods
        private void EditPerson_Clicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonIDByToolStripSender(sender);
            if (PersonID != -1)
            {
                frmSavePerson frmSavePerson = new frmSavePerson(PersonID);
                frmSavePerson.onSaveSuccessfully += OnUpdatedSucessfully;
                frmSavePerson.ShowDialog();
            }
        }
        protected virtual ToolStripItem UpdatePersonMenuStripItem()
        {
            ToolStripItem item = new ToolStripMenuItem("Edit Person", Resources.user_add_21995, EditPerson_Clicked);
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
        #region Delete Methods
        private void _DeletePersonClicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonIDByToolStripSender(sender);
            if (PersonID != -1)
            {
                IPersonServices PServ = new PersonServices();
                if (PServ.DeleteByPersonID(PersonID))
                {
                    OnDeletedSucessfully?.Invoke(PersonID);
                    Notification.Show("Person deleted successfully!", type: IconType.Success, 1);
                }
                else
                {
                    Notification.Show("Person can't delete!", type: IconType.Error, 1);
                }
            }
        }
        protected virtual ToolStripItem DeletePersonMenuStripItem()
        {
            ToolStripItem item = new ToolStripMenuItem("Delete Person", Resources.delete_4361629, _DeletePersonClicked);
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
        #region Person Details
        
        public void PersonDetails(int PersonID)
        {
            if (PersonID != -1)
            {
                IPersonServices PServ = new PersonServices();
                OperationResult<PersonReadDTO> result = PServ.FindByPersonID(PersonID);
                if (result.IsSuccess)
                {
                    frmShowPersonInformation personDetails = new frmShowPersonInformation(PersonID, OnUpdatedSucessfully);
                    personDetails.ShowDialog();
                }
            }

        }

        private void PersonDetailsClicked(object sender, EventArgs e)
        {
            int PersonID = _GetPersonIDByToolStripSender(sender);
            PersonDetails(PersonID);
        }
        
        protected virtual ToolStripItem PersonDetailsMenuStripItem()
        {
            ToolStripItem item = new ToolStripMenuItem("Person details", Resources.contacts, PersonDetailsClicked);
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
        #endregion
        public ToolStripItem[] PeopleMenuStripItems()
        {
            ToolStripItem[] items = new ToolStripItem[3];
            items[0] = UpdatePersonMenuStripItem();
            items[1] = DeletePersonMenuStripItem();
            items[2] = PersonDetailsMenuStripItem();
            return items;
        }
    }
}
