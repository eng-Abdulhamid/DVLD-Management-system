using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
namespace DVLD.PL.PeopleManagement
{
    public partial class ctrlPersonCard : UserControl
    {
        #region Fields & Properties
        private int _personId = -1;
        private PersonService? _personService;
        private PersonService PersonServiceInstance => _personService ??= new PersonService();
        public int PersonID => _personId;
        public PersonReadDTO? SelectedPersonInfo { get; private set; }
        #endregion

        #region Constructor
        public ctrlPersonCard()
        {
            InitializeComponent();
            ResetCard();

            if (UIUtility.IsDesignMode)
                return;
        }
        #endregion

        #region Loading functions
        public async Task LoadPersonInfoAsync(int personId)
        {
            if (UIUtility.IsDesignMode) return;

            if (personId <= 0)
            {
                ResetCard();
                return;
            }

            SetLoadingState();

            OperationResult<PersonReadDTO> result = await PersonServiceInstance.GetByIdAsync(personId);
            HandleLoadResult(result);
        }
        public async Task LoadPersonInfoByNationalNoAsync(string nationalNo)
        {
            if (UIUtility.IsDesignMode) return;

            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                ResetCard();
                return;
            }

            SetLoadingState();

            OperationResult<PersonReadDTO> result = await PersonServiceInstance.GetByNationalNoAsync(nationalNo);
            HandleLoadResult(result);
        }

        public void ResetCard()
        {
            _personId = -1;
            SelectedPersonInfo = null;

            ClearFields();
            ResetPersonImage();
        }

        #endregion

        #region Data Processing & Result Handling

        private void SetLoadingState()
        {
            lblFullName.Text = "Loading details...";
        }
        private void HandleLoadResult(OperationResult<PersonReadDTO> result)
        {
            if (result.IsSuccess && result.Data != null)
            {
                _personId = result.Data.PersonID;
                SelectedPersonInfo = result.Data;
                FillCard(SelectedPersonInfo);
            }
            else
            {
                ResetCard();
            }
        }
        #endregion

        #region UI Filling Methods
        private void FillCard(PersonReadDTO personData)
        {
            FillTextDetails(personData);
            FillPersonImage(personData.ImagePath, personData.Gendor);
        }
        private void FillTextDetails(PersonReadDTO personData)
        {
            lblPersonID.Text = personData.PersonID.ToString();
            lblNationalNo.Text = personData.NationalNo;
            lblFullName.Text = personData.FullName;
            lblEmail.Text = string.IsNullOrWhiteSpace(personData.Email) ? "Not Provided" : personData.Email;
            lblPhone.Text = personData.Phone;
            lblDateOfBirth.Text = $"{personData.DateOfBirth:dd MMM yyyy} ({personData.Age} years)";
            lblGender.Text = personData.Gendor.ToString();
            lblCountry.Text = personData.CountryName;
            lblAddress.Text = personData.Address;
        }
        private void FillPersonImage(string? imagePath, Gendor gender)
        {
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                LoadImageFromFile(imagePath);
            }
            else
            {
                ResetPersonImage();
            }
        }
        private void LoadImageFromFile(string imagePath)
        {
            // Using a memory stream prevents GDI+ from locking the source file on disk
            using var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read);
            pbPersonImage.Image = new Bitmap(stream);
        }
        private void ResetPersonImage()
        {
            pbPersonImage.Image = Resources.User;
        }
        private void ClearFields()
        {
            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "No Person Selected";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGender.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";
        }
        #endregion

        #region Custom Painting
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            DrawCardBorder(e.Graphics);
        }
        private void DrawCardBorder(Graphics graphics)
        {
            using var borderPen = new Pen(Color.FromArgb(226, 232, 240), 1);
            graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
        }
        #endregion
    }
}