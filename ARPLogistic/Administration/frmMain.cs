using ARPLogistic_BE;
using ARPLogistic_BE.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ARPLogistic.Administration
{
    public partial class frmMain : Form
    {
        private DataTable dtTrans;
        private UserManagement userManagement = new UserManagement();
        private SystemObject systemObject = new SystemObject();
        //MenuStrip MnuStrip = new MenuStrip();

        public frmMain()
        {
            //MessageBox.Show(Global.intUserID.ToString());
            if (Global.intUserID > 0)
                mdlGlobal.systemUsers = userManagement.RetrieveSystemUsersByID(Global.intUserID);
            //MessageBox.Show(Global.AllVisionsCS);
            InitializeComponent();
            CreateStripMenu();
        }

        void CreateStripMenu()
        {
            //Create StripMenu

            //menuStrip1.BackColor = System.Drawing.Color.DarkSlateBlue;
            menuStrip1.ForeColor = System.Drawing.Color.Black;
            //Control is added to the Form using the Add property

            this.Controls.Add(menuStrip1);

            FillMenu(Global.CompanyCode);
        }

        private void FillMenu(string strCompanyCode)
        {
            dtTrans = new DataTable();
            dtTrans = userManagement.GetObjectMenu(mdlGlobal.systemUsers.UserCode, "1", strCompanyCode);

            foreach (DataRow dr in dtTrans.Rows)
            {
                Global.UserRole = dr["RoleID"].ToString();
                ToolStripMenuItem MnuStripItem = new ToolStripMenuItem();
                if (dr["ObjectDesc"].ToString() == "LogOff")
                    MnuStripItem = new ToolStripMenuItem(dr["ObjectDesc"].ToString(), null, ChildClick);
                else
                    MnuStripItem = new ToolStripMenuItem(dr["ObjectDesc"].ToString());
                menuStrip1.Items.Add(MnuStripItem);

                if (Convert.ToInt32(dr["nChild"].ToString()) > 0)
                    FillChildMenu(MnuStripItem, dr["SystemObjectID"].ToString(), strCompanyCode);
            }

        }

        private void FillChildMenu(ToolStripMenuItem tsMenu, string strParentID, string strCompanyCode)
        {
            try
            {

                dtTrans = new DataTable();
                dtTrans = userManagement.GetObjectMenu(mdlGlobal.systemUsers.UserCode, strParentID, strCompanyCode);

                foreach (DataRow dr in dtTrans.Rows)
                {
                    ToolStripMenuItem SSMenu = new ToolStripMenuItem();
                    if (Convert.ToInt32(dr["nChild"].ToString()) > 0)
                        SSMenu = new ToolStripMenuItem(dr["ObjectDesc"].ToString());
                    else
                        SSMenu = new ToolStripMenuItem(dr["ObjectDesc"].ToString(), null, ChildClick);
                    SSMenu.Tag = Convert.ToInt32(dr["SystemObjectID"].ToString());
                    tsMenu.DropDownItems.Add(SSMenu);

                    if (Convert.ToInt32(dr["nChild"].ToString()) > 0)
                        FillChildMenu(SSMenu, dr["SystemObjectID"].ToString(), strCompanyCode);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }

        }

        public void ChildClick(object sender, System.EventArgs e)
        {
            try
            {
                ToolStripMenuItem clickedItem = (ToolStripMenuItem)sender;

                if (sender.ToString() == "LogOff")
                {
                    DialogResult dlgResult = MessageBox.Show("Do you want to LogOff?", "LogOff?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (dlgResult == DialogResult.Yes)
                    {
                        //Application.Exit();
                        Close();
                        string strFormName = "frmLogin";
                        Form fName = GetFormByName(strFormName);
                        dbSecurity.Isload(fName);
                    }
                }
                else
                {
                    if (clickedItem.Tag.ToString() != null)
                    {
                        systemObject = userManagement.RetrieveSystemObjectByID(clickedItem.Tag.ToString());
                        CheckMdiChildren(GetFormByName(systemObject.ObjectSystemName));
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        private void frmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            try
            {
                //frmLogin frmlogin = frmLogin();
                //frmLogin.Show();
                string strFormName = "frmLogin";
                Form fName = GetFormByName(strFormName);
                if (fName != null)
                    dbSecurity.Isload(fName);
                else
                    Application.Exit();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        private void CheckMdiChildren(Form form)
        {
            if (form != null)
            {
                foreach (Form frm in this.MdiChildren)
                {
                    if (frm.GetType() == form.GetType() && frm.Tag.ToString() == systemObject.ObjectSystemArg.ToString())
                    {
                        frm.Focus();
                        return;
                    }
                }

                form.MdiParent = this;
                if (systemObject.ObjectSystemArg.ToString() != "")
                    form.Tag = systemObject.ObjectSystemArg;
                form.WindowState = FormWindowState.Maximized;
                form.Text = systemObject.ObjectDesc;
                form.Show();
            }
        }

        public Form GetFormByName(string frmname)
        {
            try
            {
                foreach (Assembly ass in AppDomain.CurrentDomain.GetAssemblies())
                {

                    var formType = ass.GetTypes()
                        .Where(a => (a.BaseType == typeof(Form)) && a.Name == frmname)
                        .FirstOrDefault();

                    //var formType = Assembly.GetExecutingAssembly().GetTypes()
                    //    .Where(a => (a.BaseType == typeof(Form)) && a.Name == frmname)
                    //    .FirstOrDefault();

                    if (formType != null) // If there is no form with the given frmname
                        return (Form)Activator.CreateInstance(formType);
                    //else
                    //    return null;

                }
                return null;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
                return null;
            }

        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.WallFileName);
            this.BackgroundImage = myimage;

            tsUser.Text = "User : " + mdlGlobal.systemUsers.UserName;
            tsDepartment.Text = "Department : " + mdlGlobal.systemUsers.DepartmentCode;
            tsCompany.Text = "Company : " + Global.CompanyCode + "     ";
            tsStatusVersion.Text = "Version : " + Global.strVersionNo + "     ";
            this.Text = mdlGlobal.companyInformation.CompanyName;

        }

        private void tsCompany_DoubleClick(object sender, EventArgs e)
        {
            frmOpenCompany frmOpenCompany = new frmOpenCompany();
            frmOpenCompany.ShowDialog();
        }

        private void tsCompany_Click(object sender, EventArgs e)
        {
            frmOpenCompany frmOpenCompany = new frmOpenCompany();
            DialogResult dlgResult = frmOpenCompany.ShowDialog();
            if (dlgResult == DialogResult.OK)
            {
                //Application.Exit();
                this.Controls.Remove(menuStrip1);
                menuStrip1 = new MenuStrip();
                menuStrip1.ForeColor = System.Drawing.Color.Black;
                this.Controls.Add(menuStrip1);
                FillMenu(Global.CompanyCode);
                tsUser.Text = "User : " + mdlGlobal.systemUsers.UserName;
                tsDepartment.Text = "Department : " + mdlGlobal.systemUsers.DepartmentCode;
                tsCompany.Text = "Company : " + Global.CompanyCode + "     ";
                tsStatusVersion.Text = "Version : " + Global.strVersionNo + "     ";
                this.Text = mdlGlobal.companyInformation.CompanyName;
                Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.WallFileName);
                this.BackgroundImage = myimage;
            }
        }
    }
}
