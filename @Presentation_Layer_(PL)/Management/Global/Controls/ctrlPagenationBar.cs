using DVLD.PL.Global;
using DVLD.PL.Theme;
using System.ComponentModel;

namespace DVLD.PL.Management
{
    [DefaultEvent("OnPageChanged")]
    public partial class ctrlPagination : UserControl
    {
        #region Properites and the Constructor
        private int _totalRecords = 0;
        private int _currentPage = 1;
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
            cmbPageSize.SelectedIndex = 1; // Default to 25
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


        #endregion
        #endregion
        public void UpdateUI()
        {
            if (_totalRecords == 0)
            {
                lblPaginationInfo.Text = "0-0 of 0";
                btnPrevPage.Enabled = false;
                btnNextPage.Enabled = false;
                return;
            }

            int totalPages = (int)Math.Ceiling((double)_totalRecords / PageSize);

            if (_currentPage > totalPages) _currentPage = totalPages;
            if (_currentPage < 1) _currentPage = 1;

            int startRecord = ((_currentPage - 1) * PageSize) + 1;

            int endRecord = Math.Min(_currentPage * PageSize, _totalRecords);

            lblPaginationInfo.Text = $"{startRecord}-{endRecord} of {_totalRecords}";

            btnPrevPage.Enabled = _currentPage > 1;
            btnNextPage.Enabled = _currentPage < totalPages;

            ThemeApplicator.Apply(this);
        }
        public void Reset()
        {
            _currentPage = 1;
            UpdateUI();
        }
    }
}