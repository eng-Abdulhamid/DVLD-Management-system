using DTOs;
using DVLD_BusinessLogicLayer;
using DVLD.PL;
using DVLD.PL.Properties;
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
using Users;

namespace DVLD.PL
{
    public partial class frmDashboard : Form
    {
        public frmDashboard()
        {
            InitializeComponent();
        }
        #region Users Management
        private void btnUsersManagment_Click(object sender, EventArgs e)
        {
            //UsersManagement usersManegement = new UsersManagement();
            //usersManegement.OpenItemsListDialogInListMode();
        }
        #endregion

        private void btnPeopleMangement_Click(object sender, EventArgs e)
        {
            //ManegementPeople peopleManegement = new ManegementPeople();
            //peopleManegement.OpenItemsListDialogInListMode();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }
    }
}
