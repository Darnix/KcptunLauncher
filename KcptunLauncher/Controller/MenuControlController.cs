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
        private static MenuControlController _Instance;
        public static MenuControlController GetInstance()
        {
            if (_Instance == null)
            {
                _Instance = new MenuControlController();
            }
            return _Instance;
        }

        private NotifyIcon mNotifyIcon;
        private ContextMenu mContextMenu;

        private MenuItem enableAllServerItem;
        private MenuItem disableAllServerItem;

        private MenuItem serversItem;
        private MenuItem configItem;

        private MenuItem autoStartupItem;

        private MenuItem logItem;

        private MainProcessController mProcessCtler;
        private LogForm mLogForm;

        private MenuControlController()
        {
            Configuration.Load();
            CreateMenu();

            mNotifyIcon = new NotifyIcon();
            mNotifyIcon.Icon = Resources.icon;
            mNotifyIcon.Visible = true;
            mNotifyIcon.ContextMenu = mContextMenu;

            MainProcessController.KillAllKcptunProcess();

            mProcessCtler = MainProcessController.GetInstance();
            mProcessCtler.ProcessLogReceivedHandler += new EventHandler(_ProcessLogReceived);

            if (!mProcessCtler.CheckKcptunExists())
            {
                Configuration.EnabledServerList.Clear();
                Configuration.UpdateEnabledServerList();

                ClientSelectForm dlg = new ClientSelectForm();
                dlg.ShowDialog();
            }

            foreach (Server server in Configuration.Servers)
            {
                if (Configuration.EnabledServerList.Contains(server.Name))
                    mProcessCtler.Start(server);
            }
            LoadServersMenuItem();
        }

        public void LoadServersMenuItem()
        {
            while (serversItem.MenuItems[0] != enableAllServerItem)
            {
                serversItem.MenuItems.RemoveAt(0);
            }
            for (int i = 0, n = Configuration.Servers.Count; i < n; i++)
            {
                Server mServer = Configuration.Servers[i];
                MenuItem mServerItem = new MenuItem(mServer.Name, new EventHandler(serverItem_Click));
                mServerItem.Tag = mServer;
                mServerItem.Checked = mProcessCtler.CheckKcptunRunning(mServer.Name);
                serversItem.MenuItems.Add(i, mServerItem);
            }
        }

        public void UpdateServersMenuItemsStatus()
        {
            foreach (MenuItem mItem in serversItem.MenuItems)
            {
                mItem.Checked = Configuration.EnabledServerList.Contains(mItem.Text);
            }
        }

        private void CreateMenu()
        {
            this.mContextMenu = new ContextMenu(new MenuItem[] {
                serversItem = new MenuItem("服务器", new MenuItem[] {
                    enableAllServerItem = new MenuItem("启用所有服务器", new EventHandler(this.enableAllServerItem_Click)),
                    disableAllServerItem = new MenuItem("停用所有服务器", new EventHandler(this.disableAllServerItem_Click)),
                    new MenuItem("-"),
                    configItem = new MenuItem("编辑服务器", new EventHandler(this.configItem_Click))
                }),
                new MenuItem("-"),
                autoStartupItem = new MenuItem("开机自启动", new EventHandler(this.autoStartupItem_Click)),
                new MenuItem("-"),
                logItem = new MenuItem("显示日志", new EventHandler(this.logItem_Click)),
                new MenuItem("退出", new EventHandler(this.exitItem_Click))
            });
            autoStartupItem.Checked = AutoStartupUtil.Check();
        }

        public void Exit()
        {
            mProcessCtler.StopAll();
            mNotifyIcon.Visible = false;
        }

        private void enableAllServerItem_Click(object sender, EventArgs e)
        {
            foreach (Server mServer in Configuration.Servers)
                Configuration.EnabledServerList.Add(mServer.Name);
            foreach (Server server in Configuration.Servers)
                mProcessCtler.Start(server);
            UpdateServersMenuItemsStatus();
            Configuration.UpdateEnabledServerList();
        }

        private void disableAllServerItem_Click(object sender, EventArgs e)
        {
            foreach (Server server in Configuration.Servers)
                mProcessCtler.Stop(server.Name);
            Configuration.EnabledServerList.Clear();
            UpdateServersMenuItemsStatus();
            Configuration.UpdateEnabledServerList();
        }
            
        private void configItem_Click(object sender, EventArgs e)
        {
            ConfigForm configForm = new ConfigForm();
            configForm.ShowDialog();
        }

        private void autoStartupItem_Click(object sender, EventArgs e)
        {
            autoStartupItem.Checked = !autoStartupItem.Checked;
            AutoStartupUtil.Set(autoStartupItem.Checked);
        }

        private void logItem_Click(object sender, EventArgs e)
        {
            if (mLogForm == null || mLogForm.IsDisposed)
            {
                mLogForm = new LogForm();
            }
            mLogForm.Show();
        }

        private void serverItem_Click(object sender, EventArgs e)
        {
            MenuItem mServerItem = sender as MenuItem;
            mServerItem.Checked = !mServerItem.Checked;

            if (mServerItem.Checked)
            {
                if (!mProcessCtler.Start(mServerItem.Tag as Server))
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
                mProcessCtler.Stop(mServerItem.Text);
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
        }

        public void _ProcessLogReceived(object sender, EventArgs e)
        {
            if (mLogForm != null)
            {
                ProcessLogReceivedEventArgs args = e as ProcessLogReceivedEventArgs;
                mLogForm.UpdateLog(args.Log + Environment.NewLine);
            }
        }

        private void exitItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
