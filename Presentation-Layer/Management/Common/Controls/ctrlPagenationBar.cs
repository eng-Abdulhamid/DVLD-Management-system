using DVLD.PL.Global;
using DVLD.PL.Theme;
using System.ComponentModel;

namespace DVLD.PL.Management
{
    public partial class ctrlPagination : UserControl
    {
        #region Properites and the Constructor
        private bool _isInitializing = true;
        [Category("Pagination")]
        public event EventHandler? OnPageChanged;
        [Category("Pagination")]
        public event EventHandler? OnPageSizeChanged;
        [Category("Pagination")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int PageSize
        {
            get => int.TryParse(cmbPageSize.Text, out int size) ? size : 25;
            set
            {
                cmbPageSize.Text = value.ToString();
                UpdateUI();
            }
        }

        [Category("Pagination")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int CurrentPage
        {
            get => field;
            set
            {
                field = Math.Max(1, value);
                UpdateUI();
            }
        }

        [Category("Pagination")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalRecords
        {
            get => field;
            set
            {
                field = Math.Max(0, value);
                UpdateUI();
            }
        }
        public ctrlPagination()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            InitializeComboBox();
            RegisterEvents();

            _isInitializing = false;
        }
        private void InitializeComboBox()
        {
            cmbPageSize.Items.Clear();
            cmbPageSize.Items.AddRange(new object[] { "10", "25", "50", "100" });
            cmbPageSize.SelectedIndex = 1; 
        }
        #region Event Registration
        private void RegisterEvents()
        {
            btnNextPage.Click += BtnNextPage_Click;
            btnPrevPage.Click += BtnPrevPage_Click;
            cmbPageSize.SelectedIndexChanged += CmbPageSize_SelectedIndexChanged;
        }
        private void BtnNextPage_Click(object? sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);
            if (CurrentPage < totalPages)
            {
                CurrentPage++;
                UpdateUI();
                OnPageChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void BtnPrevPage_Click(object? sender, EventArgs e)
        {
            if (CurrentPage > 1)
            {
                CurrentPage--;
                UpdateUI();
                OnPageChanged?.Invoke(this, EventArgs.Empty);
            }
        }
        private void CmbPageSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;

            CurrentPage = 1;
            UpdateUI();
            OnPageSizeChanged?.Invoke(this, EventArgs.Empty);
        }
        #endregion
        #endregion
        public void UpdateUI()
        {
            if (TotalRecords == 0)
            {
                lblPaginationInfo.Text = "0-0 of 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
                return;
            }

            int totalPages = (int)Math.Ceiling((double)TotalRecords / PageSize);

            if (CurrentPage > totalPages) CurrentPage = totalPages;
            if (CurrentPage < 1) CurrentPage = 1;

            int startRecord = ((CurrentPage - 1) * PageSize) + 1;

            int endRecord = Math.Min(CurrentPage * PageSize, TotalRecords);

            lblPaginationInfo.Text = $"{startRecord}-{endRecord} of {TotalRecords}";

            btnPrevPage.Enabled = CurrentPage > 1;
            btnNextPage.Enabled = TotalRecords < totalPages;

            this.ApplyThemeToAll();
        }
        public void Reset()
        {
            TotalRecords = 1;
            UpdateUI();
        }
    }
}