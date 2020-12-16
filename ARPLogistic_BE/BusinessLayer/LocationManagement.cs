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
    public class LocationManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public LocationManagement()
        {
        }

        #region Locations

        private Locations objLocations;
        private ArrayList arrLocations;

        public int EditLocations(Locations objLocations)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@LocationID", objLocations.LocationID));

                sqlListParam.Add(new SqlParameter("@LocationCode", objLocations.LocationCode));
                sqlListParam.Add(new SqlParameter("@LocationName", objLocations.LocationName));
                sqlListParam.Add(new SqlParameter("@Name2", objLocations.Name2));
                sqlListParam.Add(new SqlParameter("@Address", objLocations.Address));
                sqlListParam.Add(new SqlParameter("@Address2", objLocations.Address2));
                sqlListParam.Add(new SqlParameter("@City", objLocations.City));
                sqlListParam.Add(new SqlParameter("@PhoneNo", objLocations.PhoneNo));
                sqlListParam.Add(new SqlParameter("@PhoneNo2", objLocations.PhoneNo2));
                sqlListParam.Add(new SqlParameter("@FaxNo", objLocations.FaxNo));
                sqlListParam.Add(new SqlParameter("@Contact", objLocations.Contact));
                sqlListParam.Add(new SqlParameter("@PostCode", objLocations.PostCode));
                sqlListParam.Add(new SqlParameter("@EMail", objLocations.EMail));
                sqlListParam.Add(new SqlParameter("@HomePage", objLocations.HomePage));
                sqlListParam.Add(new SqlParameter("@CountryRegionCode", objLocations.CountryRegionCode));
                sqlListParam.Add(new SqlParameter("@UseAsInTransit", objLocations.UseAsInTransit));
                sqlListParam.Add(new SqlParameter("@RequirePutaway", objLocations.RequirePutaway));
                sqlListParam.Add(new SqlParameter("@RequirePick", objLocations.RequirePick));
                sqlListParam.Add(new SqlParameter("@CrossDockDueDateCalc", objLocations.CrossDockDueDateCalc));
                sqlListParam.Add(new SqlParameter("@UseCrossDocking", objLocations.UseCrossDocking));
                sqlListParam.Add(new SqlParameter("@RequireReceive", objLocations.RequireReceive));
                sqlListParam.Add(new SqlParameter("@RequireShipment", objLocations.RequireShipment));
                sqlListParam.Add(new SqlParameter("@BinMandatory", objLocations.BinMandatory));
                sqlListParam.Add(new SqlParameter("@DirectedPutawayandPick", objLocations.DirectedPutawayandPick));
                sqlListParam.Add(new SqlParameter("@DefaultBinSelection", objLocations.DefaultBinSelection));
                sqlListParam.Add(new SqlParameter("@OutboundWhseHandlingTime", objLocations.OutboundWhseHandlingTime));
                sqlListParam.Add(new SqlParameter("@InboundWhseHandlingTime", objLocations.InboundWhseHandlingTime));
                sqlListParam.Add(new SqlParameter("@PutawayTemplateCode", objLocations.PutawayTemplateCode));
                sqlListParam.Add(new SqlParameter("@UsePutawayWorksheet", objLocations.UsePutawayWorksheet));
                sqlListParam.Add(new SqlParameter("@PickAccordingtoFEFO", objLocations.PickAccordingtoFEFO));
                sqlListParam.Add(new SqlParameter("@AllowBreakbulk", objLocations.AllowBreakbulk));
                sqlListParam.Add(new SqlParameter("@BinCapacityPolicy", objLocations.BinCapacityPolicy));
                sqlListParam.Add(new SqlParameter("@OpenShopFloorBinCode", objLocations.OpenShopFloorBinCode));
                sqlListParam.Add(new SqlParameter("@InboundProductionBinCode", objLocations.InboundProductionBinCode));
                sqlListParam.Add(new SqlParameter("@OutboundProductionBinCode", objLocations.OutboundProductionBinCode));
                sqlListParam.Add(new SqlParameter("@AdjustmentBinCode", objLocations.AdjustmentBinCode));
                sqlListParam.Add(new SqlParameter("@AlwaysCreatePutawayLine", objLocations.AlwaysCreatePutawayLine));
                sqlListParam.Add(new SqlParameter("@AlwaysCreatePickLine", objLocations.AlwaysCreatePickLine));
                sqlListParam.Add(new SqlParameter("@SpecialEquipment", objLocations.SpecialEquipment));
                sqlListParam.Add(new SqlParameter("@ReceiptBinCode", objLocations.ReceiptBinCode));
                sqlListParam.Add(new SqlParameter("@ShipmentBinCode", objLocations.ShipmentBinCode));
                sqlListParam.Add(new SqlParameter("@CrossDockBinCode", objLocations.CrossDockBinCode));
                sqlListParam.Add(new SqlParameter("@OutboundBOMBinCode", objLocations.OutboundBOMBinCode));
                sqlListParam.Add(new SqlParameter("@InboundBOMBinCode", objLocations.InboundBOMBinCode));
                sqlListParam.Add(new SqlParameter("@BaseCalendarCode", objLocations.BaseCalendarCode));
                sqlListParam.Add(new SqlParameter("@UseADCS", objLocations.UseADCS));

                sqlListParam.Add(new SqlParameter("@RowStatus", objLocations.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objLocations.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spLocationsEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveLocationsActive(int intActive)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Locations where RowStatus = " + intActive + "  order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrLocations = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrLocations.Add(GenerateLocationsObject(sqlDataReader));
                }
            }

            return arrLocations;
        }

        public ArrayList RetrieveLocationsAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Locations Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrLocations = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrLocations.Add(GenerateLocationsObject(sqlDataReader));
                }
            }

            return arrLocations;
        }

        public Locations RetrieveLocationsByID(int intLocationID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Locations where LocationID = '" + intLocationID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrLocations = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateLocationsObject(sqlDataReader);
                }
            }

            return new Locations();
        }

        public Locations RetrieveLocationsByCode(string strLocation)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from Locations WHERE LocationCode = '" + strLocation + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrLocations = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateLocationsObject(sqlDataReader);
                }
            }

            return new Locations();
        }

        public int RetrieveLocationsNextID(int intLocationsID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from Locations WHERE LocationID > '" + intLocationsID + "' and RowStatus = 0 order by LocationID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrLocations = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["LocationID"]);
                }
            }

            return intLocationsID;
        }

        public int RetrieveLocationsPreviousID(int intLocationsID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from Locations WHERE LocationID < '" + intLocationsID + "' and RowStatus = 0 order by LocationID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                arrLocations = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["LocationID"]);
                }
            }

            return intLocationsID;
        }

        public Locations GenerateLocationsObject(SqlDataReader sqlDataReader)
        {
            objLocations = new Locations();
            objLocations.LocationID = Convert.ToInt32(sqlDataReader["LocationID"]);

            objLocations.LocationCode = sqlDataReader["LocationCode"].ToString();
            objLocations.LocationName = sqlDataReader["LocationName"].ToString();
            objLocations.Name2 = sqlDataReader["Name2"].ToString();
            objLocations.Address = sqlDataReader["Address"].ToString();
            objLocations.Address2 = sqlDataReader["Address2"].ToString();
            objLocations.City = sqlDataReader["City"].ToString();
            objLocations.PhoneNo = sqlDataReader["PhoneNo"].ToString();
            objLocations.PhoneNo2 = sqlDataReader["PhoneNo2"].ToString();
            objLocations.FaxNo = sqlDataReader["FaxNo"].ToString();
            objLocations.Contact = sqlDataReader["Contact"].ToString();
            objLocations.PostCode = sqlDataReader["PostCode"].ToString();
            objLocations.EMail = sqlDataReader["EMail"].ToString();
            objLocations.HomePage = sqlDataReader["HomePage"].ToString();
            objLocations.CountryRegionCode = sqlDataReader["CountryRegionCode"].ToString();
            objLocations.UseAsInTransit = Convert.ToByte(sqlDataReader["UseAsInTransit"]);
            objLocations.RequirePutaway = Convert.ToByte(sqlDataReader["RequirePutaway"]);
            objLocations.RequirePick = Convert.ToByte(sqlDataReader["RequirePick"]);
            objLocations.CrossDockDueDateCalc = sqlDataReader["CrossDockDueDateCalc"].ToString();
            objLocations.UseCrossDocking = Convert.ToByte(sqlDataReader["UseCrossDocking"]);
            objLocations.RequireReceive = Convert.ToByte(sqlDataReader["RequireReceive"]);
            objLocations.RequireShipment = Convert.ToByte(sqlDataReader["RequireShipment"]);
            objLocations.BinMandatory = Convert.ToByte(sqlDataReader["BinMandatory"]);
            objLocations.DirectedPutawayandPick = Convert.ToByte(sqlDataReader["DirectedPutawayandPick"]);
            objLocations.DefaultBinSelection = Convert.ToInt32(sqlDataReader["DefaultBinSelection"]);
            objLocations.OutboundWhseHandlingTime = sqlDataReader["OutboundWhseHandlingTime"].ToString();
            objLocations.InboundWhseHandlingTime = sqlDataReader["InboundWhseHandlingTime"].ToString();
            objLocations.PutawayTemplateCode = sqlDataReader["PutawayTemplateCode"].ToString();
            objLocations.UsePutawayWorksheet = Convert.ToByte(sqlDataReader["UsePutawayWorksheet"]);
            objLocations.PickAccordingtoFEFO = Convert.ToByte(sqlDataReader["PickAccordingtoFEFO"]);
            objLocations.AllowBreakbulk = Convert.ToByte(sqlDataReader["AllowBreakbulk"]);
            objLocations.BinCapacityPolicy = Convert.ToInt32(sqlDataReader["BinCapacityPolicy"]);
            objLocations.OpenShopFloorBinCode = sqlDataReader["OpenShopFloorBinCode"].ToString();
            objLocations.InboundProductionBinCode = sqlDataReader["InboundProductionBinCode"].ToString();
            objLocations.OutboundProductionBinCode = sqlDataReader["OutboundProductionBinCode"].ToString();
            objLocations.AdjustmentBinCode = sqlDataReader["AdjustmentBinCode"].ToString();
            objLocations.AlwaysCreatePutawayLine = Convert.ToByte(sqlDataReader["AlwaysCreatePutawayLine"]);
            objLocations.AlwaysCreatePickLine = Convert.ToByte(sqlDataReader["AlwaysCreatePickLine"]);
            objLocations.SpecialEquipment = Convert.ToInt32(sqlDataReader["SpecialEquipment"]);
            objLocations.ReceiptBinCode = sqlDataReader["ReceiptBinCode"].ToString();
            objLocations.ShipmentBinCode = sqlDataReader["ShipmentBinCode"].ToString();
            objLocations.CrossDockBinCode = sqlDataReader["CrossDockBinCode"].ToString();
            objLocations.OutboundBOMBinCode = sqlDataReader["OutboundBOMBinCode"].ToString();
            objLocations.InboundBOMBinCode = sqlDataReader["InboundBOMBinCode"].ToString();
            objLocations.BaseCalendarCode = sqlDataReader["BaseCalendarCode"].ToString();
            objLocations.UseADCS = Convert.ToByte(sqlDataReader["UseADCS"]);

            objLocations.RowStatus = Convert.ToByte(sqlDataReader["RowStatus"]);
            objLocations.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objLocations.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objLocations.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objLocations.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objLocations;
        }

        public DataTable RetrieveLocationsGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select LocationID, LocationCode, LocationName, Address, City, PhoneNo, FaxNo, EMail FROM Locations WITH (NOLOCK) WHERE ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spLocationsList";
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
