using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic
{
    public partial class frmUpdater : Form
    {
        private short status = 0;
        public string NewVersion = "";
        public string CurrentVersion = "";
        public string CompName = "";

        private void frmUpdater_Load(object sender, EventArgs e)
        {
            this.label6.Text = this.label6.Text.Replace("___", CompName);
            this.lbCurrenctVersion.Text = CurrentVersion;
            this.lbNewVersion.Text = NewVersion;

            this.btOk.Visible = true;
            this.btOk.Focus();
        }

        public short Status
        {
            get
            {
                return status;
            }
        }

        public frmUpdater(string strNewVersion, string strCurrentVersion, string strCompanyName)
        {
            InitializeComponent();
            NewVersion = strNewVersion;
            CurrentVersion = strCurrentVersion;
            CompName = strCompanyName;
        }

        private void btOk_Click(object sender, EventArgs e)
        {
            status = 1;
            Close();
        }

        private void btCancel_Click(object sender, EventArgs e)
        {
            status = 0;
            Close();
        }

    }
}

