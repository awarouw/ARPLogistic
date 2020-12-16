using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Windows.Forms;
using System.Drawing; 

namespace ARPLogistic_BE
{
    public class Global
    {
        public static string AllVisionsCS = ConfigurationManager.ConnectionStrings["ARPLogistic"].ToString();
        public static string AllVisions_Sys = ConfigurationManager.ConnectionStrings["ARPLogistic"].ToString();

        public static string CompanyCode = "";
        public static string DatabaseCode = "";
        public static string UserRole = "";

        public static int intUserID = 0;

        public static bool status = false;
        public static bool loginFromMain = false;

        static System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
        static FileVersionInfo fvi = FileVersionInfo.GetVersionInfo(assembly.Location);

        public static string strProductName = "";
        public static string strVersionNo = "";


        public static DialogResult InputBox(string title, string promptText, ref string value)
        {
            Form form = new Form();
            Label label = new Label();
            TextBox textBox = new TextBox();
            Button buttonOk = new Button();
            Button buttonCancel = new Button();

            form.Text = title;
            label.Text = promptText;
            textBox.Text = value;
            textBox.CharacterCasing = CharacterCasing.Upper;

            buttonOk.Text = "OK";
            buttonCancel.Text = "Cancel";
            buttonOk.DialogResult = DialogResult.OK;
            buttonCancel.DialogResult = DialogResult.Cancel;

            label.SetBounds(9, 20, 372, 13);
            textBox.SetBounds(12, 36, 372, 20);
            buttonOk.SetBounds(228, 72, 75, 23);
            buttonCancel.SetBounds(309, 72, 75, 23);

            label.AutoSize = true;
            textBox.Anchor = textBox.Anchor | AnchorStyles.Right;
            buttonOk.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonCancel.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;

            form.ClientSize = new Size(396, 107);
            form.Controls.AddRange(new Control[] { label, textBox, buttonOk, buttonCancel });
            form.ClientSize = new Size(Math.Max(300, label.Right + 10), form.ClientSize.Height);
            form.FormBorderStyle = FormBorderStyle.FixedDialog;
            form.StartPosition = FormStartPosition.CenterScreen;
            form.MinimizeBox = false;
            form.MaximizeBox = false;
            form.AcceptButton = buttonOk;
            form.CancelButton = buttonCancel;

            DialogResult dialogResult = form.ShowDialog();
            value = textBox.Text;
            return dialogResult;
        }

    }
}
