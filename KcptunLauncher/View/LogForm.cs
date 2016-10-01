using KcptunLauncher.DataModel;
using KcptunLauncher.Util;
using System;
using System.Drawing;
using System.Windows.Forms;
using Newtonsoft.Json.Linq;

namespace KcptunLauncher.View
{
    public partial class LogForm : Form
    {

        public LogForm()
        {
            InitializeComponent();
            LoadServers();

            bool saveConfig = false;
            JObject loCfg = Configuration.GetConfigFile();
            if (loCfg["logFont"] == null) { loCfg["logFont"] = new JObject(); saveConfig = true; }
            if (loCfg["logFont"]["family"] == null) { loCfg["logFont"]["family"] = "Consolas"; saveConfig = true; }
            if (loCfg["logFont"]["size"] == null) { loCfg["logFont"]["size"] = 9f; saveConfig = true; }
            if (saveConfig) Configuration.SaveConfigFile(loCfg);

            mLogBox.Font = new Font((string)loCfg["logFont"]["family"], (float)loCfg["logFont"]["size"], FontStyle.Regular);
        }

        private void LoadServers()
        {
            Configuration.Servers.ForEach(mServer =>
            {
                if (!Configuration.EnabledServerList.Contains(mServer.Name)) return;

                ToolStripMenuItem mItem = new ToolStripMenuItem(mServer.Name);
                mItem.Tag = mServer;
                mItem.Click += (sender, e) =>
                {
                    for (int i = 0, n = serverMenuItem.DropDownItems.Count; i < n; i++)
                    {
                        ToolStripMenuItem item = serverMenuItem.DropDownItems[i] as ToolStripMenuItem;
                        item.Checked = item.Text.Equals(mServer.Name);
                        if (item.Checked)
                        {
                            InitLog(item.Tag as Server);
                        }
                    }
                };
                serverMenuItem.DropDownItems.Add(mItem);
            });
        }

        private void InitLog(Server server)
        {
            Text = "日志 - " + server.Name;
            mLogBox.Text = Logger.GetInstance().ReadLogs(server.Name);
            mLogBox.SelectionStart = mLogBox.Text.Length > 0 ? mLogBox.Text.Length - 1 : 0;
            mLogBox.ScrollToCaret();
        }

        private delegate void updateDelegate(string msg);
        public void UpdateLog(string msg)
        {
            if (this.InvokeRequired)
                Invoke(new updateDelegate(UpdateLog), new object[] { msg });
            else
            {
                if (IsDisposed || mLogBox.IsDisposed) return;

                mLogBox.Text += msg;
                mLogBox.SelectionStart = mLogBox.Text.Length > 0 ? mLogBox.Text.Length - 1 : 0;
                mLogBox.ScrollToCaret();
            }
        }

        private void LogForm_Shown(object sender, EventArgs e)
        {
            if (serverMenuItem.DropDownItems.Count <= 0) return;
            (serverMenuItem.DropDownItems[0] as ToolStripMenuItem).Checked = true;
            InitLog(serverMenuItem.DropDownItems[0].Tag as Server);
        }

        private void clearLogMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否清空日志？", "清空日志", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (serverMenuItem.DropDownItems.Count <= 0) return;

            for (int i = 0, n = serverMenuItem.DropDownItems.Count; i < n; i++)
            {
                ToolStripMenuItem item = serverMenuItem.DropDownItems[i] as ToolStripMenuItem;
                if (item.Checked)
                {
                    Logger.GetInstance().ClearLog((item.Tag as Server).Name);
                    mLogBox.Text = "";
                    mLogBox.ScrollToCaret();
                }
            }
        }

        private void fontMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog f = new FontDialog { Font = mLogBox.Font };
            if (f.ShowDialog() != DialogResult.OK) return;

            bool saveConfig = false;
            JObject loCfg = Configuration.GetConfigFile();
            if (loCfg["logFont"] == null)
            {
                loCfg["logFont"] = new JObject();
                saveConfig = true;
            }
            if (loCfg["logFont"]["family"] == null || !loCfg["logFont"]["family"].ToString().Equals(f.Font.FontFamily.Name))
            {
                loCfg["logFont"]["family"] = f.Font.FontFamily.Name;
                saveConfig = true;
            }
            if (loCfg["logFont"]["size"] == null || Math.Abs((float)loCfg["logFont"]["size"] - f.Font.Size) > 0)
            {
                loCfg["logFont"]["size"] = f.Font.Size;
                saveConfig = true;
            }
            if (saveConfig) Configuration.SaveConfigFile(loCfg);

            mLogBox.Font = new Font(f.Font.FontFamily, f.Font.Size, f.Font.Style);

        }
    }
}
