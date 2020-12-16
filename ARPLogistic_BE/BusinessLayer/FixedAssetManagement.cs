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
    public class FixedAssetManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public FixedAssetManagement()
        {
        }

        public string Error
        {
            get
            {
                return strError;
            }
        }


        #region FixedAsset

        private FixedAsset objFixedAsset;
        private ArrayList arrFixedAsset;

        public int EditFixedAsset(FixedAsset objFixedAsset)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@FixedAssetID", objFixedAsset.FixedAssetID));

                sqlListParam.Add(new SqlParameter("@No", objFixedAsset.No));
                sqlListParam.Add(new SqlParameter("@Description", objFixedAsset.Description));
                sqlListParam.Add(new SqlParameter("@SearchDescription", objFixedAsset.SearchDescription));
                sqlListParam.Add(new SqlParameter("@Description2", objFixedAsset.Description2));
                sqlListParam.Add(new SqlParameter("@FAClassCode", objFixedAsset.FAClassCode));
                sqlListParam.Add(new SqlParameter("@FASubclassCode", objFixedAsset.FASubclassCode));
                sqlListParam.Add(new SqlParameter("@GlobalDimension1Code", objFixedAsset.GlobalDimension1Code));
                sqlListParam.Add(new SqlParameter("@GlobalDimension2Code", objFixedAsset.GlobalDimension2Code));
                sqlListParam.Add(new SqlParameter("@LocationCode", objFixedAsset.LocationCode));
                sqlListParam.Add(new SqlParameter("@FALocationCode", objFixedAsset.FALocationCode));
                sqlListParam.Add(new SqlParameter("@VendorNo", objFixedAsset.VendorNo));
                sqlListParam.Add(new SqlParameter("@MainAssetComponent", objFixedAsset.MainAssetComponent));
                sqlListParam.Add(new SqlParameter("@ComponentofMainAsset", objFixedAsset.ComponentofMainAsset));
                sqlListParam.Add(new SqlParameter("@BudgetedAsset", objFixedAsset.BudgetedAsset));
                sqlListParam.Add(new SqlParameter("@WarrantyDate", objFixedAsset.WarrantyDate));
                sqlListParam.Add(new SqlParameter("@ResponsibleEmployee", objFixedAsset.ResponsibleEmployee));
                sqlListParam.Add(new SqlParameter("@SerialNo", objFixedAsset.SerialNo));
                sqlListParam.Add(new SqlParameter("@Blocked", objFixedAsset.Blocked));
                sqlListParam.Add(new SqlParameter("@FileNamePicture", objFixedAsset.FileNamePicture));
                sqlListParam.Add(new SqlParameter("@MaintenanceVendorNo", objFixedAsset.MaintenanceVendorNo));
                sqlListParam.Add(new SqlParameter("@UnderMaintenance", objFixedAsset.UnderMaintenance));
                sqlListParam.Add(new SqlParameter("@NextServiceDate", objFixedAsset.NextServiceDate));
                sqlListParam.Add(new SqlParameter("@NoSeries", objFixedAsset.NoSeries));
                sqlListParam.Add(new SqlParameter("@FAPostingGroup", objFixedAsset.FAPostingGroup));

                sqlListParam.Add(new SqlParameter("@RowStatus", objFixedAsset.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objFixedAsset.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spFixedAssetEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveFixedAssetActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from FixedAsset where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrFixedAsset = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrFixedAsset.Add(GenerateFixedAssetObject(sqlDataReader));
                }
            }

            return arrFixedAsset;
        }

        public ArrayList RetrieveFixedAssetAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from FixedAsset Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrFixedAsset = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrFixedAsset.Add(GenerateFixedAssetObject(sqlDataReader));
                }
            }

            return arrFixedAsset;
        }

        public FixedAsset RetrieveFixedAssetByID(int intFixedAssetID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from FixedAsset where FixedAssetID = '" + intFixedAssetID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrFixedAsset = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateFixedAssetObject(sqlDataReader);
                }
            }

            return new FixedAsset();
        }

        public FixedAsset RetrieveFixedAssetByNo(string strFixedAssetNo)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from FixedAsset where No = '" + strFixedAssetNo + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateFixedAssetObject(sqlDataReader);
                }
            }

            return new FixedAsset();
        }

        public int RetrieveFixedAssetFirstID(int intFixedAssetID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 FixedAssetID from FixedAsset where RowStatus = 0 order by FixedAssetID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["FixedAssetID"]);
                }
            }

            return intFixedAssetID;
        }

        public int RetrieveFixedAssetNextID(int intFixedAssetID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 FixedAssetID from FixedAsset where FixedAssetID > '" + intFixedAssetID + "' and RowStatus = 0 order by FixedAssetID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["FixedAssetID"]);
                }
            }
            return intFixedAssetID;
        }

        public int RetrieveFixedAssetPreviousID(int intFixedAssetID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 FixedAssetID from FixedAsset where FixedAssetID < '" + intFixedAssetID + "' and RowStatus = 0 order by FixedAssetID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {

                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["FixedAssetID"]);
                }
            }
            return intFixedAssetID;
        }

        public int RetrieveFixedAssetLastID(int intFixedAssetID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 FixedAssetID from FixedAsset where RowStatus = 0 order by FixedAssetID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["FixedAssetID"]);
                }
            }
            return intFixedAssetID;
        }

        public FixedAsset GenerateFixedAssetObject(SqlDataReader sqlDataReader)
        {
            objFixedAsset = new FixedAsset();
            objFixedAsset.FixedAssetID = Convert.ToInt32(sqlDataReader["FixedAssetID"]);

            objFixedAsset.No = sqlDataReader["No"].ToString();
            objFixedAsset.Description = sqlDataReader["Description"].ToString();
            objFixedAsset.SearchDescription = sqlDataReader["SearchDescription"].ToString();
            objFixedAsset.Description2 = sqlDataReader["Description2"].ToString();
            objFixedAsset.FAClassCode = sqlDataReader["FAClassCode"].ToString();
            objFixedAsset.FASubclassCode = sqlDataReader["FASubclassCode"].ToString();
            objFixedAsset.GlobalDimension1Code = sqlDataReader["GlobalDimension1Code"].ToString();
            objFixedAsset.GlobalDimension2Code = sqlDataReader["GlobalDimension2Code"].ToString();
            objFixedAsset.LocationCode = sqlDataReader["LocationCode"].ToString();
            objFixedAsset.FALocationCode = sqlDataReader["FALocationCode"].ToString();
            objFixedAsset.VendorNo = sqlDataReader["VendorNo"].ToString();
            objFixedAsset.MainAssetComponent = Convert.ToInt32(sqlDataReader["MainAssetComponent"]);
            objFixedAsset.ComponentofMainAsset = sqlDataReader["ComponentofMainAsset"].ToString();
            objFixedAsset.BudgetedAsset = Convert.ToByte(sqlDataReader["BudgetedAsset"]);
            objFixedAsset.WarrantyDate = Convert.ToDateTime(sqlDataReader["WarrantyDate"]);
            objFixedAsset.ResponsibleEmployee = sqlDataReader["ResponsibleEmployee"].ToString();
            objFixedAsset.SerialNo = sqlDataReader["SerialNo"].ToString();
            objFixedAsset.Blocked = Convert.ToByte(sqlDataReader["Blocked"]);
            objFixedAsset.FileNamePicture = sqlDataReader["FileNamePicture"].ToString();
            objFixedAsset.MaintenanceVendorNo = sqlDataReader["MaintenanceVendorNo"].ToString();
            objFixedAsset.UnderMaintenance = Convert.ToByte(sqlDataReader["UnderMaintenance"]);
            objFixedAsset.NextServiceDate = Convert.ToDateTime(sqlDataReader["NextServiceDate"]);
            objFixedAsset.NoSeries = sqlDataReader["NoSeries"].ToString();
            objFixedAsset.FAPostingGroup = sqlDataReader["FAPostingGroup"].ToString();

            objFixedAsset.RowStatus = (short)sqlDataReader["RowStatus"];
            objFixedAsset.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objFixedAsset.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objFixedAsset.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objFixedAsset.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objFixedAsset;
        }

        public DataTable RetrieveFixedAssetGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);

            string sqlstring = "Select FixedAssetID, No, Description FROM FixedAsset WITH (NOLOCK) where ";
            if (strFilter == "")
                sqlstring += " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring += " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spFixedAssetList";
            DataTable dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        #endregion
    }

}
