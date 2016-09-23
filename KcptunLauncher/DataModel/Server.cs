using Newtonsoft.Json;
using System.Text;

namespace KcptunLauncher.DataModel
{
    public class Server
    {
        [JsonIgnore]
        public string Name
        {
            get
            {
                return string.IsNullOrWhiteSpace(name)
                    ? "unconfigure server"
                    : name;
            }
            set { this.name = value; }
        }

        [JsonProperty(PropertyName = "name", NullValueHandling = NullValueHandling.Ignore)]
        private string name;

        [JsonProperty(PropertyName = "localIp", NullValueHandling = NullValueHandling.Ignore)]
        public string LocalIp { get; set; }

        [JsonProperty(PropertyName = "localPort", NullValueHandling = NullValueHandling.Ignore)]
        public int LocalPort { get; set; }

        //[JsonProperty(PropertyName = "localaddr", NullValueHandling = NullValueHandling.Ignore)]
        public string LocalAddress { get { return LocalIp + ":" + LocalPort; } }

        [JsonProperty(PropertyName = "remoteIp", NullValueHandling = NullValueHandling.Ignore)]
        public string RemoteIp { get; set; }

        [JsonProperty(PropertyName = "remotePort", NullValueHandling = NullValueHandling.Ignore)]
        public int RemotePort { get; set; }

        //[JsonProperty(PropertyName = "remoteaddr", NullValueHandling = NullValueHandling.Ignore)]
        public string RemoteAddress { get { return RemoteIp + ":" + RemotePort; } }

        [JsonProperty(PropertyName = "key", NullValueHandling = NullValueHandling.Ignore)]
        public string Key { get; set; }

        [JsonProperty(PropertyName = "crypt", NullValueHandling = NullValueHandling.Ignore)]
        public string Crypt { get; set; }

        [JsonProperty(PropertyName = "mode", NullValueHandling = NullValueHandling.Ignore)]
        public string Mode { get; set; }

        [JsonProperty(PropertyName = "conn", NullValueHandling = NullValueHandling.Ignore)]
        public int PhysicalConnections { get; set; }

        [JsonProperty(PropertyName = "autoexpire", NullValueHandling = NullValueHandling.Ignore)]
        public int AutoExpire { get; set; }

        [JsonProperty(PropertyName = "mtu", NullValueHandling = NullValueHandling.Ignore)]
        public int Mtu { get; set; }

        [JsonProperty(PropertyName = "sndwnd", NullValueHandling = NullValueHandling.Ignore)]
        public int SendWindowSize { get; set; }

        [JsonProperty(PropertyName = "rcvwnd", NullValueHandling = NullValueHandling.Ignore)]
        public int ReceiveWindowSize { get; set; }

        [JsonProperty(PropertyName = "nocomp", NullValueHandling = NullValueHandling.Ignore)]
        public bool NoCompression { get; set; }

        [JsonProperty(PropertyName = "datashard", NullValueHandling = NullValueHandling.Ignore)]
        public int DataShard { get; set; }

        [JsonProperty(PropertyName = "parityshard", NullValueHandling = NullValueHandling.Ignore)]
        public int ParityShard { get; set; }

        [JsonProperty(PropertyName = "dscp", NullValueHandling = NullValueHandling.Ignore)]
        public int DSCP { get; set; }

        [JsonProperty(PropertyName = "acknodelay", NullValueHandling = NullValueHandling.Ignore)]
        public bool AckNoDelay { get; set; }

        [JsonProperty(PropertyName = "nodelay", NullValueHandling = NullValueHandling.Ignore)]
        public int NoDelay { get; set; }

        [JsonProperty(PropertyName = "interval", NullValueHandling = NullValueHandling.Ignore)]
        public int Interval { get; set; }

        [JsonProperty(PropertyName = "resend", NullValueHandling = NullValueHandling.Ignore)]
        public int Resend { get; set; }

        [JsonProperty(PropertyName = "nc", NullValueHandling = NullValueHandling.Ignore)]
        public int Nc { get; set; }

        [JsonProperty(PropertyName = "sockbuf", NullValueHandling = NullValueHandling.Ignore)]
        public int SockBuffer { get; set; }

        [JsonProperty(PropertyName = "keepalive", NullValueHandling = NullValueHandling.Ignore)]
        public int KeepAlive { get; set; }

        [JsonIgnore]
        public bool IsNew { get { return Name.Equals("unconfigurate server"); } }

        public Server()
        {
        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public override bool Equals(object obj)
        {
            Server server = obj as Server;
            return server != null ? Equals(ToString(), server.ToString()) : false;
        }

        public override string ToString()
        {
            StringBuilder paramBuilder = new StringBuilder();
            paramBuilder.Append("-l ").Append(!string.IsNullOrWhiteSpace(LocalAddress) ? LocalAddress : ":12948").Append(" ");
            paramBuilder.Append("-r ").Append(!string.IsNullOrWhiteSpace(RemoteAddress) ? RemoteAddress : "127.0.0.1:29900").Append(" ");
            if (!string.IsNullOrWhiteSpace(Key)) { paramBuilder.Append("-key ").Append(Key).Append(" "); }
            if (!string.IsNullOrWhiteSpace(Crypt)) { paramBuilder.Append("-crypt ").Append(Crypt).Append(" "); }
            if (!string.IsNullOrWhiteSpace(Mode)) { paramBuilder.Append("-mode ").Append(Mode).Append(" "); }
            if (PhysicalConnections > 0) { paramBuilder.Append("-conn ").Append(PhysicalConnections).Append(" "); }
            if (AutoExpire > 0) { paramBuilder.Append("-autoexpire ").Append(AutoExpire).Append(" "); }
            if (Mtu > 0) { paramBuilder.Append("-mtu ").Append(Mtu).Append(" "); }
            if (SendWindowSize > 0) { paramBuilder.Append("-sndwnd ").Append(SendWindowSize).Append(" "); }
            if (ReceiveWindowSize > 0) { paramBuilder.Append("-rcvwnd ").Append(ReceiveWindowSize).Append(" "); }
            if (NoCompression) { paramBuilder.Append("-nocomp "); }
            if (DataShard > 0) { paramBuilder.Append("-datashard ").Append(DataShard).Append(" "); }
            if (ParityShard > 0) { paramBuilder.Append("-parityshard ").Append(ParityShard).Append(" "); }
            if (DSCP > 0) { paramBuilder.Append("-dscp ").Append(DSCP).Append(" "); }
            if (AckNoDelay) { paramBuilder.Append("-acknodelay "); }
            if (NoDelay > 0) { paramBuilder.Append("-nodelay ").Append(NoDelay).Append(" "); }
            if (Interval > 0) { paramBuilder.Append("-interval ").Append(Interval).Append(" "); }
            if (Resend > 0) { paramBuilder.Append("-resend ").Append(Resend).Append(" "); }
            if (Nc > 0) { paramBuilder.Append("-nc ").Append(Nc).Append(" "); }
            if (SockBuffer > 0) { paramBuilder.Append("-sockbuf ").Append(SockBuffer).Append(" "); }
            if (KeepAlive > 0) { paramBuilder.Append("-keepalive ").Append(KeepAlive).Append(" "); }
            return paramBuilder.ToString();
        }
    }
}
