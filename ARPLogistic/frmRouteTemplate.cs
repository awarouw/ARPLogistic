using ARPLogistic.Administration;
using ARPLogistic_BE;
using ARPLogistic_BE.Administration;
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
    public partial class frmRouteTemplate : Form
    {
        int intUniqID = 0;
        DataAccess da = new DataAccess(Global.AllVisionsCS);
        private DataTable dtTrans;

        private RouteTemplate routeTemplate = new RouteTemplate();
        private RouteTemplateManagement RouteTemplateMgmt = new RouteTemplateManagement();

        private RouteTemplateLine routeTemplateLine = new RouteTemplateLine();
        private RouteTemplateLineManagement RouteTemplateLineMgmt = new RouteTemplateLineManagement();

        public frmRouteTemplate()
        {
            InitializeComponent();
        }

        private void frmRouteTemplate_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            ClearText();

            if (intUniqID > 0)
                LoadData();
            else
                goLastRecord();

        }


        private void tsClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void ClearText()
        {
            routeTemplate = new RouteTemplate();

            routeTemplate.Name = "";
            routeTemplate.Description = "";
            routeTemplate.Blocked = 0;

            FillHeader();
        }

        void LoadData()
        {
            routeTemplate = RouteTemplateMgmt.RetrieveRouteTemplateByID(intUniqID);
            if (RouteTemplateMgmt.Error == string.Empty)
            {
                if (routeTemplate.RouteTemplateID > 0)
                {
                    FillHeader();

                    switch (routeTemplate.Blocked)
                    {
                        case 0: // New
                            panel1.Enabled = true;
                            panel2.Enabled = true;
                            tsDelete.Enabled = true;
                            break;
                        case 1: // Sent
                            panel1.Enabled = false;
                            panel2.Enabled = false;
                            tsDelete.Enabled = false;
                            break;
                    }
                }
                else if (routeTemplate.Name == string.Empty)
                {
                    ClearText();
                }
            }
            ClearLine();
        }

        void FillHeader()
        {

            txtID.Text = routeTemplate.RouteTemplateID.ToString();
            txtRouteTemplateNo.Text = routeTemplate.Name;
            txtDescription.Text = routeTemplate.Description;
            cboStatus.SelectedValue = routeTemplate.Blocked;

            RefressGrid();
            ClearLine();
        }

        private void RefressGrid()
        {
            dtTrans = RouteTemplateLineMgmt.RetrieveRouteTemplateLineByHeaderID4Grid(routeTemplate.RouteTemplateID, dtTrans);
            dgvRouteTemplateLine.DataSource = dtTrans;
            if (dgvRouteTemplateLine.RowCount > 0)
            {
                dgvRouteTemplateLine.Columns[0].Visible = false;
                dgvRouteTemplateLine.Columns[1].Visible = false;
                //dgvrouteTemplateLine.Columns[2].Visible = false;
                //dgvrouteTemplateLine.Columns[3].Visible = false;
                dgvRouteTemplateLine.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        void ClearLine()
        {
            routeTemplateLine = new RouteTemplateLine();

            routeTemplateLine.RouteTemplateID = routeTemplate.RouteTemplateID;
            routeTemplateLine.RouteTemplateCode = routeTemplate.Name;

            routeTemplateLine.TransferFromCode = "";
            routeTemplateLine.TransferToCode = "";

            routeTemplateLine.JarakTempuh = 0;
            routeTemplateLine.BiayaToll = 0;
            routeTemplateLine.BiayaBBM = 0;
            routeTemplateLine.Retribusi = 0;
            routeTemplateLine.BiayaLainLain = 0;

            CurrentLineItem();

        }

        void CurrentLineItem()
        {
            txtSeqlineNo.Text = routeTemplateLine.SeqLineNo.ToString();
            txtFromCode.Text = routeTemplateLine.TransferFromCode;
            txtToCode.Text = routeTemplateLine.TransferToCode;

            txtJarak.Text = routeTemplateLine.JarakTempuh.ToString("N0");
            txtToll.Text = routeTemplateLine.BiayaToll.ToString("N0");
            txtBBM.Text = routeTemplateLine.BiayaBBM.ToString("N0");
            txtRetribusi.Text = routeTemplateLine.Retribusi.ToString("N0");
            txtLainLain.Text = routeTemplateLine.BiayaLainLain.ToString("N0");
        }

        private void SaveHeaderData()
        {
            try
            {
                routeTemplate.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

                int intResult = RouteTemplateMgmt.EditRouteTemplate(routeTemplate);

                if (intResult == -1)
                {
                    MessageBox.Show(RouteTemplateMgmt.Error, Global.strProductName);
                }
                else
                {
                    intUniqID = intResult;
                    LoadData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        void SaveLine()
        {
            try
            {
                routeTemplateLine.RouteTemplateID = routeTemplate.RouteTemplateID;
                routeTemplateLine.RouteTemplateCode = routeTemplate.Name;

                routeTemplateLine.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

                int intResult = RouteTemplateLineMgmt.EditRouteTemplateLine(routeTemplateLine);

                if (intResult == -1)
                {
                    MessageBox.Show(RouteTemplateMgmt.Error, Global.strProductName);
                }
                else
                {
                    LoadData();
                    txtSeqlineNo.Focus();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #region Button Header

        private void tsFirstRecord_Click(object sender, EventArgs e)
        {
            goFirstRecord();
        }

        private void tsPreviousRecord_Click(object sender, EventArgs e)
        {
            goPreviousRecord();
        }

        private void tsNextRecord_Click(object sender, EventArgs e)
        {
            goNextRecord();
        }

        private void tsLastRecord_Click(object sender, EventArgs e)
        {
            goLastRecord();
        }

        void goFirstRecord()
        {
            int RouteTemplateID = routeTemplate.RouteTemplateID;
            int NewitemJournalHeaderID = RouteTemplateMgmt.RetrieveRouteTemplateFirstID(RouteTemplateID);
            if (RouteTemplateMgmt.Error == string.Empty)
            {
                intUniqID = NewitemJournalHeaderID;
                LoadData();
            }

        }

        void goNextRecord()
        {
            int RouteTemplateID = routeTemplate.RouteTemplateID;
            int NewitemJournalHeaderID = RouteTemplateMgmt.RetrieveRouteTemplateNextID(RouteTemplateID);
            if (RouteTemplateMgmt.Error == string.Empty)
            {
                intUniqID = NewitemJournalHeaderID;
                LoadData();
            }

        }

        void goPreviousRecord()
        {
            int RouteTemplateID = routeTemplate.RouteTemplateID;
            int NewitemJournalHeaderID = RouteTemplateMgmt.RetrieveRouteTemplatePreviousID(RouteTemplateID);
            if (RouteTemplateMgmt.Error == string.Empty)
            {
                intUniqID = NewitemJournalHeaderID;
                LoadData();
            }
        }

        void goLastRecord()
        {
            int RouteTemplateID = routeTemplate.RouteTemplateID;
            int NewitemJournalHeaderID = RouteTemplateMgmt.RetrieveRouteTemplateLastID(RouteTemplateID);
            if (RouteTemplateMgmt.Error == string.Empty)
            {
                intUniqID = NewitemJournalHeaderID;
                LoadData();
            }
        }

        private void tsFindRecord_Click(object sender, EventArgs e)
        {
            frmLookupWithTop frmlookup = new frmLookupWithTop();
            frmlookup.strComboFilter = "Select 'No' , 'No' UNION SELECT 'TransferfromCode', 'FromLocation' UNION SELECT 'TransfertoCode', 'ToLocation'";
            //frmlookup.strSQLString = "SELECT [StockReturnReceiptHeaderID],[DocumentNo],[DocumentDate],[PostingDate],[FromLocationCode],[ToLocationCode],[JournalDescription] FROM StockReturnReceiptHeader With (Nolock) ";
            frmlookup.strSQLString = " routeTemplateID, No, TransferfromCode, TransfertoCode, Case When RetailStatus = 1 then ShipmentDate else ReceiptDate end TrxDate, (SELECT [LookupDescription] FROM dbo.LookupField WITH (NOLOCK) WHERE LookupGroup = 'TransferRestailStatus' AND [LookupCode] = RetailStatus ) as [Status] FROM routeTemplate With (Nolock) ";
            frmlookup.strSQLOrderBy = " [Status] Desc, TrxDate, No Desc ";
            frmlookup.ShowDialog();
            if (frmlookup.strResult != "")
            {
                intUniqID = Convert.ToInt32(frmlookup.strResult);
                LoadData();
            }
        }

        private void tsNew_Click(object sender, EventArgs e)
        {
            ClearText();
            panel1.Enabled = true;
            panel2.Enabled = true;
            tsDelete.Enabled = false;
            txtRouteTemplateNo.Focus();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        void DeleteHeader()
        {

            goLastRecord();
        }

        #endregion


        #region Button Line

        private void btNew_Click(object sender, EventArgs e)
        {
            ClearLine();
        }

        private void btDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are you sure you want to delete this Route Template Line?", Global.strProductName, MessageBoxButtons.YesNo) == System.Windows.Forms.DialogResult.Yes)

                DeleteLine();

        }

        void DeleteLine()
        {
            da.RetrieveDataByString("DELETE FROM routeTemplateLine WHERE routeTemplateLineID = " + routeTemplateLine.RouteTemplateLineID + " AND RouteTemplateCode = " + routeTemplateLine.RouteTemplateCode);
            RefressGrid();
            ClearLine();
            //            goLastRecordLine();
        }

        #endregion

        #region Header Field

        #region txtRouteTemplateNo
        private void txtRouteTemplateNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtDescription.Focus();
            }
        }

        private void txtRouteTemplateNo_Leave(object sender, EventArgs e)
        {
            if (routeTemplate.Name != txtRouteTemplateNo.Text || routeTemplate.Name == "")
            {
                txtRouteTemplateNo_Validate();
            }
        }

        void txtRouteTemplateNo_Validate()
        {
            try
            {
                if (routeTemplate.Name != txtRouteTemplateNo.Text || routeTemplate.Name == "")
                {
                    if (txtRouteTemplateNo.Text != "")
                    {
                        routeTemplate.Name = txtRouteTemplateNo.Text;
                        SaveHeaderData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }
        #endregion

        #region Description

        private void txtDescription_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboStatus.Focus();
            }
        }

        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (routeTemplate.Description != txtDescription.Text || routeTemplate.Description == "")
            {
                txtDescription_Validate();
            }
        }

        void txtDescription_Validate()
        {
            try
            {
                if (routeTemplate.Description != txtDescription.Text)
                {
                    if (txtDescription.Text != "")
                    {
                        routeTemplate.Description = txtDescription.Text;
                        SaveHeaderData();
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #endregion

        #region Detail Field

        #region SeqlineNo

        private void txtSeqlineNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtFromCode.Focus();
            }
        }

        private void txtSeqlineNo_Validating(object sender, CancelEventArgs e)
        {
            if (txtSeqlineNo.Text != string.Empty || txtSeqlineNo.Text != "")
                SeqLineNo_Validate();
            else
            {
                MessageBox.Show("Line No must be integer");
                txtSeqlineNo.Focus();
            }
        }

        void SeqLineNo_Validate()
        {
            try
            {
                if (routeTemplateLine.SeqLineNo != Convert.ToInt32(txtSeqlineNo.Text) && txtSeqlineNo.Text != "")
                {
                    routeTemplateLine.SeqLineNo = Convert.ToInt32(txtSeqlineNo.Text);
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region TransferFromCode

        private void txtFromCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtToCode.Focus();
            }
        }

        private void txtFromCode_Leave(object sender, EventArgs e)
        {
            TransferFromCode_Validate();
        }

        void TransferFromCode_Validate()
        {
            try
            {
                if (routeTemplateLine.TransferFromCode != txtFromCode.Text)
                {
                    routeTemplateLine.TransferFromCode = txtFromCode.Text;
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }
        #endregion

        #region TransferToCode

        private void txtToCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtJarak.Focus();
            }
        }

        private void txtToCode_Leave(object sender, EventArgs e)
        {
            TransferToCode_Validate();
        }

        void TransferToCode_Validate()
        {
            try
            {
                if (routeTemplateLine.TransferToCode != txtToCode.Text)
                {
                    routeTemplateLine.TransferToCode = txtToCode.Text;
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }
        #endregion

        #region txtJarak

        private void txtJarak_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtToll.Focus();
            }
        }

        private void txtJarak_Validating(object sender, CancelEventArgs e)
        {
            if (txtJarak.Text != string.Empty || txtJarak.Text != "")
                JarakTempuh_Validate();
            else
            {
                MessageBox.Show("Jarak Tempuh must be Numeric");
                txtJarak.Focus();
            }
        }

        void JarakTempuh_Validate()
        {
            try
            {
                if (routeTemplateLine.JarakTempuh != Convert.ToDecimal(txtJarak.Text) && txtJarak.Text != "")
                {
                    routeTemplateLine.JarakTempuh = Convert.ToDecimal(txtJarak.Text);
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BiayaToll

        private void txtToll_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBBM.Focus();
            }
        }

        private void txtToll_Validating(object sender, CancelEventArgs e)
        {
            if (txtToll.Text != string.Empty || txtToll.Text != "")
                BiayaToll_Validate();
            else
            {
                MessageBox.Show("Biaya Toll must be Numeric");
                txtToll.Focus();
            }
        }

        void BiayaToll_Validate()
        {
            try
            {
                if (routeTemplateLine.BiayaToll != Convert.ToDecimal(txtToll.Text) && txtToll.Text != "")
                {
                    routeTemplateLine.BiayaToll = Convert.ToDecimal(txtToll.Text);
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BiayaBBM

        private void txtBBM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtRetribusi.Focus();
            }
        }

        private void txtBBM_Validating(object sender, CancelEventArgs e)
        {
            if (txtBBM.Text != string.Empty || txtBBM.Text != "")
                BiayaBBM_Validate();
            else
            {
                MessageBox.Show("Biaya BBM must be Numeric");
                txtBBM.Focus();
            }
        }

        void BiayaBBM_Validate()
        {
            try
            {
                if (routeTemplateLine.BiayaBBM != Convert.ToDecimal(txtBBM.Text) && txtBBM.Text != "")
                {
                    routeTemplateLine.BiayaBBM = Convert.ToDecimal(txtBBM.Text);
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Retribusi

        private void txtRetribusi_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtLainLain.Focus();
            }
        }

        private void txtRetribusi_Validating(object sender, CancelEventArgs e)
        {
            if (txtRetribusi.Text != string.Empty || txtRetribusi.Text != "")
                Retribusi_Validate();
            else
            {
                MessageBox.Show("Retribusi must be Numeric");
                txtRetribusi.Focus();
            }
        }

        void Retribusi_Validate()
        {
            try
            {
                if (routeTemplateLine.Retribusi != Convert.ToDecimal(txtRetribusi.Text) && txtRetribusi.Text != "")
                {
                    routeTemplateLine.Retribusi = Convert.ToDecimal(txtRetribusi.Text);
                    CurrentLineItem();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BiayaLainLain

        private void txtLainLain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtSeqlineNo.Focus();
            }
        }

        private void txtLainLain_Validating(object sender, CancelEventArgs e)
        {
            if (txtLainLain.Text != string.Empty || txtLainLain.Text != "")
                BiayaLainLain_Validate();
            else
            {
                MessageBox.Show("Biaya Lain Lain must be Numeric");
                txtLainLain.Focus();
            }
        }

        void BiayaLainLain_Validate()
        {
            try
            {
                if (routeTemplateLine.BiayaLainLain != Convert.ToDecimal(txtLainLain.Text) && txtLainLain.Text != "")
                {
                    routeTemplateLine.BiayaLainLain = Convert.ToDecimal(txtLainLain.Text);
                    CurrentLineItem();
                }
                SaveLine();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion


        private void dgvRouteTemplateLine_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            routeTemplateLine = RouteTemplateLineMgmt.RetrieveRouteTemplateLineByID(routeTemplateLine, Convert.ToInt32(dgvRouteTemplateLine.Rows[e.RowIndex].Cells[0].Value));
            CurrentLineItem();
        }

        #endregion

    }
}
