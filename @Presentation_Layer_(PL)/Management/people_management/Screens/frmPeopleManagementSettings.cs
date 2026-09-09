using DVLD.PL.Global;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPeopleManagementSettings : frmBase
    {
        public frmPeopleManagementSettings()
        {
            InitializeComponent();

            this.ApplyStandardFormTheme();
            this.AllowMaximize = false;
            this.AllowMinimize = false;
            this.AllowResize = false;

            btnSave.ApplyPrimaryStyle();
            btnCancel.ApplySecondaryStyle();
            chkAutoSearch.ApplyStandardStyle();
            chkConfirmDelete.ApplyStandardStyle();

            btnCancel.Click += (s, e) => this.Close();
            btnSave.Click += (s, e) =>
            {
                UITheme.ShowSuccessToast("Settings saved successfully.", "Preferences");
                this.Close();
            };
        }
    }
}