using DVLD.PL.Global;
using System.ComponentModel;
using CustomizeControls;
using DVLD.PL.Theme;
namespace DVLD.PL.Management
{
    [DefaultEvent("OnAddClick")]
    public partial class ctrlManagementActions : UserControl
    {
        #region Properties
        private const int ButtonSpacing = 6;
        [Category("Operations")]
        public event EventHandler? OnAddClick;
        [Category("Operations")]
        public event EventHandler? OnEditClick;
        [Category("Operations")]
        public event EventHandler? OnDeleteClick;
        [Category("Operations")]
        public event EventHandler? OnRefreshClick;
        #region Visibility Properties

        [Category("Buttons Visibility")]
        [Description("Shows or hides the Add New button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AddVisible
        {
            get => btnAddNew.Visible;
            set
            {
                btnAddNew.Visible = value;
                RearrangeButtons();
            }
        }

        [Category("Buttons Visibility")]
        [Description("Shows or hides the Edit / Update button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EditVisible
        {
            get => btnUpdate.Visible;
            set
            {
                btnUpdate.Visible = value;
                RearrangeButtons();
            }
        }

        [Category("Buttons Visibility")]
        [Description("Shows or hides the Delete button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool DeleteVisible
        {
            get => btnDelete.Visible;
            set
            {
                btnDelete.Visible = value;
                RearrangeButtons();
            }
        }

        [Category("Buttons Visibility")]
        [Description("Shows or hides the Refresh button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RefreshVisible
        {
            get => btnRefresh.Visible;
            set
            {
                btnRefresh.Visible = value;
                RearrangeButtons();
            }
        }

        #endregion
        #region Enable / Disable Properties

        [Category("Buttons State")]
        [Description("Enables or disables the Add New button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool AddEnabled
        {
            get => btnAddNew.Enabled;
            set
            {
                btnAddNew.Enabled = value;
            }
        }

        [Category("Buttons State")]
        [Description("Enables or disables the Edit / Update button.")]
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool EditEnabled
        {
            get => btnUpdate.Enabled;
            set
            {
                btnUpdate.Enabled = value;
            }
        }

        [Category("Buttons State")]
        [Description("Enables or disables the Delete button.")]
        [DefaultValue(false)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool DeleteEnabled
        {
            get => btnDelete.Enabled;
            set
            {
                btnDelete.Enabled = value;
            }
        }

        [Category("Buttons State")]
        [Description("Enables or disables the Refresh button.")]
        [DefaultValue(true)]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public bool RefreshEnabled
        {
            get => btnRefresh.Enabled;
            set
            {
                btnRefresh.Enabled = value;
            }
        }

        #endregion
        #endregion
        #region Constructor and Initialization
        public ctrlManagementActions()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode)
            {
                RearrangeButtons();
                return;
            }

            ThemeApplicator.Apply(this);
            SetupToolTips();
            RegisterEvents();

            UpdateButtonsState(false);
            RearrangeButtons();
        }
        private void SetupToolTips()
        {
            toolTip1.SetToolTip(btnAddNew, "Add new record (Ctrl + N)");
            toolTip1.SetToolTip(btnUpdate, "Edit selected record (Ctrl + E)");
            toolTip1.SetToolTip(btnDelete, "Delete selected record (Delete)");
            toolTip1.SetToolTip(btnRefresh, "Refresh list (F5)");
        }
        private void RegisterEvents()
        {
            btnAddNew.Click += (s, e) => OnAddClick?.Invoke(this, e);
            btnUpdate.Click += (s, e) => OnEditClick?.Invoke(this, e);
            btnDelete.Click += (s, e) => OnDeleteClick?.Invoke(this, e);
            btnRefresh.Click += (s, e) => OnRefreshClick?.Invoke(this, e);

            btnAddNew.VisibleChanged += (s, e) => RearrangeButtons();
            btnUpdate.VisibleChanged += (s, e) => RearrangeButtons();
            btnDelete.VisibleChanged += (s, e) => RearrangeButtons();
            btnRefresh.VisibleChanged += (s, e) => RearrangeButtons();
        }
        #endregion
        public void RearrangeButtons()
        {
            this.SuspendLayout();

            int currentX = 0;
            int visibleButtonsCount = 0;
            NButton[] buttons = { btnAddNew, btnUpdate, btnDelete, btnRefresh };

            foreach (var btn in buttons)
            {
                if (btn.Visible)
                {
                    int centerY = (this.Height - btn.Height) / 2;
                    btn.Location = new Point(currentX, Math.Max(0, centerY));
                    currentX += btn.Width + ButtonSpacing;
                    visibleButtonsCount++;
                }
            }

            int calculatedWidth = visibleButtonsCount > 0 ? (currentX - ButtonSpacing) : 0;
            if (this.Width != calculatedWidth && calculatedWidth > 0)
            {
                this.Width = calculatedWidth;
            }

            this.ResumeLayout(true);
        }
        public void UpdateButtonsState(bool hasSelection)
        {
            EditEnabled = hasSelection;
            DeleteEnabled = hasSelection;
        }
        #region Override
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            RearrangeButtons();
        }
        #endregion
    }
}