using ARPLogistic_BE;
using ARPLogistic_BE.BusinessLayer;
using ARPLogistic_BE.Entities;
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
    public partial class frmTransferRoute : Form
    {
        int intUniqID = 0;
        DataAccess da = new DataAccess(Global.AllVisionsCS);
        private TransferRouteManagement transferRouteManagement = new TransferRouteManagement();
        private TransferRoute transferRoute = new TransferRoute();

        public frmTransferRoute()
        {
            InitializeComponent();
        }

        private void frmTransferRoute_Load(object sender, EventArgs e)
        {

            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);

            da.FillDropDownList("SELECT [LocationCode], [LocationName] FROM [dbo].[Locations] With (NOLOCK) WHERE UseAsInTransit = 0 UNION Select '','' Order By [LocationName] ", cboTransferfromCode);
            da.FillDropDownList("SELECT [LocationCode], [LocationName] FROM [dbo].[Locations] With (NOLOCK) WHERE UseAsInTransit = 0 UNION Select '','' Order By [LocationName] ", cboTransfertoCode);

            fillGrid();

        }

        void fillGrid()
        {
            ClearText();
            DataTable dt = transferRouteManagement.RetrieveTransferRouteGrid("","");

            dgvTransferRoute.DataSource = dt;
            if (dgvTransferRoute.RowCount > 0)
            {
                dgvTransferRoute.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
                dgvTransferRoute.Columns[0].Visible = false;
            }
            cboTransferfromCode.Focus();
        }

        void LoadData()
        {
            transferRoute = transferRouteManagement.RetrieveTransferRouteByID(intUniqID);
            if (transferRouteManagement.Error == string.Empty)
            {
                if (transferRoute.TransferRouteID > 0)
                {
                    cboTransferfromCode.SelectedValue = transferRoute.TransferfromCode;
                    cboTransfertoCode.SelectedValue = transferRoute.TransfertoCode;

                    txtJarakTempuh.Text = transferRoute.JarakTempuh.ToString("N2");
                    txtBiayaToll.Text = transferRoute.BiayaToll.ToString("N2");
                    txtBiayaBBM.Text = transferRoute.BiayaBBM.ToString("N2");
                    txtRetribusi.Text = transferRoute.Retribusi.ToString("N2");
                    txtRetribusi.Text = transferRoute.Retribusi.ToString("N2");

                    txtID.Text = transferRoute.TransferRouteID.ToString();

                }
                else if (transferRoute.TransferfromCode == string.Empty)
                {
                    ClearText();
                }
            }
            cboTransferfromCode.Focus();
        }

        void ClearText()
        {
            transferRoute = new TransferRoute();

            cboTransferfromCode.SelectedValue = transferRoute.TransferfromCode;
            cboTransfertoCode.SelectedValue = transferRoute.TransfertoCode;

            txtJarakTempuh.Text = transferRoute.JarakTempuh.ToString("N2");
            txtBiayaToll.Text = transferRoute.BiayaToll.ToString("N2");
            txtBiayaBBM.Text = transferRoute.BiayaBBM.ToString("N2");
            txtRetribusi.Text = transferRoute.Retribusi.ToString("N2");
            txtRetribusi.Text = transferRoute.Retribusi.ToString("N2");

            txtID.Text = transferRoute.TransferRouteID.ToString();
        }

        private int SaveData()
        {
            transferRoute.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

            int intResult = transferRouteManagement.EditTransferRoute(transferRoute);

            if (intResult == -1)
            {
                MessageBox.Show(transferRouteManagement.Error, Global.strProductName);
                return -1;
            }
            else
            {
                intUniqID = intResult;
                transferRoute.TransferRouteID = intResult;
                //LoadData();
                return 0;
            }
        }

        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void dgvtransferRoute_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            intUniqID = Convert.ToInt32(dgvTransferRoute.Rows[e.RowIndex].Cells[0].Value);
            LoadData();
        }

        private void cboTransferfromCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboTransferfromCode.SelectedIndex != -1)
                if (transferRoute.TransferfromCode != cboTransferfromCode.SelectedValue.ToString())
                {
                    transferRoute.TransferfromCode = cboTransferfromCode.SelectedValue.ToString();
                    SaveData();
                }
        }

        private void cboTransfertoCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboTransfertoCode.SelectedIndex != -1)
                if (transferRoute.TransfertoCode != cboTransfertoCode.SelectedValue.ToString())
                {
                    transferRoute.TransfertoCode = cboTransfertoCode.SelectedValue.ToString();
                    SaveData();
                }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void txtJarakTempuh_Validating(object sender, CancelEventArgs e)
        {
            if (transferRoute.JarakTempuh != Convert.ToDecimal(txtJarakTempuh.Text))
            {
                transferRoute.JarakTempuh = Convert.ToDecimal(txtJarakTempuh.Text);
                SaveData();
            }
        }

        private void txtBiayaToll_Validating(object sender, CancelEventArgs e)
        {
            if (transferRoute.BiayaToll != Convert.ToDecimal(txtBiayaToll.Text))
            {
                transferRoute.BiayaToll = Convert.ToDecimal(txtBiayaToll.Text);
                SaveData();
            }
        }

        private void txtBiayaBBM_Validating(object sender, CancelEventArgs e)
        {
            if (transferRoute.BiayaBBM != Convert.ToDecimal(txtBiayaBBM.Text))
            {
                transferRoute.BiayaBBM = Convert.ToDecimal(txtBiayaBBM.Text);
                SaveData();
            }
        }

        private void txtRetribusi_Validating(object sender, CancelEventArgs e)
        {
            if (transferRoute.Retribusi != Convert.ToDecimal(txtRetribusi.Text))
            {
                transferRoute.Retribusi = Convert.ToDecimal(txtRetribusi.Text);
                SaveData();
            }
        }

        private void txtBiayaLainLain_Validating(object sender, CancelEventArgs e)
        {
            if (transferRoute.BiayaLainLain != Convert.ToDecimal( txtBiayaLainLain.Text))
            {
                transferRoute.BiayaLainLain = Convert.ToDecimal(txtBiayaLainLain.Text);
                SaveData();
            }
        }

        private void cboTransferfromCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTransfertoCode.Focus();
                //fillGrid();
            }
        }

        private void cboTransfertoCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtJarakTempuh.Focus();
                //fillGrid();
            }
        }

        private void txtJarakTempuh_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBiayaToll.Focus();
                //fillGrid();
            }
        }

        private void txtBiayaToll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBiayaBBM.Focus();
                //fillGrid();
            }
        }

        private void txtBiayaBBM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtRetribusi.Focus();
                //fillGrid();
            }
        }

        private void txtRetribusi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                txtBiayaLainLain.Focus();
                //fillGrid();
            }
        }

        private void txtBiayaLainLain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                cboTransferfromCode.Focus();
                fillGrid();
            }
        }
    }
}
