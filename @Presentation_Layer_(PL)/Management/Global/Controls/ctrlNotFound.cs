using DVLD.PL.Global;
using DVLD.PL.Theme;
using System.ComponentModel;
namespace DVLD.PL.Management
{
    [DefaultEvent("OnClearFilterClick")]
    public partial class ctrlNotFound : UserControl
    {
        #region Properties and the Constructor

        [Category("Appearance")]
        [Description("The main title displayed when no records are found.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Title
        {
            get => lblEmptyTitle.Text;
            set
            {
                lblEmptyTitle.Text = value;
                CenterControls();
            }
        }

        [Category("Appearance")]
        [Description("The detailed description displayed below the title.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string Description
        {
            get => lblEmptyDesc.Text;
            set
            {
                lblEmptyDesc.Text = value;
                CenterControls();
            }
        }

        [Category("Behavior")]
        [Description("Determines whether the Clear Filters button is visible.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool ShowClearButton
        {
            get => btnClearFilter.Visible;
            set
            {
                btnClearFilter.Visible = value;
                CenterControls();
            }
        }
        [Category("Search Behavior")]
        [Description("Fires when the Clear Filters button is clicked.")]
        public event EventHandler? OnClearFilterClick;


        public ctrlNotFound()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            RegisterEvents();

            this.Resize += (s, e) => CenterControls();
            ThemeApplicator.Apply(this);
        }
        private void RegisterEvents()
        {
            btnClearFilter.Click += (s, e) => OnClearFilterClick?.Invoke(this, EventArgs.Empty);
        }

        #endregion
        private void CenterControls()
        {
            lblEmptyIcon.Left = (this.Width - lblEmptyIcon.Width) / 2;
            lblEmptyTitle.Left = (this.Width - lblEmptyTitle.Width) / 2;
            lblEmptyDesc.Left = (this.Width - lblEmptyDesc.Width) / 2;
            btnClearFilter.Left = (this.Width - btnClearFilter.Width) / 2;
        }
        #region Overrides
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            CenterControls();
        }
        #endregion
    }
}