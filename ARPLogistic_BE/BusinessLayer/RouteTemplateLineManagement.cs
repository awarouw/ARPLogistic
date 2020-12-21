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
    public class RouteTemplateLineManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        private RouteTemplateLine objRouteTemplateLine;
        private ArrayList arrRouteTemplateLine;

        public RouteTemplateLineManagement()
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


        #region RouteTemplateLine

        public int EditRouteTemplateLine(RouteTemplateLine objRouteTemplateLine)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@RouteTemplateLineID", objRouteTemplateLine.RouteTemplateLineID));
                sqlListParam.Add(new SqlParameter("@RouteTemplateID", objRouteTemplateLine.RouteTemplateID));
                sqlListParam.Add(new SqlParameter("@RouteTemplateCode", objRouteTemplateLine.RouteTemplateCode));

                sqlListParam.Add(new SqlParameter("@RouteTemplateCode", objRouteTemplateLine.RouteTemplateCode));
                sqlListParam.Add(new SqlParameter("@SeqLineNo", objRouteTemplateLine.SeqLineNo));
                sqlListParam.Add(new SqlParameter("@TransferFromCode", objRouteTemplateLine.TransferFromCode));
                sqlListParam.Add(new SqlParameter("@TransferToCode", objRouteTemplateLine.TransferToCode));
                sqlListParam.Add(new SqlParameter("@JarakTempuh", objRouteTemplateLine.JarakTempuh));
                sqlListParam.Add(new SqlParameter("@BiayaToll", objRouteTemplateLine.BiayaToll));
                sqlListParam.Add(new SqlParameter("@BiayaBBM", objRouteTemplateLine.BiayaBBM));
                sqlListParam.Add(new SqlParameter("@Retribusi", objRouteTemplateLine.Retribusi));
                sqlListParam.Add(new SqlParameter("@BiayaLainLain", objRouteTemplateLine.BiayaLainLain));

                sqlListParam.Add(new SqlParameter("@RowStatus", objRouteTemplateLine.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objRouteTemplateLine.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spRouteTemplateLineEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveRouteTemplateLineActive()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) WHERE RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplateLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplateLine.Add(GenerateRouteTemplateLineObject(sqlDataReader));
                }
            }

            return arrRouteTemplateLine;
        }

        public ArrayList RetrieveRouteTemplateLineAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplateLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplateLine.Add(GenerateRouteTemplateLineObject(sqlDataReader));
                }
            }

            return arrRouteTemplateLine;
        }

        public ArrayList RetrieveRouteTemplateLineByHeaderID(int RouteTemplateid)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) Where RouteTemplateid = " + RouteTemplateid + " Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplateLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplateLine.Add(GenerateRouteTemplateLineObject(sqlDataReader));
                }
            }

            return arrRouteTemplateLine;
        }

        public ArrayList RetrieveRouteTemplateLineByDocTypeNoandQty(RouteTemplateLine RouteTemplateLine, int intDocumentType, string DocumentNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) WHERE DocumentType = " + intDocumentType + " AND DocumentNo = '" + DocumentNo + "' AND Quantity <> 0 order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrRouteTemplateLine = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrRouteTemplateLine.Add(GenerateRouteTemplateLineObject(sqlDataReader));
                }
            }

            return arrRouteTemplateLine;
        }

        public RouteTemplateLine RetrieveRouteTemplateLineByUniqueID(RouteTemplateLine RouteTemplateLine, string DocumentNo, int SeqLineNo, int intDocumentType)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) WHERE DocumentNo = '" + DocumentNo + "' AND DocumentType = " + intDocumentType + " AND SeqLineNo = '" + SeqLineNo + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTemplateLineObject(sqlDataReader);
                }
            }

            return RouteTemplateLine;
        }

        public RouteTemplateLine RetrieveRouteTemplateLineByID(RouteTemplateLine RouteTemplateLine, int intRouteTemplateLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from RouteTemplateLine WITh (NOLOCK) WHERE RouteTemplateLineID = '" + intRouteTemplateLineID + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateRouteTemplateLineObject(sqlDataReader);
                }
            }

            return RouteTemplateLine;
        }

        public DataTable RetrieveRouteTemplateLineByHeaderID4Grid(int RouteTemplateid, DataTable dt)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            string sqlstring = "SELECT  RouteTemplateLineID, DocumentNo, SeqLineNo, RecordType, RecordNo, Description, Quantity, UnitofMeasure as UOM, UnitPrice, LineDiscountPercent as [Disc%], LineDiscountAmount as DiscValue, Amount as Amount, VATPercent Tax, AmountIncludingVAT as TAmount " +
                            " FROM [dbo].[RouteTemplateLine] WITh (NOLOCK) where RouteTemplateid = " + RouteTemplateid + " and RowStatus = 0";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        public int RetrieveRouteTemplateLinesFirstID(int intRouteTemplateLineID, int intDocumentType)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateLineID from RouteTemplateLine WITh (NOLOCK) WHERE DocumentType = " + intDocumentType + " AND RowStatus = 0 order by RouteTemplateLineID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateLineID"]);
                }
            }

            return intRouteTemplateLineID;
        }

        public int RetrieveRouteTemplateLinesNextID(int intRouteTemplateLineID, int intDocumentType)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateLineID from RouteTemplateLine WITh (NOLOCK) WHERE RouteTemplateLineID > '" + intRouteTemplateLineID + "' AND DocumentType = " + intDocumentType + " AND RowStatus = 0 order by RouteTemplateLineID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateLineID"]);
                }
            }

            return intRouteTemplateLineID;
        }

        public int RetrieveRouteTemplateLinesPreviousID(int intRouteTemplateLineID, int intDocumentType)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateLineID from RouteTemplateLine WITh (NOLOCK) WHERE RouteTemplateLineID < '" + intRouteTemplateLineID + "' AND DocumentType = " + intDocumentType + " AND RowStatus = 0 order by RouteTemplateLineID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateLineID"]);
                }
            }

            return intRouteTemplateLineID;
        }

        public int RetrieveRouteTemplateLinesLastID(int intRouteTemplateLineID, int intDocumentType)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 RouteTemplateLineID from RouteTemplateLine WITh (NOLOCK) WHERE DocumentType = " + intDocumentType + " AND RowStatus = 0 order by RouteTemplateLineID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["RouteTemplateLineID"]);
                }
            }

            return intRouteTemplateLineID;
        }

        public int getLastLineNo(RouteTemplateLine RouteTemplateLine)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select IsNull(Max(SeqLineNo),0) as SeqLineNo from RouteTemplateLine WITh (NOLOCK) WHERE RouteTemplateID = " + RouteTemplateLine.RouteTemplateID + " AND RowStatus = 0 order by SeqLineNo Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["SeqLineNo"]);
                }
            }

            return 0;
        }

        public RouteTemplateLine GenerateRouteTemplateLineObject(SqlDataReader sqlDataReader)
        {
            objRouteTemplateLine = new RouteTemplateLine();
            objRouteTemplateLine.RouteTemplateLineID = Convert.ToInt32(sqlDataReader["RouteTemplateLineID"]);
            objRouteTemplateLine.RouteTemplateID = Convert.ToInt32(sqlDataReader["RouteTemplateID"]);
            objRouteTemplateLine.RouteTemplateCode = sqlDataReader["RouteTemplateCode"].ToString();

            objRouteTemplateLine.RouteTemplateCode = sqlDataReader["RouteTemplateCode"].ToString();
            objRouteTemplateLine.SeqLineNo = Convert.ToInt32(sqlDataReader["SeqLineNo"]);
            objRouteTemplateLine.TransferFromCode = sqlDataReader["TransferFromCode"].ToString();
            objRouteTemplateLine.TransferToCode = sqlDataReader["TransferToCode"].ToString();
            objRouteTemplateLine.JarakTempuh = Convert.ToDecimal(sqlDataReader["JarakTempuh"]);
            objRouteTemplateLine.BiayaToll = Convert.ToDecimal(sqlDataReader["BiayaToll"]);
            objRouteTemplateLine.BiayaBBM = Convert.ToDecimal(sqlDataReader["BiayaBBM"]);
            objRouteTemplateLine.Retribusi = Convert.ToDecimal(sqlDataReader["Retribusi"]);
            objRouteTemplateLine.BiayaLainLain = Convert.ToDecimal(sqlDataReader["BiayaLainLain"]);

            objRouteTemplateLine.RowStatus = (short)sqlDataReader["RowStatus"];
            objRouteTemplateLine.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objRouteTemplateLine.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objRouteTemplateLine.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objRouteTemplateLine.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objRouteTemplateLine;
        }

        #endregion

    }
}
