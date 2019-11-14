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
            this.labelFtpPath = new System.Windows.Forms.Label();
            this.FtpPath = new System.Windows.Forms.TextBox();
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
            this.menuItemDownloadReports = new System.Windows.Forms.ToolStripMenuItem();
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.folderBrowserDialog = new System.Windows.Forms.FolderBrowserDialog();
            this.buttonSelectFolder = new System.Windows.Forms.Button();
            this.groupBoxAZSRestrictions = new System.Windows.Forms.GroupBox();
            this.labelAZSCodes = new System.Windows.Forms.Label();
            this.AZSCodes = new System.Windows.Forms.TextBox();
            this.labelAZSCodesExclude = new System.Windows.Forms.Label();
            this.AZSCodesExclude = new System.Windows.Forms.TextBox();
            this.buttonAutoStart = new System.Windows.Forms.Button();
            this.labelAutoStartDisabled = new System.Windows.Forms.Label();
            this.groupBoxFtp.SuspendLayout();
            this.contextMenuNotifyIcon.SuspendLayout();
            this.groupBoxAZSRestrictions.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBoxFtp
            // 
            this.groupBoxFtp.Controls.Add(this.labelFtpPath);
            this.groupBoxFtp.Controls.Add(this.FtpPath);
            this.groupBoxFtp.Controls.Add(this.labelFtpPassword);
            this.groupBoxFtp.Controls.Add(this.FtpPassword);
            this.groupBoxFtp.Controls.Add(this.labelFtpLogin);
            this.groupBoxFtp.Controls.Add(this.FtpLogin);
            this.groupBoxFtp.Controls.Add(this.labelFtpHost);
            this.groupBoxFtp.Controls.Add(this.FtpHost);
            this.groupBoxFtp.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFtp.Name = "groupBoxFtp";
            this.groupBoxFtp.Size = new System.Drawing.Size(489, 77);
            this.groupBoxFtp.TabIndex = 5;
            this.groupBoxFtp.TabStop = false;
            this.groupBoxFtp.Text = "Настройка Ftp";
            // 
            // labelFtpPath
            // 
            this.labelFtpPath.AutoSize = true;
            this.labelFtpPath.Location = new System.Drawing.Point(6, 48);
            this.labelFtpPath.Name = "labelFtpPath";
            this.labelFtpPath.Size = new System.Drawing.Size(51, 13);
            this.labelFtpPath.TabIndex = 14;
            this.labelFtpPath.Text = "Каталог:";
            // 
            // FtpPath
            // 
            this.FtpPath.Location = new System.Drawing.Point(88, 45);
            this.FtpPath.Name = "FtpPath";
            this.FtpPath.Size = new System.Drawing.Size(388, 20);
            this.FtpPath.TabIndex = 13;
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
            this.FtpPassword.PasswordChar = '*';
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
            this.labelDownloadPath.Location = new System.Drawing.Point(18, 175);
            this.labelDownloadPath.Name = "labelDownloadPath";
            this.labelDownloadPath.Size = new System.Drawing.Size(56, 26);
            this.labelDownloadPath.TabIndex = 10;
            this.labelDownloadPath.Text = "Каталог\r\nзагрузки:";
            // 
            // DownloadPath
            // 
            this.DownloadPath.Enabled = false;
            this.DownloadPath.Location = new System.Drawing.Point(100, 178);
            this.DownloadPath.Name = "DownloadPath";
            this.DownloadPath.Size = new System.Drawing.Size(376, 20);
            this.DownloadPath.TabIndex = 9;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(426, 209);
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
            this.buttonOk.Location = new System.Drawing.Point(345, 209);
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
            // menuItemDownloadReports
            // 
            this.menuItemDownloadReports.Name = "menuItemDownloadReports";
            this.menuItemDownloadReports.Size = new System.Drawing.Size(213, 22);
            this.menuItemDownloadReports.Text = "Скачать сменные отчеты";
            this.menuItemDownloadReports.Click += new System.EventHandler(this.menuItemDownloadReports_Click);
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
            // buttonSelectFolder
            // 
            this.buttonSelectFolder.Location = new System.Drawing.Point(476, 177);
            this.buttonSelectFolder.Name = "buttonSelectFolder";
            this.buttonSelectFolder.Size = new System.Drawing.Size(24, 22);
            this.buttonSelectFolder.TabIndex = 18;
            this.buttonSelectFolder.Text = "...";
            this.buttonSelectFolder.UseVisualStyleBackColor = true;
            this.buttonSelectFolder.Click += new System.EventHandler(this.buttonSelectFolder_Click);
            // 
            // groupBoxAZSRestrictions
            // 
            this.groupBoxAZSRestrictions.Controls.Add(this.labelAZSCodesExclude);
            this.groupBoxAZSRestrictions.Controls.Add(this.AZSCodesExclude);
            this.groupBoxAZSRestrictions.Controls.Add(this.labelAZSCodes);
            this.groupBoxAZSRestrictions.Controls.Add(this.AZSCodes);
            this.groupBoxAZSRestrictions.Location = new System.Drawing.Point(12, 95);
            this.groupBoxAZSRestrictions.Name = "groupBoxAZSRestrictions";
            this.groupBoxAZSRestrictions.Size = new System.Drawing.Size(489, 77);
            this.groupBoxAZSRestrictions.TabIndex = 19;
            this.groupBoxAZSRestrictions.TabStop = false;
            this.groupBoxAZSRestrictions.Text = "Ограничения по АЗС (коды АЗС через запятую)";
            // 
            // labelAZSCodes
            // 
            this.labelAZSCodes.AutoSize = true;
            this.labelAZSCodes.Location = new System.Drawing.Point(6, 22);
            this.labelAZSCodes.Name = "labelAZSCodes";
            this.labelAZSCodes.Size = new System.Drawing.Size(288, 13);
            this.labelAZSCodes.TabIndex = 10;
            this.labelAZSCodes.Text = "Загружать сменные отчеты только по указанным АЗС:";
            // 
            // AZSCodes
            // 
            this.AZSCodes.Location = new System.Drawing.Point(300, 19);
            this.AZSCodes.Name = "AZSCodes";
            this.AZSCodes.Size = new System.Drawing.Size(176, 20);
            this.AZSCodes.TabIndex = 9;
            // 
            // labelAZSCodesExclude
            // 
            this.labelAZSCodesExclude.AutoSize = true;
            this.labelAZSCodesExclude.Location = new System.Drawing.Point(6, 48);
            this.labelAZSCodesExclude.Name = "labelAZSCodesExclude";
            this.labelAZSCodesExclude.Size = new System.Drawing.Size(267, 13);
            this.labelAZSCodesExclude.TabIndex = 12;
            this.labelAZSCodesExclude.Text = "Загружать сменные отчеты кроме указанных АЗС:";
            // 
            // AZSCodesExclude
            // 
            this.AZSCodesExclude.Location = new System.Drawing.Point(300, 45);
            this.AZSCodesExclude.Name = "AZSCodesExclude";
            this.AZSCodesExclude.Size = new System.Drawing.Size(176, 20);
            this.AZSCodesExclude.TabIndex = 11;
            // 
            // buttonAutoStart
            // 
            this.buttonAutoStart.Location = new System.Drawing.Point(177, 209);
            this.buttonAutoStart.Name = "buttonAutoStart";
            this.buttonAutoStart.Size = new System.Drawing.Size(162, 23);
            this.buttonAutoStart.TabIndex = 20;
            this.buttonAutoStart.Text = "АВТОСТАРТ";
            this.buttonAutoStart.UseVisualStyleBackColor = true;
            this.buttonAutoStart.Click += new System.EventHandler(this.buttonAutoStart_Click);
            // 
            // labelAutoStartDisabled
            // 
            this.labelAutoStartDisabled.AutoSize = true;
            this.labelAutoStartDisabled.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.labelAutoStartDisabled.ForeColor = System.Drawing.Color.Red;
            this.labelAutoStartDisabled.Location = new System.Drawing.Point(9, 205);
            this.labelAutoStartDisabled.Name = "labelAutoStartDisabled";
            this.labelAutoStartDisabled.Size = new System.Drawing.Size(297, 30);
            this.labelAutoStartDisabled.TabIndex = 21;
            this.labelAutoStartDisabled.Text = "Для добавления / удаления из автозапуска\r\nзапустите с правами администратора";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(510, 240);
            this.Controls.Add(this.labelAutoStartDisabled);
            this.Controls.Add(this.buttonAutoStart);
            this.Controls.Add(this.groupBoxAZSRestrictions);
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
            this.groupBoxAZSRestrictions.ResumeLayout(false);
            this.groupBoxAZSRestrictions.PerformLayout();
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
        private System.Windows.Forms.Label labelFtpPath;
        private System.Windows.Forms.TextBox FtpPath;
        private System.Windows.Forms.GroupBox groupBoxAZSRestrictions;
        private System.Windows.Forms.Label labelAZSCodesExclude;
        private System.Windows.Forms.TextBox AZSCodesExclude;
        private System.Windows.Forms.Label labelAZSCodes;
        private System.Windows.Forms.TextBox AZSCodes;
        private System.Windows.Forms.Button buttonAutoStart;
        private System.Windows.Forms.Label labelAutoStartDisabled;
    }
}

