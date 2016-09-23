using KcptunLauncher.Controller;
using KcptunLauncher.Util;
using System;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;

namespace KcptunLauncher
{
    static class Program
    {

        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            using (Mutex mutex = new Mutex(false, "Global\\KcptunLauncher_" + AppDomain.CurrentDomain.BaseDirectory.GetHashCode()))
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);

                if (!mutex.WaitOne(0, false))
                {
                    Process[] oldProcesses = Process.GetProcessesByName("KcptunLauncher");
                    if (oldProcesses.Length > 0)
                    {
                        Process oldProcess = oldProcesses[0];
                    }
                    MessageBox.Show("KcptunLauncher已运行");
                    return;
                }
                
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                Application.ThreadException += new ThreadExceptionEventHandler((object sender, ThreadExceptionEventArgs e) =>
                {
                    Logger.GetInstance().SaveCrashLogs(e.Exception);
                });
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler((object sender, UnhandledExceptionEventArgs e) =>
                {
                    Logger.GetInstance().SaveCrashLogs(e.ExceptionObject as Exception);
                });
                Application.ApplicationExit += new EventHandler((object sender, EventArgs e) => { MenuControlController.GetInstance().Exit(); });
                MenuControlController.GetInstance();
                Application.Run();
            }
        }
    }
}
