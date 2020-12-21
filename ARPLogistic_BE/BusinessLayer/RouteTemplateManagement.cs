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
    public class RouteTemplateManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public RouteTemplateManagement()
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

        #region RouteTemplate

        private RouteTemplate objRouteTemplate;
        private ArrayList arrRouteTemplate;

        public int EditRouteTemplate(RouteTemplate objRouteTemplate)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@RouteTemplateID", objRouteTemplate.RouteTemplateID));

                sqlListParam.Add(new SqlParameter("@Name", objRouteTemplate.Name));
                sqlListParam.Add(new SqlParameter("@Description", objRouteTemplate.Description));
                sqlListParam.Add(new SqlParameter("@Blocked", objRouteTemplate.Blocked));

                sqlListParam.Add(new SqlParameter("@RowStatus", objRouteTemplate.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objRouteTemplate.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spRouteTemplateEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveRouteTemplateActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplate WITH (NOLOCK) where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplate = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplate.Add(GenerateRouteTemplateObject(sqlDataReader));
                }
            }

            return arrRouteTemplate;
        }

        public ArrayList RetrieveRouteTemplateAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplate WITH (NOLOCK) order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplate = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplate.Add(GenerateRouteTemplateObject(sqlDataReader));
                }
            }

            return arrRouteTemplate;
        }

        public RouteTemplate RetrieveRouteTemplateByID(int intRouteTemplateID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplate WITH (NOLOCK) where RouteTemplateID = '" + intRouteTemplateID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTemplate = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTemplateObject(sqlDataReader);
                }
            }

            return new RouteTemplate();
        }

        public RouteTemplate RetrieveRouteTemplateByNo(string strRouteTemplateNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplate WITH (NOLOCK) where No = '" + strRouteTemplateNo + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrRouteTemplate = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTemplateObject(sqlDataReader);
                }
            }

            return new RouteTemplate();
        }

        public int RetrieveRouteTemplateFirstID(int intRouteTemplateID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateID from RouteTemplate WITH (NOLOCK) where RowStatus = 0 order by RouteTemplateID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateID"]);
                }
            }

            return intRouteTemplateID;
        }

        public int RetrieveRouteTemplateNextID(int intRouteTemplateID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateID from RouteTemplate WITH (NOLOCK) where RouteTemplateID > '" + intRouteTemplateID + "' and RowStatus = 0 order by RouteTemplateID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateID"]);
                }
            }
            return intRouteTemplateID;
        }

        public int RetrieveRouteTemplatePreviousID(int intRouteTemplateID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateID from RouteTemplate WITH (NOLOCK) where RouteTemplateID < '" + intRouteTemplateID + "' and RowStatus = 0 order by RouteTemplateID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateID"]);
                }
            }
            return intRouteTemplateID;
        }

        public int RetrieveRouteTemplateLastID(int intRouteTemplateID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateID from RouteTemplate WITH (NOLOCK) where RowStatus = 0 order by RouteTemplateID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateID"]);
                }
            }
            return intRouteTemplateID;
        }

        public RouteTemplate GenerateRouteTemplateObject(SqlDataReader sqlDataReader)
        {
            objRouteTemplate = new RouteTemplate();
            objRouteTemplate.RouteTemplateID = Convert.ToInt32(sqlDataReader["RouteTemplateID"]);

            objRouteTemplate.Name = sqlDataReader["Name"].ToString();
            objRouteTemplate.Description = sqlDataReader["Description"].ToString();
            objRouteTemplate.Blocked = Convert.ToByte(sqlDataReader["Blocked"]);

            objRouteTemplate.RowStatus = (short)sqlDataReader["RowStatus"];
            objRouteTemplate.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objRouteTemplate.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objRouteTemplate.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objRouteTemplate.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objRouteTemplate;
        }

        public DataTable RetrieveRouteTemplateGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select RouteTemplateID, [Name], [Description], [Blocked] FROM RouteTemplate WITH (NOLOCK) where ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spRouteTemplateList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion
    }
}
