using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPersonCard : Form
    {
        private readonly int personID = -1;
        public Action<int> PersonUpdated;
        public Action PersonDeleted;
        public frmPersonCard(int PersonID)
        {
            InitializeComponent();
            ctrlPersonCard1.RefreshCard(PersonID);
            personID = PersonID;
        }

        private void btnDeleteSelectedPerson_Click(object sender, EventArgs e)
        {
            if (personID > 0)
            {
                frmDeletePersonForm DeletePersonForm = new frmDeletePersonForm(personID);
                DeletePersonForm.DeletedSuccessfully += PersonDeletedSuccessfullyEventHundler;
                DeletePersonForm.ShowDialog();
            }
        }
        private void PersonDeletedSuccessfullyEventHundler()
        {
            PersonDeleted?.Invoke();
            this.Close();
        }

        private void btnUpdateSelectedPerson_Click(object sender, EventArgs e)
        {
            if (personID > 0)
            {
                frmSavePerson frm = new frmSavePerson(personID);

                frm.PersonSaved += PersonSaveEventHandler;

                frm.ShowDialog();
            }
        }
        private void PersonSaveEventHandler(int PersonID)
        {
            ctrlPersonCard1.RefreshCard(PersonID);
            PersonUpdated?.Invoke(PersonID);
        }
    }
}
