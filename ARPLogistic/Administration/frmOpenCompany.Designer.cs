namespace ARPLogistic.Administration
{
    partial class frmOpenCompany
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
            this.lsCompanyList = new System.Windows.Forms.ListBox();
            this.btClose = new System.Windows.Forms.Button();
            this.btOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lsCompanyList
            // 
            this.lsCompanyList.FormattingEnabled = true;
            this.lsCompanyList.ItemHeight = 16;
            this.lsCompanyList.Location = new System.Drawing.Point(13, 27);
            this.lsCompanyList.Margin = new System.Windows.Forms.Padding(4);
            this.lsCompanyList.Name = "lsCompanyList";
            this.lsCompanyList.Size = new System.Drawing.Size(372, 244);
            this.lsCompanyList.TabIndex = 6;
            this.lsCompanyList.DoubleClick += new System.EventHandler(this.lsCompanyList_DoubleClick);
            // 
            // btClose
            // 
            this.btClose.Location = new System.Drawing.Point(286, 301);
            this.btClose.Margin = new System.Windows.Forms.Padding(4);
            this.btClose.Name = "btClose";
            this.btClose.Size = new System.Drawing.Size(100, 28);
            this.btClose.TabIndex = 5;
            this.btClose.Text = "Close";
            this.btClose.UseVisualStyleBackColor = true;
            this.btClose.Click += new System.EventHandler(this.btClose_Click);
            // 
            // btOK
            // 
            this.btOK.Location = new System.Drawing.Point(13, 301);
            this.btOK.Margin = new System.Windows.Forms.Padding(4);
            this.btOK.Name = "btOK";
            this.btOK.Size = new System.Drawing.Size(100, 28);
            this.btOK.TabIndex = 4;
            this.btOK.Text = "Ok";
            this.btOK.UseVisualStyleBackColor = true;
            this.btOK.Click += new System.EventHandler(this.btOK_Click);
            // 
            // frmOpenCompany
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(404, 355);
            this.Controls.Add(this.lsCompanyList);
            this.Controls.Add(this.btClose);
            this.Controls.Add(this.btOK);
            this.Name = "frmOpenCompany";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "frmOpenCompany";
            this.Load += new System.EventHandler(this.frmOpenCompany_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox lsCompanyList;
        private System.Windows.Forms.Button btClose;
        private System.Windows.Forms.Button btOK;
    }
}