using System.ComponentModel;
namespace DVLD.PL
{
    public partial class ctrlBtnSettings : UserControl
    {

        [Category("Button Settings")]
        [DisplayName("Button Description")]
        [Description("The description displayed above the button.")]
        [DefaultValue("Description")]
        public string ButtonDescription 
        {
            get => lblDescription.Text;
            set => lblDescription.Text = value;
        }
        public enum enButtonType 
        { 
            Primary = 0, 
            Secondary = 1, 
            Danger = 2, 
            Disabled = 3
        };
        [DefaultValue(enButtonType.Primary)]
        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public enButtonType ButtonType
        {
            get;
            set;
        }
        public ctrlBtnSettings()
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