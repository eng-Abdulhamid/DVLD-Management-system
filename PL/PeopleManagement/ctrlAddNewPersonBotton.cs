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
    public partial class ctrlAddNewPersonBotton : UserControl
    {
        public ctrlAddNewPersonBotton()
        {
            InitializeComponent();
        }
        private void AddNewPerson()
        {

        }
        private void pbAdNewPerson_Click(object sender, EventArgs e)
        {
            frmAddNewPersonForm AddPerson = new frmAddNewPersonForm();
            AddPerson.ShowDialog();
        }
    }
}
