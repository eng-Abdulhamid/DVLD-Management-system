using DVLD.BLL.DTOs;
using DVLD.BLL.Enums;
using DVLD.BLL.OperationResults;
using DVLD.BLL.Services;
using DVLD.PL.Global;
using DVLD.PL.Properties;
using System.Drawing;
using System.IO;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD.PL.PeopleManagement
{
    public partial class ctrlPersonCard : UserControl
    {
        private int _personId = -1;
        private PersonService? _personService;
        private PersonService PersonServiceInstance => _personService ??= new PersonService();

        public int PersonID => _personId;
        public PersonReadDTO? SelectedPersonInfo { get; private set; }

        public ctrlPersonCard()
        {
            InitializeComponent();
            ResetCard();

            if (UIUtility.IsDesignMode)
                return;
        }

        public async Task LoadPersonInfoAsync(int personId)
        {
            if (UIUtility.IsDesignMode) return;

            _personId = personId;

            if (personId <= 0)
            {
                ResetCard();
                return;
            }

            lblFullName.Text = "Loading details...";

            OperationResult<PersonReadDTO> result = await PersonServiceInstance.GetByIdAsync(personId);

            if (result.IsSuccess && result.Data != null)
            {
                SelectedPersonInfo = result.Data;
                PopulateCard(SelectedPersonInfo);
            }
            else
            {
                ResetCard();
            }
        }

        public async Task LoadPersonInfoByNationalNoAsync(string nationalNo)
        {
            if (UIUtility.IsDesignMode) return;

            if (string.IsNullOrWhiteSpace(nationalNo))
            {
                ResetCard();
                return;
            }

            lblFullName.Text = "Loading details...";

            OperationResult<PersonReadDTO> result = await PersonServiceInstance.GetByNationalNoAsync(nationalNo);

            if (result.IsSuccess && result.Data != null)
            {
                _personId = result.Data.PersonID;
                SelectedPersonInfo = result.Data;
                PopulateCard(SelectedPersonInfo);
            }
            else
            {
                ResetCard();
            }
        }

        private void PopulateCard(PersonReadDTO personData)
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

            LoadPersonImage(personData.ImagePath, personData.Gendor == Gendor.Male);
        }

        private void LoadPersonImage(string imagePath, bool isMale)
        {
            if (!string.IsNullOrWhiteSpace(imagePath) && File.Exists(imagePath))
            {
                using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                {
                    pbPersonImage.Image = Image.FromStream(stream);
                }
            }
            else
            {
                pbPersonImage.Image = Resources.User;
            }
        }

        public void ResetCard()
        {
            _personId = -1;
            SelectedPersonInfo = null;

            lblPersonID.Text = "[????]";
            lblNationalNo.Text = "[????]";
            lblFullName.Text = "No Person Selected";
            lblEmail.Text = "[????]";
            lblPhone.Text = "[????]";
            lblDateOfBirth.Text = "[????]";
            lblGender.Text = "[????]";
            lblCountry.Text = "[????]";
            lblAddress.Text = "[????]";

            pbPersonImage.Image = Resources.User;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            using (Pen borderPen = new Pen(Color.FromArgb(226, 232, 240), 1))
            {
                e.Graphics.DrawRectangle(borderPen, 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}