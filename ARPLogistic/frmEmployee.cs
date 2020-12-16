using ARPLogistic.Administration;
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
    public partial class frmEmployee : Form
    {
        int intUniqID = 0;
        DataAccess da = new DataAccess(Global.AllVisionsCS);
        private EmployeeManagement EmployeeMgmt = new EmployeeManagement();
        private Employee employee = new Employee();

        private NoSeriesManagement noSeriesManagement = new NoSeriesManagement();

        public frmEmployee()
        {
            InitializeComponent();
        }

        private void frmEmployee_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);

            da.FillDropDownList("SELECT [Code], [Name] FROM [dbo].[CountryRegion] With (NOLOCK) UNION Select '','' Order By [Name] ", cboCountry);
            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'Gender' Order By [LookupCode] ", cboGender);

            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'EmployeeStatus' Order By [LookupCode] ", cboStatus);
            da.FillDropDownList("SELECT [Code], [Description] FROM [dbo].[CauseofInactivity] With (NOLOCK) UNION Select '','' Order By [Description] ", cboCauseOfInActiveCode);
            da.FillDropDownList("SELECT [No], [LastName] + ', ' + [FirstName] FROM [dbo].[Employee] With (NOLOCK) UNION Select '','' Order By [LastName] + ', ' + [FirstName] ", cboManagerNo);
            da.FillDropDownList("SELECT [Code], [Code] + ' - ' + [GLAccountNo] AS Description FROM [dbo].[EmployeePostingGroup] With (NOLOCK) UNION Select '','' Order By [Code] ", cboPostingGroup);
            da.FillDropDownList("SELECT [Code], [Description]FROM [dbo].[GroundsforTermination] With (NOLOCK) UNION Select '','' Order By [Description] ", cboGroundsForTermCode);
            da.FillDropDownList("SELECT [Code], [Description] FROM [dbo].[EmploymentContract] With (NOLOCK) UNION Select '','' Order By [Description] ", cboEmployeeContractCode);
            da.FillDropDownList("SELECT [Code], [Description] FROM [dbo].[EmployeeStatisticsGroup] With (NOLOCK) UNION Select '','' Order By [Description] ", cboStatisticGroupCode);
            da.FillDropDownList("SELECT [No], [Name] FROM [dbo].[Resource] With (NOLOCK) UNION Select '','' Order By [Name] ", cboResourceNo);
            da.FillDropDownList("SELECT [Code], [Name] FROM [dbo].[Salesperson_Purchaser] With (NOLOCK) UNION Select '','' Order By [Name] ", cboSalesPerson);

            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'Religions' Order By [LookupCode] ", cboReligion);
            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'MaritalStatus' Order By [LookupCode] ", cboMaritalStatus);
            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'TaxStatus' Order By [LookupCode] ", cboTaxStatus);
            da.FillDropDownList("SELECT [LookupCode], [LookupDescription] FROM dbo.LookupField With (NOLOCK) Where LookupGroup = 'BloodType' Order By [LookupCode] ", cboBloodType);


            //Caption Dimension

            da.FillLabel("SELECT dbo.Dimension.CodeCaption AS NewLabel FROM dbo.GenLedgerSetup With (NOLOCK) INNER JOIN dbo.Dimension With (NOLOCK) ON dbo.GenLedgerSetup.ShortcutDimension1Code = dbo.Dimension.DimensionCode ", lbShortcutDimension1Code);
            da.FillLabel("SELECT dbo.Dimension.CodeCaption AS NewLabel FROM dbo.GenLedgerSetup With (NOLOCK) INNER JOIN dbo.Dimension With (NOLOCK) ON dbo.GenLedgerSetup.ShortcutDimension2Code = dbo.Dimension.DimensionCode ", lbShortcutDimension2Code);

            //Fill Dimension
            da.FillDropDownList("SELECT DimensionValueCode, DimensionValueCode + ' - ' + DimensionValueName as DimensionValue FROM dbo.GenLedgerSetup  With (NOLOCK) INNER JOIN dbo.Dimension With (NOLOCK) ON dbo.GenLedgerSetup.ShortcutDimension1Code = dbo.Dimension.DimensionCode INNER JOIN dbo.DimensionValue With (NOLOCK) ON dbo.Dimension.DimensionCode = dbo.DimensionValue.DimensionCode UNION Select '','' ", cboShortcutDimension1Code);
            da.FillDropDownList("SELECT DimensionValueCode, DimensionValueCode + ' - ' + DimensionValueName as DimensionValue FROM dbo.GenLedgerSetup  With (NOLOCK) INNER JOIN dbo.Dimension With (NOLOCK) ON dbo.GenLedgerSetup.ShortcutDimension2Code = dbo.Dimension.DimensionCode INNER JOIN dbo.DimensionValue With (NOLOCK) ON dbo.Dimension.DimensionCode = dbo.DimensionValue.DimensionCode UNION Select '','' ", cboShortcutDimension2Code);

            ClearText();

            if (intUniqID == 1)
                LoadData();
            else
                goLastRecord();
        }

        void LoadData()
        {
            employee = EmployeeMgmt.RetrieveEmployeeByID(intUniqID);
            if (EmployeeMgmt.Error == string.Empty)
            {
                if (employee.EmployeeID > 0)
                {
                    FillHeader();
                }
                else
                {
                    ClearText();
                }
            }
        }

        void FillHeader()
        {
            tsLabel.Text = employee.LastName + ", " + employee.FirstName + " - Employee ";

            this.txtAddress2.Text = employee.Address2;
            this.txtMidleName.Text = employee.MiddleName;
            this.txtNo.Text = employee.No;
            this.txtLastName.Text = employee.LastName;
            this.txtJobTitle.Text = employee.JobTitle;
            this.txtFirstName.Text = employee.FirstName;
            this.txtInitial.Text = employee.Initials;
            this.txtLastUpdated.Text =  employee.LastModifiedTime.Value.ToString("dd-MMM-yyyy");
            this.txtLastUpdatedBy.Text = employee.LastModifiedBy;
            this.cboGender.SelectedValue = employee.Gender;
            this.cboCountry.SelectedValue = employee.Country;
            this.txtPhoneNo2.Text = employee.PhoneNo;
            this.txtExtension.Text = employee.Extension;
            this.txtMobilePhoneNo.Text = employee.MobilePhoneNo;
            this.txtCompanyEmailAddress.Text = employee.CompanyEMail;
            this.cboStatus.SelectedValue = employee.Status;
            this.cboCauseOfInActiveCode.SelectedValue = employee.CauseofInactivityCode;
            this.cboSalesPerson.SelectedValue = employee.SalespersPurchCode;
            this.cboResourceNo.SelectedValue = employee.ResourceNo;
            this.cboStatisticGroupCode.SelectedValue = employee.StatisticsGroupCode;
            this.cboEmployeeContractCode.SelectedValue = employee.EmplymtContractCode;
            this.cboGroundsForTermCode.SelectedValue = employee.GroundsforTermCode;
            this.txtAddress.Text = employee.Address;
            this.txtPostalCode.Text = employee.PostCode;
            this.txtCity.Text = employee.City;
            this.txtPhoneNo.Text = employee.PhoneNo;
            this.txtEmailAddress.Text = employee.EMail;
            if (employee.EmployeeID > 0)
            {
                this.dtEmployeeDate.Value = Convert.ToDateTime(employee.EmploymentDate);
                this.dtInActiveDate.Value = Convert.ToDateTime(employee.InactiveDate);
                this.dtTerminationDate.Value = Convert.ToDateTime(employee.TerminationDate);
                this.dtBirthDate.Value = Convert.ToDateTime(employee.BirthDate);
            }
            this.txtJamsostekNo.Text = employee.JamsostekNo;
            this.txtBPJSKesehatanNo.Text = employee.BPJSKesehatanNo;
            this.txtNPWP.Text = employee.SocialSecurityNo;
            this.txtBirthOfPlace.Text = employee.PlaceofBirth;
            this.cboReligion.SelectedValue = employee.ReligionCode;
            this.txtBankAcccountNo.Text = employee.BankAccountNo;
            this.txtBankAccountName.Text = employee.BankAccountName;
            this.cboManagerNo.SelectedValue = employee.ManagerNo;
            this.cboMaritalStatus.SelectedValue = employee.MaritalStatus;
            this.cboTaxStatus.SelectedValue = employee.TaxStatusCode;
            this.cboBloodType.SelectedValue = employee.BloodType;
            cboPostingGroup.SelectedValue = employee.EmployeePostingGroup;
            cboShortcutDimension1Code.SelectedValue = employee.GlobalDimension1Code;
            cboShortcutDimension2Code.SelectedValue = employee.GlobalDimension2Code;
        }

        void ClearText()
        {
            employee = new Employee();
            FillHeader();
        }

        void SaveData()
        {
            try
            {
                employee.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

                if (employee.No == "")
                {
                    string newno = "";
                    newno = noSeriesManagement.GetNextNo("EMP", DateTime.Today, true);

                    employee.No = newno;
                }

                int intResult = EmployeeMgmt.EditEmployee(employee);

                if (intResult == -1)
                {
                    MessageBox.Show(EmployeeMgmt.Error, Global.strProductName);
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

        private void btClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        #region Button Record

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
            int EmployeepID = employee.EmployeeID;
            int NewcustomersID = EmployeeMgmt.RetrieveEmployeeFirstID(EmployeepID);
            if (EmployeeMgmt.Error == string.Empty)
            {
                intUniqID = NewcustomersID;
                LoadData();
            }

        }

        void goNextRecord()
        {
            int EmployeepID = employee.EmployeeID;
            int NewcustomersID = EmployeeMgmt.RetrieveEmployeeNextID(EmployeepID);
            if (EmployeeMgmt.Error == string.Empty)
            {
                intUniqID = NewcustomersID;
                LoadData();
            }

        }

        void goPreviousRecord()
        {
            int EmployeepID = employee.EmployeeID;
            int NewcustomersID = EmployeeMgmt.RetrieveEmployeePreviousID(EmployeepID);
            if (EmployeeMgmt.Error == string.Empty)
            {
                intUniqID = NewcustomersID;
                LoadData();
            }
        }

        void goLastRecord()
        {
            int EmployeepID = employee.EmployeeID;
            int NewcustomersID = EmployeeMgmt.RetrieveEmployeeLastID(EmployeepID);
            if (EmployeeMgmt.Error == string.Empty)
            {
                intUniqID = NewcustomersID;
                LoadData();
            }
        }

        private void tsFindRecord_Click(object sender, EventArgs e)
        {
            frmLookup frmlookup = new frmLookup();
            frmlookup.strComboFilter = "SELECT 'Name', 'Name' UNION SELECT 'Address', 'Address' ";
            frmlookup.strSQLString = "Select EmployeeID, No,[LastName] + ', ' + [FirstName] Name, Address, City,  PhoneNo,  FaxNo FROM Employee WITH (NOLOCK) Order by [LastName] + ', ' + [FirstName]";
            frmlookup.ShowDialog();
            if (frmlookup.strResult != "")
            {
                intUniqID = Convert.ToInt32(frmlookup.strResult);
                LoadData();
            }
        }

        #endregion

        #region Header Button

        private void tsNew_Click(object sender, EventArgs e)
        {
            ClearText();
        }

        private void tsDelete_Click(object sender, EventArgs e)
        {

        }

        private void tsPreview_Click(object sender, EventArgs e)
        {

        }

        #endregion


        #region General

        #region No

        private void txtNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtJobTitle.Focus();
            }
        }

        private void txtNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.No != txtNo.Text || employee.No == "")
            {
                No_Validating();
            }
        }

        void No_Validating()
        {
            try
            {
                if (employee.No != txtNo.Text || employee.No == "")
                {
                    employee.No = txtNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region JobTitle

        private void txtJobTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtFirstName.Focus();
            }
        }

        private void txtJobTitle_Validating(object sender, CancelEventArgs e)
        {
            if (employee.JobTitle != txtJobTitle.Text || employee.JobTitle == "")
            {
                JobTitle_Validating();
            }
        }

        void JobTitle_Validating()
        {
            try
            {
                if (employee.JobTitle != txtJobTitle.Text || employee.JobTitle == "")
                {
                    employee.JobTitle = txtJobTitle.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region FirstName

        private void txtFirstName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtLastName.Focus();
            }
        }

        private void txtFirstName_Validating(object sender, CancelEventArgs e)
        {
            if (employee.FirstName != txtFirstName.Text || employee.FirstName == "")
            {
                FirstName_Validating();
            }
        }

        void FirstName_Validating()
        {
            try
            {
                if (employee.FirstName != txtFirstName.Text || employee.FirstName == "")
                {
                    employee.FirstName = txtFirstName.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region LastName

        private void txtLastName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtMidleName.Focus();
            }
        }

        private void txtLastName_Validating(object sender, CancelEventArgs e)
        {
            if (employee.LastName != txtLastName.Text || employee.LastName == "")
            {
                LastName_Validating();
            }
        }

        void LastName_Validating()
        {
            try
            {
                if (employee.LastName != txtLastName.Text || employee.LastName == "")
                {
                    employee.LastName = txtLastName.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region MidleName

        private void txtMidleName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtInitial.Focus();
            }
        }

        private void txtMidleName_Validating(object sender, CancelEventArgs e)
        {
            if (employee.MiddleName != txtMidleName.Text || employee.MiddleName == "")
            {
                MiddleName_Validating();
            }
        }

        void MiddleName_Validating()
        {
            try
            {
                if (employee.MiddleName != txtMidleName.Text || employee.MiddleName == "")
                {
                    employee.MiddleName = txtMidleName.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Initial

        private void txtInitial_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtAddress.Focus();
            }
        }

        private void txtInitial_Validating(object sender, CancelEventArgs e)
        {
            if (employee.Initials != txtInitial.Text || employee.Initials == "")
            {
                Initials_Validating();
            }
        }

        void Initials_Validating()
        {
            try
            {
                if (employee.Initials != txtInitial.Text || employee.Initials == "")
                {
                    employee.Initials = txtInitial.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Address

        private void txtAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtAddress2.Focus();
            }
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            if (employee.Address != txtAddress.Text || employee.Address == "")
            {
                Address_Validating();
            }
        }

        void Address_Validating()
        {
            try
            {
                if (employee.Address != txtAddress.Text || employee.Address == "")
                {
                    employee.Address = txtAddress.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Address2

        private void txtAddress2_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtPostalCode.Focus();
            }
        }

        private void txtAddress2_Validating(object sender, CancelEventArgs e)
        {
            if (employee.Address2 != txtAddress2.Text || employee.Address2 == "")
            {
                Address2_Validating();
            }
        }

        void Address2_Validating()
        {
            try
            {
                if (employee.Address2 != txtAddress2.Text || employee.Address2 == "")
                {
                    employee.Address2 = txtAddress2.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region PostCode

        private void txtPostalCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtCity.Focus();
            }
        }

        private void txtPostalCode_Validating(object sender, CancelEventArgs e)
        {
            if (employee.PostCode != txtPostalCode.Text || employee.PostCode == "")
            {
                PostCode_Validating();
            }
        }

        void PostCode_Validating()
        {
            try
            {
                if (employee.PostCode != txtPostalCode.Text || employee.PostCode == "")
                {
                    employee.PostCode = txtPostalCode.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region City

        private void txtCity_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboCountry.Focus();
            }
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            if (employee.City != txtCity.Text || employee.City == "")
            {
                City_Validating();
            }
        }

        void City_Validating()
        {
            try
            {
                if (employee.City != txtCity.Text || employee.City == "")
                {
                    employee.City = txtCity.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Country

        private void cboCountry_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtPhoneNo.Focus();
            }
        }

        private void cboCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cboCountry.SelectedIndex > -1)
            {
                Country_Validating();
            }
        }

        void Country_Validating()
        {
            try
            {
                if (cboCountry.SelectedIndex > -1)
                    if (employee.Country != cboCountry.SelectedValue.ToString())
                    {
                        employee.Country = cboCountry.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region PhoneNo

        private void txtPhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboGender.Focus();
            }
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.PhoneNo != txtPhoneNo.Text || employee.PhoneNo == "")
            {
                PhoneNo_Validating();
            }
        }

        void PhoneNo_Validating()
        {
            try
            {
                if (employee.PhoneNo != txtPhoneNo.Text || employee.PhoneNo == "")
                {
                    employee.PhoneNo = txtPhoneNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Gender

        private void cboGender_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtPhoneNo2.Focus();
            }
        }

        private void cboGender_Validating(object sender, CancelEventArgs e)
        {
            if (cboGender.SelectedIndex > -1)
            {
                Gender_Validating();
            }
        }

        void Gender_Validating()
        {
            try
            {
                if (cboGender.SelectedIndex > -1)
                    if (employee.Gender != Convert.ToInt32(cboGender.SelectedValue))
                    {
                        employee.Gender = Convert.ToInt32(cboGender.SelectedValue);
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #endregion

        #region Comunication

        #region Extension

        private void txtExtension_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtMobilePhoneNo.Focus();
            }
        }

        private void txtExtension_Validating(object sender, CancelEventArgs e)
        {
            if (employee.Extension != txtExtension.Text || employee.Extension == "")
            {
                Extension_Validating();
            }
        }

        void Extension_Validating()
        {
            try
            {
                if (employee.Extension != txtExtension.Text || employee.Extension == "")
                {
                    employee.Extension = txtExtension.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region MobilePhoneNo

        private void txtMobilePhoneNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtEmailAddress.Focus();
            }
        }

        private void txtMobilePhoneNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.MobilePhoneNo != txtMobilePhoneNo.Text || employee.MobilePhoneNo == "")
            {
                MobilePhoneNo_Validating();
            }
        }

        void MobilePhoneNo_Validating()
        {
            try
            {
                if (employee.MobilePhoneNo != txtMobilePhoneNo.Text || employee.MobilePhoneNo == "")
                {
                    employee.MobilePhoneNo = txtMobilePhoneNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region EMail

        private void txtEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtCompanyEmailAddress.Focus();
            }
        }

        private void txtEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (employee.EMail != txtEmailAddress.Text || employee.EMail == "")
            {
                EMail_Validating();
            }
        }

        void EMail_Validating()
        {
            try
            {
                if (employee.EMail != txtEmailAddress.Text || employee.EMail == "")
                {
                    employee.EMail = txtEmailAddress.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region CompanyEMail

        private void txtCompanyEmailAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dtEmployeeDate.Focus();
            }
        }

        private void txtCompanyEmailAddress_Validating(object sender, CancelEventArgs e)
        {
            if (employee.CompanyEMail != txtCompanyEmailAddress.Text || employee.CompanyEMail == "")
            {
                CompanyEMail_Validating();
            }
        }

        void CompanyEMail_Validating()
        {
            try
            {
                if (employee.CompanyEMail != txtCompanyEmailAddress.Text || employee.CompanyEMail == "")
                {
                    employee.CompanyEMail = txtCompanyEmailAddress.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #endregion

        #region Administration

        #region EmploymentDate

        private void dtEmployeeDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboStatus.Focus();
            }
        }

        private void dtEmployeeDate_Validating(object sender, CancelEventArgs e)
        {
            if (employee.EmploymentDate != dtEmployeeDate.Value)
            {
                EmploymentDate_Validating();
            }
        }

        void EmploymentDate_Validating()
        {
            try
            {
                if (employee.EmploymentDate != dtEmployeeDate.Value || dtEmployeeDate.Value > Convert.ToDateTime("1/1/2010"))
                {
                    employee.EmploymentDate = dtEmployeeDate.Value;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region Status

        private void cboStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dtInActiveDate.Focus();
            }
        }

        private void cboStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cboStatus.SelectedIndex > -1)
            {
                Status_Validating();
            }
        }

        void Status_Validating()
        {
            try
            {
                if (cboStatus.SelectedIndex > -1)
                    if (employee.Status != Convert.ToInt32(cboStatus.SelectedValue))
                    {
                        employee.Status = Convert.ToInt32(cboStatus.SelectedValue);
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region InactiveDate

        private void dtInActiveDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboCauseOfInActiveCode.Focus();
            }
        }

        private void dtInActiveDate_Validating(object sender, CancelEventArgs e)
        {
            if (employee.InactiveDate != dtInActiveDate.Value)
            {
                InactiveDate_Validating();
            }
        }

        void InactiveDate_Validating()
        {
            try
            {
                if (employee.InactiveDate != dtInActiveDate.Value || dtInActiveDate.Value > Convert.ToDateTime("1/1/2010"))
                {
                    employee.InactiveDate = dtInActiveDate.Value;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region CauseofInactivityCode

        private void cboCauseOfInActiveCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dtTerminationDate.Focus();
            }
        }

        private void cboCauseOfInActiveCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboCauseOfInActiveCode.SelectedIndex > -1)
            {
                CauseofInactivityCode_Validating();
            }
        }

        void CauseofInactivityCode_Validating()
        {
            try
            {
                if (cboCauseOfInActiveCode.SelectedIndex > -1)
                    if (employee.CauseofInactivityCode != cboCauseOfInActiveCode.SelectedValue.ToString())
                    {
                        employee.CauseofInactivityCode = cboCauseOfInActiveCode.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region TerminationDate

        private void dtTerminationDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboCauseOfInActiveCode.Focus();
            }
        }

        private void dtTerminationDate_Validating(object sender, CancelEventArgs e)
        {
            if (employee.TerminationDate != dtInActiveDate.Value)
            {
                TerminationDate_Validating();
            }
        }

        void TerminationDate_Validating()
        {
            try
            {
                if (employee.TerminationDate != dtInActiveDate.Value || dtInActiveDate.Value > Convert.ToDateTime("1/1/2010"))
                {
                    employee.TerminationDate = dtInActiveDate.Value;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region ManagerNo

        private void cboManagerNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboPostingGroup.Focus();
            }
        }

        private void cboManagerNo_Validating(object sender, CancelEventArgs e)
        {
            if (cboManagerNo.SelectedIndex > -1)
            {
                ManagerNo_Validating();
            }
        }

        void ManagerNo_Validating()
        {
            try
            {
                if (cboManagerNo.SelectedIndex > -1)
                    if (employee.ManagerNo != cboManagerNo.SelectedValue.ToString())
                    {
                        employee.ManagerNo = cboManagerNo.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region EmployeePostingGroup

        private void cboPostingGroup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboGroundsForTermCode.Focus();
            }
        }

        private void cboPostingGroup_Validating(object sender, CancelEventArgs e)
        {
            if (cboPostingGroup.SelectedIndex > -1)
            {
                EmployeePostingGroup_Validating();
            }
        }

        void EmployeePostingGroup_Validating()
        {
            try
            {
                if (cboPostingGroup.SelectedIndex > -1)
                    if (employee.EmployeePostingGroup != cboPostingGroup.SelectedValue.ToString())
                    {
                        employee.EmployeePostingGroup = cboPostingGroup.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region GroundsforTermCode

        private void cboGroundsForTermCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboGroundsForTermCode.Focus();
            }
        }

        private void cboGroundsForTermCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboGroundsForTermCode.SelectedIndex > -1)
            {
                GroundsforTermCode_Validating();
            }
        }

        void GroundsforTermCode_Validating()
        {
            try
            {
                if (cboGroundsForTermCode.SelectedIndex > -1)
                    if (employee.GroundsforTermCode != cboGroundsForTermCode.SelectedValue.ToString())
                    {
                        employee.GroundsforTermCode = cboGroundsForTermCode.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region EmplymtContractCode

        private void cboEmployeeContractCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboStatisticGroupCode.Focus();
            }
        }

        private void cboEmployeeContractCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboEmployeeContractCode.SelectedIndex > -1)
            {
                EmplymtContractCode_Validating();
            }
        }

        void EmplymtContractCode_Validating()
        {
            try
            {
                if (cboEmployeeContractCode.SelectedIndex > -1)
                    if (employee.EmplymtContractCode != cboEmployeeContractCode.SelectedValue.ToString())
                    {
                        employee.EmplymtContractCode = cboEmployeeContractCode.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region StatisticsGroupCode

        private void cboStatisticGroupCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboResourceNo.Focus();
            }
        }

        private void cboStatisticGroupCode_Validating(object sender, CancelEventArgs e)
        {
            if (cboStatisticGroupCode.SelectedIndex > -1)
            {
                StatisticsGroupCode_Validating();
            }
        }

        void StatisticsGroupCode_Validating()
        {
            try
            {
                if (cboStatisticGroupCode.SelectedIndex > -1)
                    if (employee.StatisticsGroupCode != cboStatisticGroupCode.SelectedValue.ToString())
                    {
                        employee.StatisticsGroupCode = cboStatisticGroupCode.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region ResourceNo

        private void cboResourceNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboSalesPerson.Focus();
            }
        }

        private void cboResourceNo_Validating(object sender, CancelEventArgs e)
        {
            if (cboResourceNo.SelectedIndex > -1)
            {
                ResourceNo_Validating();
            }
        }

        void ResourceNo_Validating()
        {
            try
            {
                if (cboResourceNo.SelectedIndex > -1)
                    if (employee.ResourceNo != cboResourceNo.SelectedValue.ToString())
                    {
                        employee.ResourceNo = cboResourceNo.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region SalespersPurchCode

        private void cboSalesPerson_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBirthOfPlace.Focus();
            }
        }

        private void cboSalesPerson_Validating(object sender, CancelEventArgs e)
        {
            if (cboSalesPerson.SelectedIndex > -1)
            {
                SalespersPurchCode_Validating();
            }
        }

        void SalespersPurchCode_Validating()
        {
            try
            {
                if (cboSalesPerson.SelectedIndex > -1)
                    if (employee.SalespersPurchCode != cboSalesPerson.SelectedValue.ToString())
                    {
                        employee.SalespersPurchCode = cboSalesPerson.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #endregion

        #region Personal

        #region PlaceofBirth

        private void txtBirthOfPlace_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dtBirthDate.Focus();
            }
        }

        private void txtBirthOfPlace_Validating(object sender, CancelEventArgs e)
        {
            if (employee.PlaceofBirth != txtBirthOfPlace.Text || employee.PlaceofBirth == "")
            {
                PlaceofBirth_Validating();
            }
        }

        void PlaceofBirth_Validating()
        {
            try
            {
                if (employee.PlaceofBirth != txtBirthOfPlace.Text || employee.PlaceofBirth == "")
                {
                    employee.PlaceofBirth = txtBirthOfPlace.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BirthDate

        private void dtBirthDate_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtJamsostekNo.Focus();
            }
        }

        private void dtBirthDate_Validating(object sender, CancelEventArgs e)
        {
            if (employee.BirthDate != dtBirthDate.Value)
            {
                BirthDate_Validating();
            }
        }

        void BirthDate_Validating()
        {
            try
            {
                if (employee.BirthDate != dtBirthDate.Value || dtBirthDate.Value > Convert.ToDateTime("1/1/2010"))
                {
                    employee.BirthDate = dtBirthDate.Value;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region JamsostekNo

        private void txtJamsostekNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBPJSKesehatanNo.Focus();
            }
        }

        private void txtJamsostekNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.JamsostekNo != txtJamsostekNo.Text || employee.JamsostekNo == "")
            {
                JamsostekNo_Validating();
            }
        }

        void JamsostekNo_Validating()
        {
            try
            {
                if (employee.JamsostekNo != txtJamsostekNo.Text || employee.JamsostekNo == "")
                {
                    employee.JamsostekNo = txtJamsostekNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BPJSKesehatanNo

        private void txtBPJSKesehatanNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtNPWP.Focus();
            }
        }

        private void txtBPJSKesehatanNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.BPJSKesehatanNo != txtBPJSKesehatanNo.Text || employee.BPJSKesehatanNo == "")
            {
                BPJSKesehatanNo_Validating();
            }
        }

        void BPJSKesehatanNo_Validating()
        {
            try
            {
                if (employee.BPJSKesehatanNo != txtBPJSKesehatanNo.Text || employee.BPJSKesehatanNo == "")
                {
                    employee.BPJSKesehatanNo = txtBPJSKesehatanNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region TaxCode

        private void txtNPWP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtNoKTP.Focus();
            }
        }

        private void txtNPWP_Validating(object sender, CancelEventArgs e)
        {
            if (employee.TaxCode != txtNPWP.Text || employee.TaxCode == "")
            {
                TaxCode_Validating();
            }
        }

        void TaxCode_Validating()
        {
            try
            {
                if (employee.TaxCode != txtNPWP.Text || employee.TaxCode == "")
                {
                    employee.TaxCode = txtNPWP.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region SocialSecurityNo

        private void txtNoKTP_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboReligion.Focus();
            }
        }

        private void txtNoKTP_Validating(object sender, CancelEventArgs e)
        {
            if (employee.SocialSecurityNo != txtNoKTP.Text || employee.SocialSecurityNo == "")
            {
                SocialSecurityNo_Validating();
            }
        }

        void SocialSecurityNo_Validating()
        {
            try
            {
                if (employee.SocialSecurityNo != txtNoKTP.Text || employee.SocialSecurityNo == "")
                {
                    employee.SocialSecurityNo = txtNoKTP.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region ReligionCode

        private void cboReligion_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBankAcccountNo.Focus();
            }
        }

        private void cboReligion_Validating(object sender, CancelEventArgs e)
        {
            if (cboReligion.SelectedIndex > -1)
            {
                ReligionCode_Validating();
            }
        }

        void ReligionCode_Validating()
        {
            try
            {
                if (cboStatus.SelectedIndex > -1)
                    if (employee.ReligionCode != cboReligion.SelectedValue.ToString())
                    {
                        employee.ReligionCode = cboReligion.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BankAccountNo

        private void txtBankAcccountNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBankAccountName.Focus();
            }
        }

        private void txtBankAcccountNo_Validating(object sender, CancelEventArgs e)
        {
            if (employee.BankAccountNo != txtBankAcccountNo.Text || employee.BankAccountNo == "")
            {
                BankAccountNo_Validating();
            }
        }

        void BankAccountNo_Validating()
        {
            try
            {
                if (employee.BankAccountNo != txtBankAcccountNo.Text || employee.BankAccountNo == "")
                {
                    employee.BankAccountNo = txtBankAcccountNo.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BankAccountName

        private void txtBankAccountName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboMaritalStatus.Focus();
            }
        }

        private void txtBankAccountName_Validating(object sender, CancelEventArgs e)
        {
            if (employee.BankAccountName != txtBankAccountName.Text || employee.BankAccountName == "")
            {
                BankAccountName_Validating();
            }
        }

        void BankAccountName_Validating()
        {
            try
            {
                if (employee.BankAccountName != txtBankAccountName.Text || employee.BankAccountName == "")
                {
                    employee.BankAccountName = txtBankAccountName.Text;
                    SaveData();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region MaritalStatus

        private void cboMaritalStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtBankAcccountNo.Focus();
            }
        }

        private void cboMaritalStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cboMaritalStatus.SelectedIndex > -1)
            {
                MaritalStatus_Validating();
            }
        }

        void MaritalStatus_Validating()
        {
            try
            {
                if (cboMaritalStatus.SelectedIndex > -1)
                    if (employee.MaritalStatus != cboMaritalStatus.SelectedValue.ToString())
                    {
                        employee.MaritalStatus = cboMaritalStatus.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region TaxStatusCode

        private void cboTaxStatus_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboBloodType.Focus();
            }
        }

        private void cboTaxStatus_Validating(object sender, CancelEventArgs e)
        {
            if (cboTaxStatus.SelectedIndex > -1)
            {
                TaxStatusCode_Validating();
            }
        }

        void TaxStatusCode_Validating()
        {
            try
            {
                if (cboTaxStatus.SelectedIndex > -1)
                    if (employee.TaxStatusCode != cboTaxStatus.SelectedValue.ToString())
                    {
                        employee.TaxStatusCode = cboTaxStatus.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        #region BloodType

        private void cboBloodType_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtNo.Focus();
            }
        }

        private void cboBloodType_Validating(object sender, CancelEventArgs e)
        {
            if (cboBloodType.SelectedIndex > -1)
            {
                BloodType_Validating();
            }
        }

        void BloodType_Validating()
        {
            try
            {
                if (cboBloodType.SelectedIndex > -1)
                    if (employee.BloodType != cboBloodType.SelectedValue.ToString())
                    {
                        employee.BloodType = cboBloodType.SelectedValue.ToString();
                        SaveData();
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }

        #endregion

        private void cboShortcutDimension1Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                cboShortcutDimension2Code.Focus();
            }
        }

        #endregion

        private void cboShortcutDimension1Code_Validating(object sender, CancelEventArgs e)
        {
            if (cboShortcutDimension1Code.SelectedIndex > -1)
                if (employee.GlobalDimension1Code != cboShortcutDimension1Code.SelectedValue.ToString())
                {
                    employee.GlobalDimension1Code = cboShortcutDimension1Code.SelectedValue.ToString();
                    SaveData();
                }
        }

        private void cboShortcutDimension2Code_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                dtEmployeeDate.Focus();
            }
        }

        private void cboShortcutDimension2Code_Validating(object sender, CancelEventArgs e)
        {
            if (cboShortcutDimension2Code.SelectedIndex > -1)
                if (employee.GlobalDimension2Code != cboShortcutDimension2Code.SelectedValue.ToString())
                {
                    employee.GlobalDimension2Code = cboShortcutDimension2Code.SelectedValue.ToString();
                    SaveData();
                }
        }
    }
}
