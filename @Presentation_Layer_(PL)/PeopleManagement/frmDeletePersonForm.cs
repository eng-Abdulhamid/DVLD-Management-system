using CustomControls;
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

namespace DVLDPL.PeopleManagement
{
    public partial class frmDeletePersonForm : Form
    {
        private readonly int personID = -1;
        public Action DeletedSuccessfully;
        public frmDeletePersonForm(int PersonID)
        {
            InitializeComponent();
            if (PersonID > 0)
            {
                personID = PersonID;
                ctrlPersonCard1.RefreshCard(PersonID);
            }
            else
            {
                Notification.Show("Cannot load this person, please try again later.", IconType.Error);
                this.Close();
            }

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            PersonServices personServices = new PersonServices();
            if (personServices.DeleteByPersonID(personID))
            {
                Notification.Show($"Person Deleted Successfully.", IconType.Success);
                this.Close();
                DeletedSuccessfully?.Invoke();
            }
        }
    }
}
