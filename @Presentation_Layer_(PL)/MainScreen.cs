using CustomControls;
using DVLDPL.PeopleManagement;
using DVLDPL.UsersManagement;
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
    public partial class frmMainScreen : Form
    {
        public frmMainScreen()
        {
            InitializeComponent();
        }

        private void btnPeopleManagement_Click_1(object sender, EventArgs e)
        {
            using (frmPeopleManagement frm = new frmPeopleManagement())
            {
                frm.ShowDialog(this);
            }
        }

        private void btnUserManagement_Click(object sender, EventArgs e)
        {
            using (frmUsersManagement frm = new frmUsersManagement())
            {
                frm.ShowDialog(this);
            }
        }
    }
}
