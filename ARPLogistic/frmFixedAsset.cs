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
    public partial class frmFixedAsset : Form
    {
        int intUniqID = 0;
        private FixedAssetManagement fixedAssetManagement = new FixedAssetManagement();
        private FixedAsset fixedAsset = new FixedAsset();
        public frmFixedAsset()
        {
            InitializeComponent();
        }

        private void frmFixedAsset_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);

            ClearText();

            DataAccess da = new DataAccess(Global.AllVisionsCS);

            LoadData();
        }

        private void ClearText()
        {
            fixedAsset = new FixedAsset();
            txtNo.Text = fixedAsset.No;
            txtDescription.Text = fixedAsset.Description;
            txtSerialNo.Text = fixedAsset.SerialNo;
        }

        void LoadData()
        {
            fixedAsset = fixedAssetManagement.RetrieveFixedAssetByID(intUniqID);
            if (fixedAssetManagement.Error == string.Empty)
            {
                if (fixedAsset.FixedAssetID > 0)
                {
                    txtNo.Text = fixedAsset.No;
                    txtDescription.Text = fixedAsset.Description;
                    txtSerialNo.Text = fixedAsset.SerialNo;
                }
                else if (fixedAsset.No == string.Empty)
                {
                    ClearText();
                }
            }
        }

        private int SaveData()
        {
            fixedAsset.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

            int intResult = fixedAssetManagement.EditFixedAsset(fixedAsset);

            if (intResult == -1)
            {
                MessageBox.Show(fixedAssetManagement.Error, Global.strProductName);
                return -1;
            }
            else
            {
                intUniqID = intResult;
                fixedAsset.FixedAssetID = intResult;
                //LoadData();
                return 0;
            }
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btNext_Click(object sender, EventArgs e)
        {
            int FixedAssetID = fixedAsset.FixedAssetID;
            int NewLocationID = fixedAssetManagement.RetrieveFixedAssetNextID(FixedAssetID);
            if (fixedAssetManagement.Error == string.Empty)
            {
                intUniqID = NewLocationID;
                LoadData();
            }
        }

        private void byPrevious_Click(object sender, EventArgs e)
        {
            int FixedAssetID = fixedAsset.FixedAssetID;
            int NewLocationID = fixedAssetManagement.RetrieveFixedAssetPreviousID(FixedAssetID);
            if (fixedAssetManagement.Error == string.Empty)
            {
                intUniqID = NewLocationID;
                LoadData();
            }
        }

        private void tsAdd_Click(object sender, EventArgs e)
        {
            ClearText();
        }


        private void txtNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtNo.Text != "")
            {
                fixedAsset.No = txtNo.Text;
                SaveData();
            }
        }

        private void txtDescription_Validating(object sender, CancelEventArgs e)
        {
            if (txtDescription.Text != "")
            {
                fixedAsset.Description = txtDescription.Text;
                SaveData();
            }
        }

        private void txtSerialNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtSerialNo.Text != "")
            {
                fixedAsset.SerialNo = txtSerialNo.Text;
                SaveData();
            }
        }

    }
}
