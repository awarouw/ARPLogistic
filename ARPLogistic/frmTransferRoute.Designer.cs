namespace ARPLogistic
{
    partial class frmTransferRoute
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmTransferRoute));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsClose = new System.Windows.Forms.ToolStripButton();
            this.tsExchangeRate = new System.Windows.Forms.ToolStripButton();
            this.toolStrip2 = new System.Windows.Forms.ToolStrip();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsNew = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.tsPreview = new System.Windows.Forms.ToolStripButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.cboTransfertoCode = new System.Windows.Forms.ComboBox();
            this.cboTransferfromCode = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtBiayaLainLain = new System.Windows.Forms.TextBox();
            this.txtRetribusi = new System.Windows.Forms.TextBox();
            this.txtBiayaBBM = new System.Windows.Forms.TextBox();
            this.txtBiayaToll = new System.Windows.Forms.TextBox();
            this.txtJarakTempuh = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dgvTransferRoute = new System.Windows.Forms.DataGridView();
            this.toolStrip1.SuspendLayout();
            this.toolStrip2.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferRoute)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsClose,
            this.tsExchangeRate});
            this.toolStrip1.Location = new System.Drawing.Point(0, 579);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(900, 39);
            this.toolStrip1.TabIndex = 145;
            this.toolStrip1.Text = "toolStrip1";
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
            // tsExchangeRate
            // 
            this.tsExchangeRate.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.tsExchangeRate.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsExchangeRate.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsExchangeRate.Name = "tsExchangeRate";
            this.tsExchangeRate.Size = new System.Drawing.Size(23, 36);
            this.tsExchangeRate.Text = "Exchange Rate";
            // 
            // toolStrip2
            // 
            this.toolStrip2.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip2.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripLabel1,
            this.toolStripSeparator2,
            this.tsNew,
            this.toolStripSeparator1,
            this.tsPreview});
            this.toolStrip2.Location = new System.Drawing.Point(0, 0);
            this.toolStrip2.Name = "toolStrip2";
            this.toolStrip2.Size = new System.Drawing.Size(900, 40);
            this.toolStrip2.TabIndex = 219;
            this.toolStrip2.Text = "toolStrip2";
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Font = new System.Drawing.Font("Segoe UI Semibold", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.toolStripLabel1.ForeColor = System.Drawing.Color.Blue;
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Padding = new System.Windows.Forms.Padding(20, 0, 20, 0);
            this.toolStripLabel1.Size = new System.Drawing.Size(185, 37);
            this.toolStripLabel1.Text = "Currencies";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 40);
            // 
            // tsNew
            // 
            this.tsNew.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsNew.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsNew.Name = "tsNew";
            this.tsNew.Padding = new System.Windows.Forms.Padding(12, 0, 12, 0);
            this.tsNew.Size = new System.Drawing.Size(67, 37);
            this.tsNew.Text = "New";
            this.tsNew.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 40);
            // 
            // tsPreview
            // 
            this.tsPreview.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.tsPreview.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.tsPreview.Name = "tsPreview";
            this.tsPreview.Size = new System.Drawing.Size(64, 37);
            this.tsPreview.Text = "Preview";
            this.tsPreview.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.tsPreview.Visible = false;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.cboTransfertoCode);
            this.panel2.Controls.Add(this.cboTransferfromCode);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.txtBiayaLainLain);
            this.panel2.Controls.Add(this.txtRetribusi);
            this.panel2.Controls.Add(this.txtBiayaBBM);
            this.panel2.Controls.Add(this.txtBiayaToll);
            this.panel2.Controls.Add(this.txtJarakTempuh);
            this.panel2.Controls.Add(this.label6);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtID);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 40);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(900, 194);
            this.panel2.TabIndex = 226;
            // 
            // cboTransfertoCode
            // 
            this.cboTransfertoCode.FormattingEnabled = true;
            this.cboTransfertoCode.Location = new System.Drawing.Point(189, 48);
            this.cboTransfertoCode.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransfertoCode.Name = "cboTransfertoCode";
            this.cboTransfertoCode.Size = new System.Drawing.Size(280, 24);
            this.cboTransfertoCode.TabIndex = 32;
            this.cboTransfertoCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransfertoCode_KeyDown);
            this.cboTransfertoCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboTransfertoCode_Validating);
            // 
            // cboTransferfromCode
            // 
            this.cboTransferfromCode.FormattingEnabled = true;
            this.cboTransferfromCode.Location = new System.Drawing.Point(189, 15);
            this.cboTransferfromCode.Margin = new System.Windows.Forms.Padding(4);
            this.cboTransferfromCode.Name = "cboTransferfromCode";
            this.cboTransferfromCode.Size = new System.Drawing.Size(280, 24);
            this.cboTransferfromCode.TabIndex = 31;
            this.cboTransferfromCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.cboTransferfromCode_KeyDown);
            this.cboTransferfromCode.Validating += new System.ComponentModel.CancelEventHandler(this.cboTransferfromCode_Validating);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(510, 150);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(105, 17);
            this.label7.TabIndex = 30;
            this.label7.Text = "Biaya Lain Lain";
            // 
            // txtBiayaLainLain
            // 
            this.txtBiayaLainLain.Location = new System.Drawing.Point(726, 147);
            this.txtBiayaLainLain.Margin = new System.Windows.Forms.Padding(4);
            this.txtBiayaLainLain.Name = "txtBiayaLainLain";
            this.txtBiayaLainLain.Size = new System.Drawing.Size(132, 22);
            this.txtBiayaLainLain.TabIndex = 29;
            this.txtBiayaLainLain.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBiayaLainLain_KeyDown);
            this.txtBiayaLainLain.Validating += new System.ComponentModel.CancelEventHandler(this.txtBiayaLainLain_Validating);
            // 
            // txtRetribusi
            // 
            this.txtRetribusi.Location = new System.Drawing.Point(726, 117);
            this.txtRetribusi.Margin = new System.Windows.Forms.Padding(4);
            this.txtRetribusi.Name = "txtRetribusi";
            this.txtRetribusi.Size = new System.Drawing.Size(132, 22);
            this.txtRetribusi.TabIndex = 28;
            this.txtRetribusi.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtRetribusi_KeyDown);
            this.txtRetribusi.Validating += new System.ComponentModel.CancelEventHandler(this.txtRetribusi_Validating);
            // 
            // txtBiayaBBM
            // 
            this.txtBiayaBBM.Location = new System.Drawing.Point(726, 84);
            this.txtBiayaBBM.Margin = new System.Windows.Forms.Padding(4);
            this.txtBiayaBBM.Name = "txtBiayaBBM";
            this.txtBiayaBBM.Size = new System.Drawing.Size(132, 22);
            this.txtBiayaBBM.TabIndex = 27;
            this.txtBiayaBBM.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBiayaBBM_KeyDown);
            this.txtBiayaBBM.Validating += new System.ComponentModel.CancelEventHandler(this.txtBiayaBBM_Validating);
            // 
            // txtBiayaToll
            // 
            this.txtBiayaToll.Location = new System.Drawing.Point(726, 48);
            this.txtBiayaToll.Margin = new System.Windows.Forms.Padding(4);
            this.txtBiayaToll.Name = "txtBiayaToll";
            this.txtBiayaToll.Size = new System.Drawing.Size(132, 22);
            this.txtBiayaToll.TabIndex = 26;
            this.txtBiayaToll.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtBiayaToll_KeyDown);
            this.txtBiayaToll.Validating += new System.ComponentModel.CancelEventHandler(this.txtBiayaToll_Validating);
            // 
            // txtJarakTempuh
            // 
            this.txtJarakTempuh.Location = new System.Drawing.Point(726, 15);
            this.txtJarakTempuh.Margin = new System.Windows.Forms.Padding(4);
            this.txtJarakTempuh.Name = "txtJarakTempuh";
            this.txtJarakTempuh.Size = new System.Drawing.Size(132, 22);
            this.txtJarakTempuh.TabIndex = 25;
            this.txtJarakTempuh.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtJarakTempuh_KeyDown);
            this.txtJarakTempuh.Validating += new System.ComponentModel.CancelEventHandler(this.txtJarakTempuh_Validating);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(510, 117);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(64, 17);
            this.label6.TabIndex = 24;
            this.label6.Text = "Retribusi";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(510, 84);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(76, 17);
            this.label5.TabIndex = 22;
            this.label5.Text = "Biaya BBM";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(510, 51);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 20;
            this.label4.Text = "Biaya Toll";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 52);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Transfer to Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(510, 18);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "Jarak Tempuh";
            // 
            // txtID
            // 
            this.txtID.Location = new System.Drawing.Point(381, 84);
            this.txtID.Margin = new System.Windows.Forms.Padding(4);
            this.txtID.Name = "txtID";
            this.txtID.Size = new System.Drawing.Size(43, 22);
            this.txtID.TabIndex = 11;
            this.txtID.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 20);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 17);
            this.label1.TabIndex = 6;
            this.label1.Text = "Transfer from Code";
            // 
            // dgvTransferRoute
            // 
            this.dgvTransferRoute.AllowUserToAddRows = false;
            this.dgvTransferRoute.AllowUserToDeleteRows = false;
            this.dgvTransferRoute.BackgroundColor = System.Drawing.Color.White;
            this.dgvTransferRoute.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvTransferRoute.Location = new System.Drawing.Point(0, 234);
            this.dgvTransferRoute.Margin = new System.Windows.Forms.Padding(4);
            this.dgvTransferRoute.Name = "dgvTransferRoute";
            this.dgvTransferRoute.ReadOnly = true;
            this.dgvTransferRoute.Size = new System.Drawing.Size(900, 345);
            this.dgvTransferRoute.TabIndex = 227;
            // 
            // frmTransferRoute
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(900, 618);
            this.Controls.Add(this.dgvTransferRoute);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.toolStrip2);
            this.Controls.Add(this.toolStrip1);
            this.Name = "frmTransferRoute";
            this.Text = "frmTransferRoute";
            this.Load += new System.EventHandler(this.frmTransferRoute_Load);
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.toolStrip2.ResumeLayout(false);
            this.toolStrip2.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTransferRoute)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsClose;
        private System.Windows.Forms.ToolStripButton tsExchangeRate;
        private System.Windows.Forms.ToolStrip toolStrip2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsNew;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton tsPreview;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dgvTransferRoute;
        private System.Windows.Forms.TextBox txtBiayaLainLain;
        private System.Windows.Forms.TextBox txtRetribusi;
        private System.Windows.Forms.TextBox txtBiayaBBM;
        private System.Windows.Forms.TextBox txtBiayaToll;
        private System.Windows.Forms.TextBox txtJarakTempuh;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.ComboBox cboTransfertoCode;
        private System.Windows.Forms.ComboBox cboTransferfromCode;
    }
}