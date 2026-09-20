using System.ComponentModel;
namespace DVLD.PL
{
    public partial class ctrlButtonSettingsLayout : UserControl
    {
        public enum enButtonType
        {
            Primary = 0,
            Secondary = 1,
            Danger = 2,
            Disabled = 3
        };

        [Category("Button Settings")]
        [DisplayName("Button Description")]
        [Description("The description displayed above the button.")]
        [DefaultValue("Description")]
        public string ButtonDescription
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }

        [Category("Button Settings")]
        [DisplayName("Button Name")]
        [Description("Choose Button Type which will appear for the user.")]
        [DefaultValue(enButtonType.Primary)]
        public enButtonType ButtonType
        {
            get => field;
            set
            {
                field = value;

                btn.Text = value switch
                {
                    enButtonType.Primary => "Primary",
                    enButtonType.Secondary => "Secondary",
                    enButtonType.Danger => "Danger",
                    enButtonType.Disabled => "Disabled",
                    _ => string.Empty
                };
            }
        }
        public ctrlButtonSettingsLayout()
        {
            InitializeComponent();

            CenterControls();

            Resize += ctrlBtnSettings_Resize;
        }
        private void ctrlBtnSettings_Resize(object? sender, EventArgs e)
        {
            CenterControls();
        }
        private void CenterControls()
        {
            lblDescription.Location = new Point(
                0,
                lblDescription.Top
            );

            lblDescription.Width = ClientSize.Width;

            btn.Left = (ClientSize.Width - btn.Width) / 2;

            label5.Left = (ClientSize.Width - label5.Width) / 2;
        }
    }
}