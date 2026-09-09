using DVLD.PL.Global;
using System.ComponentModel;
using static DVLD.PL.Global.UITheme;

namespace DVLD.PL.Management
{
    [DefaultEvent("OnPageChanged")]
    public partial class ctrlPagination : UserControl
    {
        #region Fields
        private int _totalRecords = 0;
        private int _currentPage = 1;
        private bool _isInitializing = true;
        #endregion

        #region Events
        [Category("Pagination")]
        public event EventHandler? OnPageChanged;

        [Category("Pagination")]
        public event EventHandler? OnPageSizeChanged;
        #endregion

        #region Properties
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
            get => _currentPage;
            set
            {
                _currentPage = Math.Max(1, value);
                UpdateUI();
            }
        }

        [Category("Pagination")]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public int TotalRecords
        {
            get => _totalRecords;
            set
            {
                _totalRecords = Math.Max(0, value);
                UpdateUI();
            }
        }
        #endregion

        public ctrlPagination()
        {
            InitializeComponent();

            if (UIUtility.IsDesignMode) return;

            InitializeComboBox();
            ApplyStyles();
            RegisterEvents();

            _isInitializing = false;
        }

        private void InitializeComboBox()
        {
            cmbPageSize.Items.Clear();
            cmbPageSize.Items.AddRange(new object[] { "10", "25", "50", "100" });
            cmbPageSize.SelectedIndex = 1; // Default to 25
        }

        private void ApplyStyles()
        {
            btnPrevPage.ApplySecondaryStyle();
            btnNextPage.ApplySecondaryStyle();
            cmbPageSize.ApplyStandardStyle();

            btnPrevPage.Text = string.Empty;
            btnNextPage.Text = string.Empty;
        }

        private void RegisterEvents()
        {
            btnNextPage.Click += BtnNextPage_Click;
            btnPrevPage.Click += BtnPrevPage_Click;
            cmbPageSize.SelectedIndexChanged += CmbPageSize_SelectedIndexChanged;
        }

        private void BtnNextPage_Click(object? sender, EventArgs e)
        {
            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);
            if (_currentPage < totalPages)
            {
                _currentPage++;
                UpdateUI();
                OnPageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void BtnPrevPage_Click(object? sender, EventArgs e)
        {
            if (_currentPage > 1)
            {
                _currentPage--;
                UpdateUI();
                OnPageChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private void CmbPageSize_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (_isInitializing) return;

            _currentPage = 1; 
            UpdateUI();
            OnPageSizeChanged?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Updates the pagination UI elements including the record range text and button states.
        /// </summary>
        public void UpdateUI()
        {
            // Handle the empty state when there are no records to display.
            if (_totalRecords == 0)
            {
                lblPaginationInfo.Text = "0-0 of 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
                return;
            }

            // Calculate the total number of pages required to display all records.
            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);

            // Prevent the current page from exceeding the valid range limits.
            if (_currentPage > totalPages) _currentPage = totalPages;
            if (_currentPage < 1) _currentPage = 1;

            // Calculate the starting record number for the current page.
            int startRecord = ((_currentPage - 1) * PageSize) + 1;

            // Calculate the ending record number, ensuring it does not exceed the total records.
            int endRecord = Math.Min(_currentPage * PageSize, _totalRecords);

            // Display the calculated range to the user.
            lblPaginationInfo.Text = $"{startRecord}-{endRecord} of {_totalRecords}";

            // Enable or disable navigation buttons based on the current page position.
            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < totalPages;

            // Reapply visual themes to reflect the enabled/disabled state of the buttons.
            ApplyStyles();
        }

        /// <summary>
        /// Resets the pagination to the first page and updates the UI accordingly.
        /// </summary>
        public void Reset()
        {
            _currentPage = 1;
            UpdateUI();
        }
    }
}