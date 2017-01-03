using KcptunLauncher.View;
using KcptunLauncher.Properties;
using Newtonsoft.Json.Linq;
using System;
using System.Windows.Forms;
using KcptunLauncher.DataModel;
using KcptunLauncher.Util;

namespace KcptunLauncher.Controller
{
    public class MenuControlController
    {
        private static MenuControlController _instance;
        public static MenuControlController GetInstance()
        {
            return _instance ?? (_instance = new MenuControlController());
        }

        private readonly NotifyIcon _notifyIcon;
        private ContextMenu _contextMenu;

        private MenuItem _enableAllServerItem;
        private MenuItem _disableAllServerItem;

        private MenuItem _serversItem;
        private MenuItem _configItem;

        private MenuItem _autoStartupItem;
        private MenuItem _autoCheckUpdateItem;

        private MenuItem _logItem;

        private MenuItem _aboutItem;

        private readonly MainProcessController _processCtler;
        private LogForm _logForm;

        private MenuControlController()
        {
            Configuration.Load();
            CreateMenu();

            _notifyIcon = new NotifyIcon
            {
                Icon = Resources.icon,
                Visible = true,
                ContextMenu = _contextMenu
            };
            _notifyIcon.BalloonTipClicked += (sender, e) =>
            {
                UpdateController updateCtllr = UpdateController.GetInstance();
                if (updateCtllr.LatestRelease != null)
                {
                    updateCtllr.StartUpdating(updateCtllr.LatestRelease);
                }
            };

            MainProcessController.KillAllKcptunProcess();

            _processCtler = MainProcessController.GetInstance();
            _processCtler.ProcessLogReceivedHandler += mProcessCtler_ProcessLogReceived;

            if (!_processCtler.CheckKcptunExists())
            {
                Configuration.EnabledServerList.Clear();
                Configuration.UpdateEnabledServerList();

                ClientSelectForm dlg = new ClientSelectForm();
                dlg.ShowDialog();
            }

            foreach (Server server in Configuration.Servers)
            {
                if (Configuration.EnabledServerList.Contains(server.Name))
                    _processCtler.Start(server);
            }
            LoadServersMenuItem();
        }

        public void LoadServersMenuItem()
        {
            while (_serversItem.MenuItems[0] != _enableAllServerItem)
            {
                _serversItem.MenuItems.RemoveAt(0);
            }
            for (int i = 0, n = Configuration.Servers.Count; i < n; i++)
            {
                Server mServer = Configuration.Servers[i];
                MenuItem mServerItem = new MenuItem(mServer.Name, serverItem_Click)
                {
                    Tag = mServer,
                    Checked = _processCtler.CheckKcptunRunning(mServer.Name)
                };
                _serversItem.MenuItems.Add(i, mServerItem);
            }
            UpdateNotificationText();
        }

        public void UpdateServersMenuItemsStatus()
        {
            foreach (MenuItem mItem in _serversItem.MenuItems)
            {
                mItem.Checked = Configuration.EnabledServerList.Contains(mItem.Text);
            }
        }

        private void CreateMenu()
        {
            this._contextMenu = new ContextMenu(new MenuItem[] {
                _serversItem = new MenuItem("服务器", new MenuItem[] {
                    _enableAllServerItem = new MenuItem("启用所有服务器", this.enableAllServerItem_Click),
                    _disableAllServerItem = new MenuItem("停用所有服务器", this.disableAllServerItem_Click),
                    new MenuItem("-"),
                    _configItem = new MenuItem("编辑服务器", this.configItem_Click)
                }),
                new MenuItem("-"),
                _autoStartupItem = new MenuItem("开机自启动", this.autoStartupItem_Click),
                new MenuItem("-"),
                _logItem = new MenuItem("显示日志", this.logItem_Click),
                new MenuItem("更新", new MenuItem[]
                {
                    new MenuItem("检查更新", this.checkUpdateItem_Click),
                    new MenuItem("-"),
                   _autoCheckUpdateItem = new MenuItem("启动时检查更新", this.autoCheckUpdateItem_Click)
                }),
                _aboutItem = new MenuItem("关于", this.aboutItem_Click),
                new MenuItem("-"),
                new MenuItem("退出", this.exitItem_Click)
            });
            _autoStartupItem.Checked = AutoStartupUtil.Check();

            if (Configuration.GetConfigFile()["autoCheckUpdate"] == null)
            {
                JObject loCfg = Configuration.GetConfigFile();
                loCfg["autoCheckUpdate"] = false;
                Configuration.SaveConfigFile(loCfg);
            }
            _autoCheckUpdateItem.Checked = (bool)Configuration.GetConfigFile()["autoCheckUpdate"];
            if (_autoCheckUpdateItem.Checked) UpdateController.GetInstance().StartChecking(true);
            UpdateController.GetInstance().StartCheckingKcptun();
        }

        public void UpdateNotificationText()
        {
            _notifyIcon.Text = "KcptunLauncher " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString()
                             + Environment.NewLine
                             + (Configuration.EnabledServerList.Count > 0 ? "正在运行的服务器" : "无正在运行的服务器")
                             + Environment.NewLine;
            Configuration.EnabledServerList.ForEach(enabledServer => { _notifyIcon.Text += enabledServer + Environment.NewLine; });
        }

        public void ShowNotification(int timeout, string title, string text, ToolTipIcon icon, EventHandler handler)
        {
            _notifyIcon.ShowBalloonTip(timeout, title, text, icon);
            _notifyIcon.BalloonTipClicked += handler;
        }

        public void Exit()
        {
            _processCtler.StopAll();
            _notifyIcon.Visible = false;
        }

        private void enableAllServerItem_Click(object sender, EventArgs e)
        {
            foreach (Server mServer in Configuration.Servers)
                Configuration.EnabledServerList.Add(mServer.Name);
            foreach (Server server in Configuration.Servers)
                _processCtler.Start(server);
            UpdateServersMenuItemsStatus();
            Configuration.UpdateEnabledServerList();
            UpdateNotificationText();
        }

        private void disableAllServerItem_Click(object sender, EventArgs e)
        {
            foreach (Server server in Configuration.Servers)
                _processCtler.Stop(server.Name);
            Configuration.EnabledServerList.Clear();
            UpdateServersMenuItemsStatus();
            Configuration.UpdateEnabledServerList();
            UpdateNotificationText();
        }

        private void configItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        private void autoStartupItem_Click(object sender, EventArgs e)
        {
            _autoStartupItem.Checked = !_autoStartupItem.Checked;
            AutoStartupUtil.Set(_autoStartupItem.Checked);
        }

        private void autoCheckUpdateItem_Click(object sender, EventArgs e)
        {
            _autoCheckUpdateItem.Checked = !_autoCheckUpdateItem.Checked;

            JObject loCfg = Configuration.GetConfigFile();
            loCfg["autoCheckUpdate"] = _autoCheckUpdateItem.Checked;
            Configuration.SaveConfigFile(loCfg);
        }

        private void checkUpdateItem_Click(object sender, EventArgs e)
        {
            UpdateController.GetInstance().StartChecking(false);
        }

        private void logItem_Click(object sender, EventArgs e)
        {
            if (_logForm == null || _logForm.IsDisposed)
            {
                _logForm = new LogForm();
            }
            _logForm.Show();
        }

        private void serverItem_Click(object sender, EventArgs e)
        {
            MenuItem mServerItem = sender as MenuItem;
            if (mServerItem == null) return;
            mServerItem.Checked = !mServerItem.Checked;

            if (mServerItem.Checked)
            {
                if (!_processCtler.Start(mServerItem.Tag as Server))
                {
                    mServerItem.Checked = false;
                    return;
                }
                foreach (string enableServer in Configuration.EnabledServerList)
                {
                    if (enableServer.Equals((mServerItem.Tag as Server).Name))
                    {
                        break;
                    }
                }
                Configuration.EnabledServerList.Add((mServerItem.Tag as Server).Name);
            }
            else
            {
                _processCtler.Stop(mServerItem.Text);
                foreach (string enableServer in Configuration.EnabledServerList)
                {
                    if (enableServer.Equals((mServerItem.Tag as Server).Name))
                    {
                        Configuration.EnabledServerList.Remove(enableServer);
                        break;
                    }
                }
            }
            JObject cfgJObj = Configuration.GetConfigFile();
            if (cfgJObj != null)
            {
                JArray jArr = new JArray();
                foreach (string enableServer in Configuration.EnabledServerList)
                {
                    jArr.Add(enableServer);
                }

                cfgJObj.Remove("enabledServer");
                cfgJObj.Add("enabledServer", jArr);
                Configuration.SaveConfigFile(cfgJObj);
            }
            UpdateNotificationText();
        }

        private void aboutItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/Darnix/KcptunLauncher");
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        public void mProcessCtler_ProcessLogReceived(object sender, EventArgs e)
        {
            if (_logForm == null) return;

            ProcessLogReceivedEventArgs args = e as ProcessLogReceivedEventArgs;
            _logForm.UpdateLog(args.Log + Environment.NewLine);
        }
    }
}
