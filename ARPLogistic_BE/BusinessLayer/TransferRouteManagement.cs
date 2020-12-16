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
    public class TransferRouteManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public TransferRouteManagement()
        {
        }

        #region TransferRoute

        private TransferRoute objTransferRoute;
        private ArrayList arrTransferRoute;

        public int EditTransferRoute(TransferRoute objTransferRoute)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@TransferRouteID", objTransferRoute.TransferRouteID));

                sqlListParam.Add(new SqlParameter("@TransferfromCode", objTransferRoute.TransferfromCode));
                sqlListParam.Add(new SqlParameter("@TransfertoCode", objTransferRoute.TransfertoCode));
                sqlListParam.Add(new SqlParameter("@JarakTempuh", objTransferRoute.JarakTempuh));
                sqlListParam.Add(new SqlParameter("@BiayaToll", objTransferRoute.BiayaToll));
                sqlListParam.Add(new SqlParameter("@BiayaBBM", objTransferRoute.BiayaBBM));
                sqlListParam.Add(new SqlParameter("@Retribusi", objTransferRoute.Retribusi));
                sqlListParam.Add(new SqlParameter("@BiayaLainLain", objTransferRoute.BiayaLainLain));

                sqlListParam.Add(new SqlParameter("@RowStatus", objTransferRoute.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objTransferRoute.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spTransferRouteEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveTransferRouteActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from TransferRoute where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrTransferRoute = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrTransferRoute.Add(GenerateTransferRouteObject(sqlDataReader));
                }
            }

            return arrTransferRoute;
        }

        public ArrayList RetrieveTransferRouteAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from TransferRoute Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrTransferRoute = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrTransferRoute.Add(GenerateTransferRouteObject(sqlDataReader));
                }
            }

            return arrTransferRoute;
        }

        public TransferRoute RetrieveTransferRouteByID(int intTransferRouteID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from TransferRoute where TransferRouteID = '" + intTransferRouteID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrTransferRoute = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateTransferRouteObject(sqlDataReader);
                }
            }

            return new TransferRoute();
        }

        public TransferRoute RetrieveTransferRouteByCode(string strTransferRoute)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from TransferRoute WHERE TransferRouteCode = '" + strTransferRoute + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrTransferRoute = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateTransferRouteObject(sqlDataReader);
                }
            }

            return new TransferRoute();
        }

        public int RetrieveTransferRouteNextID(int intTransferRouteID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from TransferRoute WHERE TransferRouteID > '" + intTransferRouteID + "' and RowStatus = 0 order by TransferRouteID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrTransferRoute = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["TransferRouteID"]);
                }
            }

            return intTransferRouteID;
        }

        public int RetrieveTransferRoutePreviousID(int intTransferRouteID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from TransferRoute WHERE TransferRouteID < '" + intTransferRouteID + "' and RowStatus = 0 order by TransferRouteID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                arrTransferRoute = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["TransferRouteID"]);
                }
            }

            return intTransferRouteID;
        }

        public TransferRoute GenerateTransferRouteObject(SqlDataReader sqlDataReader)
        {
            objTransferRoute = new TransferRoute();
            objTransferRoute.TransferRouteID = Convert.ToInt32(sqlDataReader["TransferRouteID"]);

            objTransferRoute.TransferfromCode = sqlDataReader["TransferfromCode"].ToString();
            objTransferRoute.TransfertoCode = sqlDataReader["TransfertoCode"].ToString();
            objTransferRoute.JarakTempuh = Convert.ToDecimal(sqlDataReader["JarakTempuh"]);
            objTransferRoute.BiayaToll = Convert.ToDecimal(sqlDataReader["BiayaToll"]);
            objTransferRoute.BiayaBBM = Convert.ToDecimal(sqlDataReader["BiayaBBM"]);
            objTransferRoute.Retribusi = Convert.ToDecimal(sqlDataReader["Retribusi"]);
            objTransferRoute.BiayaLainLain = Convert.ToDecimal(sqlDataReader["BiayaLainLain"]);

            objTransferRoute.RowStatus = Convert.ToByte(sqlDataReader["RowStatus"]);
            objTransferRoute.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objTransferRoute.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objTransferRoute.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objTransferRoute.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objTransferRoute;
        }

        public DataTable RetrieveTransferRouteGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select TransferRouteID, TransferRouteCode, TransferRouteName, Address, City, PhoneNo, FaxNo, EMail FROM TransferRoute WITH (NOLOCK) WHERE ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spTransferRouteList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion

        #region IFacade Members


        public string Error
        {
            get
            {
                return strError;
            }
        }

        #endregion
    }
}
