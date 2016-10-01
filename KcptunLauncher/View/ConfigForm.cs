using KcptunLauncher.Controller;
using KcptunLauncher.DataModel;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KcptunLauncher.View
{
    public partial class ConfigForm : Form
    {
        private BindingSource mSource;
        private string selectedServerName;

        public ConfigForm()
        {
            InitializeComponent();
            mSource = new BindingSource();
            mSource.DataSource = Configuration.Servers;
            mServerList.DataSource = mSource;
        }

        private void LoadServer(Server server)
        {
            if (server == null) return;
            serverNameBox.Text = !server.Name.Equals("unconfigurate server") ? server.Name : "";
            localIpBox.Text = server.LocalIp;
            localPortBox.Text = server.LocalPort + "";
            remoteIpBox.Text = server.RemoteIp;
            remotePortBox.Text = server.RemotePort + "";
            keyBox.Text = server.Key;
            if (!string.IsNullOrWhiteSpace(server.Crypt) || !server.IsNew)
            {
                for (int i = 0, n = cryptCB.Items.Count; i < n; i++)
                {
                    if (Equals(cryptCB.Items[i], server.Crypt))
                    {
                        cryptCB.SelectedIndex = i;
                        break;
                    }
                }
            }
            else { cryptCB.SelectedIndex = 0; }
            if (!string.IsNullOrWhiteSpace(server.Mode) || !server.IsNew)
            {
                for (int i = 0, n = modeCB.Items.Count; i < n; i++)
                {
                    if (Equals(modeCB.Items[i], server.Mode))
                    {
                        modeCB.SelectedIndex = i;
                        break;
                    }
                }
            }
            else { modeCB.SelectedIndex = 1; }
            connBox.Text = server.PhysicalConnections + "";
            mtuBox.Text = server.Mtu + "";
            sndwndBox.Text = server.SendWindowSize + "";
            rcvwndBox.Text = server.ReceiveWindowSize + "";
            nocompCB.Checked = server.NoCompression;
            datashardBox.Text = server.DataShard + "";
            parityshardBox.Text = server.ParityShard + "";
            dscpBox.Text = server.DSCP + "";

            autoExpireBox.Text = server.AutoExpire + "";
            ackNoDelayCB.Checked = server.AckNoDelay;
            noDelayBox.Text = server.NoDelay + "";
            intervalBox.Text = server.Interval + "";
            resendBox.Text = server.Resend + "";
            ncBox.Text = server.Nc + "";
            sockBufBox.Text = server.SockBuffer + "";
            keepAliveBox.Text = server.KeepAlive + "";
        }

        private void Save(Server server)
        {
            if (Configuration.EnabledServerList.Contains(selectedServerName))
            {
                MainProcessController mpCtler = MainProcessController.GetInstance();
                mpCtler.Stop(selectedServerName);
                mpCtler.Start(server);
            }

            JObject cfgJObj = Configuration.GetConfigFile();
            JArray serverJArr = cfgJObj["servers"] as JArray;
            foreach (JObject serverJObj in serverJArr)
            {
                if (serverJObj["name"].ToString().Equals(selectedServerName))
                {
                    serverJArr.Remove(serverJObj);
                    break;
                }
            }
            serverJArr.Add(JObject.Parse(JsonConvert.SerializeObject(server)));

            Configuration.SaveConfigFile(cfgJObj);
        }

        private Server GenServer()
        {
            Server server = new Server();
            server.Name = serverNameBox.Text;
            server.LocalIp = localIpBox.Text;
            if (!string.IsNullOrWhiteSpace(localPortBox.Text))
            {
                server.LocalPort = Convert.ToInt32(localPortBox.Text);
            }
            server.RemoteIp = remoteIpBox.Text;
            if (!string.IsNullOrWhiteSpace(remotePortBox.Text))
            {
                server.RemotePort = Convert.ToInt32(remotePortBox.Text);
            }
            server.Key = keyBox.Text;
            server.Crypt = cryptCB.Text;
            server.Mode = modeCB.Text;
            if (!string.IsNullOrWhiteSpace(connBox.Text))
            {
                server.PhysicalConnections = Convert.ToInt32(connBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(mtuBox.Text))
            {
                server.Mtu = Convert.ToInt32(mtuBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(sndwndBox.Text))
            {
                server.SendWindowSize = Convert.ToInt32(sndwndBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(rcvwndBox.Text))
            {
                server.ReceiveWindowSize = Convert.ToInt32(rcvwndBox.Text);
            }
            server.NoCompression = nocompCB.Checked;
            server.AckNoDelay = ackNoDelayCB.Checked;
            if (!string.IsNullOrWhiteSpace(autoExpireBox.Text))
            {
                server.AutoExpire = Convert.ToInt32(autoExpireBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(datashardBox.Text))
            {
                server.DataShard = Convert.ToInt32(datashardBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(parityshardBox.Text))
            {
                server.ParityShard = Convert.ToInt32(parityshardBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(dscpBox.Text))
            {
                server.DSCP = Convert.ToInt32(dscpBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(noDelayBox.Text))
            {
                server.NoDelay = Convert.ToInt32(noDelayBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(intervalBox.Text))
            {
                server.Interval = Convert.ToInt32(intervalBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(resendBox.Text))
            {
                server.Resend = Convert.ToInt32(resendBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(ncBox.Text))
            {
                server.Nc = Convert.ToInt32(ncBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(sockBufBox.Text))
            {
                server.SockBuffer = Convert.ToInt32(sockBufBox.Text);
            }
            if (!string.IsNullOrWhiteSpace(keepAliveBox.Text))
            {
                server.KeepAlive = Convert.ToInt32(keepAliveBox.Text);
            }
            return server;
        }

        private void ConfigForm_Shown(object sender, EventArgs e)
        {
            if (Configuration.Servers.Count > 0)
            {
                LoadServer(mServerList.Items[0] as Server);
            }
        }

        private void confirmBtn_Click(object sender, EventArgs e)
        {
            int selectedIdx = mServerList.SelectedIndex;
            if (selectedIdx < Configuration.Servers.Count && Configuration.Servers.Count > 0)
            {
                Server genServer = GenServer();
                if (!Equals(Configuration.Servers[selectedIdx].Name, genServer.Name))
                {
                    MainProcessController mpCtler = MainProcessController.GetInstance();
                    System.Diagnostics.Process oProcess = mpCtler.Processes[Configuration.Servers[selectedIdx].Name] as System.Diagnostics.Process;
                    mpCtler.Processes.Remove(Configuration.Servers[selectedIdx].Name);
                    mpCtler.Processes.Add(GenServer().Name, oProcess);

                    Configuration.UpdateEnabledServerName(Configuration.Servers[selectedIdx].Name, genServer.Name);
                    Util.Logger.GetInstance().UpdateLogFileName(Configuration.Servers[selectedIdx].Name, genServer.Name);
                }

                Configuration.Servers[selectedIdx] = genServer;
                Configuration.NotifyServersChanged();
                MenuControlController.GetInstance().LoadServersMenuItem();
            }
            Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void mServerList_SelectedIndexChanged(object sender, EventArgs e)
        {
            foreach (Server server in Configuration.Servers)
            {
                if (server.Name.Equals(selectedServerName))
                {
                    Server genServer = GenServer();
                    if (!selectedServerName.Equals(genServer.Name)
                        || !server.ToString().Equals(genServer.ToString()))
                    {
                        Save(genServer);
                        Configuration.Servers.Remove(server);
                        Configuration.Servers.Add(genServer);
                        Configuration.UpdateEnabledServerName(server.Name, genServer.Name);
                        Util.Logger.GetInstance().UpdateLogFileName(server.Name, genServer.Name);
                        MenuControlController.GetInstance().LoadServersMenuItem();
                        List<Server> servers = mSource.DataSource as List<Server>;
                        for (int i = 0, n = servers.Count; i < n; i++)
                        {
                            Server cServer = servers[i];
                            if (cServer.Name.Equals(selectedServerName))
                            {
                                mSource[i] = genServer;
                                mSource.ResetBindings(false);
                                break;
                            }
                        }

                        mSource.ResetBindings(false);
                    }
                    break;
                }
            }

            Server mServer = mServerList.SelectedItem as Server;
            selectedServerName = mServer.Name;
            LoadServer(mServer);
        }

        private void addServerBtn_Click(object sender, EventArgs e)
        {
            Configuration.AddServer(new Server() { Name = "unconfigurate server" });
            mSource.ResetBindings(false);
            mServerList.SelectedIndex = mServerList.Items.Count - 1;
            serverNameBox.Focus();
        }

        private void removeServerBtn_Click(object sender, EventArgs e)
        {
            Configuration.RemoveServer((mSource.DataSource as List<Server>)[mServerList.SelectedIndex]);
            mSource.ResetBindings(false);
            if (mSource.Count > 0) mServerList.SelectedIndex = mServerList.Items.Count - 1;
            MenuControlController.GetInstance().LoadServersMenuItem();            
        }

        private void moveUpBtn_Click(object sender, EventArgs e)
        {
            int selectedIdx = mServerList.SelectedIndex;
            if (selectedIdx == 0)
            {
                return;
            }

            Server tmpServer = mSource[selectedIdx - 1] as Server;
            mSource[selectedIdx - 1] = mSource[selectedIdx];
            mSource[selectedIdx] = tmpServer;
            mSource.ResetBindings(false);
            mServerList.SelectedIndex = selectedIdx - 1;
            LoadServer(mSource[selectedIdx - 1] as Server);
        }

        private void moveDownBtn_Click(object sender, EventArgs e)
        {
            int selectedIdx = mServerList.SelectedIndex;
            if (selectedIdx == mServerList.Items.Count - 1)
            {
                return;
            }

            Server tmpServer = mSource[selectedIdx + 1] as Server;
            mSource[selectedIdx + 1] = mSource[selectedIdx];
            mSource[selectedIdx] = tmpServer;
            mSource.ResetBindings(false);
            mServerList.SelectedIndex = selectedIdx + 1;
            LoadServer(mSource[selectedIdx + 1] as Server);
        }
    }
}
