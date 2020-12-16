using ARPLogistic_BE.Entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ARPLogistic_BE.BusinessLayer
{
    public class NoSeriesManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;
        private NoSeries objNoSeries;
        private NoSeriesLine ObjNoSeriesLine;
        private string NoSeriesCode;

        public NoSeriesManagement()
        {
        }

        #region Error Message

        public string Error
        {
            get
            {
                return strError;
            }
        }

        #endregion


        public NoSeriesManagement(NoSeries noSeries)
        {
            objNoSeries = noSeries;

            //string testvalue = "010";
            //int tempValue = int.Parse(testvalue) + 1;
            //string newValue = tempValue.ToString("000");

        }

        public NoSeries RetrieveNoSeriesByID(int intNoSeriedID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from NoSeries where NoSeriedID = '" + intNoSeriedID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateNoSeriesObject(sqlDataReader);
                }
            }

            return new NoSeries();
        }

        public NoSeries RetrieveNoSeriesByCode(string strNoSeriesCode)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from NoSeries WHERE NoSeriesCode = '" + strNoSeriesCode + "' and RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateNoSeriesObject(sqlDataReader);
                }
            }

            return new NoSeries();
        }

        public NoSeries GenerateNoSeriesObject(SqlDataReader sqlDataReader)
        {
            objNoSeries = new NoSeries();
            objNoSeries.NoSeriesID = Convert.ToInt32(sqlDataReader["NoSeriesID"]);
            objNoSeries.NoSeriesCode = sqlDataReader["NoSeriesCode"].ToString();
            objNoSeries.NoSeriesDescription = sqlDataReader["NoSeriesDescription"].ToString();
            objNoSeries.NoSeriesDefaultNos = Convert.ToByte(sqlDataReader["NoSeriesDefaultNos"]);
            objNoSeries.NoSeriesManualNos = Convert.ToByte(sqlDataReader["NoSeriesManualNos"]);
            objNoSeries.NoSeriesDateOrder = Convert.ToByte(sqlDataReader["NoSeriesDateOrder"]);
            objNoSeries.DistLocationPrefix = Convert.ToByte(sqlDataReader["DistLocationPrefix"]);

            objNoSeries.RowStatus = (short)sqlDataReader["RowStatus"];
            objNoSeries.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objNoSeries.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objNoSeries.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objNoSeries.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return objNoSeries;
        }

        public int RetrieveNoSeriesFirstID(int intNoSeriesID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 NoSeriesID from NoSeries WHERE  RowStatus = 0 order by NoSeriesID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["NoSeriesID"]);
                }
            }

            return intNoSeriesID;
        }

        public int RetrieveNoSeriesNextID(int intNoSeriesID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 NoSeriesID from NoSeries WHERE NoSeriesID > '" + intNoSeriesID + "' and RowStatus = 0 order by NoSeriesID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["NoSeriesID"]);
                }
            }

            return intNoSeriesID;
        }

        public int RetrieveNoSeriesPreviousID(int intNoSeriesID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 NoSeriesID from NoSeries WHERE NoSeriesID < '" + intNoSeriesID + "' and RowStatus = 0 order by NoSeriesID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["NoSeriesID"]);
                }
            }

            return intNoSeriesID;
        }

        public int RetrieveNoSeriesLastID(int intNoSeriesID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 NoSeriesID from NoSeries WHERE RowStatus = 0 order by NoSeriesID Desc");
            strError = dataAccess.Error;


            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["NoSeriesID"]);
                }
            }

            return intNoSeriesID;
        }

        public DataTable RetrieveNoSeriesGrid(string strField, string strFilter)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select NoSeriesID, NoSeriesNo as No, Description FROM NoSeries WITH (NOLOCK) WHERE ";
            if (strFilter == "")
                sqlstring = sqlstring + " 1 = 1 ";
            else
                sqlstring = sqlstring + " " + strField + " = '" + strFilter + "' ";
            sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";

            //string sqlstring = "exec spNoSeriesList";
            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }


        public NoSeriesLine RetrieveNoSeriesLineByCode(string strNoSeriesCode)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from NoSeriesLine WHERE NoSeriesCode = '" + strNoSeriesCode + "' and RowStatus = 0 and isnull(StartingDate,getdate()) <= getdate() order by startingdate desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateNoSeriesLineObject(sqlDataReader);
                }
            }

            return new NoSeriesLine();
        }

        public NoSeriesLine GenerateNoSeriesLineObject(SqlDataReader sqlDataReader)
        {
            ObjNoSeriesLine = new NoSeriesLine();
            ObjNoSeriesLine.NoSeriesLineID = Convert.ToInt32(sqlDataReader["NoSeriesLineID"]);
            ObjNoSeriesLine.NoSeriesCode = sqlDataReader["NoSeriesCode"].ToString();
            ObjNoSeriesLine.SeqLineNo = Convert.ToInt32(sqlDataReader["SeqLineNo"]);
            if (sqlDataReader["StartingDate"] != null && sqlDataReader["StartingDate"].ToString() != "")
                ObjNoSeriesLine.StartingDate = Convert.ToDateTime(sqlDataReader["StartingDate"]);
            ObjNoSeriesLine.StartingNo = sqlDataReader["StartingNo"].ToString();
            ObjNoSeriesLine.EndingNo = sqlDataReader["EndingNo"].ToString();
            ObjNoSeriesLine.WarningNo = sqlDataReader["WarningNo"].ToString();
            ObjNoSeriesLine.IncrementbyNo = Convert.ToByte(sqlDataReader["IncrementbyNo"]);
            ObjNoSeriesLine.LastNoUsed = sqlDataReader["LastNoUsed"].ToString();
            ObjNoSeriesLine.isOpen = Convert.ToByte(sqlDataReader["isOpen"]);
            if (sqlDataReader["LastDateUsed"] != null && sqlDataReader["LastDateUsed"].ToString() != "")
                ObjNoSeriesLine.LastDateUsed = Convert.ToDateTime(sqlDataReader["LastDateUsed"]);

            ObjNoSeriesLine.RowStatus = (short)sqlDataReader["RowStatus"];
            ObjNoSeriesLine.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                ObjNoSeriesLine.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            ObjNoSeriesLine.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                ObjNoSeriesLine.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            return ObjNoSeriesLine;
        }

        public int EditNoSeriesLine()
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@NoSeriesLineID", ObjNoSeriesLine.NoSeriesLineID));

                sqlListParam.Add(new SqlParameter("@NoSeriesCode", ObjNoSeriesLine.NoSeriesCode));
                sqlListParam.Add(new SqlParameter("@SeqLineNo", ObjNoSeriesLine.SeqLineNo));
                sqlListParam.Add(new SqlParameter("@StartingDate", ObjNoSeriesLine.StartingDate));
                sqlListParam.Add(new SqlParameter("@StartingNo", ObjNoSeriesLine.StartingNo));
                sqlListParam.Add(new SqlParameter("@EndingNo", ObjNoSeriesLine.EndingNo));
                sqlListParam.Add(new SqlParameter("@WarningNo", ObjNoSeriesLine.WarningNo));
                sqlListParam.Add(new SqlParameter("@IncrementbyNo", ObjNoSeriesLine.IncrementbyNo));
                sqlListParam.Add(new SqlParameter("@LastNoUsed", ObjNoSeriesLine.LastNoUsed));
                sqlListParam.Add(new SqlParameter("@isOpen", ObjNoSeriesLine.isOpen));
                sqlListParam.Add(new SqlParameter("@LastDateUsed", ObjNoSeriesLine.LastDateUsed));

                sqlListParam.Add(new SqlParameter("@RowStatus", ObjNoSeriesLine.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", ObjNoSeriesLine.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
                int intResult = dataAccess.ProcessData(sqlListParam, "spNoSeriesLineEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public NoSeriesLine RetrieveNoSeriesLineByID(int intNoSeriesLineID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from NoSeriesLine where NoSeriesLineID = '" + intNoSeriesLineID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return GenerateNoSeriesLineObject(sqlDataReader);
                }
            }

            return new NoSeriesLine();
        }

        public DataTable RetrieveNoSeriesLineGrid(string strNoSeriesCode)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisionsCS);
            DataTable dt = new DataTable();

            string sqlstring = "Select [NoSeriesLineID],[NoSeriesCode],[SeqLineNo],[StartingDate] ,[StartingNo],[EndingNo],[LastNoUsed] FROM [dbo].[NoSeriesLine] WITH (NOLOCK) ";
            sqlstring = sqlstring + " WHERE [NoSeriesCode] = '" + strNoSeriesCode + "' order by [SeqLineNo]";

            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }


        public void InitSeries(string DefaultNoSeriesCode, string OldNoSeriesCode, DateTime? NewDate, string ManualNo, out string NewNo, out string NewNoSeriesCode)
        {
            //jika new code tidak di entry manual
            string NewNoTemp = "";
            string NewNoSeriesCodeTemp = "";

            if (ManualNo == "")
            {
                objNoSeries = RetrieveNoSeriesByCode(DefaultNoSeriesCode);
                if (objNoSeries.NoSeriesDefaultNos == 0)
                {
                    strError = "bukan default no";
                }
                if (OldNoSeriesCode != "")
                {
                    NoSeriesCode = DefaultNoSeriesCode;
                    //FilterSeries;
                    objNoSeries = RetrieveNoSeriesByCode(OldNoSeriesCode);
                    if (objNoSeries.NoSeriesID > 0)
                        objNoSeries = RetrieveNoSeriesByCode(DefaultNoSeriesCode);
                }
                NewNoTemp = GetNextNo(objNoSeries.NoSeriesCode, NewDate, true);
                NewNoSeriesCodeTemp = objNoSeries.NoSeriesCode;
            }
            else
                if (TestManual(DefaultNoSeriesCode))
            {
                NewNoTemp = ManualNo;
                NewNoSeriesCodeTemp = "";
            }

            NewNo = NewNoTemp;
            NewNoSeriesCode = NewNoSeriesCodeTemp;
        }

        public Boolean TestManual(string DefaultNoSeriesCode)
        {
            if (DefaultNoSeriesCode != "")
            {
                objNoSeries = RetrieveNoSeriesByCode(DefaultNoSeriesCode);
                if (objNoSeries.NoSeriesManualNos == 0)
                    return false;
                return true;
            }
            return false;
        }

        public string GetNextNo(string NoSeriesCode, DateTime? SeriesDate, Boolean ModifySeries)
        {
            int StartPos;
            int EndPos;
            string OldNo;
            string NewNo;
            ObjNoSeriesLine = RetrieveNoSeriesLineByCode(NoSeriesCode);
            getIntegerPos(string.IsNullOrEmpty(ObjNoSeriesLine.LastNoUsed)
                ? ObjNoSeriesLine.StartingNo
                : ObjNoSeriesLine.LastNoUsed, out StartPos, out EndPos);
            OldNo = (string.IsNullOrEmpty(ObjNoSeriesLine.LastNoUsed)
                ? ObjNoSeriesLine.StartingNo
                : ObjNoSeriesLine.LastNoUsed).Substring(StartPos - 1, EndPos - StartPos + 2);
            int NumberLength = OldNo.Length;
            NewNo = (int.Parse(OldNo) + ObjNoSeriesLine.IncrementbyNo).ToString().PadLeft(NumberLength, '0');
            NewNo = (string.IsNullOrEmpty(ObjNoSeriesLine.LastNoUsed)
                ? ObjNoSeriesLine.StartingNo
                : ObjNoSeriesLine.LastNoUsed).Replace(OldNo, NewNo);

            ObjNoSeriesLine.LastNoUsed = NewNo;
            ObjNoSeriesLine.LastDateUsed = DateTime.Now;

            EditNoSeriesLine();

            return NewNo;
        }

        public void getIntegerPos(string NoSeries, out int StartPos, out int EndPos)
        {
            StartPos = 0;
            EndPos = 0;
            int[] arr = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            if (NoSeries != "")
            {
                for (int i = 0; i < NoSeries.Length; i++)
                {
                    foreach (int value in arr)
                    {
                        if (NoSeries[i].ToString() == value.ToString())
                        {
                            if (StartPos == 0)
                                StartPos = i + 1;
                            EndPos = i;
                        }
                    }
                }
            }
        }

        public string SetDefaultSeries(string NoSeriesCode)
        {
            NoSeries noSeries = RetrieveNoSeriesByCode(NoSeriesCode);
            if (noSeries.NoSeriesDefaultNos == 1)
                return noSeries.NoSeriesCode;
            else
                return "";
        }


    }

}
