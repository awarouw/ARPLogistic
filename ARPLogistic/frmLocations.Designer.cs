namespace ARPLogistic
{
    partial class frmLocations
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsPrevious = new System.Windows.Forms.ToolStripButton();
            this.tsNext = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsAdd = new System.Windows.Forms.ToolStripButton();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.panel4 = new System.Windows.Forms.Panel();
            this.labelHeader = new System.Windows.Forms.Label();
            this.tabLocation = new System.Windows.Forms.TabControl();
            this.tabGeneral = new System.Windows.Forms.TabPage();
            this.cboUseAsInTransit = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.txtFaxNo = new System.Windows.Forms.TextBox();
            this.lblPostCode = new System.Windows.Forms.Label();
            this.txtPostCode = new System.Windows.Forms.TextBox();
            this.lblAddress2 = new System.Windows.Forms.Label();
            this.txtAddress2 = new System.Windows.Forms.TextBox();
            this.cmbCountry = new System.Windows.Forms.ComboBox();
            this.lblCountryRegionCode = new System.Windows.Forms.Label();
            this.lblEmail = new System.Windows.Forms.Label();
            this.txtEmail = new System.Windows.Forms.TextBox();
            this.lblPhoneNo = new System.Windows.Forms.Label();
            this.txtPhoneNo = new System.Windows.Forms.TextBox();
            this.lblContact = new System.Windows.Forms.Label();
            this.txtContact = new System.Windows.Forms.TextBox();
            this.lblCity = new System.Windows.Forms.Label();
            this.txtCity = new System.Windows.Forms.TextBox();
            this.lblNo = new System.Windows.Forms.Label();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.lblAddress = new System.Windows.Forms.Label();
            this.txtAddress = new System.Windows.Forms.TextBox();
            this.lblName2 = new System.Windows.Forms.Label();
            this.txtName2 = new System.Windows.Forms.TextBox();
            this.lblName = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.toolStrip1.SuspendLayout();
            this.panel4.SuspendLayout();
            this.tabLocation.SuspendLayout();
            this.tabGeneral.SuspendLayout();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsPrevious,
            this.tsNext,
            this.toolStripSeparator1,
            this.tsAdd,
            this.tsClose,
            this.toolStripSeparator2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 610);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(983, 39);
            this.toolStrip1.TabIndex = 138;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsPrevious
            // 
            this.tsPrevious.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPrevious.Image = global::ARPLogistic.Properties.Resources.Prev_32x32;
            this.tsPrevious.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPrevious.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPrevious.Name = "tsPrevious";
            this.tsPrevious.Size = new System.Drawing.Size(36, 36);
            this.tsPrevious.Text = "Previous";
            this.tsPrevious.ToolTipText = "Previous";
            this.tsPrevious.Click += new System.EventHandler(this.byPrevious_Click);
            // 
            // tsNext
            // 
            this.tsNext.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNext.Image = global::ARPLogistic.Properties.Resources.Next_32x32;
            this.tsNext.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNext.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNext.Name = "tsNext";
            this.tsNext.Size = new System.Drawing.Size(36, 36);
            this.tsNext.Text = "Next";
            this.tsNext.ToolTipText = "Next";
            this.tsNext.Click += new System.EventHandler(this.btNext_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsAdd
            // 
            this.tsAdd.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsAdd.Image = global::ARPLogistic.Properties.Resources.Add_32x32;
            this.tsAdd.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsAdd.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsAdd.Name = "tsAdd";
            this.tsAdd.Size = new System.Drawing.Size(36, 36);
            this.tsAdd.Text = "Add";
            this.tsAdd.ToolTipText = "New";
            this.tsAdd.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // tsClose
            // 
            this.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClose.Image = global::ARPLogistic.Properties.Resources.Action_Exit_32x32;
            this.tsClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(36, 36);
            this.tsClose.Text = "Close";
            this.tsClose.ToolTipText = "Close";
            this.tsClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.labelHeader);
            this.panel4.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel4.Location = new System.Drawing.Point(0, 0);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(983, 74);
            this.panel4.TabIndex = 139;
            // 
            // labelHeader
            // 
            this.labelHeader.AutoSize = true;
            this.labelHeader.Font = new System.Drawing.Font("Kristen ITC", 24F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelHeader.ForeColor = System.Drawing.Color.Red;
            this.labelHeader.Location = new System.Drawing.Point(16, 11);
            this.labelHeader.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.labelHeader.Name = "labelHeader";
            this.labelHeader.Size = new System.Drawing.Size(210, 54);
            this.labelHeader.TabIndex = 131;
            this.labelHeader.Text = "Location";
            // 
            // tabLocation
            // 
            this.tabLocation.Controls.Add(this.tabGeneral);
            this.tabLocation.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabLocation.Location = new System.Drawing.Point(0, 74);
            this.tabLocation.Margin = new System.Windows.Forms.Padding(4);
            this.tabLocation.Name = "tabLocation";
            this.tabLocation.SelectedIndex = 0;
            this.tabLocation.Size = new System.Drawing.Size(983, 536);
            this.tabLocation.TabIndex = 140;
            // 
            // tabGeneral
            // 
            this.tabGeneral.Controls.Add(this.cboUseAsInTransit);
            this.tabGeneral.Controls.Add(this.label1);
            this.tabGeneral.Controls.Add(this.label8);
            this.tabGeneral.Controls.Add(this.txtFaxNo);
            this.tabGeneral.Controls.Add(this.lblPostCode);
            this.tabGeneral.Controls.Add(this.txtPostCode);
            this.tabGeneral.Controls.Add(this.lblAddress2);
            this.tabGeneral.Controls.Add(this.txtAddress2);
            this.tabGeneral.Controls.Add(this.cmbCountry);
            this.tabGeneral.Controls.Add(this.lblCountryRegionCode);
            this.tabGeneral.Controls.Add(this.lblEmail);
            this.tabGeneral.Controls.Add(this.txtEmail);
            this.tabGeneral.Controls.Add(this.lblPhoneNo);
            this.tabGeneral.Controls.Add(this.txtPhoneNo);
            this.tabGeneral.Controls.Add(this.lblContact);
            this.tabGeneral.Controls.Add(this.txtContact);
            this.tabGeneral.Controls.Add(this.lblCity);
            this.tabGeneral.Controls.Add(this.txtCity);
            this.tabGeneral.Controls.Add(this.lblNo);
            this.tabGeneral.Controls.Add(this.txtNo);
            this.tabGeneral.Controls.Add(this.lblAddress);
            this.tabGeneral.Controls.Add(this.txtAddress);
            this.tabGeneral.Controls.Add(this.lblName2);
            this.tabGeneral.Controls.Add(this.txtName2);
            this.tabGeneral.Controls.Add(this.lblName);
            this.tabGeneral.Controls.Add(this.txtName);
            this.tabGeneral.Location = new System.Drawing.Point(4, 25);
            this.tabGeneral.Margin = new System.Windows.Forms.Padding(4);
            this.tabGeneral.Name = "tabGeneral";
            this.tabGeneral.Padding = new System.Windows.Forms.Padding(4);
            this.tabGeneral.Size = new System.Drawing.Size(975, 507);
            this.tabGeneral.TabIndex = 0;
            this.tabGeneral.Text = "General";
            this.tabGeneral.UseVisualStyleBackColor = true;
            // 
            // cboUseAsInTransit
            // 
            this.cboUseAsInTransit.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboUseAsInTransit.FormattingEnabled = true;
            this.cboUseAsInTransit.Location = new System.Drawing.Point(239, 451);
            this.cboUseAsInTransit.Margin = new System.Windows.Forms.Padding(4);
            this.cboUseAsInTransit.Name = "cboUseAsInTransit";
            this.cboUseAsInTransit.Size = new System.Drawing.Size(186, 27);
            this.cboUseAsInTransit.TabIndex = 223;
            this.cboUseAsInTransit.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboUseAsInTransit_KeyDown);
            this.cboUseAsInTransit.Validating += new System.ComponentModel.CancelEventHandler(this.cboUseAsInTransit_Validating);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 451);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 21);
            this.label1.TabIndex = 224;
            this.label1.Text = "Use As In Transit";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(12, 343);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(58, 21);
            this.label8.TabIndex = 222;
            this.label8.Text = "Fax No";
            // 
            // txtFaxNo
            // 
            this.txtFaxNo.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtFaxNo.Location = new System.Drawing.Point(239, 343);
            this.txtFaxNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtFaxNo.MaxLength = 30;
            this.txtFaxNo.Name = "txtFaxNo";
            this.txtFaxNo.Size = new System.Drawing.Size(240, 27);
            this.txtFaxNo.TabIndex = 9;
            this.txtFaxNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtFaxNo_Validating);
            // 
            // lblPostCode
            // 
            this.lblPostCode.AutoSize = true;
            this.lblPostCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPostCode.Location = new System.Drawing.Point(13, 272);
            this.lblPostCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPostCode.Name = "lblPostCode";
            this.lblPostCode.Size = new System.Drawing.Size(81, 21);
            this.lblPostCode.TabIndex = 205;
            this.lblPostCode.Text = "Post Code";
            // 
            // txtPostCode
            // 
            this.txtPostCode.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtPostCode.Location = new System.Drawing.Point(240, 271);
            this.txtPostCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtPostCode.MaxLength = 30;
            this.txtPostCode.Name = "txtPostCode";
            this.txtPostCode.Size = new System.Drawing.Size(160, 27);
            this.txtPostCode.TabIndex = 7;
            this.txtPostCode.Validating += new System.ComponentModel.CancelEventHandler(this.txtPostCode_Validating);
            // 
            // lblAddress2
            // 
            this.lblAddress2.AutoSize = true;
            this.lblAddress2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress2.Location = new System.Drawing.Point(13, 160);
            this.lblAddress2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress2.Name = "lblAddress2";
            this.lblAddress2.Size = new System.Drawing.Size(80, 21);
            this.lblAddress2.TabIndex = 197;
            this.lblAddress2.Text = "Address 2";
            // 
            // txtAddress2
            // 
            this.txtAddress2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtAddress2.Location = new System.Drawing.Point(240, 160);
            this.txtAddress2.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress2.MaxLength = 50;
            this.txtAddress2.Name = "txtAddress2";
            this.txtAddress2.Size = new System.Drawing.Size(480, 27);
            this.txtAddress2.TabIndex = 4;
            this.txtAddress2.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress2_Validating);
            // 
            // cmbCountry
            // 
            this.cmbCountry.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCountry.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCountry.FormattingEnabled = true;
            this.cmbCountry.Location = new System.Drawing.Point(240, 235);
            this.cmbCountry.Margin = new System.Windows.Forms.Padding(4);
            this.cmbCountry.Name = "cmbCountry";
            this.cmbCountry.Size = new System.Drawing.Size(240, 27);
            this.cmbCountry.TabIndex = 6;
            this.cmbCountry.Validating += new System.ComponentModel.CancelEventHandler(this.cmbCountry_Validating);
            // 
            // lblCountryRegionCode
            // 
            this.lblCountryRegionCode.AutoSize = true;
            this.lblCountryRegionCode.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCountryRegionCode.Location = new System.Drawing.Point(13, 235);
            this.lblCountryRegionCode.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCountryRegionCode.Name = "lblCountryRegionCode";
            this.lblCountryRegionCode.Size = new System.Drawing.Size(66, 21);
            this.lblCountryRegionCode.TabIndex = 151;
            this.lblCountryRegionCode.Text = "Country";
            // 
            // lblEmail
            // 
            this.lblEmail.AutoSize = true;
            this.lblEmail.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEmail.Location = new System.Drawing.Point(12, 417);
            this.lblEmail.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblEmail.Name = "lblEmail";
            this.lblEmail.Size = new System.Drawing.Size(48, 21);
            this.lblEmail.TabIndex = 65;
            this.lblEmail.Text = "Email";
            // 
            // txtEmail
            // 
            this.txtEmail.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtEmail.Location = new System.Drawing.Point(239, 416);
            this.txtEmail.Margin = new System.Windows.Forms.Padding(4);
            this.txtEmail.MaxLength = 80;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.Size = new System.Drawing.Size(480, 27);
            this.txtEmail.TabIndex = 12;
            this.txtEmail.Validating += new System.ComponentModel.CancelEventHandler(this.txtEmail_Validating);
            // 
            // lblPhoneNo
            // 
            this.lblPhoneNo.AutoSize = true;
            this.lblPhoneNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPhoneNo.Location = new System.Drawing.Point(13, 308);
            this.lblPhoneNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblPhoneNo.Name = "lblPhoneNo";
            this.lblPhoneNo.Size = new System.Drawing.Size(79, 21);
            this.lblPhoneNo.TabIndex = 51;
            this.lblPhoneNo.Text = "Phone No";
            // 
            // txtPhoneNo
            // 
            this.txtPhoneNo.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtPhoneNo.Location = new System.Drawing.Point(240, 308);
            this.txtPhoneNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtPhoneNo.MaxLength = 30;
            this.txtPhoneNo.Name = "txtPhoneNo";
            this.txtPhoneNo.Size = new System.Drawing.Size(240, 27);
            this.txtPhoneNo.TabIndex = 8;
            this.txtPhoneNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtPhoneNo_Validating);
            // 
            // lblContact
            // 
            this.lblContact.AutoSize = true;
            this.lblContact.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblContact.Location = new System.Drawing.Point(12, 380);
            this.lblContact.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblContact.Name = "lblContact";
            this.lblContact.Size = new System.Drawing.Size(64, 21);
            this.lblContact.TabIndex = 49;
            this.lblContact.Text = "Contact";
            // 
            // txtContact
            // 
            this.txtContact.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtContact.Location = new System.Drawing.Point(239, 380);
            this.txtContact.Margin = new System.Windows.Forms.Padding(4);
            this.txtContact.MaxLength = 50;
            this.txtContact.Name = "txtContact";
            this.txtContact.Size = new System.Drawing.Size(240, 27);
            this.txtContact.TabIndex = 10;
            this.txtContact.Validating += new System.ComponentModel.CancelEventHandler(this.txtContact_Validating);
            // 
            // lblCity
            // 
            this.lblCity.AutoSize = true;
            this.lblCity.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCity.Location = new System.Drawing.Point(13, 197);
            this.lblCity.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblCity.Name = "lblCity";
            this.lblCity.Size = new System.Drawing.Size(37, 21);
            this.lblCity.TabIndex = 47;
            this.lblCity.Text = "City";
            // 
            // txtCity
            // 
            this.txtCity.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtCity.Location = new System.Drawing.Point(240, 197);
            this.txtCity.Margin = new System.Windows.Forms.Padding(4);
            this.txtCity.MaxLength = 30;
            this.txtCity.Name = "txtCity";
            this.txtCity.Size = new System.Drawing.Size(240, 27);
            this.txtCity.TabIndex = 5;
            this.txtCity.Validating += new System.ComponentModel.CancelEventHandler(this.txtCity_Validating);
            // 
            // lblNo
            // 
            this.lblNo.AutoSize = true;
            this.lblNo.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNo.Location = new System.Drawing.Point(13, 12);
            this.lblNo.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblNo.Name = "lblNo";
            this.lblNo.Size = new System.Drawing.Size(46, 21);
            this.lblNo.TabIndex = 45;
            this.lblNo.Text = "Code";
            // 
            // txtNo
            // 
            this.txtNo.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtNo.Location = new System.Drawing.Point(240, 12);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNo.MaxLength = 20;
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(144, 27);
            this.txtNo.TabIndex = 0;
            this.txtNo.Validating += new System.ComponentModel.CancelEventHandler(this.txtNo_Validating);
            // 
            // lblAddress
            // 
            this.lblAddress.AutoSize = true;
            this.lblAddress.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAddress.Location = new System.Drawing.Point(13, 123);
            this.lblAddress.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblAddress.Name = "lblAddress";
            this.lblAddress.Size = new System.Drawing.Size(67, 21);
            this.lblAddress.TabIndex = 41;
            this.lblAddress.Text = "Address";
            // 
            // txtAddress
            // 
            this.txtAddress.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtAddress.Location = new System.Drawing.Point(240, 123);
            this.txtAddress.Margin = new System.Windows.Forms.Padding(4);
            this.txtAddress.MaxLength = 50;
            this.txtAddress.Name = "txtAddress";
            this.txtAddress.Size = new System.Drawing.Size(480, 27);
            this.txtAddress.TabIndex = 3;
            this.txtAddress.Validating += new System.ComponentModel.CancelEventHandler(this.txtAddress_Validating);
            // 
            // lblName2
            // 
            this.lblName2.AutoSize = true;
            this.lblName2.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName2.Location = new System.Drawing.Point(13, 86);
            this.lblName2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName2.Name = "lblName2";
            this.lblName2.Size = new System.Drawing.Size(65, 21);
            this.lblName2.TabIndex = 37;
            this.lblName2.Text = "Name 2";
            // 
            // txtName2
            // 
            this.txtName2.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtName2.Location = new System.Drawing.Point(240, 86);
            this.txtName2.Margin = new System.Windows.Forms.Padding(4);
            this.txtName2.MaxLength = 50;
            this.txtName2.Name = "txtName2";
            this.txtName2.Size = new System.Drawing.Size(483, 27);
            this.txtName2.TabIndex = 2;
            this.txtName2.Validating += new System.ComponentModel.CancelEventHandler(this.txtName2_Validating);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("Calibri", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblName.Location = new System.Drawing.Point(13, 49);
            this.lblName.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(52, 21);
            this.lblName.TabIndex = 35;
            this.lblName.Text = "Name";
            // 
            // txtName
            // 
            this.txtName.Font = new System.Drawing.Font("Calibri", 9.75F);
            this.txtName.Location = new System.Drawing.Point(240, 49);
            this.txtName.Margin = new System.Windows.Forms.Padding(4);
            this.txtName.MaxLength = 50;
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(483, 27);
            this.txtName.TabIndex = 1;
            this.txtName.Validating += new System.ComponentModel.CancelEventHandler(this.txtName_Validating);
            // 
            // frmLocations
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(983, 649);
            this.Controls.Add(this.tabLocation);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmLocations";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmLocations";
            this.Load += new System.EventHandler(this.frmLocations_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.panel4.PerformLayout();
            this.tabLocation.ResumeLayout(false);
            this.tabGeneral.ResumeLayout(false);
            this.tabGeneral.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsPrevious;
        private System.Windows.Forms.ToolStripButton tsNext;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsAdd;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.Panel panel4;
        internal System.Windows.Forms.Label labelHeader;
        internal System.Windows.Forms.TabControl tabLocation;
        internal System.Windows.Forms.TabPage tabGeneral;
        internal System.Windows.Forms.ComboBox cboUseAsInTransit;
        internal System.Windows.Forms.Label label1;
        internal System.Windows.Forms.Label label8;
        internal System.Windows.Forms.TextBox txtFaxNo;
        internal System.Windows.Forms.Label lblPostCode;
        internal System.Windows.Forms.TextBox txtPostCode;
        internal System.Windows.Forms.Label lblAddress2;
        internal System.Windows.Forms.TextBox txtAddress2;
        internal System.Windows.Forms.ComboBox cmbCountry;
        internal System.Windows.Forms.Label lblCountryRegionCode;
        internal System.Windows.Forms.Label lblEmail;
        internal System.Windows.Forms.TextBox txtEmail;
        internal System.Windows.Forms.Label lblPhoneNo;
        internal System.Windows.Forms.TextBox txtPhoneNo;
        internal System.Windows.Forms.Label lblContact;
        internal System.Windows.Forms.TextBox txtContact;
        internal System.Windows.Forms.Label lblCity;
        internal System.Windows.Forms.TextBox txtCity;
        internal System.Windows.Forms.Label lblNo;
        internal System.Windows.Forms.TextBox txtNo;
        internal System.Windows.Forms.Label lblAddress;
        internal System.Windows.Forms.TextBox txtAddress;
        internal System.Windows.Forms.Label lblName2;
        internal System.Windows.Forms.TextBox txtName2;
        internal System.Windows.Forms.Label lblName;
        internal System.Windows.Forms.TextBox txtName;
    }
}