using ARPLogistic_BE;
using ARPLogistic_BE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic.Administration
{
    public partial class frmLogin : Form
    {
        CompanyManagement companyManagement = new CompanyManagement();

        public frmLogin()
        {
            InitializeComponent();
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\logoapp.jpg");
            //Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);
            //this.BackgroundImage = myimage;
            txtUserID.Focus();
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);
            Global.strProductName = fvi.ProductName;
            Global.strVersionNo = fvi.FileVersion;

           // this.Text += " to " + Global.MyBranchOffice;
            this.lbVersion.Text = "Version : " + Global.strVersionNo;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        void Login()
        {
            try
            {
                UserManagement userManagement = new UserManagement();
                string userpass = dbSecurity.MD5(txtUserPassword.Text);
                mdlGlobal.systemUsers = userManagement.CekUserAuthorize(txtUserID.Text, userpass);
                if (mdlGlobal.systemUsers.SystemUsersID > 0)
                {
                    Global.CompanyCode = mdlGlobal.systemUsers.CompanyCode;
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

                    SaveSystemUserRoles();

                    frmMain frmMain = new frmMain();
                    frmMain.Text = mdlGlobal.systemUsers.CompanyName;
                    frmMain.Show();
                    //frmEmployee frmEmployee = new frmEmployee();
                    //frmEmployee.Show();

                    txtUserID.Text = "";
                    txtUserPassword.Text = "";
                    Hide();
                }
                else
                {
                    MessageBox.Show("User ID and Password not registered");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
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


        private int SaveSystemUserRoles()
        {
            UserManagement userManagement = new UserManagement();
            SystemUserRoles systemuserroles = new SystemUserRoles();
            systemuserroles = userManagement.RetrieveUserRolesByUniqID(Global.CompanyCode, mdlGlobal.systemUsers.UserCode);
            systemuserroles.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;
            systemuserroles.LastVersion = Global.strVersionNo;

            int intResult = userManagement.EditUserRoles(systemuserroles);

            if (userManagement.Error == "")
                return intResult;
            else
            {
                MessageBox.Show(userManagement.Error, Global.strProductName);
                return intResult;
            }
        }


        private void txtUserID_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtUserPassword.Focus();
            }
        }

        private void txtUserPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtUserID.Focus();
                Login();
            }
        }
    }
}
