using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Reflection;
using System.Configuration;
using System.Collections;
using System.IO;
using Excel = Microsoft.Office.Interop.Excel;

namespace ARPLogistic_BE
{
    public class dbSecurity
    {

        public static string MD5(string password)
        {
            byte[] textBytes = System.Text.Encoding.Default.GetBytes(password);
            try
            {
                System.Security.Cryptography.MD5CryptoServiceProvider cryptHandler;
                cryptHandler = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hash = cryptHandler.ComputeHash(textBytes);
                string ret = "";
                foreach (byte a in hash)
                {
                    if (a < 16)
                        ret += "0" + a.ToString("x");
                    else
                        ret += a.ToString("x");
                }
                return ret;
            }
            catch
            {
                throw;
            }
        }

        public static Boolean Isload(Form f)
        {
            foreach (Form FOpen in Application.OpenForms)
            {
                if (FOpen.Name == f.Name)
                {
                    FOpen.Show();
                    return true;
                }
            }
            return false;
        }

        public static Form GetFormByName(string frmname)
        {
            var formType = Assembly.GetExecutingAssembly().GetTypes()
                .Where(a => (a.BaseType == typeof(Form)) && a.Name == frmname)
                .FirstOrDefault();

            if (formType == null) // If there is no form with the given frmname
                return null;

            return (Form)Activator.CreateInstance(formType);
        }

        public static void ToCsV(DataGridView dGV, string filename)
        {
            try
            {
                Excel.Application xlApp;
                Excel.Workbook xlWorkBook;
                Excel.Worksheet xlWorkSheet;
                object misValue = System.Reflection.Missing.Value;

                xlApp = new Excel.Application();
                xlWorkBook = xlApp.Workbooks.Add(misValue);
                xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);
                int i = 0;
                int j = 0;
                int k = 0;

                // storing header part in Excel
                for (i = 1; i < dGV.Columns.Count + 1; i++)
                {
                    if (dGV.Columns[i - 1].Visible == true)
                    {
                        j += 1;
                        xlWorkSheet.Cells[1, j] = dGV.Columns[i - 1].HeaderText;
                    }
                }

                for (i = 0; i <= dGV.RowCount - 1; i++)
                {
                    k = 0;
                    for (j = 0; j <= dGV.ColumnCount - 1; j++)
                    {
                        if (dGV.Columns[j].Visible == true)
                        {
                            k += 1;
                            DataGridViewCell cell = dGV[j, i];
                            xlWorkSheet.Cells[i + 2, k] = cell.Value;
                        }
                    }
                }

                xlWorkBook.SaveAs(filename, Excel.XlFileFormat.xlWorkbookNormal, misValue, misValue, misValue, misValue, Excel.XlSaveAsAccessMode.xlExclusive, misValue, misValue, misValue, misValue, misValue);
                xlWorkBook.Close(true, misValue, misValue);
                xlApp.Quit();

                releaseObject(xlWorkSheet);
                releaseObject(xlWorkBook);
                releaseObject(xlApp);
            }
            catch
            {
                throw;
            }
        }

        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception ex)
            {
                obj = null;
                MessageBox.Show("Exception Occured while releasing object " + ex.ToString());
            }
            finally
            {
                GC.Collect();
            }
        }


        public static string CheckSecurity(string strSecurityCheck, string strCompanyCode)
        {
            string s = strSecurityCheck;
            DateTime dtResult = DateTime.Today;
            string result = "";
            string strCompany = "";
            string subResult = "";
            for (int index = 0; index < s.Length; index++)
            {
                if (s[index].ToString() == "0")
                    subResult = s[index].ToString();
                else
                    if (index % 2 != 0)
                        switch (s[index].ToString())
                        {
                            case "A":
                                subResult = "1";
                                break;
                            case "B":
                                subResult = "2";
                                break;
                            case "C":
                                subResult = "3";
                                break;
                            case "D":
                                subResult = "4";
                                break;
                            case "E":
                                subResult = "5";
                                break;
                            case "F":
                                subResult = "6";
                                break;
                            case "G":
                                subResult = "7";
                                break;
                            case "H":
                                subResult = "8";
                                break;
                            default:
                                subResult = "9";
                                break;
                        }
                    else
                        subResult = s[index].ToString();

                if (index % 2 != 0)
                    result += subResult;
                else
                {
                    strCompany += (char)((int)Convert.ToChar(subResult) - 1);
                }

            }

            dtResult = new DateTime(Convert.ToInt32(result.Substring(0, 4)), Convert.ToInt32(result.Substring(4, 2)), Convert.ToInt32(result.Substring(6, 2)));
            //dtResult = Convert.ToDateTime(result.ToString());
            if (dtResult.AddMonths(1) > DateTime.Today)
                if (strCompany.ToUpper() == strCompanyCode.Substring(0,8).ToUpper())
                    return "";
                else
                    return "Please check your Company Code";
            else
                return "Please check your Company Date";
        }

    }
}
