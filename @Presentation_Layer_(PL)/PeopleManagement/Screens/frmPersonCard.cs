using DVLD.PL.Global;
using System;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class frmPersonCard : frmBase
    {
        private readonly int _personId;
        private ToolTip? _toolTips;

        public event Action<int>? PersonUpdated;
        public event Action? PersonDeleted;

        public frmPersonCard() : this(-1)
        {
        }

        public frmPersonCard(int personId)
        {
            InitializeComponent();

            this.ApplyStandardFormTheme();
            this.AllowMaximize = false;
            this.AllowResize = false;

            _personId = personId;

            ApplyStyles();
            RegisterEvents();
            SetupToolTips();
        }

        private void ApplyStyles()
        {
            btnEdit.ApplyPrimaryStyle();
            btnDelete.ApplyDangerStyle();
        }

        private void SetupToolTips()
        {
            _toolTips = new ToolTip
            {
                InitialDelay = 300,
                ReshowDelay = 100,
                AutoPopDelay = 5000,
                UseAnimation = true,
                UseFading = true
            };

            _toolTips.SetToolTip(btnEdit, "Edit person details");
            _toolTips.SetToolTip(btnDelete, "Delete person record");
        }

        private async void frmPersonCard_Load(object sender, EventArgs e)
        {
            if (UIUtility.IsDesignMode) return;

            if (_personId <= 0)
            {
                UITheme.ShowErrorToast("Invalid person identifier.");
                this.Close();
                return;
            }

            await ctrlPersonCard1.LoadPersonInfoAsync(_personId);
        }

        private void RegisterEvents()
        {
            btnEdit.Click += (s, e) => OpenEditDialog();
            btnDelete.Click += (s, e) => OpenDeleteDialog();
        }

        private void OpenEditDialog()
        {
            using frmSavePerson frm = new frmSavePerson(_personId);
            frm.PersonSaved += async (id) =>
            {
                await ctrlPersonCard1.LoadPersonInfoAsync(_personId);
                PersonUpdated?.Invoke(_personId);
            };
            frm.ShowDialog();
        }

        private void OpenDeleteDialog()
        {
            using frmDeletePersonForm frm = new frmDeletePersonForm(_personId);
            frm.DeletedSuccessfully += () =>
            {
                PersonDeleted?.Invoke();
                this.Close();
            };
            frm.ShowDialog();
        }
    }
}