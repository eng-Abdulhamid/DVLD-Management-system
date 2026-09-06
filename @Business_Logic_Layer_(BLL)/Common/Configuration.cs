using DVLD.DAL.Settings;

namespace DVLD.BLL.Configuration
{
    public static class BllBootstrapper
    {
        public static void Initialize(string connectionString)
        {
            Settings.ConnectionString = connectionString;
        }
    }
}