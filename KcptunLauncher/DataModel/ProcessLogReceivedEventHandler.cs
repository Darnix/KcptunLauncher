using System;

namespace KcptunLauncher.DataModel
{
    public class ProcessLogReceivedEventArgs : EventArgs
    {
        public string ServerName { get; set; }
        public string Log { get; set; }
    }
}
