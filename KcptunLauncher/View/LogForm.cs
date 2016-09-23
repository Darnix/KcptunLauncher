using KcptunLauncher.DataModel;
using KcptunLauncher.Util;
using System;
using System.Windows.Forms;

namespace KcptunLauncher.View
{
    public partial class LogForm : Form
    {

        public LogForm()
        {
            InitializeComponent();
            LoadServers();
        }

        private void LoadServers()
        {
            Configuration.Servers.ForEach(mServer =>
            {
                if (Configuration.EnabledServerList.Contains(mServer.Name))
                {
                    ToolStripMenuItem mItem = new ToolStripMenuItem(mServer.Name);
                    mItem.Tag = mServer;
                    mItem.Click += new EventHandler((object sender, EventArgs e) =>
                    {
                        for (int i = 0, n = serverMenuItem.DropDownItems.Count; i < n; i++)
                        {
                            ToolStripMenuItem _Item = serverMenuItem.DropDownItems[i] as ToolStripMenuItem;
                            _Item.Checked = _Item.Text.Equals(mServer.Name);
                            if (_Item.Checked)
                            {
                                InitLog(_Item.Tag as Server);
                            }
                        }
                    });
                    serverMenuItem.DropDownItems.Add(mItem);
                }
            });
        }

        private void InitLog(Server server)
        {
            Text = "日志" + " - " + server.Name;
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
            if (serverMenuItem.DropDownItems.Count > 0)
            {
                (serverMenuItem.DropDownItems[0] as ToolStripMenuItem).Checked = true;
                InitLog(serverMenuItem.DropDownItems[0].Tag as Server);
            }
        }

        private void clearLogMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(this, "是否清空日志？", "清空日志", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            if (serverMenuItem.DropDownItems.Count > 0)
            {
                for (int i = 0, n = serverMenuItem.DropDownItems.Count; i < n; i++)
                {
                    ToolStripMenuItem _Item = serverMenuItem.DropDownItems[i] as ToolStripMenuItem;
                    if (_Item.Checked)
                    {
                        Logger.GetInstance().ClearLog((_Item.Tag as Server).Name);
                        mLogBox.Text = "";
                        mLogBox.ScrollToCaret();
                    }
                }
            }
        }
    }
}
