using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace GetTopazSessionReports
{
    public partial class SessionNumberInputForm : Form
    {
        public long sessionNum = 0;

        public SessionNumberInputForm()
        {
            InitializeComponent();
        }

        private void buttonOk_Click(object sender, EventArgs e)
        {
            if (!Int64.TryParse(SessionNum.Text, out sessionNum))
                MessageBox.Show("Номер смены должен быть числом!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            else
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            sessionNum = -1;
        }
    }
}
