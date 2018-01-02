namespace GetTopazSessionReports
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
            this.notifyIcon = new System.Windows.Forms.NotifyIcon(this.components);
            this.contextMenuNotifyIcon = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.FirebirdServerName = new System.Windows.Forms.TextBox();
            this.labelFirebirdServerName = new System.Windows.Forms.Label();
            this.groupBoxFirebird = new System.Windows.Forms.GroupBox();
            this.labelFirebirdDatabaseFile = new System.Windows.Forms.Label();
            this.FirebirdDatabaseFile = new System.Windows.Forms.TextBox();
            this.labelFirebirdPassword = new System.Windows.Forms.Label();
            this.FirebirdPassword = new System.Windows.Forms.TextBox();
            this.labelFirebirdUserName = new System.Windows.Forms.Label();
            this.FirebirdUserName = new System.Windows.Forms.TextBox();
            this.groupBoxFtp = new System.Windows.Forms.GroupBox();
            this.labelFtpPassword = new System.Windows.Forms.Label();
            this.FtpPassword = new System.Windows.Forms.TextBox();
            this.labelFtpLogin = new System.Windows.Forms.Label();
            this.FtpLogin = new System.Windows.Forms.TextBox();
            this.labelFtpHost = new System.Windows.Forms.Label();
            this.FtpHost = new System.Windows.Forms.TextBox();
            this.labelStartDate = new System.Windows.Forms.Label();
            this.StartDate = new System.Windows.Forms.DateTimePicker();
            this.labelLastSession = new System.Windows.Forms.Label();
            this.LastSession = new System.Windows.Forms.TextBox();
            this.buttonOk = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.contextMenuNotifyIcon.SuspendLayout();
            this.groupBoxFirebird.SuspendLayout();
            this.groupBoxFtp.SuspendLayout();
            this.SuspendLayout();
            // 
            // notifyIcon
            // 
            this.notifyIcon.ContextMenuStrip = this.contextMenuNotifyIcon;
            this.notifyIcon.Icon = ((System.Drawing.Icon)(resources.GetObject("notifyIcon.Icon")));
            this.notifyIcon.Text = "Получение сменных отчетов Топаз";
            this.notifyIcon.Visible = true;
            this.notifyIcon.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.notifyIcon_MouseDoubleClick);
            // 
            // contextMenuNotifyIcon
            // 
            this.contextMenuNotifyIcon.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuItemExit});
            this.contextMenuNotifyIcon.Name = "contextMenuNotifyIcon";
            this.contextMenuNotifyIcon.Size = new System.Drawing.Size(187, 26);
            // 
            // menuItemExit
            // 
            this.menuItemExit.Name = "menuItemExit";
            this.menuItemExit.Size = new System.Drawing.Size(186, 22);
            this.menuItemExit.Text = "Закрыть программу";
            this.menuItemExit.Click += new System.EventHandler(this.menuItemExit_Click);
            // 
            // FirebirdServerName
            // 
            this.FirebirdServerName.Location = new System.Drawing.Point(89, 19);
            this.FirebirdServerName.Name = "FirebirdServerName";
            this.FirebirdServerName.Size = new System.Drawing.Size(121, 20);
            this.FirebirdServerName.TabIndex = 1;
            // 
            // labelFirebirdServerName
            // 
            this.labelFirebirdServerName.AutoSize = true;
            this.labelFirebirdServerName.Location = new System.Drawing.Point(6, 22);
            this.labelFirebirdServerName.Name = "labelFirebirdServerName";
            this.labelFirebirdServerName.Size = new System.Drawing.Size(77, 13);
            this.labelFirebirdServerName.TabIndex = 2;
            this.labelFirebirdServerName.Text = "Имя сервера:";
            // 
            // groupBoxFirebird
            // 
            this.groupBoxFirebird.Controls.Add(this.labelFirebirdDatabaseFile);
            this.groupBoxFirebird.Controls.Add(this.FirebirdDatabaseFile);
            this.groupBoxFirebird.Controls.Add(this.labelFirebirdPassword);
            this.groupBoxFirebird.Controls.Add(this.FirebirdPassword);
            this.groupBoxFirebird.Controls.Add(this.labelFirebirdUserName);
            this.groupBoxFirebird.Controls.Add(this.FirebirdUserName);
            this.groupBoxFirebird.Controls.Add(this.labelFirebirdServerName);
            this.groupBoxFirebird.Controls.Add(this.FirebirdServerName);
            this.groupBoxFirebird.Location = new System.Drawing.Point(12, 12);
            this.groupBoxFirebird.Name = "groupBoxFirebird";
            this.groupBoxFirebird.Size = new System.Drawing.Size(489, 76);
            this.groupBoxFirebird.TabIndex = 3;
            this.groupBoxFirebird.TabStop = false;
            this.groupBoxFirebird.Text = "Подключение к серверу Firebird";
            // 
            // labelFirebirdDatabaseFile
            // 
            this.labelFirebirdDatabaseFile.AutoSize = true;
            this.labelFirebirdDatabaseFile.Location = new System.Drawing.Point(6, 48);
            this.labelFirebirdDatabaseFile.Name = "labelFirebirdDatabaseFile";
            this.labelFirebirdDatabaseFile.Size = new System.Drawing.Size(58, 13);
            this.labelFirebirdDatabaseFile.TabIndex = 8;
            this.labelFirebirdDatabaseFile.Text = "Файл БД:";
            // 
            // FirebirdDatabaseFile
            // 
            this.FirebirdDatabaseFile.Location = new System.Drawing.Point(89, 45);
            this.FirebirdDatabaseFile.Name = "FirebirdDatabaseFile";
            this.FirebirdDatabaseFile.Size = new System.Drawing.Size(388, 20);
            this.FirebirdDatabaseFile.TabIndex = 7;
            // 
            // labelFirebirdPassword
            // 
            this.labelFirebirdPassword.AutoSize = true;
            this.labelFirebirdPassword.Location = new System.Drawing.Point(345, 22);
            this.labelFirebirdPassword.Name = "labelFirebirdPassword";
            this.labelFirebirdPassword.Size = new System.Drawing.Size(48, 13);
            this.labelFirebirdPassword.TabIndex = 6;
            this.labelFirebirdPassword.Text = "Пароль:";
            // 
            // FirebirdPassword
            // 
            this.FirebirdPassword.Location = new System.Drawing.Point(399, 19);
            this.FirebirdPassword.Name = "FirebirdPassword";
            this.FirebirdPassword.Size = new System.Drawing.Size(78, 20);
            this.FirebirdPassword.TabIndex = 5;
            // 
            // labelFirebirdUserName
            // 
            this.labelFirebirdUserName.AutoSize = true;
            this.labelFirebirdUserName.Location = new System.Drawing.Point(218, 22);
            this.labelFirebirdUserName.Name = "labelFirebirdUserName";
            this.labelFirebirdUserName.Size = new System.Drawing.Size(41, 13);
            this.labelFirebirdUserName.TabIndex = 4;
            this.labelFirebirdUserName.Text = "Логин:";
            // 
            // FirebirdUserName
            // 
            this.FirebirdUserName.Location = new System.Drawing.Point(265, 19);
            this.FirebirdUserName.Name = "FirebirdUserName";
            this.FirebirdUserName.Size = new System.Drawing.Size(78, 20);
            this.FirebirdUserName.TabIndex = 3;
            // 
            // groupBoxFtp
            // 
            this.groupBoxFtp.Controls.Add(this.labelFtpPassword);
            this.groupBoxFtp.Controls.Add(this.FtpPassword);
            this.groupBoxFtp.Controls.Add(this.labelFtpLogin);
            this.groupBoxFtp.Controls.Add(this.FtpLogin);
            this.groupBoxFtp.Controls.Add(this.labelFtpHost);
            this.groupBoxFtp.Controls.Add(this.FtpHost);
            this.groupBoxFtp.Location = new System.Drawing.Point(12, 94);
            this.groupBoxFtp.Name = "groupBoxFtp";
            this.groupBoxFtp.Size = new System.Drawing.Size(489, 51);
            this.groupBoxFtp.TabIndex = 4;
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
            // labelStartDate
            // 
            this.labelStartDate.AutoSize = true;
            this.labelStartDate.Location = new System.Drawing.Point(18, 154);
            this.labelStartDate.Name = "labelStartDate";
            this.labelStartDate.Size = new System.Drawing.Size(58, 13);
            this.labelStartDate.TabIndex = 10;
            this.labelStartDate.Text = "Нач. дата:";
            // 
            // StartDate
            // 
            this.StartDate.Location = new System.Drawing.Point(101, 154);
            this.StartDate.Name = "StartDate";
            this.StartDate.Size = new System.Drawing.Size(121, 20);
            this.StartDate.TabIndex = 11;
            // 
            // labelLastSession
            // 
            this.labelLastSession.AutoSize = true;
            this.labelLastSession.Location = new System.Drawing.Point(18, 183);
            this.labelLastSession.Name = "labelLastSession";
            this.labelLastSession.Size = new System.Drawing.Size(74, 13);
            this.labelLastSession.TabIndex = 13;
            this.labelLastSession.Text = "Выгр. смена:";
            // 
            // LastSession
            // 
            this.LastSession.Location = new System.Drawing.Point(101, 180);
            this.LastSession.Name = "LastSession";
            this.LastSession.Size = new System.Drawing.Size(121, 20);
            this.LastSession.TabIndex = 12;
            // 
            // buttonOk
            // 
            this.buttonOk.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOk.Location = new System.Drawing.Point(345, 205);
            this.buttonOk.Name = "buttonOk";
            this.buttonOk.Size = new System.Drawing.Size(75, 23);
            this.buttonOk.TabIndex = 14;
            this.buttonOk.Text = "Принять";
            this.buttonOk.UseVisualStyleBackColor = true;
            this.buttonOk.Click += new System.EventHandler(this.buttonOk_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(426, 205);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 15;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // timer
            // 
            this.timer.Interval = 1800000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 235);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOk);
            this.Controls.Add(this.labelLastSession);
            this.Controls.Add(this.LastSession);
            this.Controls.Add(this.StartDate);
            this.Controls.Add(this.labelStartDate);
            this.Controls.Add(this.groupBoxFtp);
            this.Controls.Add(this.groupBoxFirebird);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Настройка получения сменных отчетов Топаз";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.contextMenuNotifyIcon.ResumeLayout(false);
            this.groupBoxFirebird.ResumeLayout(false);
            this.groupBoxFirebird.PerformLayout();
            this.groupBoxFtp.ResumeLayout(false);
            this.groupBoxFtp.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.NotifyIcon notifyIcon;
        private System.Windows.Forms.ContextMenuStrip contextMenuNotifyIcon;
        private System.Windows.Forms.ToolStripMenuItem menuItemExit;
        private System.Windows.Forms.TextBox FirebirdServerName;
        private System.Windows.Forms.Label labelFirebirdServerName;
        private System.Windows.Forms.GroupBox groupBoxFirebird;
        private System.Windows.Forms.Label labelFirebirdPassword;
        private System.Windows.Forms.TextBox FirebirdPassword;
        private System.Windows.Forms.Label labelFirebirdUserName;
        private System.Windows.Forms.TextBox FirebirdUserName;
        private System.Windows.Forms.Label labelFirebirdDatabaseFile;
        private System.Windows.Forms.TextBox FirebirdDatabaseFile;
        private System.Windows.Forms.GroupBox groupBoxFtp;
        private System.Windows.Forms.Label labelFtpPassword;
        private System.Windows.Forms.TextBox FtpPassword;
        private System.Windows.Forms.Label labelFtpLogin;
        private System.Windows.Forms.TextBox FtpLogin;
        private System.Windows.Forms.Label labelFtpHost;
        private System.Windows.Forms.TextBox FtpHost;
        private System.Windows.Forms.Label labelStartDate;
        private System.Windows.Forms.DateTimePicker StartDate;
        private System.Windows.Forms.Label labelLastSession;
        private System.Windows.Forms.TextBox LastSession;
        private System.Windows.Forms.Button buttonOk;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Timer timer;
    }
}

