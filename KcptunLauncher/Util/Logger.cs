using KcptunLauncher.View;
using System;
using System.IO;
using System.Text;

namespace KcptunLauncher.Util
{
    public class Logger
    {
        private static Logger _Instance;

        public static Logger GetInstance()
        {
            if (_Instance == null) _Instance = new Logger();
            return _Instance;
        }

        private string LOG_FOLDER_PATH = AppDomain.CurrentDomain.BaseDirectory + @"log\";

        private Logger() { }

        public string ReadLogs(string serverName)
        {
            if (!Directory.Exists(LOG_FOLDER_PATH)) { Directory.CreateDirectory(LOG_FOLDER_PATH); }
            return File.ReadAllText(LOG_FOLDER_PATH + serverName + ".log");
        }

        public void WriteLog(string serverName, string log)
        {
            if (!Directory.Exists(LOG_FOLDER_PATH)) { Directory.CreateDirectory(LOG_FOLDER_PATH); }
            string tmp = log + Environment.NewLine;
            File.AppendAllText(LOG_FOLDER_PATH + serverName + ".log", tmp);
        }

        public void ClearLog(string serverName)
        {
            if (!Directory.Exists(LOG_FOLDER_PATH)) { Directory.CreateDirectory(LOG_FOLDER_PATH); }
            File.WriteAllLines(LOG_FOLDER_PATH + serverName + ".log", new string[0]);
        }

        public void UpdateLogFileName(string serverName, string newServerName)
        {
            if (!Directory.Exists(LOG_FOLDER_PATH)) { Directory.CreateDirectory(LOG_FOLDER_PATH); }

            if (File.Exists(LOG_FOLDER_PATH + newServerName + ".log"))
            {
                File.Delete(LOG_FOLDER_PATH + newServerName + ".log");
            }

            if (File.Exists(LOG_FOLDER_PATH + serverName + ".log"))
            {
                File.Move(LOG_FOLDER_PATH + serverName + ".log", LOG_FOLDER_PATH + newServerName + ".log");
            }
        }

        public void SaveCrashLogs(Exception e)
        {
            if (!Directory.Exists(LOG_FOLDER_PATH)) { Directory.CreateDirectory(LOG_FOLDER_PATH); }

            File.AppendAllText(LOG_FOLDER_PATH + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".log",
                GenerateExceptionMessage(e));

            LogDetailForm f = new LogDetailForm(e.GetType().Name, e.Message + Environment.NewLine + e.StackTrace, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));
            f.ShowDialog();
        }

        public string GenerateExceptionMessage(Exception e)
        {
            if (e == null) { return ""; }

            StringBuilder exBuilder = new StringBuilder();
            exBuilder.AppendLine("time:" + DateTime.Now.ToString())
                    .AppendLine("type:" + e.GetType().Name)
                    .AppendLine("message:" + e.Message)
                    .AppendLine("stackTrace：" + e.StackTrace);
            return exBuilder.ToString();
        }
    }
}
