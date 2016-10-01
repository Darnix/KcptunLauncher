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
        public static string KcptunClientFilePath = AppDomain.CurrentDomain.BaseDirectory + "client_windows_amd64.exe";

        private static MainProcessController _instance;
        public static MainProcessController GetInstance()
        {
            return _instance ?? (_instance = new MainProcessController());
        }

        public Hashtable Processes { get; }

        private MainProcessController()
        {
            Processes = new Hashtable();
        }

        public bool CheckKcptunExists()
        {
            return File.Exists(KcptunClientFilePath);
        }

        public bool CheckKcptunRunning(string serverName)
        {
            return Processes.ContainsKey(serverName);
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
            if (Processes.ContainsKey(server.Name))
            {
                return true;
            }

            if (!File.Exists(KcptunClientFilePath))
            {
                if (System.Windows.Forms.MessageBox.Show("未找到Kcptun客户端，是否查找？", "kcptun", System.Windows.Forms.MessageBoxButtons.YesNo, System.Windows.Forms.MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.Yes)
                {
                    ClientSelectForm csForm = new ClientSelectForm();
                    csForm.ShowDialog();
                }
                return false;
            }

            Process mProcess = new Process();
            mProcess.StartInfo.FileName = KcptunClientFilePath;
            mProcess.StartInfo.Arguments = server.ToString();

            mProcess.StartInfo.UseShellExecute = false;
            mProcess.StartInfo.CreateNoWindow = true;
            mProcess.StartInfo.RedirectStandardError = true;
            mProcess.StartInfo.RedirectStandardInput = true;
            mProcess.StartInfo.RedirectStandardOutput = true;

            mProcess.ErrorDataReceived += (sender, e) => { ProcessLogReceived(mProcess, server, e.Data); };
            mProcess.OutputDataReceived += (sender, e) => { ProcessLogReceived(mProcess, server, e.Data); };

            Processes.Add(server.Name, mProcess);

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
            if (!Processes.ContainsKey(serverName)) return;

            if (Configuration.EnabledServerList.Contains(serverName))
            {
                Configuration.EnabledServerList.Remove(serverName);
            }

            Process mProcess = Processes[serverName] as Process;
            if (mProcess != null && !mProcess.HasExited)
            {
                mProcess.Kill();
                mProcess.CancelErrorRead();
                mProcess.CancelOutputRead();
            }
            Processes.Remove(serverName);
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
