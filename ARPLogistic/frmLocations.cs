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
    public partial class frmLocations : Form
    {
        int intUniqID = 0;
        private LocationManagement locationManagement = new LocationManagement();
        private Locations locations = new Locations();

        public frmLocations()
        {
            InitializeComponent();
        }

        public frmLocations(int UniqID)
        {
            InitializeComponent();
            intUniqID = UniqID;
        }


        private void frmLocations_Load(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Normal;
            StartPosition = FormStartPosition.CenterScreen;

            Image myimage = new Bitmap(Application.StartupPath + "\\Images\\" + mdlGlobal.companyInformation.LogoFileName);

            ClearText();

            DataAccess da = new DataAccess(Global.AllVisionsCS);

            da.FillDropDownList("SELECT [Code], [Name] FROM [dbo].[CountryRegion] With (NOLOCK) UNION Select '','' Order By [Name] ", cmbCountry);
            da.FillDropDownList("SELECT '0' as Code, 'No' as Descr UNION SELECT '1' AS Code, 'Yes' as Descr ", cboUseAsInTransit);

            LoadData();
        }

        private void ClearText()
        {
            locations = new Locations();

            txtAddress.Text = "";
            txtAddress2.Text = "";
            txtCity.Text = "";
            txtContact.Text = "";
            txtEmail.Text = "";
            txtName.Text = "";
            txtName2.Text = "";
            txtNo.Text = "";
            txtPhoneNo.Text = "";
            txtPostCode.Text = "";
            txtFaxNo.Text = "";

            cmbCountry.SelectedIndex = -1;
            cboUseAsInTransit.SelectedValue = 0;

        }

        void LoadData()
        {
            locations = locationManagement.RetrieveLocationsByID(intUniqID);
            if (locationManagement.Error == string.Empty)
            {
                if (locations.LocationID > 0)
                {
                    txtAddress.Text = locations.Address;
                    txtAddress2.Text = locations.Address2;
                    txtCity.Text = locations.City;
                    txtContact.Text = locations.Contact;
                    txtEmail.Text = locations.EMail;
                    txtName.Text = locations.LocationName;
                    txtName2.Text = locations.Name2;
                    txtNo.Text = locations.LocationCode;
                    txtPhoneNo.Text = locations.PhoneNo;
                    txtPostCode.Text = locations.PostCode;
                    txtFaxNo.Text = locations.FaxNo;

                    cmbCountry.SelectedValue = locations.CountryRegionCode;
                    cboUseAsInTransit.SelectedValue = locations.UseAsInTransit;
                }
                else if (locations.LocationCode == string.Empty)
                {
                    ClearText();
                }
            }
        }

        private int SaveData()
        {
            locations.CreatedBy = mdlGlobal.GetComputerName() + " - " + mdlGlobal.systemUsers.UserName;

            int intResult = locationManagement.EditLocations(locations);

            if (intResult == -1)
            {
                MessageBox.Show(locationManagement.Error, Global.strProductName);
                return -1;
            }
            else
            {
                intUniqID = intResult;
                locations.LocationID = intResult;
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
            int Locationid = locations.LocationID;
            int NewLocationID = locationManagement.RetrieveLocationsNextID(Locationid);
            if (locationManagement.Error == string.Empty)
            {
                intUniqID = NewLocationID;
                LoadData();
            }
        }

        private void byPrevious_Click(object sender, EventArgs e)
        {
            int Locationid = locations.LocationID;
            int NewLocationID = locationManagement.RetrieveLocationsPreviousID(Locationid);
            if (locationManagement.Error == string.Empty)
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
                locations.LocationCode = txtNo.Text;
                SaveData();
            }
        }

        private void txtName_Validating(object sender, CancelEventArgs e)
        {
            locations.LocationName = txtName.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtName2_Validating(object sender, CancelEventArgs e)
        {
            locations.Name2 = txtName2.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtAddress_Validating(object sender, CancelEventArgs e)
        {
            locations.Address = txtAddress.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtAddress2_Validating(object sender, CancelEventArgs e)
        {
            locations.Address2 = txtAddress2.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtCity_Validating(object sender, CancelEventArgs e)
        {
            locations.City = txtCity.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void cmbCountry_Validating(object sender, CancelEventArgs e)
        {
            if (cmbCountry.SelectedValue != null)
            {
                locations.CountryRegionCode = cmbCountry.SelectedValue.ToString();
                if (txtNo.Text != "")
                    SaveData();
                else
                    MessageBox.Show("Location Code must define first");
            }
        }

        private void txtPostCode_Validating(object sender, CancelEventArgs e)
        {
            locations.PostCode = txtPostCode.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtPhoneNo_Validating(object sender, CancelEventArgs e)
        {
            locations.PhoneNo = txtPhoneNo.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtFaxNo_Validating(object sender, CancelEventArgs e)
        {
            locations.FaxNo = txtFaxNo.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtContact_Validating(object sender, CancelEventArgs e)
        {
            locations.Contact = txtContact.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void txtEmail_Validating(object sender, CancelEventArgs e)
        {
            locations.EMail = txtEmail.Text;
            if (txtNo.Text != "")
                SaveData();
            else
                MessageBox.Show("Location Code must define first");
        }

        private void cboUseAsInTransit_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                e.SuppressKeyPress = true;
                e.Handled = true;
                txtNo.Focus();
            }
        }

        private void cboUseAsInTransit_Validating(object sender, CancelEventArgs e)
        {
            if (cboUseAsInTransit.SelectedIndex > -1)
            {
                UseAsInTransit_Validate();
            }
        }

        void UseAsInTransit_Validate()
        {
            try
            {
                if (cboUseAsInTransit.SelectedIndex > -1)
                    if (locations.UseAsInTransit != Convert.ToByte(cboUseAsInTransit.SelectedValue))
                    {
                        locations.UseAsInTransit = Convert.ToByte(cboUseAsInTransit.SelectedValue);
                        if (txtNo.Text != "")
                            SaveData();
                        else
                            MessageBox.Show("Location Code must define first");
                    }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }
        }


    }
}
