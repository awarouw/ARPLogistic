using ARPLogistic_BE.Entities;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.BusinessLayer
{
    public class EmployeeManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public EmployeeManagement()
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

        #region Employee

        private Employee objEmployee;
        private ArrayList arrEmployee;

        public int EditEmployee(Employee objEmployee)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@EmployeeID", objEmployee.EmployeeID));

                sqlListParam.Add(new SqlParameter("@No", objEmployee.No));
                sqlListParam.Add(new SqlParameter("@FirstName", objEmployee.FirstName));
                sqlListParam.Add(new SqlParameter("@MiddleName", objEmployee.MiddleName));
                sqlListParam.Add(new SqlParameter("@LastName", objEmployee.LastName));
                sqlListParam.Add(new SqlParameter("@Initials", objEmployee.Initials));
                sqlListParam.Add(new SqlParameter("@JobTitle", objEmployee.JobTitle));
                sqlListParam.Add(new SqlParameter("@Address", objEmployee.Address));
                sqlListParam.Add(new SqlParameter("@Address2", objEmployee.Address2));
                sqlListParam.Add(new SqlParameter("@City", objEmployee.City));
                sqlListParam.Add(new SqlParameter("@PostCode", objEmployee.PostCode));
                sqlListParam.Add(new SqlParameter("@BloodType", objEmployee.BloodType));
                sqlListParam.Add(new SqlParameter("@PhoneNo", objEmployee.PhoneNo));
                sqlListParam.Add(new SqlParameter("@MobilePhoneNo", objEmployee.MobilePhoneNo));
                sqlListParam.Add(new SqlParameter("@EMail", objEmployee.EMail));
                sqlListParam.Add(new SqlParameter("@ReligionCode", objEmployee.ReligionCode));
                sqlListParam.Add(new SqlParameter("@JamsostekNo", objEmployee.JamsostekNo));
                sqlListParam.Add(new SqlParameter("@BPJSKesehatanNo", objEmployee.BPJSKesehatanNo));
                sqlListParam.Add(new SqlParameter("@FilePicture", objEmployee.FilePicture));
                sqlListParam.Add(new SqlParameter("@BirthDate", objEmployee.BirthDate));
                sqlListParam.Add(new SqlParameter("@SocialSecurityNo", objEmployee.SocialSecurityNo));
                sqlListParam.Add(new SqlParameter("@TaxCode", objEmployee.TaxCode));
                sqlListParam.Add(new SqlParameter("@PlaceofBirth", objEmployee.PlaceofBirth));
                sqlListParam.Add(new SqlParameter("@MaritalStatus", objEmployee.MaritalStatus));
                sqlListParam.Add(new SqlParameter("@TaxStatusCode", objEmployee.TaxStatusCode));
                sqlListParam.Add(new SqlParameter("@BankAccountNo", objEmployee.BankAccountNo));
                sqlListParam.Add(new SqlParameter("@BankAccountName", objEmployee.BankAccountName));
                sqlListParam.Add(new SqlParameter("@Gender", objEmployee.Gender));
                sqlListParam.Add(new SqlParameter("@Country", objEmployee.Country));
                sqlListParam.Add(new SqlParameter("@ManagerNo", objEmployee.ManagerNo));
                sqlListParam.Add(new SqlParameter("@EmplymtContractCode", objEmployee.EmplymtContractCode));
                sqlListParam.Add(new SqlParameter("@StatisticsGroupCode", objEmployee.StatisticsGroupCode));
                sqlListParam.Add(new SqlParameter("@EmployeePostingGroup", objEmployee.EmployeePostingGroup));
                sqlListParam.Add(new SqlParameter("@EmploymentDate", objEmployee.EmploymentDate));
                sqlListParam.Add(new SqlParameter("@Status", objEmployee.Status));
                sqlListParam.Add(new SqlParameter("@InactiveDate", objEmployee.InactiveDate));
                sqlListParam.Add(new SqlParameter("@CauseofInactivityCode", objEmployee.CauseofInactivityCode));
                sqlListParam.Add(new SqlParameter("@TerminationDate", objEmployee.TerminationDate));
                sqlListParam.Add(new SqlParameter("@GroundsforTermCode", objEmployee.GroundsforTermCode));
                sqlListParam.Add(new SqlParameter("@GlobalDimension1Code", objEmployee.GlobalDimension1Code));
                sqlListParam.Add(new SqlParameter("@GlobalDimension2Code", objEmployee.GlobalDimension2Code));
                sqlListParam.Add(new SqlParameter("@ResourceNo", objEmployee.ResourceNo));
                sqlListParam.Add(new SqlParameter("@FaxNo", objEmployee.FaxNo));
                sqlListParam.Add(new SqlParameter("@CompanyEMail", objEmployee.CompanyEMail));
                sqlListParam.Add(new SqlParameter("@Title", objEmployee.Title));
                sqlListParam.Add(new SqlParameter("@SalespersPurchCode", objEmployee.SalespersPurchCode));
                sqlListParam.Add(new SqlParameter("@NoSeries", objEmployee.NoSeries));

                sqlListParam.Add(new SqlParameter("@RowStatus", objEmployee.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objEmployee.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spEmployeeEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveEmployeeActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Employee WITH (NOLOCK) where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrEmployee = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrEmployee.Add(GenerateEmployeeObject(sqlDataReader));
                }
            }

            return arrEmployee;
        }

        public ArrayList RetrieveEmployeeAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Employee WITH (NOLOCK) order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrEmployee = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrEmployee.Add(GenerateEmployeeObject(sqlDataReader));
                }
            }

            return arrEmployee;
        }

        public Employee RetrieveEmployeeByID(int intEmployeeID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Employee WITH (NOLOCK) where EmployeeID = '" + intEmployeeID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrEmployee = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateEmployeeObject(sqlDataReader);
                }
            }

            return new Employee();
        }

        public Employee RetrieveEmployeeByNo(string strEmployeeNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Employee WITH (NOLOCK) where No = '" + strEmployeeNo + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrEmployee = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateEmployeeObject(sqlDataReader);
                }
            }

            return new Employee();
        }

        public int RetrieveEmployeeFirstID(int intEmployeeID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 EmployeeID from Employee WITH (NOLOCK) where RowStatus = 0 order by EmployeeID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["EmployeeID"]);
                }
            }

            return intEmployeeID;
        }

        public int RetrieveEmployeeNextID(int intEmployeeID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 EmployeeID from Employee WITH (NOLOCK) where EmployeeID > '" + intEmployeeID + "' and RowStatus = 0 order by EmployeeID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["EmployeeID"]);
                }
            }
            return intEmployeeID;
        }

        public int RetrieveEmployeePreviousID(int intEmployeeID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 EmployeeID from Employee WITH (NOLOCK) where EmployeeID < '" + intEmployeeID + "' and RowStatus = 0 order by EmployeeID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["EmployeeID"]);
                }
            }
            return intEmployeeID;
        }

        public int RetrieveEmployeeLastID(int intEmployeeID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 EmployeeID from Employee WITH (NOLOCK) where RowStatus = 0 order by EmployeeID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["EmployeeID"]);
                }
            }
            return intEmployeeID;
        }

        public Employee GenerateEmployeeObject(SqlDataReader sqlDataReader)
        {
            objEmployee = new Employee();
            objEmployee.EmployeeID = Convert.ToInt32(sqlDataReader["EmployeeID"]);

            objEmployee.No = sqlDataReader["No"].ToString();
            objEmployee.FirstName = sqlDataReader["FirstName"].ToString();
            objEmployee.MiddleName = sqlDataReader["MiddleName"].ToString();
            objEmployee.LastName = sqlDataReader["LastName"].ToString();
            objEmployee.Initials = sqlDataReader["Initials"].ToString();
            objEmployee.JobTitle = sqlDataReader["JobTitle"].ToString();
            objEmployee.Address = sqlDataReader["Address"].ToString();
            objEmployee.Address2 = sqlDataReader["Address2"].ToString();
            objEmployee.City = sqlDataReader["City"].ToString();
            objEmployee.PostCode = sqlDataReader["PostCode"].ToString();
            objEmployee.BloodType = sqlDataReader["BloodType"].ToString();
            objEmployee.PhoneNo = sqlDataReader["PhoneNo"].ToString();
            objEmployee.MobilePhoneNo = sqlDataReader["MobilePhoneNo"].ToString();
            objEmployee.EMail = sqlDataReader["EMail"].ToString();
            objEmployee.ReligionCode = sqlDataReader["ReligionCode"].ToString();
            objEmployee.JamsostekNo = sqlDataReader["JamsostekNo"].ToString();
            objEmployee.BPJSKesehatanNo = sqlDataReader["BPJSKesehatanNo"].ToString();
            objEmployee.FilePicture = sqlDataReader["FilePicture"].ToString();
            objEmployee.BirthDate = Convert.ToDateTime(sqlDataReader["BirthDate"]);
            objEmployee.SocialSecurityNo = sqlDataReader["SocialSecurityNo"].ToString();
            objEmployee.TaxCode = sqlDataReader["TaxCode"].ToString();
            objEmployee.PlaceofBirth = sqlDataReader["PlaceofBirth"].ToString();
            objEmployee.MaritalStatus = sqlDataReader["MaritalStatus"].ToString();
            objEmployee.TaxStatusCode = sqlDataReader["TaxStatusCode"].ToString();
            objEmployee.BankAccountNo = sqlDataReader["BankAccountNo"].ToString();
            objEmployee.BankAccountName = sqlDataReader["BankAccountName"].ToString();
            objEmployee.Gender = Convert.ToInt32(sqlDataReader["Gender"]);
            objEmployee.Country = sqlDataReader["Country"].ToString();
            objEmployee.ManagerNo = sqlDataReader["ManagerNo"].ToString();
            objEmployee.EmplymtContractCode = sqlDataReader["EmplymtContractCode"].ToString();
            objEmployee.StatisticsGroupCode = sqlDataReader["StatisticsGroupCode"].ToString();
            objEmployee.EmployeePostingGroup = sqlDataReader["EmployeePostingGroup"].ToString();
            objEmployee.EmploymentDate = Convert.ToDateTime(sqlDataReader["EmploymentDate"]);
            objEmployee.Status = Convert.ToInt32(sqlDataReader["Status"]);
            objEmployee.InactiveDate = Convert.ToDateTime(sqlDataReader["InactiveDate"]);
            objEmployee.CauseofInactivityCode = sqlDataReader["CauseofInactivityCode"].ToString();
            objEmployee.TerminationDate = Convert.ToDateTime(sqlDataReader["TerminationDate"]);
            objEmployee.GroundsforTermCode = sqlDataReader["GroundsforTermCode"].ToString();
            objEmployee.GlobalDimension1Code = sqlDataReader["GlobalDimension1Code"].ToString();
            objEmployee.GlobalDimension2Code = sqlDataReader["GlobalDimension2Code"].ToString();
            objEmployee.ResourceNo = sqlDataReader["ResourceNo"].ToString();
            objEmployee.FaxNo = sqlDataReader["FaxNo"].ToString();
            objEmployee.CompanyEMail = sqlDataReader["CompanyEMail"].ToString();
            objEmployee.Title = sqlDataReader["Title"].ToString();
            objEmployee.SalespersPurchCode = sqlDataReader["SalespersPurchCode"].ToString();
            objEmployee.NoSeries = sqlDataReader["NoSeries"].ToString();

            objEmployee.RowStatus = (short)sqlDataReader["RowStatus"];
            objEmployee.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objEmployee.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objEmployee.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objEmployee.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objEmployee;
        }

        public DataTable RetrieveEmployeeGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select EmployeeID, No, Name, Address, City, PhoneNo FROM Employee WITH (NOLOCK) where ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spEmployeeList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion
    }
}
