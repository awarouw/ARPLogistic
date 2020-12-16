namespace ARPLogistic
{
    partial class frmFixedAsset
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmFixedAsset));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsFirstRecord = new System.Windows.Forms.ToolStripButton();
            this.tsPreviousRecord = new System.Windows.Forms.ToolStripButton();
            this.tsNextRecord = new System.Windows.Forms.ToolStripButton();
            this.tsLastRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tsFindRecord = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsDelete = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPreview = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator10 = new System.Windows.Forms.ToolStripSeparator();
            this.panel1 = new System.Windows.Forms.Panel();
            this.tlpHeader = new System.Windows.Forms.TableLayoutPanel();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.txtNo = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtSerialNo = new System.Windows.Forms.TextBox();
            this.label29 = new System.Windows.Forms.Label();
            this.cboBlocked = new System.Windows.Forms.ComboBox();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.tlpHeader.SuspendLayout();
            this.SuspendLayout();
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
            this.tsFindRecord,
            this.toolStripSeparator3});
            this.toolStrip1.Location = new System.Drawing.Point(0, 303);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(710, 39);
            this.toolStrip1.TabIndex = 142;
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
            this.tsFirstRecord.Visible = false;
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
            this.tsPreviousRecord.Click += new System.EventHandler(this.byPrevious_Click);
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
            this.tsNextRecord.Click += new System.EventHandler(this.btNext_Click);
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
            this.tsLastRecord.Visible = false;
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
            this.tsClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // tsFindRecord
            // 
            this.tsFindRecord.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsFindRecord.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsFindRecord.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsFindRecord.Name = "tsFindRecord";
            this.tsFindRecord.Size = new System.Drawing.Size(23, 36);
            this.tsFindRecord.Text = "Find";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 39);
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.tsNew,
            this.toolStripSeparator2,
            this.tsDelete,
            this.toolStripSeparator5,
            this.tsPreview,
            this.toolStripSeparator10});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(710, 59);
            this.toolStrip2.TabIndex = 216;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(192, 56);
            this.toolStripLabel1.Text = "Fixed Asset";
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
            this.tsNew.Click += new System.EventHandler(this.tsAdd_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 59);
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
            this.tsDelete.Visible = false;
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
            this.tsPreview.Visible = false;
            // 
            // toolStripSeparator10
            // 
            this.toolStripSeparator10.Name = "toolStripSeparator10";
            this.toolStripSeparator10.Size = new System.Drawing.Size(6, 59);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.DarkRed;
            this.panel1.Controls.Add(this.tlpHeader);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 59);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(710, 244);
            this.panel1.TabIndex = 218;
            // 
            // tlpHeader
            // 
            this.tlpHeader.BackColor = System.Drawing.Color.White;
            this.tlpHeader.ColumnCount = 9;
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 16.66667F));
            this.tlpHeader.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 85F));
            this.tlpHeader.Controls.Add(this.label1, 0, 0);
            this.tlpHeader.Controls.Add(this.txtDescription, 1, 1);
            this.tlpHeader.Controls.Add(this.txtNo, 1, 0);
            this.tlpHeader.Controls.Add(this.label4, 0, 1);
            this.tlpHeader.Controls.Add(this.label6, 0, 2);
            this.tlpHeader.Controls.Add(this.txtSerialNo, 1, 2);
            this.tlpHeader.Controls.Add(this.label29, 5, 0);
            this.tlpHeader.Controls.Add(this.cboBlocked, 6, 0);
            this.tlpHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpHeader.Location = new System.Drawing.Point(0, 0);
            this.tlpHeader.Name = "tlpHeader";
            this.tlpHeader.RowCount = 5;
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tlpHeader.Size = new System.Drawing.Size(710, 244);
            this.tlpHeader.TabIndex = 225;
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 17);
            this.label1.TabIndex = 170;
            this.label1.Text = "No";
            // 
            // txtDescription
            // 
            this.tlpHeader.SetColumnSpan(this.txtDescription, 2);
            this.txtDescription.Location = new System.Drawing.Point(94, 52);
            this.txtDescription.Margin = new System.Windows.Forms.Padding(4);
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(172, 22);
            this.txtDescription.TabIndex = 152;
            // 
            // txtNo
            // 
            this.txtNo.Location = new System.Drawing.Point(94, 4);
            this.txtNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtNo.Name = "txtNo";
            this.txtNo.Size = new System.Drawing.Size(82, 22);
            this.txtNo.TabIndex = 150;
            // 
            // label4
            // 
            this.label4.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label4.Location = new System.Drawing.Point(4, 63);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(79, 17);
            this.label4.TabIndex = 171;
            this.label4.Text = "Description";
            // 
            // label6
            // 
            this.label6.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(4, 111);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(66, 17);
            this.label6.TabIndex = 175;
            this.label6.Text = "Serial No";
            // 
            // txtSerialNo
            // 
            this.tlpHeader.SetColumnSpan(this.txtSerialNo, 2);
            this.txtSerialNo.Location = new System.Drawing.Point(94, 100);
            this.txtSerialNo.Margin = new System.Windows.Forms.Padding(4);
            this.txtSerialNo.Name = "txtSerialNo";
            this.txtSerialNo.Size = new System.Drawing.Size(172, 22);
            this.txtSerialNo.TabIndex = 270;
            // 
            // label29
            // 
            this.label29.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.label29.AutoSize = true;
            this.label29.Location = new System.Drawing.Point(354, 15);
            this.label29.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label29.Name = "label29";
            this.label29.Size = new System.Drawing.Size(58, 17);
            this.label29.TabIndex = 246;
            this.label29.Text = "Blocked";
            this.label29.Visible = false;
            // 
            // cboBlocked
            // 
            this.cboBlocked.Enabled = false;
            this.cboBlocked.FormattingEnabled = true;
            this.cboBlocked.Location = new System.Drawing.Point(444, 4);
            this.cboBlocked.Margin = new System.Windows.Forms.Padding(4);
            this.cboBlocked.Name = "cboBlocked";
            this.cboBlocked.Size = new System.Drawing.Size(82, 24);
            this.cboBlocked.TabIndex = 247;
            this.cboBlocked.Visible = false;
            // 
            // frmFixedAsset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 342);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmFixedAsset";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmFixedAsset";
            this.Load += new System.EventHandler(this.frmFixedAsset_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.tlpHeader.ResumeLayout(false);
            this.tlpHeader.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsFirstRecord;
        private System.Windows.Forms.ToolStripButton tsPreviousRecord;
        private System.Windows.Forms.ToolStripButton tsNextRecord;
        private System.Windows.Forms.ToolStripButton tsLastRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripButton tsFindRecord;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsDelete;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripButton tsPreview;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator10;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tlpHeader;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.TextBox txtNo;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtSerialNo;
        private System.Windows.Forms.Label label29;
        private System.Windows.Forms.ComboBox cboBlocked;
    }
}