using System;
using System.IO;
using System.Text;
namespace DataAccessLayer
{
    //public enum enResult
    //{
    //    Success = 0,
    //    NotFound = 1,
    //    DataBaseError = 2,


    //}
    internal class Logs
    {
        public enum enType { Error = 0, Info = 1 };
        private static StringBuilder _PrepareLogLine(enType TypeOfLog, string LogDetails)
        {
            StringBuilder LogMessage = new StringBuilder();
            LogMessage.Append("[");
            LogMessage.Append(DateTime.Now.ToString("dd/MM/yyyy"));
            LogMessage.Append("] ");
            switch (TypeOfLog)
            {
                case enType.Error:
                    {
                        LogMessage.Append("Error");
                        break;
                    }
                case enType.Info:
                    {
                        LogMessage.Append("Info");
                        break;
                    }
            }
            LogMessage.Append(": ");
            LogMessage.Append(LogDetails);
            return LogMessage;

        }
        internal static void AppendLog(enType typeOfLog, string logDetails)
        {
            string basePath = AppDomain.CurrentDomain.BaseDirectory;
            string logFilePath = Path.Combine(basePath, "dvld.log");

            if (!File.Exists(logFilePath))
            {
                using (File.Create(logFilePath)) { }
            }

            File.AppendAllText(
                logFilePath,
                _PrepareLogLine(typeOfLog, logDetails) + Environment.NewLine
            );
        }
    }
}
