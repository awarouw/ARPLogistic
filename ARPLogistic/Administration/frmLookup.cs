using ARPLogistic_BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic.Administration
{
    public partial class frmLookup : Form
    {
        public string strSQLString = "";
        public string strComboFilter = "";
        public string strResult = "";
        public string strExcelFileName = "";
        DataAccess da = new DataAccess(Global.AllVisionsCS);
        DataSet ds = new DataSet();

        public frmLookup()
        {
            InitializeComponent();
        }

        private void frmLookup_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            //Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);
            //this.pi.Image = myimage;

            LoadData(strSQLString);
            da.FillDropDownList(strComboFilter, cboFilter);
        }

        private void txtFilter_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (cboFilter.SelectedIndex > -1)
                {
                    e.SuppressKeyPress = true;
                    e.Handled = true;

                    DataView dv;
                    dv = new DataView(ds.Tables[0], cboFilter.SelectedValue + " like '%" + txtFilter.Text + "%'", cboFilter.SelectedValue + " Desc", DataViewRowState.CurrentRows);
                    dataGridView1.DataSource = dv;

                    dataGridView1.Focus();
                }
                // or

                //BindingSource bs = new BindingSource();
                //bs.DataSource = dataGridView1.DataSource;
                //bs.Filter = cboFilter.Text + " like '%" + txtFilter.Text + "%'";
                //dataGridView1.DataSource = bs.DataSource;
            }

        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            LoadData(strSQLString);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow != null)
            {
                strResult = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please choose lookup data");
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadData(string SQLString)
        {
            ds = da.RetrieveDatSet(SQLString);
            if (ds.Tables.Count > 0)
            {
                dataGridView1.DataSource = ds.Tables[0];
                dataGridView1.Columns[0].Visible = false;
                dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            }
        }

        private void dataGridView1_CellContentDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            strResult = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            this.Close();

            //MessageBox.Show(dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString());
        }

        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                //GetItemInformation();
                strResult = dataGridView1.Rows[dataGridView1.CurrentRow.Index].Cells[0].Value.ToString();
                this.Close();
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            if (strExcelFileName == "")
                sfd.FileName = "ExportedData.xls";
            else
                sfd.FileName = strExcelFileName;

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                dbSecurity.ToCsV(dataGridView1, sfd.FileName); // Here dataGridview1 is your grid view name
            }
        }

    }
}
