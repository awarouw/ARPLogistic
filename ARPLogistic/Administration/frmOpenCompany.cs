using ARPLogistic_BE;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic.Administration
{
    public partial class frmOpenCompany : Form
    {
        CompanyManagement companyManagement = new CompanyManagement();

        public frmOpenCompany()
        {
            InitializeComponent();
        }

        private void btClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            Close();
        }

        private void btOK_Click(object sender, EventArgs e)
        {
            UpdateComp();
            //if (lsCompanyList.SelectedIndex > -1)
            //{
            //    string strCompanyCode = lsCompanyList.SelectedItem.ToString();
            //    //rest of your logic
            //    //mdlGlobal.systemUsers.CompanyCode = strCompanyCode;
            //    Global.CompanyCode = strCompanyCode;
            //    Global.intUserID = mdlGlobal.systemUsers.SystemUsersID;
            //    mdlGlobal.companyInformation = companyManagement.RetrieveCompanyInformationByCode(strCompanyCode);
            //    this.DialogResult = DialogResult.OK;
            //}
        }

        private void frmOpenCompany_Load(object sender, EventArgs e)
        {
            bind();
        }

        private void bind()
        {
            //Clear the existing list
            //lsCompanyList.
            //This implementation assumes the DataSource is a DataSet
            //string strCompanyCode = mdlGlobal.companyInformation.ParentCompanyCode;
            DataTable dt = companyManagement.RetrieveCompanyList(mdlGlobal.systemUsers.UserCode);

            //SqlConnection con = new SqlConnection("connectionstring");
            //SqlDataAdapter ada = new SqlDataAdapter("select * from MasterLocation", con);
            //DataTable dt = new DataTable();
            //ada.Fill(dt);

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                DataRow dr = dt.Rows[i];
                //ListViewItem listitem = new ListViewItem(dr["CompanyCode"].ToString());
                //listitem.SubItems.Add(dr["var_Location_Name"].ToString());
                //listitem.SubItems.Add(dr["fk_int_District_ID"].ToString());
                //listitem.SubItems.Add(dr["fk_int_Company_ID"].ToString());
                lsCompanyList.Items.Add(dr["CompanyCode"].ToString());
            }
        }

        private void lsCompanyList_DoubleClick(object sender, EventArgs e)
        {
            UpdateComp();
            //if (lsCompanyList.SelectedIndex > -1)
            //{
            //    string strCompanyCode = lsCompanyList.SelectedItem.ToString();
            //    //rest of your logic
            //    //mdlGlobal.systemUsers.CompanyCode = strCompanyCode;
            //    Global.CompanyCode = strCompanyCode;
            //    Global.intUserID = mdlGlobal.systemUsers.SystemUsersID;
            //    mdlGlobal.companyInformation = companyManagement.RetrieveCompanyInformationByCode(Global.CompanyCode);
            //    Global.AllVisionsCS = mdlGlobal.companyInformation.AllVisionCS;
            //    this.DialogResult = DialogResult.OK;
            //}
        }

        void UpdateComp()
        {
            if (lsCompanyList.SelectedIndex > -1)
            {
                string strCompanyCode = lsCompanyList.SelectedItem.ToString();
                //rest of your logic
                //mdlGlobal.systemUsers.CompanyCode = strCompanyCode;
                Global.CompanyCode = strCompanyCode;
                Global.intUserID = mdlGlobal.systemUsers.SystemUsersID;
                mdlGlobal.companyInformation = companyManagement.RetrieveCompanyInformationByCode(Global.CompanyCode);
                Global.AllVisionsCS = mdlGlobal.companyInformation.AllVisionsCS;

                //periksa versi didatabase jika lebih besar maka periksa perubahan script
                var e1 = new Version(mdlGlobal.companyInformation.APPVersion);
                var e2 = new Version(Global.strVersionNo.Trim());
                if (e1.CompareTo(e2) < 0)
                {
                    DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);

                    string[] DirectoryList = Directory.GetDirectories(Directory.GetCurrentDirectory() + @"\Versions\", "*");

                    string sourceDir = Directory.GetCurrentDirectory() + @"\Versions";

                    string[] fileList;
                    foreach (string dl in DirectoryList)
                    {
                        fileList = Directory.GetFiles(dl, "*.*");
                        string DirName = dl.Substring(sourceDir.Length + 1);
                        var e3 = new Version(DirName.Trim());
                        if (e1.CompareTo(e3) < 0)
                        {
                            foreach (string f in fileList)
                            {
                                string fName = f.Substring(dl.Length + 1);

                                string strError = dataAccess.ProcessDataWithQueryParameter(File.ReadAllText(Directory.GetCurrentDirectory() + @"\Versions\" + e3 + @"\" + fName));

                                if (strError != string.Empty)
                                {
                                    MessageBox.Show(strError, " UPDATE DATABASE ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
                                    //updateFailed = true;
                                }
                            }
                        }
                    }
                    mdlGlobal.companyInformation.APPVersion = Global.strVersionNo.Trim();
                    SaveCompanyData();
                }
                this.DialogResult = DialogResult.OK;
            }
        }



        private int SaveCompanyData()
        {
            mdlGlobal.companyInformation.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

            string intResult = companyManagement.EditCompanyInformation(mdlGlobal.companyInformation);

            if (intResult == "Error")
            {
                MessageBox.Show(companyManagement.Error, Global.strProductName);
                return -1;
            }
            else
                return 0;
        }

    }
}
