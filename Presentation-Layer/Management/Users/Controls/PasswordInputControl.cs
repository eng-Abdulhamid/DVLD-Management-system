using DVLD.PL.Global;
using DVLD.PL.Properties;
using DVLD.PL.Theme;
using System.ComponentModel;

namespace DVLD.PL.UsersManagement
{
    [DefaultEvent(nameof(ValidationStateChanged))]
    public partial class PasswordInputControl : UserControl
    {
        private readonly PasswordCriterionView[] _criterionViews;
        private PasswordCriteriaState _criteriaState;

        public PasswordInputControl()
        {
            InitializeComponent();

            txtNewPassword.PasswordChar = '\0';
            txtConfirmPassword.PasswordChar = '\0';

            _criterionViews = FillCritionViews();

            txtConfirmPassword.TextChanged += ConfirmPassword_TextChanged;

            UIUtility.SetupPasswordVisibility(txtNewPassword);
            UIUtility.SetupPasswordVisibility(txtConfirmPassword);

            UpdateCriteria();
            this.ApplyThemeToAll();

            txtNewPassword.ShowClearButton = false;
            txtConfirmPassword.ShowClearButton = false;

            ThemeManager.ThemeChanged += ThemeManager_ThemeChanged;
        }

        private void ThemeManager_ThemeChanged(object? sender, EventArgs e)
        {
            this.ApplyThemeToAll();
            txtNewPassword.ShowClearButton = false;
            txtConfirmPassword.ShowClearButton = false;
            UpdateCriteria();
        }

        private PasswordCriterionView[] FillCritionViews()
        {
            return new PasswordCriterionView[] {
                new(
                    picCheckIfMeetMinimumLength,
                    lblMinimumLength,
                    () => RequireLength,
                    password => MinimumPasswordLength <= password.Length &&
                                password.Length <= MaximumPasswordLength,
                    _ => $"{MinimumPasswordLength} to {MaximumPasswordLength} characters"
                ),

                new(
                    picCheckIfMeetUppercase,
                    lblUppercase,
                    () => RequireUppercase,
                    password => password.Any(char.IsUpper),
                    _ => "At least one uppercase letter"
                ),

                new(
                    picCheckIfMeetLowercase,
                    lblLowercase,
                    () => RequireLowercase,
                    password => password.Any(char.IsLower),
                    _ => "At least one lowercase letter"
                ),

                new(
                    picCheckIfMeetNumber,
                    lblNumber,
                    () => RequireNumber,
                    password => password.Any(char.IsNumber),
                    _ => "At least one number"
                ),

                new(
                    picCheckIfMeetSpecial,
                    lblSpecial,
                    () => RequireSpecialCharacter,
                    password => password.Any(IsSpecialCharacter),
                    _ => "At least one special character"
                )
            };
        }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string NewPassword => txtNewPassword.Text;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public string ConfirmPassword => txtConfirmPassword.Text;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRequirementsMet => _criteriaState.AllMet;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsMatch =>
            !string.IsNullOrEmpty(NewPassword) &&
            NewPassword == ConfirmPassword;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsValid =>
            !string.IsNullOrWhiteSpace(NewPassword) &&
            !string.IsNullOrWhiteSpace(ConfirmPassword) &&
            IsRequirementsMet &&
            IsMatch;

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Obsolete("Use IsRequirementsMet instead.")]
        public bool IsMeetRequirments => IsRequirementsMet;

        [Category("Password")]
        [DefaultValue(8)]
        public int MinimumPasswordLength
        {
            get => _minimumPasswordLength;
            set
            {
                value = Math.Max(1, value);

                if (_minimumPasswordLength == value)
                    return;

                _minimumPasswordLength = value;

                if (_maximumPasswordLength < _minimumPasswordLength)
                    _maximumPasswordLength = _minimumPasswordLength;

                UpdateCriteria();
            }
        }
        private int _minimumPasswordLength = 8;

        [Category("Password")]
        [DefaultValue(128)]
        public int MaximumPasswordLength
        {
            get => _maximumPasswordLength;
            set
            {
                value = Math.Max(MinimumPasswordLength, value);

                if (_maximumPasswordLength == value)
                    return;

                _maximumPasswordLength = value;
                UpdateCriteria();
            }
        }
        private int _maximumPasswordLength = 128;

        [Category("Password")]
        [DefaultValue(true)]
        public bool RequireLength { get; set; } = true;

        [Category("Password")]
        [DefaultValue(true)]
        public bool RequireUppercase { get; set; } = true;

        [Category("Password")]
        [DefaultValue(true)]
        public bool RequireLowercase { get; set; } = true;

        [Category("Password")]
        [DefaultValue(true)]
        public bool RequireNumber { get; set; } = true;

        [Category("Password")]
        [DefaultValue(true)]
        public bool RequireSpecialCharacter { get; set; } = true;

        [Category("Action")]
        public event EventHandler? ValidationStateChanged;

        protected virtual void OnValidationStateChanged()
        {
            ValidationStateChanged?.Invoke(this, EventArgs.Empty);
        }

        public bool ValidatePassword()
        {
            ClearErrors();

            if (string.IsNullOrWhiteSpace(NewPassword))
            {
                ShowFieldError(
                    txtNewPassword,
                    "Please enter a new password.");

                return false;
            }

            if (!IsRequirementsMet)
            {
                ShowFieldError(
                    txtNewPassword,
                    "The password does not meet the requirements.");

                return false;
            }

            if (string.IsNullOrWhiteSpace(ConfirmPassword))
            {
                ShowFieldError(
                    txtConfirmPassword,
                    "Please confirm the new password.");

                return false;
            }

            if (!IsMatch)
            {
                ShowFieldError(
                    txtConfirmPassword,
                    "Passwords do not match.");

                return false;
            }

            return true;
        }

        public void ResetPassword()
        {
            txtNewPassword.ResetText();
            txtConfirmPassword.ResetText();

            ClearErrors();

            UpdateCriteria();
            txtNewPassword.Focus();
        }

        public void FocusNewPassword()
        {
            txtNewPassword.Focus();
        }

        public void FocusConfirmPassword()
        {
            txtConfirmPassword.Focus();
        }

        private void NewPassword_TextChanged(object? sender, EventArgs e)
        {
            ClearErrors();

            UpdateCriteria();
            OnValidationStateChanged();
        }

        private void ConfirmPassword_TextChanged(object? sender, EventArgs e)
        {
            txtConfirmPassword.HasError = false;

            OnValidationStateChanged();
        }

        private void UpdateCriteria()
        {
            _criteriaState = EvaluatePassword(NewPassword);

            foreach (var criterion in _criterionViews)
            {
                bool required = criterion.IsRequired();

                criterion.Icon.Visible = required;
                criterion.Label.Visible = required;

                if (!required)
                    continue;

                bool isMet = criterion.IsMet(NewPassword);

                criterion.Label.Text = $"{criterion.Description("")}";

                ChangeCriteriaStatus(
                    criterion.Icon,
                    criterion.Label,
                    isMet);
            }
        }

        private PasswordCriteriaState EvaluatePassword(string password)
        {
            bool length =
                password.Length >= MinimumPasswordLength &&
                password.Length <= MaximumPasswordLength;

            bool uppercase =
                password.Any(char.IsUpper);

            bool lowercase =
                password.Any(char.IsLower);

            bool number =
                password.Any(char.IsNumber);

            bool special =
                password.Any(IsSpecialCharacter);

            return new PasswordCriteriaState(
                Length: !RequireLength || length,
                Uppercase: !RequireUppercase || uppercase,
                Lowercase: !RequireLowercase || lowercase,
                Number: !RequireNumber || number,
                SpecialCharacter: !RequireSpecialCharacter || special);
        }

        private static bool IsSpecialCharacter(char character)
        {
            return char.IsPunctuation(character) ||
                   char.IsSymbol(character);
        }

        private static void ChangeCriteriaStatus(
            PictureBox pictureBox,
            Label label,
            bool isMet)
        {
            if (isMet)
            {
                pictureBox.Image = Resources._checked;
                //label.ApplyTheme(StatusLabelStyler.Success, label.Text);
            }
            else
            {
                pictureBox.Image = Resources.unChecked;
                //label.ApplyStatusBadge(StatusLabelStyler.Danger, label.Text);
            }
        }

        private void ShowFieldError(
            CustomizeControls.NTextBox control,
            string message)
        {
            control.HasError = true;
            control.Focus();
            control.Shake();

            ////NotificationTheme.ShowErrorToast(
            //    message,
            //    "Validation Error");
        }

        private void ClearErrors()
        {
            txtNewPassword.HasError = false;
            txtConfirmPassword.HasError = false;
        }

        private void btnRandomPassword_Click(object sender, EventArgs e)
        {
            string RandomPassword = UIUtility.GenerateRandomPassword();

            txtNewPassword.Text = RandomPassword;
            txtConfirmPassword.Text = RandomPassword;

            txtNewPassword.SelectionStart = txtNewPassword.Text.Length;
            txtNewPassword.SelectionLength = 0;

            txtConfirmPassword.SelectionStart = txtConfirmPassword.Text.Length;
            txtConfirmPassword.SelectionLength = 0;

            txtNewPassword.Focus();
        }

        private readonly record struct PasswordCriteriaState(
            bool Length,
            bool Uppercase,
            bool Lowercase,
            bool Number,
            bool SpecialCharacter)
        {
            public bool AllMet =>
                Length &&
                Uppercase &&
                Lowercase &&
                Number &&
                SpecialCharacter;
        }

        private sealed record PasswordCriterionView(
            PictureBox Icon,
            Label Label,
            Func<bool> IsRequired,
            Func<string, bool> IsMet,
            Func<string, string> Description);
    }
}