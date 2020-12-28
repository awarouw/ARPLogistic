namespace ARPLogistic
{
    partial class frmRouteTransaction
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmRouteTransaction));
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.tsLabel = new System.Windows.Forms.ToolStripLabel();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tsFindRecord = new System.Windows.Forms.ToolStripButton();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.label2 = new System.Windows.Forms.Label();
            this.txtRouteTemplateNo = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.cboStatus = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.label10 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtSeqlineNo = new System.Windows.Forms.TextBox();
            this.btNew = new System.Windows.Forms.Button();
            this.label17 = new System.Windows.Forms.Label();
            this.txtFromCode = new System.Windows.Forms.TextBox();
            this.txtToCode = new System.Windows.Forms.TextBox();
            this.txtJarak = new System.Windows.Forms.TextBox();
            this.txtToll = new System.Windows.Forms.TextBox();
            this.txtBBM = new System.Windows.Forms.TextBox();
            this.txtRetribusi = new System.Windows.Forms.TextBox();
            this.btDelete = new System.Windows.Forms.Button();
            this.txtLainLain = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvRouteTemplateLine = new System.Windows.Forms.DataGridView();
            this.toolStrip2.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteTemplateLine)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsLabel,
            this.tsNew,
            this.toolStripSeparator4,
            this.tsDelete,
            this.toolStripSeparator5,
            this.tsPreview});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(1077, 59);
            this.toolStrip2.TabIndex = 226;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // tsLabel
            // 
            this.tsLabel.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tsLabel.ForeColor = System.Drawing.Color.Blue;
            this.tsLabel.Name = "tsLabel";
            this.tsLabel.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.tsLabel.Size = new System.Drawing.Size(276, 56);
            this.tsLabel.Text = "Route Transaction";
            // 
            // tsNew
            // 
            this.tsNew.Image = global::ARPLogistic.Properties.Resources.Add_32x32;
            this.tsNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.tsNew.Size = new System.Drawing.Size(67, 56);
            this.tsNew.Text = "New";
            this.tsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 59);
            // 
            // tsDelete
            // 
            this.tsDelete.Image = global::ARPLogistic.Properties.Resources.DeleteDataSource_32x32;
            this.tsDelete.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsDelete.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsDelete.Name = "tsDelete";
            this.tsDelete.Padding = new System.Windows.Forms.Padding(6, 0, 6, 0);
            this.tsDelete.Size = new System.Drawing.Size(69, 56);
            this.tsDelete.Text = "Delete";
            this.tsDelete.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(6, 59);
            // 
            // tsPreview
            // 
            this.tsPreview.Image = global::ARPLogistic.Properties.Resources.Preview_32x32;
            this.tsPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPreview.Name = "tsPreview";
            this.tsPreview.Size = new System.Drawing.Size(64, 56);
            this.tsPreview.Text = "Preview";
            this.tsPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsFirstRecord,
            this.tsPreviousRecord,
            this.tsNextRecord,
            this.tsLastRecord,
            this.toolStripSeparator1,
            this.tsClose,
            this.tsFindRecord});
            this.toolStrip1.Location = new System.Drawing.Point(0, 609);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(1077, 39);
            this.toolStrip1.TabIndex = 227;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // tsFirstRecord
            // 
            this.tsFirstRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFirstRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsFirstRecord.Image")));
            this.tsFirstRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFirstRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFirstRecord.Name = "tsFirstRecord";
            this.tsFirstRecord.Size = new System.Drawing.Size(36, 36);
            this.tsFirstRecord.Text = "First";
            // 
            // tsPreviousRecord
            // 
            this.tsPreviousRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsPreviousRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsPreviousRecord.Image")));
            this.tsPreviousRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPreviousRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPreviousRecord.Name = "tsPreviousRecord";
            this.tsPreviousRecord.Size = new System.Drawing.Size(36, 36);
            this.tsPreviousRecord.Text = "Previous";
            this.tsPreviousRecord.ToolTipText = "Previous";
            // 
            // tsNextRecord
            // 
            this.tsNextRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsNextRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsNextRecord.Image")));
            this.tsNextRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNextRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNextRecord.Name = "tsNextRecord";
            this.tsNextRecord.Size = new System.Drawing.Size(36, 36);
            this.tsNextRecord.Text = "Next";
            this.tsNextRecord.ToolTipText = "Next";
            // 
            // tsLastRecord
            // 
            this.tsLastRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsLastRecord.Image = ((System.Drawing.Image)(resources.GetObject("tsLastRecord.Image")));
            this.tsLastRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsLastRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsLastRecord.Name = "tsLastRecord";
            this.tsLastRecord.Size = new System.Drawing.Size(36, 36);
            this.tsLastRecord.Text = "Last";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // tsClose
            // 
            this.tsClose.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.tsClose.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsClose.Image = ((System.Drawing.Image)(resources.GetObject("tsClose.Image")));
            this.tsClose.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsClose.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsClose.Name = "tsClose";
            this.tsClose.Size = new System.Drawing.Size(36, 36);
            this.tsClose.Text = "Close";
            this.tsClose.ToolTipText = "Close";
            // 
            // tsFindRecord
            // 
            this.tsFindRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFindRecord.Image = global::ARPLogistic.Properties.Resources.Find_32x32;
            this.tsFindRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFindRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFindRecord.Name = "tsFindRecord";
            this.tsFindRecord.Size = new System.Drawing.Size(36, 36);
            this.tsFindRecord.Text = "Find";
            // 
            // panel4
            // 
            this.panel4.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel4.Location = new System.Drawing.Point(0, 565);
            this.panel4.Margin = new System.Windows.Forms.Padding(4);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1077, 44);
            this.panel4.TabIndex = 228;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.tableLayoutPanel1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1077, 101);
            this.panel1.TabIndex = 229;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 8;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 12.5F));
            this.tableLayoutPanel1.Controls.Add(this.label2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.txtRouteTemplateNo, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.label8, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtDescription, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.txtID, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.label9, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.cboStatus, 6, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1077, 101);
            this.tableLayoutPanel1.TabIndex = 70;
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(4, 0);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 5;
            this.label2.Text = "No";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtRouteTemplateNo
            // 
            this.txtRouteTemplateNo.Location = new System.Drawing.Point(138, 4);
            this.txtRouteTemplateNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtRouteTemplateNo.Name = "txtRouteTemplateNo";
            this.txtRouteTemplateNo.Size = new System.Drawing.Size(126, 22);
            this.txtRouteTemplateNo.TabIndex = 1;
            // 
            // label8
            // 
            this.label8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(4, 25);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(79, 25);
            this.label8.TabIndex = 65;
            this.label8.Text = "Description";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // txtDescription
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.txtDescription, 3);
            this.txtDescription.Location = new System.Drawing.Point(138, 29);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(394, 22);
            this.txtDescription.TabIndex = 64;
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(406, 4);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(33, 22);
            this.txtID.TabIndex = 55;
            this.txtID.Visible = false;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(674, 0);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(48, 25);
            this.label9.TabIndex = 67;
            this.label9.Text = "Status";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cboStatus
            // 
            this.cboStatus.Enabled = false;
            this.cboStatus.FormattingEnabled = true;
            this.cboStatus.Location = new System.Drawing.Point(808, 4);
            this.cboStatus.Margin = new System.Windows.Forms.Padding(4);
            this.cboStatus.Name = "cboStatus";
            this.cboStatus.Size = new System.Drawing.Size(126, 24);
            this.cboStatus.TabIndex = 66;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.panel2.Controls.Add(this.tableLayoutPanel2);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 160);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1077, 89);
            this.panel2.TabIndex = 230;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.ColumnCount = 9;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 8.236347F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.9051F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 17.9051F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19069F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19069F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19069F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19069F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 11.19069F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 75F));
            this.tableLayoutPanel2.Controls.Add(this.label10, 7, 0);
            this.tableLayoutPanel2.Controls.Add(this.label7, 6, 0);
            this.tableLayoutPanel2.Controls.Add(this.label6, 5, 0);
            this.tableLayoutPanel2.Controls.Add(this.label5, 4, 0);
            this.tableLayoutPanel2.Controls.Add(this.label4, 3, 0);
            this.tableLayoutPanel2.Controls.Add(this.label3, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.label1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtSeqlineNo, 0, 1);
            this.tableLayoutPanel2.Controls.Add(this.btNew, 8, 0);
            this.tableLayoutPanel2.Controls.Add(this.label17, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.txtFromCode, 1, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtToCode, 2, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtJarak, 3, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtToll, 4, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtBBM, 5, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtRetribusi, 6, 1);
            this.tableLayoutPanel2.Controls.Add(this.btDelete, 8, 1);
            this.tableLayoutPanel2.Controls.Add(this.txtLainLain, 7, 1);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 2;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(1077, 89);
            this.tableLayoutPanel2.TabIndex = 27;
            // 
            // label10
            // 
            this.label10.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(892, 0);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(104, 44);
            this.label10.TabIndex = 34;
            this.label10.Text = "Biaya LainLain";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(780, 0);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(104, 44);
            this.label7.TabIndex = 33;
            this.label7.Text = "Retribusi";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(668, 0);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(104, 44);
            this.label6.TabIndex = 32;
            this.label6.Text = "Biaya BBM";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(556, 0);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(104, 44);
            this.label5.TabIndex = 31;
            this.label5.Text = "Biaya Toll";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(444, 0);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(104, 44);
            this.label4.TabIndex = 30;
            this.label4.Text = "Jarak Tempuh";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(265, 0);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(171, 44);
            this.label3.TabIndex = 29;
            this.label3.Text = "To Location";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 0);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 44);
            this.label1.TabIndex = 28;
            this.label1.Text = "From Location";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtSeqlineNo
            // 
            this.txtSeqlineNo.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.txtSeqlineNo.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtSeqlineNo.Location = new System.Drawing.Point(4, 48);
            this.txtSeqlineNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSeqlineNo.Name = "txtSeqlineNo";
            this.txtSeqlineNo.Size = new System.Drawing.Size(74, 22);
            this.txtSeqlineNo.TabIndex = 16;
            // 
            // btNew
            // 
            this.btNew.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btNew.Location = new System.Drawing.Point(1004, 4);
            this.btNew.Margin = new System.Windows.Forms.Padding(4);
            this.btNew.Name = "btNew";
            this.btNew.Size = new System.Drawing.Size(58, 36);
            this.btNew.TabIndex = 26;
            this.btNew.UseVisualStyleBackColor = true;
            // 
            // label17
            // 
            this.label17.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(4, 0);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(74, 44);
            this.label17.TabIndex = 20;
            this.label17.Text = "No";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // txtFromCode
            // 
            this.txtFromCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtFromCode.Location = new System.Drawing.Point(86, 48);
            this.txtFromCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtFromCode.Name = "txtFromCode";
            this.txtFromCode.Size = new System.Drawing.Size(171, 22);
            this.txtFromCode.TabIndex = 21;
            // 
            // txtToCode
            // 
            this.txtToCode.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtToCode.Location = new System.Drawing.Point(265, 48);
            this.txtToCode.Margin = new System.Windows.Forms.Padding(4);
            this.txtToCode.Name = "txtToCode";
            this.txtToCode.Size = new System.Drawing.Size(171, 22);
            this.txtToCode.TabIndex = 22;
            // 
            // txtJarak
            // 
            this.txtJarak.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtJarak.Location = new System.Drawing.Point(444, 48);
            this.txtJarak.Margin = new System.Windows.Forms.Padding(4);
            this.txtJarak.Name = "txtJarak";
            this.txtJarak.Size = new System.Drawing.Size(104, 22);
            this.txtJarak.TabIndex = 23;
            // 
            // txtToll
            // 
            this.txtToll.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtToll.Location = new System.Drawing.Point(556, 48);
            this.txtToll.Margin = new System.Windows.Forms.Padding(4);
            this.txtToll.Name = "txtToll";
            this.txtToll.Size = new System.Drawing.Size(104, 22);
            this.txtToll.TabIndex = 24;
            // 
            // txtBBM
            // 
            this.txtBBM.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtBBM.Location = new System.Drawing.Point(668, 48);
            this.txtBBM.Margin = new System.Windows.Forms.Padding(4);
            this.txtBBM.Name = "txtBBM";
            this.txtBBM.Size = new System.Drawing.Size(104, 22);
            this.txtBBM.TabIndex = 25;
            // 
            // txtRetribusi
            // 
            this.txtRetribusi.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtRetribusi.Location = new System.Drawing.Point(780, 48);
            this.txtRetribusi.Margin = new System.Windows.Forms.Padding(4);
            this.txtRetribusi.Name = "txtRetribusi";
            this.txtRetribusi.Size = new System.Drawing.Size(104, 22);
            this.txtRetribusi.TabIndex = 26;
            // 
            // btDelete
            // 
            this.btDelete.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btDelete.Location = new System.Drawing.Point(1004, 48);
            this.btDelete.Margin = new System.Windows.Forms.Padding(4);
            this.btDelete.Name = "btDelete";
            this.btDelete.Size = new System.Drawing.Size(58, 37);
            this.btDelete.TabIndex = 8;
            this.btDelete.UseVisualStyleBackColor = true;
            // 
            // txtLainLain
            // 
            this.txtLainLain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txtLainLain.Location = new System.Drawing.Point(892, 48);
            this.txtLainLain.Margin = new System.Windows.Forms.Padding(4);
            this.txtLainLain.Name = "txtLainLain";
            this.txtLainLain.Size = new System.Drawing.Size(104, 22);
            this.txtLainLain.TabIndex = 27;
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.dgvRouteTemplateLine);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 249);
            this.panel3.Margin = new System.Windows.Forms.Padding(4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1077, 316);
            this.panel3.TabIndex = 231;
            // 
            // dgvRouteTemplateLine
            // 
            this.dgvRouteTemplateLine.AllowUserToAddRows = false;
            this.dgvRouteTemplateLine.AllowUserToDeleteRows = false;
            this.dgvRouteTemplateLine.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgvRouteTemplateLine.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRouteTemplateLine.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvRouteTemplateLine.Location = new System.Drawing.Point(0, 0);
            this.dgvRouteTemplateLine.Margin = new System.Windows.Forms.Padding(4);
            this.dgvRouteTemplateLine.Name = "dgvRouteTemplateLine";
            this.dgvRouteTemplateLine.ReadOnly = true;
            this.dgvRouteTemplateLine.Size = new System.Drawing.Size(1077, 316);
            this.dgvRouteTemplateLine.TabIndex = 0;
            // 
            // frmRouteTransaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1077, 648);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.toolStrip2);
            this.Name = "frmRouteTransaction";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmRouteTransaction";
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvRouteTemplateLine)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel tsLabel;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsPreview;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsFirstRecord;
        private System.Windows.Forms.ToolStripButton tsPreviousRecord;
        private System.Windows.Forms.ToolStripButton tsNextRecord;
        private System.Windows.Forms.ToolStripButton tsLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripButton tsFindRecord;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtRouteTemplateNo;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.ComboBox cboStatus;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtSeqlineNo;
        private System.Windows.Forms.Button btNew;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtFromCode;
        private System.Windows.Forms.TextBox txtToCode;
        private System.Windows.Forms.TextBox txtJarak;
        private System.Windows.Forms.TextBox txtToll;
        private System.Windows.Forms.TextBox txtBBM;
        private System.Windows.Forms.TextBox txtRetribusi;
        private System.Windows.Forms.Button btDelete;
        private System.Windows.Forms.TextBox txtLainLain;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvRouteTemplateLine;
    }
}