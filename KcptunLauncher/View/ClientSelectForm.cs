using System;
using System.Windows.Forms;

namespace KcptunLauncher.View
{
    public partial class ClientSelectForm : Form
    {
        public ClientSelectForm()
        {
            InitializeComponent();
        }

        private void browseBtn_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofDlg = new OpenFileDialog();
            ofDlg.Filter = "(*.exe)|*.exe";
            ofDlg.FileName = "client_windows_amd64.exe";
            if (ofDlg.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = ofDlg.FileName;
            }
        }

        private void downloadBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(@"https://github.com/xtaci/kcptun/releases/latest");
        }

        private void okBtn_Click(object sender, EventArgs e)
        {
            if (!System.IO.File.Exists(textBox1.Text))
            {
                MessageBox.Show("file not exists!");
            }
            System.IO.File.Copy(textBox1.Text, Controller.MainProcessController.KCPTUN_CLIENT_FILE_PATH);
            this.Close();
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
