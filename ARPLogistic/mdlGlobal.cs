using ARPLogistic_BE;
using ARPLogistic_BE.Entities;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;

namespace ARPLogistic
{
    public class mdlGlobal
    {
        public static SystemUsers systemUsers;
        public static CompanyInformation companyInformation;
        public static string strUpdateFile = "AVUpdater";
        public static string ftpPath = "";
        public static string FtpRemoteHost = "";
        public static string ftpUser = "";
        public static string FtpPassword = "";
        public static string filePass = "P@ssw0rd123";

        public static Form GetForm(string frmname)
        {
            try
            {
                var formType = Assembly.GetExecutingAssembly().GetTypes()
                    .Where(a => (a.BaseType == typeof(Form)) && a.Name == frmname)
                    .FirstOrDefault();

                if (formType == null) // If there is no form with the given frmname
                    return null;

                return (Form)Activator.CreateInstance(formType);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return null;
            }

        }

        /// <summary>
        /// 1 -> A<br/>
        /// 2 -> B<br/>
        /// 3 -> C<br/>
        /// ...
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static string ExcelColumnFromNumber(int column)
        {
            string columnString = "";
            decimal columnNumber = column;
            while (columnNumber > 0)
            {
                decimal currentLetterNumber = (columnNumber - 1) % 26;
                char currentLetter = (char)(currentLetterNumber + 65);
                columnString = currentLetter + columnString;
                columnNumber = (columnNumber - (currentLetterNumber + 1)) / 26;
            }
            return columnString;
        }

        /// <summary>
        /// A -> 1<br/>
        /// B -> 2<br/>
        /// C -> 3<br/>
        /// ...
        /// </summary>
        /// <param name="column"></param>
        /// <returns></returns>
        public static int NumberFromExcelColumn(string column)
        {
            int retVal = 0;
            string col = column.ToUpper();
            for (int iChar = col.Length - 1; iChar >= 0; iChar--)
            {
                char colPiece = col[iChar];
                int colNum = colPiece - 64;
                retVal = retVal + colNum * (int)Math.Pow(26, col.Length - (iChar + 1));
            }
            return retVal;
        }


        private void AutoEmail(string strSubject, string strBody, string strFileName)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient(ConfigurationManager.AppSettings["MailSMTP"].ToString(), Convert.ToInt32(ConfigurationManager.AppSettings["MailSMTPPort"].ToString()));

                mail.From = new MailAddress(ConfigurationManager.AppSettings["MailNoReply"].ToString());
                mail.To.Add(ConfigurationManager.AppSettings["MailSendTo"].ToString());
                foreach (var address in ConfigurationManager.AppSettings["MailSendCCTo"].ToString().Split(new[] { ";" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    mail.CC.Add(address);
                }
                //mail.CC.Add(new MailAddress(ConfigurationManager.AppSettings["MailSendCCTo"].ToString()));
                mail.Subject = strSubject;
                mail.Body = strBody;

                System.Net.Mail.Attachment attachment;
                attachment = new System.Net.Mail.Attachment(strFileName);
                mail.Attachments.Add(attachment);

                // if (strFileName != null)
                //{
                //    Attachment attachment = new Attachment(strFileName, MediaTypeNames.Application.Octet);
                //    ContentDisposition disposition = attachment.ContentDisposition;
                //    disposition.CreationDate = File.GetCreationTime(strFileName);
                //    disposition.ModificationDate = File.GetLastWriteTime(strFileName);
                //    disposition.ReadDate = File.GetLastAccessTime(strFileName);
                //    disposition.FileName = Path.GetFileName(strFileName);
                //    disposition.Size = new FileInfo(strFileName).Length;
                //    disposition.DispositionType = DispositionTypeNames.Attachment;
                //    mail.Attachments.Add(attachment);
                //}

                SmtpServer.Port = 587;
                SmtpServer.UseDefaultCredentials = false;
                //SmtpServer.Credentials = new System.Net.NetworkCredential("username", "password");
                //SmtpServer.EnableSsl = true;
                SmtpServer.EnableSsl = false;

                SmtpServer.Send(mail);
                // MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public static bool FileCompare(string file1, string file2)
        {
            int file1byte;
            int file2byte;
            FileStream fs1;
            FileStream fs2;

            // Determine if the same file was referenced two times.
            if (file1 == file2)
            {
                // Return true to indicate that the files are the same.
                return true;
            }

            // Open the two files.
            fs1 = new FileStream(file1, FileMode.Open);
            fs2 = new FileStream(file2, FileMode.Open);

            // Check the file sizes. If they are not the same, the files 
            // are not the same.
            if (fs1.Length != fs2.Length)
            {
                // Close the file
                fs1.Close();
                fs2.Close();

                // Return false to indicate files are different
                return false;
            }

            // Read and compare a byte from each file until either a
            // non-matching set of bytes is found or until the end of
            // file1 is reached.
            do
            {
                // Read one byte from each file.
                file1byte = fs1.ReadByte();
                file2byte = fs2.ReadByte();
            }
            while ((file1byte == file2byte) && (file1byte != -1));

            // Close the files.
            fs1.Close();
            fs2.Close();

            // Return the success of the comparison. "file1byte" is 
            // equal to "file2byte" at this point only if the files are 
            // the same.
            return ((file1byte - file2byte) == 0);
        }

        public static string GetComputerName()
        {
            return Environment.MachineName.ToString();
        }

        //public static string ExportPOSData_XML(string strSQLQuery, string strPath, int intMode)
        //{
        //    if (intMode == 1)
        //    {
        //        DataTable dtTable = new DataTable();
        //        DataTable dtTransactionDetail = new DataTable();

        //        POSTransactionHeader_BL transHeaderFacade = new POSTransactionHeader_BL();
        //        POSTransactionDetail_BL transDetailFacade = new POSTransactionDetail_BL();
        //        VoucherTransaction_BL voucherTransFacade = new VoucherTransaction_BL();
        //        VoucherTransaction_EL voucherTrans = new VoucherTransaction_EL();
        //        dtTable = transHeaderFacade.GetDataTransactionByDate(fromDate, toDate);
        //        if (transHeaderFacade.Error != string.Empty)
        //            return transHeaderFacade.Error;

        //        if (dtTable.Rows.Count > 0)
        //        {
        //            System.Xml.XmlTextWriter xt = new System.Xml.XmlTextWriter(strPath + "\\" + DateTime.Now.ToString("yyyyMMdd") + "-" + Global.LocationCode + ".xml", Encoding.ASCII);
        //            xt.WriteStartDocument(true);
        //            xt.Formatting = System.Xml.Formatting.Indented;
        //            xt.WriteStartElement("DocumentElement");
        //            foreach (DataRow row in dtTable.Rows)
        //            {
        //                xt.WriteStartElement("SO");
        //                xt.WriteElementString("NO_TRANSACTION", row["NO_TRANSACTION"].ToString());
        //                xt.WriteElementString("LOCATION_CODE", row["LOCATION_CODE"].ToString());
        //                xt.WriteElementString("CUSTOMER_CODE", row["CUSTOMER_CODE"].ToString());
        //                xt.WriteElementString("TRANSACTION_DATE", row["TRANSACTION_DATE"].ToString());
        //                xt.WriteElementString("PAYMENT_CODE", row["PAYMENT_CODE"].ToString());
        //                xt.WriteStartElement("LINES");
        //                dtTransactionDetail = transDetailFacade.GetDataTransactionDetailByDate(Convert.ToInt32(row["ID"]));
        //                if (transDetailFacade.Error != string.Empty)
        //                    return transDetailFacade.Error;

        //                if (dtTransactionDetail.Rows.Count > 0)
        //                {
        //                    foreach (DataRow rowItem in dtTransactionDetail.Rows)
        //                    {
        //                        xt.WriteStartElement("LINE");
        //                        xt.WriteElementString("ITEM_CODE", rowItem["ITEM_CODE"].ToString());
        //                        xt.WriteElementString("DESCRIPTION", rowItem["DESCRIPTION"].ToString());
        //                        xt.WriteElementString("QUANTITY", rowItem["QUANTITY"].ToString());
        //                        xt.WriteElementString("UNIT_PRICE", rowItem["UNIT_PRICE"].ToString());
        //                        xt.WriteElementString("DISC", rowItem["DISC"].ToString());
        //                        xt.WriteElementString("TOTAL_AMOUNT_AFTER_DISC", rowItem["TOTAL_AMOUNT_AFTER_DISC"].ToString());
        //                        xt.WriteEndElement();
        //                    }
        //                }
        //                xt.WriteEndElement();
        //                xt.WriteStartElement("VOUCHERS");
        //                voucherTrans = voucherTransFacade.RetrieveByTransationID(Convert.ToInt32(row["ID"]));
        //                if (voucherTransFacade.Error != string.Empty)
        //                    return voucherTransFacade.Error;

        //                if (voucherTrans.ID > 0)
        //                {
        //                    xt.WriteStartElement("VOUCHER");
        //                    xt.WriteElementString("VOUCHER_NO", voucherTrans.VoucherNo);
        //                    xt.WriteElementString("VOUCHER_VALUE", voucherTrans.VoucherAmount.ToString());
        //                    xt.WriteEndElement();
        //                }
        //                xt.WriteEndElement();
        //                xt.WriteEndElement();
        //            }
        //            xt.WriteEndElement();
        //            xt.WriteEndDocument();
        //            xt.Close();
        //        }
        //    }
        //    return string.Empty;
        //}

        public static void loadXML()
        {
            try
            {
                string strStatus = String.Empty;
                string strFileName = Application.StartupPath + "\\FTPSetup.XML";
                if (File.Exists(strFileName))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(strFileName);

                    XmlNodeReader reader = new XmlNodeReader(document);
                    while (reader.Read())
                    {
                        if (reader.NodeType == XmlNodeType.Element)
                            strStatus = reader.Name.ToUpper();
                        if (reader.NodeType == XmlNodeType.Text)
                            if (strStatus != String.Empty)
                                switch (strStatus)
                                {
                                    case "FTPREMOTEHOST":
                                        FtpRemoteHost = reader.Value;
                                        break;
                                    case "FTPUSER":
                                        ftpUser = reader.Value;
                                        break;
                                    case "FTPPASSWORD":
                                        FtpPassword = reader.Value;
                                        break;
                                    case "FTPPATH":
                                        ftpPath = reader.Value;
                                        break;
                                }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, Global.strProductName);
            }

        }


        public enum ValidationType
        {
            Only_Numbers = 1,
            Only_Characters = 2,
            Not_Null = 3,
            Only_Email = 4,
            Phone_Number = 5
        }

        public static void AssignValidation(TextBox CTRL, ValidationType Val_Type)
        {
            TextBox txt = CTRL;
            switch (Val_Type)
            {
                case ValidationType.Only_Numbers:
                    //AddHandler txt.KeyPress, AddressOf number_Leave;
                    txt.KeyPress += number_Leave;
                    break;
                case ValidationType.Only_Characters:
                    //AddHandler txt.KeyPress, AddressOf OCHAR_Leave;
                    txt.KeyPress += OCHAR_Leave;
                    break;
                case ValidationType.Not_Null:
                    txt.KeyPress += NotNull_Leave;
                    //AddHandler txt.Leave, AddressOf NotNull_Leave;
                    break;
                case ValidationType.Phone_Number:
                    txt.KeyPress += Phonenumber_Leave;
                    //AddHandler txt.KeyPress, AddressOf Phonenumber_Leave;
                    break;
                default:
                    break;
            }
        }

        private static void number_Leave(object sender, KeyPressEventArgs e)
        {
            //    Dim numbers As TextBox = CType(sender, TextBox)
            //If InStr("1234567890.", e.KeyChar) = 0 And Asc(e.KeyChar) <> 8 Or(e.KeyChar = "." And InStr(numbers.Text, ".") > 0) Then
            //    e.KeyChar = Chr(0)
            //    e.Handled = True
            //End If
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && e.KeyChar != '.')
            {
                e.KeyChar = '\0';
                e.Handled = true;
                return;
            }
            if (e.KeyChar == '.' && (sender as TextBox).Text.IndexOf('.') > -1)
            {
                e.KeyChar = '\0';
                e.Handled = true;
                return;
            }
        }

        private static void Phonenumber_Leave(object sender, KeyPressEventArgs e)
        {

            if (!Regex.Match((sender as TextBox).Text, @"^[1-9]\d{2}-[1-9]\d{2}-\d{4}$").Success)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }// end if
        }
        private static void NotNull_Leave(object sender, KeyPressEventArgs e)
        {
            if ((sender as TextBox).Text.Trim() == "")
            {
                MessageBox.Show("This field Must be filled!");
                (sender as TextBox).Focus();
            }// end if
             //    If No.Text.Trim = "" Then
             //    MsgBox("This field Must be filled!")
             //    No.Focus()
             //End If
        }
        private static void OCHAR_Leave(object sender, KeyPressEventArgs e)
        {

            if (!Regex.Match((sender as TextBox).Text, @"^[0-9]+\s+([a-zA-Z]+|[a-zA-Z]+\s[a-zA-Z]+)$").Success)
            {
                e.KeyChar = '\0';
                e.Handled = true;
            }// end if
        }

    }

}
