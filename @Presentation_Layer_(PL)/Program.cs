using DVLD.PL;
using DVLD.PL.Configuration;
using DVLD.PL.Login;
namespace DVLD.PL
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.ThreadException += GlobalExceptionHandler;
            //InitializeConnectionString();
            Application.Run(new frmLoginScreen());
        }
        private static void InitializeConnectionString()
        {
            if (!HandleConfigurationFile.AppSettingExists("ConnectionString"))
            {
                MessageBox.Show(
                    "Connection string is missing in the configuration file. Please set it up before running the application.",
                    "Configuration Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }
            else
            {
                string connectionString = HandleConfigurationFile.GetValueByKey("ConnectionString");
                if (string.IsNullOrWhiteSpace(connectionString))
                {
                    MessageBox.Show(
                        "Connection string is empty in the configuration file. Please set it up before running the application.",
                        "Configuration Error",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Error);
                    return;
                }
                else
                {
                    BLL.Configuration.BllBootstrapper.Initialize(connectionString);
                }
            }
        }
        private static void GlobalExceptionHandler(object sender, ThreadExceptionEventArgs e)
        {
            MessageBox.Show(
                "An unexpected error occurred. Please try again.",
                "Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);

            // Log e.Exception
        }

    }
}
