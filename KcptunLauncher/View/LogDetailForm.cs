using System.Windows.Forms;

namespace KcptunLauncher.View
{
    public partial class LogDetailForm : Form
    {
        public string Type
        {
            get { return this.type; }
            set { this.type = value; this.typeBox.Text = this.type; }
        }
        private string type;

        public string Content
        {
            get { return this.content; }
            set { this.content = value; this.contentBox.Text = this.content; }
        }
        private string content;

        public string Time
        {
            get { return this.time; }
            set { this.time = value; this.timeBox.Text = this.time; }
        }
        private string time;

        public LogDetailForm()
        {
            InitializeComponent();
        }

        public LogDetailForm(string type, string content, string time)
        {
            InitializeComponent();
            this.Type = type;
            this.Content = content;
            this.Time = time;
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            int WM_KEYDOWN = 256;
            int WM_SYSKEYDOWN = 260;

            if (msg.Msg == WM_KEYDOWN | msg.Msg == WM_SYSKEYDOWN)
            {
                switch (keyData)
                {
                    case Keys.Escape:
                        Close();
                        break;
                }
            }
            return false;
        }

        private void exReportLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/Darnix/KcptunLauncher/issues");
        }
    }
}
