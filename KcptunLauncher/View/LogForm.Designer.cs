namespace KcptunLauncher.View
{
    partial class LogForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(LogForm));
            this.mLogBox = new System.Windows.Forms.TextBox();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.serverMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clearLogMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // mLogBox
            // 
            this.mLogBox.BackColor = System.Drawing.SystemColors.Desktop;
            this.mLogBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mLogBox.Font = new System.Drawing.Font("Consolas", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mLogBox.ForeColor = System.Drawing.Color.White;
            this.mLogBox.Location = new System.Drawing.Point(0, 25);
            this.mLogBox.MaxLength = 2147483647;
            this.mLogBox.Multiline = true;
            this.mLogBox.Name = "mLogBox";
            this.mLogBox.ReadOnly = true;
            this.mLogBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.mLogBox.Size = new System.Drawing.Size(434, 286);
            this.mLogBox.TabIndex = 0;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.serverMenuItem,
            this.clearLogMenuItem,
            this.fontMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(434, 25);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // serverMenuItem
            // 
            this.serverMenuItem.Name = "serverMenuItem";
            this.serverMenuItem.Size = new System.Drawing.Size(71, 21);
            this.serverMenuItem.Text = "服务器(&S)";
            // 
            // clearLogMenuItem
            // 
            this.clearLogMenuItem.Name = "clearLogMenuItem";
            this.clearLogMenuItem.Size = new System.Drawing.Size(84, 21);
            this.clearLogMenuItem.Text = "清空日志(&C)";
            this.clearLogMenuItem.Click += new System.EventHandler(this.clearLogMenuItem_Click);
            // 
            // fontMenuItem
            // 
            this.fontMenuItem.Name = "fontMenuItem";
            this.fontMenuItem.Size = new System.Drawing.Size(82, 21);
            this.fontMenuItem.Text = "设置字体(&F)";
            this.fontMenuItem.Click += new System.EventHandler(this.fontMenuItem_Click);
            // 
            // LogForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 311);
            this.Controls.Add(this.mLogBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "LogForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "日志";
            this.Shown += new System.EventHandler(this.LogForm_Shown);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox mLogBox;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem serverMenuItem;
        private System.Windows.Forms.ToolStripMenuItem clearLogMenuItem;
        private System.Windows.Forms.ToolStripMenuItem fontMenuItem;
    }
}