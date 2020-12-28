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
    public class RouteTrxLineManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public RouteTrxLineManagement()
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

        #region RouteTrxLine

        private RouteTrxLine objRouteTrxLine;
        private ArrayList arrRouteTrxLine;

        public int EditRouteTrxLine(RouteTrxLine objRouteTrxLine)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@RouteTrxLineID", objRouteTrxLine.RouteTrxLineID));


                sqlListParam.Add(new SqlParameter("@RowStatus", objRouteTrxLine.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objRouteTrxLine.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spRouteTrxLineEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveRouteTrxLineActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrxLine WITH (NOLOCK) where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTrxLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTrxLine.Add(GenerateRouteTrxLineObject(sqlDataReader));
                }
            }

            return arrRouteTrxLine;
        }

        public ArrayList RetrieveRouteTrxLineAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrxLine WITH (NOLOCK) order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTrxLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTrxLine.Add(GenerateRouteTrxLineObject(sqlDataReader));
                }
            }

            return arrRouteTrxLine;
        }

        public RouteTrxLine RetrieveRouteTrxLineByID(int intRouteTrxLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrxLine WITH (NOLOCK) where RouteTrxLineID = '" + intRouteTrxLineID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTrxLine = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTrxLineObject(sqlDataReader);
                }
            }

            return new RouteTrxLine();
        }

        public RouteTrxLine RetrieveRouteTrxLineByNo(string strRouteTrxLineNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrxLine WITH (NOLOCK) where No = '" + strRouteTrxLineNo + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTrxLine = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTrxLineObject(sqlDataReader);
                }
            }

            return new RouteTrxLine();
        }

        public int RetrieveRouteTrxLineFirstID(int intRouteTrxLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxLineID from RouteTrxLine WITH (NOLOCK) where RowStatus = 0 order by RouteTrxLineID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxLineID"]);
                }
            }

            return intRouteTrxLineID;
        }

        public int RetrieveRouteTrxLineNextID(int intRouteTrxLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxLineID from RouteTrxLine WITH (NOLOCK) where RouteTrxLineID > '" + intRouteTrxLineID + "' and RowStatus = 0 order by RouteTrxLineID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxLineID"]);
                }
            }
            return intRouteTrxLineID;
        }

        public int RetrieveRouteTrxLinePreviousID(int intRouteTrxLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxLineID from RouteTrxLine WITH (NOLOCK) where RouteTrxLineID < '" + intRouteTrxLineID + "' and RowStatus = 0 order by RouteTrxLineID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxLineID"]);
                }
            }
            return intRouteTrxLineID;
        }

        public int RetrieveRouteTrxLineLastID(int intRouteTrxLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxLineID from RouteTrxLine WITH (NOLOCK) where RowStatus = 0 order by RouteTrxLineID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxLineID"]);
                }
            }
            return intRouteTrxLineID;
        }

        public RouteTrxLine GenerateRouteTrxLineObject(SqlDataReader sqlDataReader)
        {
            objRouteTrxLine = new RouteTrxLine();
            objRouteTrxLine.RouteTrxLineID = Convert.ToInt32(sqlDataReader["RouteTrxLineID"]);


            objRouteTrxLine.RowStatus = (short)sqlDataReader["RowStatus"];
            objRouteTrxLine.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objRouteTrxLine.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objRouteTrxLine.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objRouteTrxLine.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objRouteTrxLine;
        }

        public DataTable RetrieveRouteTrxLineGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select RouteTrxLineID, [Name], [Description], [Blocked] FROM RouteTrxLine WITH (NOLOCK) where ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spRouteTrxLineList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion
    }
}
