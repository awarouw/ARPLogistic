using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Collections;
using ARPLogistic_BE.Entities;

namespace ARPLogistic_BE
{
    public class CompanyManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public CompanyManagement()
        {
        }

        #region IFacade Members

        public string Error
        {
            get
            {
                return strError;
            }
        }

        #endregion


        #region CompanyInformation

        private CompanyInformation objCompanyInformation;
        // private ArrayList arrCompanyInformation;

        public string EditCompanyInformation(CompanyInformation objCompanyInformation)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@CompanyCode", objCompanyInformation.CompanyCode));
                sqlListParam.Add(new SqlParameter("@ParentCompanyCode", objCompanyInformation.ParentCompanyCode));
                sqlListParam.Add(new SqlParameter("@CompanyName", objCompanyInformation.CompanyName));
                sqlListParam.Add(new SqlParameter("@CompanyName2", objCompanyInformation.CompanyName2));
                sqlListParam.Add(new SqlParameter("@CompanyAddress", objCompanyInformation.CompanyAddress));
                sqlListParam.Add(new SqlParameter("@CompanyAddress2", objCompanyInformation.CompanyAddress2));
                sqlListParam.Add(new SqlParameter("@CompanyCity", objCompanyInformation.CompanyCity));
                sqlListParam.Add(new SqlParameter("@CompanyPhoneNo", objCompanyInformation.CompanyPhoneNo));
                sqlListParam.Add(new SqlParameter("@CompanyPhoneNo2", objCompanyInformation.CompanyPhoneNo2));
                sqlListParam.Add(new SqlParameter("@CompanyFaxNo", objCompanyInformation.CompanyFaxNo));
                sqlListParam.Add(new SqlParameter("@GiroNo", objCompanyInformation.GiroNo));
                sqlListParam.Add(new SqlParameter("@BankName", objCompanyInformation.BankName));
                sqlListParam.Add(new SqlParameter("@BankBranchNo", objCompanyInformation.BankBranchNo));
                sqlListParam.Add(new SqlParameter("@BankAccountNo", objCompanyInformation.BankAccountNo));
                sqlListParam.Add(new SqlParameter("@BankAccountName", objCompanyInformation.BankAccountName));
                sqlListParam.Add(new SqlParameter("@BankAddress", objCompanyInformation.BankAddress));
                sqlListParam.Add(new SqlParameter("@PaymentRoutingNo", objCompanyInformation.PaymentRoutingNo));
                sqlListParam.Add(new SqlParameter("@CustomsPermitNo", objCompanyInformation.CustomsPermitNo));
                sqlListParam.Add(new SqlParameter("@CustomsPermitDate", objCompanyInformation.CustomsPermitDate));
                sqlListParam.Add(new SqlParameter("@VATRegistrationNo", objCompanyInformation.VATRegistrationNo));
                sqlListParam.Add(new SqlParameter("@RegistrationNo", objCompanyInformation.RegistrationNo));
                sqlListParam.Add(new SqlParameter("@ShiptoName", objCompanyInformation.ShiptoName));
                sqlListParam.Add(new SqlParameter("@ShiptoName2", objCompanyInformation.ShiptoName2));
                sqlListParam.Add(new SqlParameter("@ShiptoAddress", objCompanyInformation.ShiptoAddress));
                sqlListParam.Add(new SqlParameter("@ShiptoAddress2", objCompanyInformation.ShiptoAddress2));
                sqlListParam.Add(new SqlParameter("@ShiptoCity", objCompanyInformation.ShiptoCity));
                sqlListParam.Add(new SqlParameter("@ShiptoContact", objCompanyInformation.ShiptoContact));
                sqlListParam.Add(new SqlParameter("@LocationCode", objCompanyInformation.LocationCode));
                sqlListParam.Add(new SqlParameter("@ImageFolderName", objCompanyInformation.ImageFolderName));
                sqlListParam.Add(new SqlParameter("@PostCode", objCompanyInformation.PostCode));
                sqlListParam.Add(new SqlParameter("@ShiptoPostCode", objCompanyInformation.ShiptoPostCode));
                sqlListParam.Add(new SqlParameter("@EMail", objCompanyInformation.EMail));
                sqlListParam.Add(new SqlParameter("@HomePage", objCompanyInformation.HomePage));
                sqlListParam.Add(new SqlParameter("@CountryRegionCode", objCompanyInformation.CountryRegionCode));
                sqlListParam.Add(new SqlParameter("@ShiptoCountryRegionCode", objCompanyInformation.ShiptoCountryRegionCode));
                sqlListParam.Add(new SqlParameter("@IBAN", objCompanyInformation.IBAN));
                sqlListParam.Add(new SqlParameter("@SWIFTCode", objCompanyInformation.SWIFTCode));
                sqlListParam.Add(new SqlParameter("@IndustrialClassification", objCompanyInformation.IndustrialClassification));
                sqlListParam.Add(new SqlParameter("@AbbreviatedName", objCompanyInformation.AbbreviatedName));
                sqlListParam.Add(new SqlParameter("@ShowAbbreviatedName", objCompanyInformation.ShowAbbreviatedName));
                sqlListParam.Add(new SqlParameter("@SystemIndicator", objCompanyInformation.SystemIndicator));
                sqlListParam.Add(new SqlParameter("@CustomSystemIndicatorText", objCompanyInformation.CustomSystemIndicatorText));
                sqlListParam.Add(new SqlParameter("@SystemIndicatorStyle", objCompanyInformation.SystemIndicatorStyle));
                sqlListParam.Add(new SqlParameter("@ResponsibilityCenter", objCompanyInformation.ResponsibilityCenter));
                sqlListParam.Add(new SqlParameter("@CheckAvailPeriodCalc", objCompanyInformation.CheckAvailPeriodCalc));
                sqlListParam.Add(new SqlParameter("@CheckAvailTimeBucket", objCompanyInformation.CheckAvailTimeBucket));
                sqlListParam.Add(new SqlParameter("@BaseCalendarCode", objCompanyInformation.BaseCalendarCode));
                sqlListParam.Add(new SqlParameter("@CalConvergenceTimeFrame", objCompanyInformation.CalConvergenceTimeFrame));
                sqlListParam.Add(new SqlParameter("@ABN", objCompanyInformation.ABN));
                sqlListParam.Add(new SqlParameter("@TaxPeriod", objCompanyInformation.TaxPeriod));
                sqlListParam.Add(new SqlParameter("@ABNDivisionPartNo", objCompanyInformation.ABNDivisionPartNo));
                sqlListParam.Add(new SqlParameter("@IRDNo", objCompanyInformation.IRDNo));
                sqlListParam.Add(new SqlParameter("@RDOCode", objCompanyInformation.RDOCode));
                sqlListParam.Add(new SqlParameter("@VATRegistrationDate", objCompanyInformation.VATRegistrationDate));
                sqlListParam.Add(new SqlParameter("@SignInvoiceName", objCompanyInformation.SignInvoiceName));
                sqlListParam.Add(new SqlParameter("@SignInvoiceDept", objCompanyInformation.SignInvoiceDept));
                sqlListParam.Add(new SqlParameter("@APPVersion", objCompanyInformation.APPVersion));
                sqlListParam.Add(new SqlParameter("@FileFolder", objCompanyInformation.FileFolder));
                sqlListParam.Add(new SqlParameter("@LoginImageName", objCompanyInformation.LoginImageName));
                sqlListParam.Add(new SqlParameter("@LogoFileName", objCompanyInformation.LogoFileName));
                sqlListParam.Add(new SqlParameter("@WallFileName", objCompanyInformation.WallFileName));
                sqlListParam.Add(new SqlParameter("@SecurityCheck", objCompanyInformation.SecurityCheck));

                sqlListParam.Add(new SqlParameter("@RowStatus", objCompanyInformation.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objCompanyInformation.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                string intResult = dataAccess.ProcessDataWithNonQuery(sqlListParam, "dbo.spCompanyInformationEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return "Error";
            }

        }

        public CompanyInformation RetrieveCompanyInformationByID()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from dbo.CompanyInformation where CompanyCode = DB_Name() AND RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateCompanyInformationObject(sqlDataReader);
                }
            }

            return new CompanyInformation();
        }

        public CompanyInformation RetrieveCompanyInformationByCode(string strCompanyCode)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from dbo.CompanyInformation where CompanyCode = '" + strCompanyCode + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateCompanyInformationObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new CompanyInformation();
        }

        public CompanyInformation RetrieveCompanyInformationByUser(string strUser)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select CompanyInformation.* from dbo.CompanyInformation as CompanyInformation INNER JOIN dbo.systemuserroles as systemuserroles ON CompanyInformation.CompanyCode = systemuserroles.CompanyCode where systemuserroles.UserCode = '" + strUser + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateCompanyInformationObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new CompanyInformation();
        }

        public CompanyInformation GenerateCompanyInformationObject(SqlDataReader sqlDataReader)
        {
            objCompanyInformation = new CompanyInformation();

            objCompanyInformation.CompanyCode = sqlDataReader["CompanyCode"].ToString();
            objCompanyInformation.ParentCompanyCode = sqlDataReader["ParentCompanyCode"].ToString();
            objCompanyInformation.CompanyName = sqlDataReader["CompanyName"].ToString();
            objCompanyInformation.CompanyName2 = sqlDataReader["CompanyName2"].ToString();
            objCompanyInformation.CompanyAddress = sqlDataReader["CompanyAddress"].ToString();
            objCompanyInformation.CompanyAddress2 = sqlDataReader["CompanyAddress2"].ToString();
            objCompanyInformation.CompanyCity = sqlDataReader["CompanyCity"].ToString();
            objCompanyInformation.CompanyPhoneNo = sqlDataReader["CompanyPhoneNo"].ToString();
            objCompanyInformation.CompanyPhoneNo2 = sqlDataReader["CompanyPhoneNo2"].ToString();
            objCompanyInformation.CompanyFaxNo = sqlDataReader["CompanyFaxNo"].ToString();
            objCompanyInformation.GiroNo = sqlDataReader["GiroNo"].ToString();
            objCompanyInformation.BankName = sqlDataReader["BankName"].ToString();
            objCompanyInformation.BankBranchNo = sqlDataReader["BankBranchNo"].ToString();
            objCompanyInformation.BankAccountNo = sqlDataReader["BankAccountNo"].ToString();
            objCompanyInformation.BankAccountName = sqlDataReader["BankAccountName"].ToString();
            objCompanyInformation.BankAddress = sqlDataReader["BankAddress"].ToString();
            objCompanyInformation.PaymentRoutingNo = sqlDataReader["PaymentRoutingNo"].ToString();
            objCompanyInformation.CustomsPermitNo = sqlDataReader["CustomsPermitNo"].ToString();
            objCompanyInformation.CustomsPermitDate = Convert.ToDateTime(sqlDataReader["CustomsPermitDate"]);
            objCompanyInformation.VATRegistrationNo = sqlDataReader["VATRegistrationNo"].ToString();
            objCompanyInformation.RegistrationNo = sqlDataReader["RegistrationNo"].ToString();
            objCompanyInformation.ShiptoName = sqlDataReader["ShiptoName"].ToString();
            objCompanyInformation.ShiptoName2 = sqlDataReader["ShiptoName2"].ToString();
            objCompanyInformation.ShiptoAddress = sqlDataReader["ShiptoAddress"].ToString();
            objCompanyInformation.ShiptoAddress2 = sqlDataReader["ShiptoAddress2"].ToString();
            objCompanyInformation.ShiptoCity = sqlDataReader["ShiptoCity"].ToString();
            objCompanyInformation.ShiptoContact = sqlDataReader["ShiptoContact"].ToString();
            objCompanyInformation.LocationCode = sqlDataReader["LocationCode"].ToString();
            objCompanyInformation.ImageFolderName = sqlDataReader["ImageFolderName"].ToString();
            objCompanyInformation.PostCode = sqlDataReader["PostCode"].ToString();
            objCompanyInformation.ShiptoPostCode = sqlDataReader["ShiptoPostCode"].ToString();
            objCompanyInformation.EMail = sqlDataReader["EMail"].ToString();
            objCompanyInformation.HomePage = sqlDataReader["HomePage"].ToString();
            objCompanyInformation.CountryRegionCode = sqlDataReader["CountryRegionCode"].ToString();
            objCompanyInformation.ShiptoCountryRegionCode = sqlDataReader["ShiptoCountryRegionCode"].ToString();
            objCompanyInformation.IBAN = sqlDataReader["IBAN"].ToString();
            objCompanyInformation.SWIFTCode = sqlDataReader["SWIFTCode"].ToString();
            objCompanyInformation.IndustrialClassification = sqlDataReader["IndustrialClassification"].ToString();
            objCompanyInformation.AbbreviatedName = sqlDataReader["AbbreviatedName"].ToString();
            objCompanyInformation.ShowAbbreviatedName = Convert.ToByte(sqlDataReader["ShowAbbreviatedName"]);
            objCompanyInformation.SystemIndicator = Convert.ToInt32(sqlDataReader["SystemIndicator"]);
            objCompanyInformation.CustomSystemIndicatorText = sqlDataReader["CustomSystemIndicatorText"].ToString();
            objCompanyInformation.SystemIndicatorStyle = Convert.ToInt32(sqlDataReader["SystemIndicatorStyle"]);
            objCompanyInformation.ResponsibilityCenter = sqlDataReader["ResponsibilityCenter"].ToString();
            objCompanyInformation.CheckAvailPeriodCalc = sqlDataReader["CheckAvailPeriodCalc"].ToString();
            objCompanyInformation.CheckAvailTimeBucket = Convert.ToInt32(sqlDataReader["CheckAvailTimeBucket"]);
            objCompanyInformation.BaseCalendarCode = sqlDataReader["BaseCalendarCode"].ToString();
            objCompanyInformation.CalConvergenceTimeFrame = sqlDataReader["CalConvergenceTimeFrame"].ToString();
            objCompanyInformation.ABN = sqlDataReader["ABN"].ToString();
            objCompanyInformation.TaxPeriod = Convert.ToInt32(sqlDataReader["TaxPeriod"]);
            objCompanyInformation.ABNDivisionPartNo = sqlDataReader["ABNDivisionPartNo"].ToString();
            objCompanyInformation.IRDNo = sqlDataReader["IRDNo"].ToString();
            objCompanyInformation.RDOCode = sqlDataReader["RDOCode"].ToString();
            objCompanyInformation.VATRegistrationDate = Convert.ToDateTime(sqlDataReader["VATRegistrationDate"]);
            objCompanyInformation.SignInvoiceName = sqlDataReader["SignInvoiceName"].ToString();
            objCompanyInformation.SignInvoiceDept = sqlDataReader["SignInvoiceDept"].ToString();
            objCompanyInformation.APPVersion = sqlDataReader["APPVersion"].ToString();
            objCompanyInformation.FileFolder = sqlDataReader["FileFolder"].ToString();
            objCompanyInformation.LoginImageName = sqlDataReader["LoginImageName"].ToString();
            objCompanyInformation.LogoFileName = sqlDataReader["LogoFileName"].ToString();
            objCompanyInformation.WallFileName = sqlDataReader["WallFileName"].ToString();
            objCompanyInformation.SecurityCheck = sqlDataReader["SecurityCheck"].ToString();

            objCompanyInformation.RowStatus = Convert.ToByte(sqlDataReader["RowStatus"]);
            objCompanyInformation.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objCompanyInformation.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objCompanyInformation.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objCompanyInformation.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);

            objCompanyInformation.AllVisionsCS = Global.AllVisionsCS;
            return objCompanyInformation;
        }

        public DataTable RetrieveCustomersGrid(string strCompanyCode)
        {
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                DataTable dt = new DataTable();

                objCompanyInformation = RetrieveCompanyInformationByCode(strCompanyCode);
                string sqlstring = "";
                if (objCompanyInformation.CompanyCode == objCompanyInformation.ParentCompanyCode)
                    sqlstring = "Select CompanyCode FROM CompanyInformation WITH (NOLOCK) where ParentCompanyCode = '" + strCompanyCode + "'";
                else
                    sqlstring = "Select CompanyCode FROM CompanyInformation WITH (NOLOCK) where CompanyCode = '" + strCompanyCode + "'";

                //string sqlstring = "exec spCustomersList";
                dt = dataAccess.RetrieveDataTable(sqlstring);

                return dt;
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new DataTable();
            }
        }

        public DataTable RetrieveCompanyList(string strUserCode)
        {
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                DataTable dt = new DataTable();

                //objCompanyInformation = RetrieveCompanyInformationByCode(strCompanyCode);
                string sqlstring = "";
                //if (objCompanyInformation.CompanyCode == objCompanyInformation.ParentCompanyCode)
                sqlstring = "Select CompanyCode FROM dbo.systemuserroles WITH (NOLOCK) where UserCode = '" + strUserCode + "' AND RowStatus = 0";
                //else
                //    sqlstring = "Select CompanyCode FROM dbo.systemuserroles WITH (NOLOCK) where CompanyCode = '" + strCompanyCode + "'";

                //string sqlstring = "exec spCustomersList";
                dt = dataAccess.RetrieveDataTable(sqlstring);

                return dt;
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new DataTable();
            }
        }

        #endregion

        public DataTable RetrieveCompanyToGrid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dataTable = new DataTable();

            string strQuery = "SELECT TOP 100 PERCENT dbo.CompanyInformation.CompanyCode, dbo.CompanyInformation.ParentCompanyCode,";
            strQuery += " dbo.CompanyInformation.CompanyName, dbo.CompanyInformation.CompanyName2, dbo.CompanyInformation.CompanyAddress,";
            strQuery += " dbo.CompanyInformation.CompanyAddress2, dbo.CompanyInformation.CompanyCity, dbo.CompanyInformation.CompanyPhoneNo,";
            strQuery += " dbo.CompanyInformation.CompanyPhoneNo2, dbo.CompanyInformation.CompanyFaxNo, dbo.CompanyInformation.PostCode,";
            strQuery += " dbo.CompanyInformation.EMail, dbo.CompanyInformation.HomePage, dbo.CompanyInformation.CountryRegionCode ";
            strQuery += "FROM dbo.CompanyInformation ORDER BY CompanyCode ASC";

            return dataAccess.RetrieveDataTable(strQuery);
        }

        public string RetrieveCompanyFirstID()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 CompanyCode from CompanyInformation where RowStatus = 0 order by CompanyCode");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows && sqlDataReader.Read())
                return Convert.ToString(sqlDataReader["CompanyCode"]);

            return "Nothing";
        }
    }
}
