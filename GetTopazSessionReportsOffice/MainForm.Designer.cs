namespace GetTopazSessionReportsOffice
{
    partial class MainForm
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.groupBoxFtp = new System.Windows.Forms.GroupBox();
            this.labelFtpPassword = new System.Windows.Forms.Label();
            this.FtpPassword = new System.Windows.Forms.TextBox();
            this.labelFtpLogin = new System.Windows.Forms.Label();
            this.FtpLogin = new System.Windows.Forms.TextBox();
            this.labelFtpHost = new System.Windows.Forms.Label();
            this.FtpHost = new System.Windows.Forms.TextBox();
            this.labelDownloadPath = new System.Windows.Forms.Label();
            this.DownloadPath = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonOk = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.menuItemDownloadReports = new System.Windows.Forms.ToolStripMenuItem();
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.groupBoxFtp.SuspendLayout();
            this.contextMenuNotifyIcon.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFtp
            // 
            this.groupBoxFtp.Controls.Add(this.labelFtpPassword);
            this.groupBoxFtp.Controls.Add(this.FtpPassword);
            this.groupBoxFtp.Controls.Add(this.labelFtpLogin);
            this.groupBoxFtp.Controls.Add(this.FtpLogin);
            this.groupBoxFtp.Controls.Add(this.labelFtpHost);
            this.groupBoxFtp.Controls.Add(this.FtpHost);
            this.groupBoxFtp.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFtp.Name = "groupBoxFtp";
            this.groupBoxFtp.Size = new System.Drawing.Size(489, 51);
            this.groupBoxFtp.TabIndex = 5;
            this.groupBoxFtp.TabStop = false;
            this.groupBoxFtp.Text = "Настройка Ftp";
            // 
            // labelFtpPassword
            // 
            this.labelFtpPassword.AutoSize = true;
            this.labelFtpPassword.Location = new System.Drawing.Point(345, 22);
            this.labelFtpPassword.Name = "labelFtpPassword";
            this.labelFtpPassword.Size = new System.Drawing.Size(48, 13);
            this.labelFtpPassword.TabIndex = 12;
            this.labelFtpPassword.Text = "Пароль:";
            // 
            // FtpPassword
            // 
            this.FtpPassword.Location = new System.Drawing.Point(399, 19);
            this.FtpPassword.Name = "FtpPassword";
            this.FtpPassword.Size = new System.Drawing.Size(78, 20);
            this.FtpPassword.TabIndex = 11;
            // 
            // labelFtpLogin
            // 
            this.labelFtpLogin.AutoSize = true;
            this.labelFtpLogin.Location = new System.Drawing.Point(218, 22);
            this.labelFtpLogin.Name = "labelFtpLogin";
            this.labelFtpLogin.Size = new System.Drawing.Size(41, 13);
            this.labelFtpLogin.TabIndex = 10;
            this.labelFtpLogin.Text = "Логин:";
            // 
            // FtpLogin
            // 
            this.FtpLogin.Location = new System.Drawing.Point(265, 19);
            this.FtpLogin.Name = "FtpLogin";
            this.FtpLogin.Size = new System.Drawing.Size(78, 20);
            this.FtpLogin.TabIndex = 9;
            // 
            // labelFtpHost
            // 
            this.labelFtpHost.AutoSize = true;
            this.labelFtpHost.Location = new System.Drawing.Point(6, 22);
            this.labelFtpHost.Name = "labelFtpHost";
            this.labelFtpHost.Size = new System.Drawing.Size(77, 13);
            this.labelFtpHost.TabIndex = 8;
            this.labelFtpHost.Text = "Имя сервера:";
            // 
            // FtpHost
            // 
            this.FtpHost.Location = new System.Drawing.Point(89, 19);
            this.FtpHost.Name = "FtpHost";
            this.FtpHost.Size = new System.Drawing.Size(121, 20);
            this.FtpHost.TabIndex = 7;
            // 
            // labelDownloadPath
            // 
            this.labelDownloadPath.AutoSize = true;
            this.labelDownloadPath.Location = new System.Drawing.Point(18, 72);
            this.labelDownloadPath.Name = "labelDownloadPath";
            this.labelDownloadPath.Size = new System.Drawing.Size(51, 13);
            this.labelDownloadPath.TabIndex = 10;
            this.labelDownloadPath.Text = "Каталог:";
            // 
            // DownloadPath
            // 
            this.DownloadPath.Enabled = false;
            this.DownloadPath.Location = new System.Drawing.Point(101, 69);
            this.DownloadPath.Name = "DownloadPath";
            this.DownloadPath.Size = new System.Drawing.Size(376, 20);
            this.DownloadPath.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(426, 95);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 17;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(345, 95);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 16;
            this.buttonOk.Text = "Принять";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1800000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemDownloadReports,
            this.menuItemExit});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            this.contextMenuNotifyIcon.Size = new System.Drawing.Size(214, 48);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(213, 22);
            this.menuItemExit.Text = "Закрыть программу";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Получение сменных отчетов Топаз";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // menuItemDownloadReports
            // 
            this.menuItemDownloadReports.Name = "menuItemDownloadReports";
            this.menuItemDownloadReports.Size = new System.Drawing.Size(213, 22);
            this.menuItemDownloadReports.Text = "Скачать сменные отчеты";
            this.menuItemDownloadReports.Click += new System.EventHandler(this.menuItemDownloadReports_Click);
            // 
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(477, 68);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(24, 22);
            this.buttonSelectFolder.TabIndex = 18;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 125);
            this.Controls.Add(this.buttonSelectFolder);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelDownloadPath);
            this.Controls.Add(this.DownloadPath);
            this.Controls.Add(this.groupBoxFtp);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка получения сменных отчетов Топаз";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.groupBoxFtp.ResumeLayout(false);
            this.groupBoxFtp.PerformLayout();
            this.contextMenuNotifyIcon.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBoxFtp;
        private System.Windows.Forms.Label labelFtpPassword;
        private System.Windows.Forms.TextBox FtpPassword;
        private System.Windows.Forms.Label labelFtpLogin;
        private System.Windows.Forms.TextBox FtpLogin;
        private System.Windows.Forms.Label labelFtpHost;
        private System.Windows.Forms.TextBox FtpHost;
        private System.Windows.Forms.Label labelDownloadPath;
        private System.Windows.Forms.TextBox DownloadPath;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemDownloadReports;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog;
        private System.Windows.Forms.Button buttonSelectFolder;
    }
}

