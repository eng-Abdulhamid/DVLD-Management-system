using System;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class ctrlAddNewPersonBotton : UserControl
    {
        public event Action<int> PersonSaved;
        public ctrlAddNewPersonBotton()
        {
            InitializeComponent();
        }
        private void pbAdNewPerson_Click(object sender, EventArgs e)
        {
            frmSavePerson AddPerson = new frmSavePerson();
            AddPerson.PersonSaved += (personId) => PersonSaved?.Invoke(personId);
            AddPerson.ShowDialog();
        }
    }
}
