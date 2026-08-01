using DVLDPL;
using DVLDPL;
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
    public partial class frmShowPersonInformation : Form
    {
        int _PersonID { get; set; }
        public Action<int> OnEditPerson { get; set; }
        public frmShowPersonInformation(int PersonID, Action<int> onEditPerson)
        {
            InitializeComponent();
            _PersonID = PersonID;
            ctrlPersonCard1.LoadPersonDataInCard(PersonID);
            OnEditPerson = onEditPerson;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (_PersonID > 0)
            {
                frmSavePerson frm = new frmSavePerson(_PersonID);
                frm.onSaveSuccessfully += (PersonID) =>
                {
                    ctrlPersonCard1.LoadPersonDataInCard(_PersonID);
                    OnEditPerson?.Invoke(PersonID);
                };
                frm.ShowDialog();
            }

        }
    }
}
