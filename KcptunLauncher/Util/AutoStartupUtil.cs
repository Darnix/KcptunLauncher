using System;
using System.Windows.Forms;
using Microsoft.Win32;

namespace KcptunLauncher.Util
{
    public class AutoStartupUtil
    {
        private static string Key = "KcptunLauncher_" + AppDomain.CurrentDomain.BaseDirectory.GetHashCode();

        public static bool Set(bool enabled)
        {
            RegistryKey runKey = null;
            try
            {
                string path = Application.ExecutablePath;
                runKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                if (enabled)
                {
                    runKey.SetValue(Key, path);
                }
                else
                {
                    runKey.DeleteValue(Key);
                }
                return true;
            }
            catch (Exception e)
            {
                Logger.GetInstance().SaveCrashLogs(e);
                return false;
            }
            finally
            {
                if (runKey != null)
                {
                    try { runKey.Close(); }
                    catch (Exception e)
                    {
                        Logger.GetInstance().SaveCrashLogs(e);
                    }
                }
            }
        }

        public static bool Check()
        {
            RegistryKey runKey = null;
            try
            {
                string path = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                runKey = Registry.CurrentUser.OpenSubKey(@"Software\Microsoft\Windows\CurrentVersion\Run", true);
                string[] runList = runKey.GetValueNames();
                foreach (string item in runList)
                {
                    if (item.Equals(Key, StringComparison.OrdinalIgnoreCase))
                        return true;
                    else if (item.Equals("KcptunLauncher", StringComparison.OrdinalIgnoreCase))
                    {
                        string value = Convert.ToString(runKey.GetValue(item));
                        if (path.Equals(value, StringComparison.OrdinalIgnoreCase))
                        {
                            runKey.DeleteValue(item);
                            runKey.SetValue(Key, path);
                            return true;
                        }
                    }
                }
                return false;
            }
            catch (Exception e)
            {
                Logger.GetInstance().SaveCrashLogs(e);
                return false;
            }
            finally
            {
                if (runKey != null)
                {
                    try { runKey.Close(); }
                    catch (Exception e)
                    {
                        Logger.GetInstance().SaveCrashLogs(e);
                    }
                }
            }
        }
    }
}
