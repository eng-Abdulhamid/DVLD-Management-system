using DVLD.PL.Global;
namespace DVLD.PL.Home
{
    public partial class frmAppSettings : BaseForm
    {
        public frmAppSettings()
        {
            InitializeComponent();
            SetContextTitle("App Settings");
            base.ApplyTheme();
        }   
    }
}
