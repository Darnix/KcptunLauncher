using KcptunLauncher.DataModel;
using KcptunLauncher.Util;
using KcptunLauncher.View;
using System;
using System.Collections;
using System.Diagnostics;
using System.IO;

namespace KcptunLauncher.Controller
{
    public class MainProcessController
    {
        public static string KCPTUN_CLIENT_FILE_PATH = AppDomain.CurrentDomain.BaseDirectory + "client_windows_amd64.exe";

        private static MainProcessController _Instance;
        public static MainProcessController GetInstance()
        {
            if (_Instance == null) { _Instance = new MainProcessController(); }
            return _Instance;
        }

        private Hashtable mProcesses;
        public Hashtable Processes { get { return mProcesses; } }

        private MainProcessController()
        {
            mProcesses = new Hashtable();
        }

        public bool CheckKcptunExists()
        {
            if (File.Exists(KCPTUN_CLIENT_FILE_PATH))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool CheckKcptunRunning(string serverName)
        {
            return mProcesses.ContainsKey(serverName);
        }

        public EventHandler ProcessLogReceivedHandler;

        public static void KillAllKcptunProcess()
        {
            Process[] processes = Process.GetProcesses();
            foreach (Process mProcess in processes)
            {
                if (mProcess.ProcessName.Equals("client_windows_amd64"))
                {
                    mProcess.Kill();
                }
            }
        }

        public bool Start(Server server)
        {
            if (mProcesses.ContainsKey(server.Name))
            {
                return true;
            }

            if (!File.Exists(KCPTUN_CLIENT_FILE_PATH))
            {
                if (System.Windows.Forms.MessageBox.Show("未找到Kcptun客户端，是否查找？", "kcptun", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ClientSelectForm csForm = new ClientSelectForm();
                    csForm.ShowDialog();
                }
                return false;
            }

            Process mProcess = new Process();
            mProcess.StartInfo.FileName = KCPTUN_CLIENT_FILE_PATH;
            mProcess.StartInfo.Arguments = server.ToString();

            mProcess.StartInfo.UseShellExecute = false;
            mProcess.StartInfo.CreateNoWindow = true;
            mProcess.StartInfo.RedirectStandardError = true;
            mProcess.StartInfo.RedirectStandardInput = true;
            mProcess.StartInfo.RedirectStandardOutput = true;

            mProcess.ErrorDataReceived += new DataReceivedEventHandler((object sender, DataReceivedEventArgs e) => { ProcessLogReceived(mProcess, server, e.Data); });
            mProcess.OutputDataReceived += new DataReceivedEventHandler((object sender, DataReceivedEventArgs e) => { ProcessLogReceived(mProcess, server, e.Data); });

            mProcesses.Add(server.Name, mProcess);

            mProcess.Start();
            mProcess.BeginErrorReadLine();
            mProcess.BeginOutputReadLine();

            return true;
        }

        private void ProcessLogReceived(Process process, Server server, string log)
        {
            Logger.GetInstance().WriteLog(server.Name, log);

            ProcessLogReceivedHandler?.Invoke(process, new ProcessLogReceivedEventArgs()
            {
                ServerName = server.Name,
                Log = log
            });
        }

        public void Stop(string serverName)
        {
            if (mProcesses.ContainsKey(serverName))
            {
                if (Configuration.EnabledServerList.Contains(serverName))
                {
                    Configuration.EnabledServerList.Remove(serverName);
                }
                Process mProcess = mProcesses[serverName] as Process;
                if (!mProcess.HasExited)
                {
                    mProcess.Kill();
                    mProcess.CancelErrorRead();
                    mProcess.CancelOutputRead();
                    mProcess = null;
                }
                mProcesses.Remove(serverName);
            }
        }

        public void StopAll()
        {
            foreach (Server server in Configuration.Servers)
            {
                Stop(server.Name);
            }
        }
    }
}
