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
    public class RouteTrxManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public RouteTrxManagement()
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

        #region RouteTrx

        private RouteTrx objRouteTrx;
        private ArrayList arrRouteTrx;

        public int EditRouteTrx(RouteTrx objRouteTrx)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@RouteTrxID", objRouteTrx.RouteTrxID));



                sqlListParam.Add(new SqlParameter("@RowStatus", objRouteTrx.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objRouteTrx.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spRouteTrxEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveRouteTrxActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrx WITH (NOLOCK) where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTrx = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTrx.Add(GenerateRouteTrxObject(sqlDataReader));
                }
            }

            return arrRouteTrx;
        }

        public ArrayList RetrieveRouteTrxAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrx WITH (NOLOCK) order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTrx = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTrx.Add(GenerateRouteTrxObject(sqlDataReader));
                }
            }

            return arrRouteTrx;
        }

        public RouteTrx RetrieveRouteTrxByID(int intRouteTrxID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrx WITH (NOLOCK) where RouteTrxID = '" + intRouteTrxID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTrx = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTrxObject(sqlDataReader);
                }
            }

            return new RouteTrx();
        }

        public RouteTrx RetrieveRouteTrxByNo(string strRouteTrxNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTrx WITH (NOLOCK) where No = '" + strRouteTrxNo + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTrx = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTrxObject(sqlDataReader);
                }
            }

            return new RouteTrx();
        }

        public int RetrieveRouteTrxFirstID(int intRouteTrxID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxID from RouteTrx WITH (NOLOCK) where RowStatus = 0 order by RouteTrxID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxID"]);
                }
            }

            return intRouteTrxID;
        }

        public int RetrieveRouteTrxNextID(int intRouteTrxID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxID from RouteTrx WITH (NOLOCK) where RouteTrxID > '" + intRouteTrxID + "' and RowStatus = 0 order by RouteTrxID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxID"]);
                }
            }
            return intRouteTrxID;
        }

        public int RetrieveRouteTrxPreviousID(int intRouteTrxID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxID from RouteTrx WITH (NOLOCK) where RouteTrxID < '" + intRouteTrxID + "' and RowStatus = 0 order by RouteTrxID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxID"]);
                }
            }
            return intRouteTrxID;
        }

        public int RetrieveRouteTrxLastID(int intRouteTrxID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTrxID from RouteTrx WITH (NOLOCK) where RowStatus = 0 order by RouteTrxID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTrxID"]);
                }
            }
            return intRouteTrxID;
        }

        public RouteTrx GenerateRouteTrxObject(SqlDataReader sqlDataReader)
        {
            objRouteTrx = new RouteTrx();
            objRouteTrx.RouteTrxID = Convert.ToInt32(sqlDataReader["RouteTrxID"]);



            objRouteTrx.RowStatus = (short)sqlDataReader["RowStatus"];
            objRouteTrx.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objRouteTrx.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objRouteTrx.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objRouteTrx.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objRouteTrx;
        }

        public DataTable RetrieveRouteTrxGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select RouteTrxID, [Name], [Description], [Blocked] FROM RouteTrx WITH (NOLOCK) where ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spRouteTrxList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion
    }
}
