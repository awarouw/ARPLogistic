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
    public class UserManagement
    {
        private string strError = string.Empty;
        private List<SqlParameter> sqlListParam;

        public UserManagement()
        {
        }

        #region SystemUsers

        private SystemUsers objSystemUsers;
        private ArrayList arrSystemUsers;

        public SystemUsers GenerateObject(SqlDataReader sqlDataReader)
        {
            objSystemUsers = new SystemUsers();
            objSystemUsers.SystemUsersID = Convert.ToInt32(sqlDataReader["systemusersID"]);
            objSystemUsers.UserCode = sqlDataReader["UserCode"].ToString();
            objSystemUsers.UserName = sqlDataReader["UserName"].ToString();
            objSystemUsers.UserPassword = sqlDataReader["UserPassword"].ToString();
            objSystemUsers.RowStatus = (short)sqlDataReader["RowStatus"];
            objSystemUsers.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
            {
                objSystemUsers.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            }
            objSystemUsers.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
            {
                objSystemUsers.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
            }
            objSystemUsers.DepartmentCode = sqlDataReader["DepartmentCode"].ToString();
            objSystemUsers.CompanyCode = sqlDataReader["CompanyCode"].ToString();
            objSystemUsers.CompanyName = sqlDataReader["CompanyName"].ToString();
            objSystemUsers.LocationCode = sqlDataReader["LocationCode"].ToString();

            return objSystemUsers;
        }

        public SystemUsers CekUserAuthorize(string userCode, string userPassword)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select systemusers.*, dbo.CompanyInformation.CompanyCode, dbo.CompanyInformation.CompanyName, RoleID from systemusers with (nolock) inner join [dbo].[systemuserroles] with (nolock) on systemusers.UserCode = systemuserroles.UserCode INNER JOIN dbo.CompanyInformation with (nolock) ON dbo.systemuserroles.CompanyCode = dbo.CompanyInformation.CompanyCode where systemusers.RowStatus = 0 and DefaultCompany = 1 AND systemusers.UserCode = '" + userCode + "' and systemusers.UserPassword = '" + userPassword + "'");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemUsersObject(sqlDataReader);
                    }
                }
                return new SystemUsers();
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

            finally
            {
                sqlDataReader.Close();
            }
        }

        public DataTable GetObjectMenu(string strUserName, string intParentID, string strCompanyCode)
        {
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                DataTable dt = new DataTable();

                string sqlstring = "SELECT TOP (100) PERCENT dbo.systemobject.ObjectDesc, dbo.systemobject.SystemObjectID, dbo.systemuserroles.RoleID, ";
                sqlstring += "      (SELECT COUNT(ChildID) AS Expr1 FROM dbo.systemusermenu AS smc WITH (NOLOCK) WHERE smc.CompanyCode = dbo.systempermission.CompanyCode AND smc.RoleID = dbo.systempermission.RoleID AND (ParentID = SM.ChildID)) AS nChild ";
                sqlstring += " FROM dbo.systemuserroles WITH (NOLOCK) ";
                sqlstring += "  INNER JOIN dbo.systemusermenu AS SM WITH (NOLOCK) ";
                sqlstring += "      ON dbo.systemuserroles.CompanyCode = SM.CompanyCode  ";
                sqlstring += "          AND dbo.systemuserroles.RoleID = SM.RoleID ";
                sqlstring += "  INNER JOIN dbo.systempermission WITH (NOLOCK)  ";
                sqlstring += "      ON SM.RoleID = dbo.systempermission.RoleID ";
                sqlstring += "          AND SM.ChildID = dbo.systempermission.ObjectID  ";
                sqlstring += "          AND SM.CompanyCode = dbo.systempermission.CompanyCode ";
                sqlstring += "  INNER JOIN dbo.systemobject WITH (NOLOCK)  ";
                sqlstring += "      ON dbo.systempermission.ObjectID = dbo.systemobject.SystemObjectID ";
                sqlstring += " WHERE  dbo.systemobject.RowStatus = 0  ";
                sqlstring += "  AND SM.RowStatus = 0  ";
                sqlstring += "  AND   (dbo.systemuserroles.UserCode = '" + strUserName + "')  ";
                sqlstring += "  AND (sm.ParentID = '" + intParentID + "')  ";
                sqlstring += "  AND (dbo.systemuserroles.CompanyCode = '" + strCompanyCode + "') ";
                sqlstring += " order by sm.SeqNo ";

                dt = dataAccess.RetrieveDataTable(sqlstring);

                return dt;
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new DataTable();
            }

        }

        public int EditSystemUsers(SystemUsers objSystemUsers)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemUsersID", objSystemUsers.SystemUsersID));

                sqlListParam.Add(new SqlParameter("@UserCode", objSystemUsers.UserCode));
                sqlListParam.Add(new SqlParameter("@UserName", objSystemUsers.UserName));
                sqlListParam.Add(new SqlParameter("@UserPassword", objSystemUsers.UserPassword));
                sqlListParam.Add(new SqlParameter("@AllowPostingFrom", objSystemUsers.AllowPostingFrom));
                sqlListParam.Add(new SqlParameter("@AllowPostingTo", objSystemUsers.AllowPostingTo));
                sqlListParam.Add(new SqlParameter("@RegisterTime", objSystemUsers.RegisterTime));
                sqlListParam.Add(new SqlParameter("@SalespersPurchCode", objSystemUsers.SalespersPurchCode));
                sqlListParam.Add(new SqlParameter("@ApproverID", objSystemUsers.ApproverID));
                sqlListParam.Add(new SqlParameter("@SalesAmountApprovalLimit", objSystemUsers.SalesAmountApprovalLimit));
                sqlListParam.Add(new SqlParameter("@PurchaseAmountApprovalLimit", objSystemUsers.PurchaseAmountApprovalLimit));
                sqlListParam.Add(new SqlParameter("@UnlimitedSalesApproval", objSystemUsers.UnlimitedSalesApproval));
                sqlListParam.Add(new SqlParameter("@UnlimitedPurchaseApproval", objSystemUsers.UnlimitedPurchaseApproval));
                sqlListParam.Add(new SqlParameter("@Substitute", objSystemUsers.Substitute));
                sqlListParam.Add(new SqlParameter("@EMailAddress", objSystemUsers.EMailAddress));
                sqlListParam.Add(new SqlParameter("@RequestAmountApprovalLimit", objSystemUsers.RequestAmountApprovalLimit));
                sqlListParam.Add(new SqlParameter("@UnlimitedRequestApproval", objSystemUsers.UnlimitedRequestApproval));
                sqlListParam.Add(new SqlParameter("@AllowFAPostingFrom", objSystemUsers.AllowFAPostingFrom));
                sqlListParam.Add(new SqlParameter("@AllowFAPostingTo", objSystemUsers.AllowFAPostingTo));
                sqlListParam.Add(new SqlParameter("@SalesRespCtrFilter", objSystemUsers.SalesRespCtrFilter));
                sqlListParam.Add(new SqlParameter("@PurchaseRespCtrFilter", objSystemUsers.PurchaseRespCtrFilter));
                sqlListParam.Add(new SqlParameter("@ServiceRespCtr_Filter", objSystemUsers.ServiceRespCtr_Filter));
                sqlListParam.Add(new SqlParameter("@DepartmentCode", objSystemUsers.DepartmentCode));
                sqlListParam.Add(new SqlParameter("@LocationCode", objSystemUsers.LocationCode));

                sqlListParam.Add(new SqlParameter("@RowStatus", objSystemUsers.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemUsers.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int intResult = dataAccess.ProcessData(sqlListParam, "spSystemUsersEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public int DeleteSystemUsers()
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemUsersID", objSystemUsers.SystemUsersID));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemUsers.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int intResult = dataAccess.ProcessData(sqlListParam, "spSystemUsersDelete");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveSystemUsersActive()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemUsers where RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc ");
                strError = dataAccess.Error;
                arrSystemUsers = new ArrayList();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        arrSystemUsers.Add(GenerateSystemUsersObject(sqlDataReader));
                    }
                }

                return arrSystemUsers;
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new ArrayList();
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public ArrayList RetrieveSystemUsersAll()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemUsers order by isnull(LastModifiedTime, CreatedTime) desc ");
                strError = dataAccess.Error;
                arrSystemUsers = new ArrayList();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        arrSystemUsers.Add(GenerateSystemUsersObject(sqlDataReader));
                    }
                }

                return arrSystemUsers;
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new ArrayList();
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public SystemUsers RetrieveSystemUsersByID(int intSystemUsersID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                //sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemUsers where SystemUsersID = '" + intSystemUsersID + "' and RowStatus = 0");
                sqlDataReader = dataAccess.RetrieveDataByString("Select systemusers.*, dbo.CompanyInformation.CompanyCode, dbo.CompanyInformation.CompanyName, RoleID from systemusers with (nolock) inner join [dbo].[systemuserroles] with (nolock) on systemusers.UserCode = systemuserroles.UserCode INNER JOIN dbo.CompanyInformation with (nolock) ON dbo.systemuserroles.CompanyCode = dbo.CompanyInformation.CompanyCode where DefaultCompany = 1 AND SystemUsersID = '" + intSystemUsersID + "'");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    arrSystemUsers = new ArrayList();
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemUsersObject(sqlDataReader);
                    }
                }

                return new SystemUsers();
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public SystemUsers RetrieveSystemUsersByID2(int intSystemUsersID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                //sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemUsers where SystemUsersID = '" + intSystemUsersID + "' and RowStatus = 0");
                sqlDataReader = dataAccess.RetrieveDataByString("SELECT systemusers.* FROM systemusers WHERE SystemUsersID = '" + intSystemUsersID + "'");
                //sqlDataReader = dataAccess.RetrieveDataByString("Select systemusers.*, dbo.CompanyInformation.CompanyCode, dbo.CompanyInformation.CompanyName, RoleID from systemusers with (nolock) inner join [dbo].[systemuserroles] with (nolock) on systemusers.UserCode = systemuserroles.UserCode INNER JOIN dbo.CompanyInformation with (nolock) ON dbo.systemuserroles.CompanyCode = dbo.CompanyInformation.CompanyCode where DefaultCompany = 1 AND SystemUsersID = '" + intSystemUsersID + "' AND systemusers.RowStatus =0");

                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    arrSystemUsers = new ArrayList();
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemUsersObject2(sqlDataReader);
                    }
                }

                return new SystemUsers();
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public SystemUsers RetrieveSystemUsersRetail(string userCode)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select systemusers.*, dbo.CompanyInformation.CompanyCode, dbo.CompanyInformation.CompanyName, RoleID from systemusers with (nolock) inner join [dbo].[systemuserroles] with (nolock) on systemusers.UserCode = systemuserroles.UserCode INNER JOIN dbo.CompanyInformation with (nolock) ON dbo.systemuserroles.CompanyCode = dbo.CompanyInformation.CompanyCode where systemusers.RowStatus = 0 and DefaultCompany = 1 AND systemusers.UserCode = '" + userCode + "' ");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemUsersObject(sqlDataReader);
                    }
                }
                return new SystemUsers();
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

            finally
            {
                sqlDataReader.Close();
            }
        }

        public SystemUsers RetrieveSystemUsers()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemUsers WHERE RowStatus = 0");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    arrSystemUsers = new ArrayList();
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemUsersObject(sqlDataReader);
                    }
                }

                return new SystemUsers();
            }

            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

            finally
            {
                sqlDataReader.Close();
            }


        }

        public SystemUsers GenerateSystemUsersObject(SqlDataReader sqlDataReader)
        {
            try
            {
                objSystemUsers = new SystemUsers();

                objSystemUsers.SystemUsersID = Convert.ToInt32(sqlDataReader["SystemUsersID"]);

                objSystemUsers.UserCode = sqlDataReader["UserCode"].ToString();
                objSystemUsers.UserName = sqlDataReader["UserName"].ToString();
                objSystemUsers.UserPassword = sqlDataReader["UserPassword"].ToString();
                if (sqlDataReader["AllowPostingFrom"] != null && sqlDataReader["AllowPostingFrom"].ToString() != "")
                    objSystemUsers.AllowPostingFrom = Convert.ToDateTime(sqlDataReader["AllowPostingFrom"]);
                if (sqlDataReader["AllowPostingTo"] != null && sqlDataReader["AllowPostingTo"].ToString() != "")
                    objSystemUsers.AllowPostingTo = Convert.ToDateTime(sqlDataReader["AllowPostingTo"]);
                objSystemUsers.RegisterTime = Convert.ToByte(sqlDataReader["RegisterTime"]);
                objSystemUsers.SalespersPurchCode = sqlDataReader["SalespersPurchCode"].ToString();
                objSystemUsers.ApproverID = sqlDataReader["ApproverID"].ToString();
                objSystemUsers.SalesAmountApprovalLimit = Convert.ToInt32(sqlDataReader["SalesAmountApprovalLimit"]);
                objSystemUsers.PurchaseAmountApprovalLimit = Convert.ToInt32(sqlDataReader["PurchaseAmountApprovalLimit"]);
                objSystemUsers.UnlimitedSalesApproval = Convert.ToByte(sqlDataReader["UnlimitedSalesApproval"]);
                objSystemUsers.UnlimitedPurchaseApproval = Convert.ToByte(sqlDataReader["UnlimitedPurchaseApproval"]);
                objSystemUsers.Substitute = sqlDataReader["Substitute"].ToString();
                objSystemUsers.EMailAddress = sqlDataReader["EMailAddress"].ToString();
                objSystemUsers.RequestAmountApprovalLimit = Convert.ToInt32(sqlDataReader["RequestAmountApprovalLimit"]);
                objSystemUsers.UnlimitedRequestApproval = Convert.ToByte(sqlDataReader["UnlimitedRequestApproval"]);
                if (sqlDataReader["AllowFAPostingFrom"] != null && sqlDataReader["AllowFAPostingFrom"].ToString() != "")
                    objSystemUsers.AllowFAPostingFrom = Convert.ToDateTime(sqlDataReader["AllowFAPostingFrom"]);
                if (sqlDataReader["AllowFAPostingTo"] != null && sqlDataReader["AllowFAPostingTo"].ToString() != "")
                    objSystemUsers.AllowFAPostingTo = Convert.ToDateTime(sqlDataReader["AllowFAPostingTo"]);
                objSystemUsers.SalesRespCtrFilter = sqlDataReader["SalesRespCtrFilter"].ToString();
                objSystemUsers.PurchaseRespCtrFilter = sqlDataReader["PurchaseRespCtrFilter"].ToString();
                objSystemUsers.ServiceRespCtr_Filter = sqlDataReader["ServiceRespCtr_Filter"].ToString();

                objSystemUsers.RowStatus = (short)sqlDataReader["RowStatus"];
                objSystemUsers.CreatedBy = sqlDataReader["CreatedBy"].ToString();
                if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                    objSystemUsers.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
                objSystemUsers.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
                if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                    objSystemUsers.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);

                objSystemUsers.DepartmentCode = sqlDataReader["DepartmentCode"].ToString();
                objSystemUsers.CompanyCode = sqlDataReader["CompanyCode"].ToString();
                objSystemUsers.LocationCode = sqlDataReader["LocationCode"].ToString();

                objSystemUsers.Role = sqlDataReader["RoleID"].ToString();

                return objSystemUsers;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

        }

        public SystemUsers GenerateSystemUsersObject2(SqlDataReader sqlDataReader)
        {
            try
            {
                objSystemUsers = new SystemUsers();

                objSystemUsers.SystemUsersID = Convert.ToInt32(sqlDataReader["SystemUsersID"]);

                objSystemUsers.UserCode = sqlDataReader["UserCode"].ToString();
                objSystemUsers.UserName = sqlDataReader["UserName"].ToString();
                objSystemUsers.UserPassword = sqlDataReader["UserPassword"].ToString();
                if (sqlDataReader["AllowPostingFrom"] != null && sqlDataReader["AllowPostingFrom"].ToString() != "")
                    objSystemUsers.AllowPostingFrom = Convert.ToDateTime(sqlDataReader["AllowPostingFrom"]);
                if (sqlDataReader["AllowPostingTo"] != null && sqlDataReader["AllowPostingTo"].ToString() != "")
                    objSystemUsers.AllowPostingTo = Convert.ToDateTime(sqlDataReader["AllowPostingTo"]);
                objSystemUsers.RegisterTime = Convert.ToByte(sqlDataReader["RegisterTime"]);
                objSystemUsers.SalespersPurchCode = sqlDataReader["SalespersPurchCode"].ToString();
                objSystemUsers.ApproverID = sqlDataReader["ApproverID"].ToString();
                objSystemUsers.SalesAmountApprovalLimit = Convert.ToInt32(sqlDataReader["SalesAmountApprovalLimit"]);
                objSystemUsers.PurchaseAmountApprovalLimit = Convert.ToInt32(sqlDataReader["PurchaseAmountApprovalLimit"]);
                objSystemUsers.UnlimitedSalesApproval = Convert.ToByte(sqlDataReader["UnlimitedSalesApproval"]);
                objSystemUsers.UnlimitedPurchaseApproval = Convert.ToByte(sqlDataReader["UnlimitedPurchaseApproval"]);
                objSystemUsers.Substitute = sqlDataReader["Substitute"].ToString();
                objSystemUsers.EMailAddress = sqlDataReader["EMailAddress"].ToString();
                objSystemUsers.RequestAmountApprovalLimit = Convert.ToInt32(sqlDataReader["RequestAmountApprovalLimit"]);
                objSystemUsers.UnlimitedRequestApproval = Convert.ToByte(sqlDataReader["UnlimitedRequestApproval"]);
                if (sqlDataReader["AllowFAPostingFrom"] != null && sqlDataReader["AllowFAPostingFrom"].ToString() != "")
                    objSystemUsers.AllowFAPostingFrom = Convert.ToDateTime(sqlDataReader["AllowFAPostingFrom"]);
                if (sqlDataReader["AllowFAPostingTo"] != null && sqlDataReader["AllowFAPostingTo"].ToString() != "")
                    objSystemUsers.AllowFAPostingTo = Convert.ToDateTime(sqlDataReader["AllowFAPostingTo"]);
                objSystemUsers.SalesRespCtrFilter = sqlDataReader["SalesRespCtrFilter"].ToString();
                objSystemUsers.PurchaseRespCtrFilter = sqlDataReader["PurchaseRespCtrFilter"].ToString();
                objSystemUsers.ServiceRespCtr_Filter = sqlDataReader["ServiceRespCtr_Filter"].ToString();

                objSystemUsers.RowStatus = (short)sqlDataReader["RowStatus"];
                objSystemUsers.CreatedBy = sqlDataReader["CreatedBy"].ToString();
                if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                    objSystemUsers.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
                objSystemUsers.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
                if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                    objSystemUsers.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);
                objSystemUsers.DepartmentCode = sqlDataReader["DepartmentCode"].ToString();
                objSystemUsers.LocationCode = sqlDataReader["LocationCode"].ToString();

                return objSystemUsers;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemUsers();
            }

        }

        public DataTable RetrieveSystemUsers4Grid(string strField, string strFilter)
        {
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                DataTable dt = new DataTable();
                string sqlstring = "Select [SystemUsersID] ,[UserCode] ,[UserName] ,[AllowPostingFrom] ,[AllowPostingTo] ,[SalespersPurchCode],[EMailAddress], DepartmentCode, LocationCode from SystemUsers With (NOLOCK) where  ";
                if (strFilter == "")
                    sqlstring = sqlstring + " 1 = 1 ";
                else
                    sqlstring = sqlstring + " " + strField + " like '%" + strFilter + "%' ";
                sqlstring = sqlstring + " AND RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc";
                dt = dataAccess.RetrieveDataTable(sqlstring);

                return dt;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new DataTable();
            }

        }

        public DataTable RetrieveUserToGrid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dataTable = new DataTable();
            string strQuery = "SELECT SystemUsersID AS ID, UserName AS [Full Name], UserCode AS Username,";
            strQuery += " EMailAddress AS [Email], CASE WHEN RowStatus = 0 THEN 'Active' ELSE";
            strQuery += " 'Inactive' END as Status FROM dbo.systemusers ORDER BY UserName";
            return dataAccess.RetrieveDataTable(strQuery);
        }

        public int RetrieveUserFirstID()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemUsersID from SystemUsers order by UserName");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows && sqlDataReader.Read())
                return Convert.ToInt16(sqlDataReader["SystemUsersID"]);

            return -1;
        }

        #endregion SystemUsers

        #region SystemObject

        private SystemObject objSystemObject;
        private ArrayList arrSystemObject;

        public int EditSystemObject(SystemObject systemObject)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemObjectID", objSystemObject.SystemObjectID));

                sqlListParam.Add(new SqlParameter("@ObjectType", objSystemObject.ObjectType));
                sqlListParam.Add(new SqlParameter("@ObjectDesc", objSystemObject.ObjectDesc));
                sqlListParam.Add(new SqlParameter("@ObjectSystemName", objSystemObject.ObjectSystemName));
                sqlListParam.Add(new SqlParameter("@ObjectSystemArg", objSystemObject.ObjectSystemArg));
                sqlListParam.Add(new SqlParameter("@ObjectSystemImageFileName", objSystemObject.ObjectSystemImageFileName));
                sqlListParam.Add(new SqlParameter("@ObjectSeqNo", objSystemObject.ObjectSeqNo));

                sqlListParam.Add(new SqlParameter("@RowStatus", objSystemObject.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemObject.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int intResult = dataAccess.ProcessData(sqlListParam, "spSystemObjectEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public int DeleteSystemObject()
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemObjectID", objSystemObject.SystemObjectID));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemObject.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int intResult = dataAccess.ProcessData(sqlListParam, "spSystemObjectDelete");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveSystemObjectActive()
        {
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemObject where RowStatus = 0 order by isnull(LastModifiedTime, CreatedTime) desc ");
                strError = dataAccess.Error;
                arrSystemObject = new ArrayList();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        arrSystemObject.Add(GenerateSystemObject(sqlDataReader));
                    }
                }

                return arrSystemObject;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new ArrayList();
            }

        }

        public ArrayList RetrieveSystemObjectAll()
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemObject order by isnull(LastModifiedTime, CreatedTime) desc ");
                strError = dataAccess.Error;
                arrSystemObject = new ArrayList();

                if (sqlDataReader.HasRows)
                {
                    while (sqlDataReader.Read())
                    {
                        arrSystemObject.Add(GenerateSystemObject(sqlDataReader));
                    }
                }

                return arrSystemObject;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new ArrayList();
            }

            finally
            {
                sqlDataReader.Close();
            }


        }

        public SystemObject RetrieveSystemObjectByID(string strObjectID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemObject where SystemObjectID = '" + strObjectID + "' ");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    arrSystemObject = new ArrayList();
                    while (sqlDataReader.Read())
                    {
                        return GenerateSystemObject(sqlDataReader);
                    }
                }

                return new SystemObject();
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemObject();
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public string RetrieveSystemObjectBySystemName(string strObjectSystemName)
        {
            string strID = "";
            SqlDataReader sqlDataReader = null;
            try
            {
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                sqlDataReader = dataAccess.RetrieveDataByString("Select TOP 1 SystemObjectID from SystemObject where ObjectSystemName = '" + strObjectSystemName + "' ");
                strError = dataAccess.Error;

                if (sqlDataReader.HasRows)
                {
                    arrSystemObject = new ArrayList();
                    while (sqlDataReader.Read())
                    {
                        return sqlDataReader["SystemObjectID"].ToString();
                    }
                }

                return strID;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return "";
            }

            finally
            {
                sqlDataReader.Close();
            }

        }

        public SystemObject GenerateSystemObject(SqlDataReader sqlDataReader)
        {
            try
            {
                objSystemObject = new SystemObject();

                objSystemObject.SystemObjectID = sqlDataReader["SystemObjectID"].ToString();

                objSystemObject.ObjectType = sqlDataReader["ObjectType"].ToString();
                objSystemObject.ObjectDesc = sqlDataReader["ObjectDesc"].ToString();
                objSystemObject.ObjectSystemName = sqlDataReader["ObjectSystemName"].ToString();
                objSystemObject.ObjectSystemArg = sqlDataReader["ObjectSystemArg"].ToString();
                objSystemObject.ObjectSystemImageFileName = sqlDataReader["ObjectSystemImageFileName"].ToString();
                objSystemObject.ObjectSeqNo = Convert.ToByte(sqlDataReader["ObjectSeqNo"]);

                objSystemObject.RowStatus = (short)sqlDataReader["RowStatus"];
                objSystemObject.CreatedBy = sqlDataReader["CreatedBy"].ToString();
                if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                    objSystemObject.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
                objSystemObject.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
                if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                    objSystemObject.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);

                return objSystemObject;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return new SystemObject();
            }

        }

        #endregion SystemObject

        #region SystemPermission
        private SystemPermission objSystemPermission;
        private ArrayList arrSystemPermission;

        #region IFacade Members

        public int EditSystemPermission(SystemPermission objSystemPermission)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemPermissionID", objSystemPermission.SystemPermissionID));

                sqlListParam.Add(new SqlParameter("@CompanyCode", objSystemPermission.CompanyCode));
                sqlListParam.Add(new SqlParameter("@Role", objSystemPermission.Role));
                sqlListParam.Add(new SqlParameter("@ObjectID", objSystemPermission.ObjectID));
                sqlListParam.Add(new SqlParameter("@ReadData", objSystemPermission.ReadData));
                sqlListParam.Add(new SqlParameter("@InsertData", objSystemPermission.InsertData));
                sqlListParam.Add(new SqlParameter("@ModifyData", objSystemPermission.ModifyData));
                sqlListParam.Add(new SqlParameter("@DeleteData", objSystemPermission.DeleteData));
                sqlListParam.Add(new SqlParameter("@ExecuteData", objSystemPermission.ExecuteData));
                sqlListParam.Add(new SqlParameter("@ValueData", objSystemPermission.ValueData));

                sqlListParam.Add(new SqlParameter("@RowStatus", objSystemPermission.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemPermission.CreatedBy));

                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int intResult = dataAccess.ProcessData(sqlListParam, "spSystemPermissionEdit");

                strError = dataAccess.Error;

                return intResult;

            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }

        }

        public ArrayList RetrieveSystemPermissionAll()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select * from SystemPermission Order by isnull(LastModifiedTime, CreatedTime) desc ");
            strError = dataAccess.Error;
            arrSystemPermission = new ArrayList();

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    arrSystemPermission.Add(GenerateSystemPermissionObject(sqlDataReader));
                }
            }

            return arrSystemPermission;
        }

        public SystemPermission RetrieveSystemPermissionByID(int intSystemPermissionID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from SystemPermission WITH (NOLOCK) where SystemPermissionID = '" + intSystemPermissionID + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrSystemPermission = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateSystemPermissionObject(sqlDataReader);
                }
            }

            return new SystemPermission();
        }

        public SystemPermission RetrieveSystemPermissionByUniqID(string strCompanyCode, string strRole, string strObjectID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 * from SystemPermission WITH (NOLOCK) where CompanyCode = '" + strCompanyCode + " ' AND RoleID = '" + strRole + " 'AND ObjectID = '" + strObjectID + "' AND RowStatus = 0");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrSystemPermission = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateSystemPermissionObject(sqlDataReader);
                }
            }

            return new SystemPermission();
        }

        public SystemPermission RetrieveSystemPermissionByObjectName(string strCompanyCode, string strRole, string strObjectSystemName)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 dbo.systempermission.* FROM dbo.systempermission WITH (nolock) INNER JOIN dbo.systemobject WITH (nolock) ON dbo.systempermission.ObjectID = dbo.systemobject.SystemObjectID where dbo.systempermission.CompanyCode = '" + strCompanyCode + " ' AND dbo.systempermission.RoleID = '" + strRole + " 'AND ObjectSystemName  = '" + strObjectSystemName + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                arrSystemPermission = new ArrayList();
                while (sqlDataReader.Read())
                {
                    return GenerateSystemPermissionObject(sqlDataReader);
                }
            }

            return new SystemPermission();
        }

        public int RetrieveGenJournalHeaderFirstID(int intSystemPermissionID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemPermissionID from SystemPermission WITh (NOLOCK) WHERE RowStatus = 0 order by SystemPermissionID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["SystemPermissionID"]);
                }
            }

            return intSystemPermissionID;
        }

        public int RetrieveGenJournalHeaderNextID(int intSystemPermissionID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemPermissionID from SystemPermission WITh (NOLOCK) WHERE SystemPermissionID > '" + intSystemPermissionID + "' AND RowStatus = 0 order by SystemPermissionID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["SystemPermissionID"]);
                }
            }

            return intSystemPermissionID;
        }

        public int RetrieveGenJournalHeaderPreviousID(int intSystemPermissionID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemPermissionID from SystemPermission WITh (NOLOCK) WHERE SystemPermissionID < '" + intSystemPermissionID + "' AND RowStatus = 0 order by SystemPermissionID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["SystemPermissionID"]);
                }
            }

            return intSystemPermissionID;
        }

        public int RetrieveGenJournalHeaderLastID(int intSystemPermissionID)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemPermissionID from SystemPermission WITh (NOLOCK) WHERE RowStatus = 0 order by SystemPermissionID Desc");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    return Convert.ToInt32(sqlDataReader["SystemPermissionID"]);
                }
            }

            return intSystemPermissionID;
        }

        public SystemPermission GenerateSystemPermissionObject(SqlDataReader sqlDataReader)
        {
            objSystemPermission = new SystemPermission();
            objSystemPermission.SystemPermissionID = Convert.ToInt32(sqlDataReader["SystemPermissionID"]);

            objSystemPermission.CompanyCode = sqlDataReader["CompanyCode"].ToString();
            objSystemPermission.Role = sqlDataReader["RoleID"].ToString();
            objSystemPermission.ObjectID = sqlDataReader["ObjectID"].ToString();
            objSystemPermission.ReadData = Convert.ToByte(sqlDataReader["ReadData"]);
            objSystemPermission.InsertData = Convert.ToByte(sqlDataReader["InsertData"]);
            objSystemPermission.ModifyData = Convert.ToByte(sqlDataReader["ModifyData"]);
            objSystemPermission.DeleteData = Convert.ToByte(sqlDataReader["DeleteData"]);
            objSystemPermission.ExecuteData = Convert.ToByte(sqlDataReader["ExecuteData"]);
            objSystemPermission.ValueData = Convert.ToByte(sqlDataReader["ValueData"]);

            objSystemPermission.RowStatus = (short)sqlDataReader["RowStatus"];
            objSystemPermission.CreatedBy = sqlDataReader["CreatedBy"].ToString();
            if (sqlDataReader["CreatedTime"] != null && sqlDataReader["CreatedTime"].ToString() != "")
                objSystemPermission.CreatedTime = Convert.ToDateTime(sqlDataReader["CreatedTime"]);
            objSystemPermission.LastModifiedBy = sqlDataReader["LastModifiedBy"].ToString();
            if (sqlDataReader["LastModifiedTime"] != null && sqlDataReader["LastModifiedTime"].ToString() != "")
                objSystemPermission.LastModifiedTime = Convert.ToDateTime(sqlDataReader["LastModifiedTime"]);

            return objSystemPermission;
        }

        public DataTable RetrieveSystemPermission4Grid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dt = new DataTable();

            string sqlstring = "Select [SystemPermissionID], [Code] ,[Description] FROM SystemPermission WITH (NOLOCK) where RowStatus = 0 ";
            sqlstring = sqlstring + " order by Description ";

            dt = dataAccess.RetrieveDataTable(sqlstring);

            return dt;
        }

        public DataTable RetrieveUserPermissionToGrid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dataTable = new DataTable();

            string strQuery = "SELECT SystemPermissionID, CompanyCode AS [Company Code], RoleID AS Role, ObjectDesc";
            strQuery += " AS [Object Name], CASE WHEN ReadData = 1 THEN 'Yes' ELSE 'No' END AS [Read], CASE WHEN";
            strQuery += " InsertData = 1 THEN 'Yes' ELSE 'No' END AS [Insert], CASE WHEN ModifyData = 1 THEN 'Yes' ELSE";
            strQuery += " 'No' END AS [Modify], CASE WHEN DeleteData = 1 THEN 'Yes' ELSE 'No' END AS [Delete], CASE WHEN";
            strQuery += " ExecuteData = 1 THEN 'Yes' ELSE 'No' END AS [Execute], CASE WHEN ValueData = 1 THEN 'Yes' ELSE";
            strQuery += " 'No' END AS [Value], CASE WHEN systempermission.RowStatus = 0 THEN 'Active' ELSE 'Inactive' END";
            strQuery += " AS [Status] FROM dbo.systempermission LEFT JOIN dbo.systemobject ON dbo.systempermission.ObjectID";
            strQuery += " = dbo.systemobject.SystemObjectID";


            return dataAccess.RetrieveDataTable(strQuery);
        }
        #endregion

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

        #region SystemRoles

        private SystemRoles objSystemRoles;
        public int EditSystemRoles(SystemRoles objSystemRoles)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemRolesID", objSystemRoles.SystemRolesID));
                sqlListParam.Add(new SqlParameter("@RoleID", objSystemRoles.Role));
                sqlListParam.Add(new SqlParameter("@Descriptions", objSystemRoles.Descriptions));
                sqlListParam.Add(new SqlParameter("@RowStatus", objSystemRoles.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objSystemRoles.CreatedBy));
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int result = dataAccess.ProcessData(sqlListParam, "spSystemRolesEdit");
                strError = dataAccess.Error;

                return result;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }
        }

        public DataTable RetrieveRolesToGrid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dataTable = new DataTable();
            string strQuery = "SELECT TOP 100 PERCENT dbo.systemroles.SystemRolesID, dbo.systemroles.RoleID, ";
            strQuery += "dbo.systemroles.Descriptions, CASE WHEN dbo.systemroles.RowStatus = 0 THEN";
            strQuery += " 'Active' ELSE 'Inactive' END AS Status FROM dbo.systemroles ORDER BY dbo.systemroles.SystemRolesID";
            return dataAccess.RetrieveDataTable(strQuery);
        }


        public SystemRoles RetrieveSystemRolesByID(int Id)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("SELECT * FROM [dbo].[systemroles] WHERE SystemRolesID = '" + Id + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateSystemRolesObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new SystemRoles();
        }


        public SystemRoles GenerateSystemRolesObject(SqlDataReader sqlDataReader)
        {
            objSystemRoles = new SystemRoles();

            objSystemRoles.SystemRolesID = Convert.ToInt32(sqlDataReader["SystemRolesID"].ToString());
            objSystemRoles.Role = sqlDataReader["RoleID"].ToString();
            objSystemRoles.Descriptions = sqlDataReader["Descriptions"].ToString();
            objSystemRoles.RowStatus = Convert.ToInt16(sqlDataReader["RowStatus"].ToString());

            return objSystemRoles;
        }


        public int RetrieveRolesFirstID()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemRolesID from systemroles order by SystemRolesID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows && sqlDataReader.Read())
                return Convert.ToInt16(sqlDataReader["SystemRolesID"]);

            return -1;
        }


        #endregion

        #region SystemUserRoles


        private SystemUserRoles objSystemUserRoles;
        public int EditUserRoles(SystemUserRoles objItemStyle)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();
                sqlListParam.Add(new SqlParameter("@SystemUserRolesID", objItemStyle.SystemUserRolesID));
                sqlListParam.Add(new SqlParameter("@CompanyCode", objItemStyle.CompanyCode));
                sqlListParam.Add(new SqlParameter("@UserCode", objItemStyle.UserCode));
                sqlListParam.Add(new SqlParameter("@RoleID", objItemStyle.Role));
                sqlListParam.Add(new SqlParameter("@DefaultCompany", objItemStyle.DefaultCompany));
                sqlListParam.Add(new SqlParameter("@RowStatus", objItemStyle.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", objItemStyle.CreatedBy));
                sqlListParam.Add(new SqlParameter("@LastVersion", objItemStyle.LastVersion));
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int result = dataAccess.ProcessData(sqlListParam, "spSystemUserRolesEdit");
                strError = dataAccess.Error;

                return result;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }
        }

        public DataTable RetrieveUserRolesToGrid()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            DataTable dataTable = new DataTable();

            string strQuery = "SELECT SystemUserRolesID AS ID, dbo.systemuserroles.UserCode, dbo.systemuserroles.CompanyCode,";
            strQuery += " dbo.systemuserroles.RoleID, CASE WHEN dbo.systemuserroles.DefaultCompany = 1 THEN 'Yes'";
            strQuery += " ELSE 'No' END AS [Default Company] , CASE WHEN dbo.systemuserroles.RowStatus = 0";
            strQuery += " THEN 'Active' ELSE 'Inactive' END AS [Status], LastVersion FROM dbo.systemuserroles";


            return dataAccess.RetrieveDataTable(strQuery);
        }

        public SystemUserRoles RetrieveUserRolesByID(int Id)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("SELECT * FROM [dbo].[systemuserroles] WHERE SystemUserRolesID = '" + Id + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateUserRolesObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new SystemUserRoles();
        }

        public SystemUserRoles RetrieveUserRolesByUniqID(string strCompanyCode, string strUserCode)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("SELECT * FROM [dbo].[systemuserroles] WHERE CompanyCode = '" + strCompanyCode + "' AND UserCode = '" + strUserCode + "'");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateUserRolesObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new SystemUserRoles();
        }


        public SystemUserRoles GenerateUserRolesObject(SqlDataReader sqlDataReader)
        {
            objSystemUserRoles = new SystemUserRoles();

            objSystemUserRoles.SystemUserRolesID = Convert.ToInt32(sqlDataReader["SystemUserRolesID"].ToString());
            objSystemUserRoles.CompanyCode = sqlDataReader["CompanyCode"].ToString();
            objSystemUserRoles.UserCode = sqlDataReader["UserCode"].ToString();
            objSystemUserRoles.Role = sqlDataReader["RoleID"].ToString();
            objSystemUserRoles.DefaultCompany = Convert.ToInt16(sqlDataReader["DefaultCompany"].ToString());
            objSystemUserRoles.RowStatus = Convert.ToInt16(sqlDataReader["RowStatus"].ToString());
            objSystemUserRoles.LastVersion = sqlDataReader["LastVersion"].ToString();

            return objSystemUserRoles;
        }


        public int RetrieveUserRolesFirstID()
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("Select top 1 SystemUserRolesID from systemuserroles order by SystemUserRolesID");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows && sqlDataReader.Read())
                return Convert.ToInt16(sqlDataReader["SystemUserRolesID"]);

            return -1;
        }

        #endregion

        #region SystemUserMenu

        private SystemUserMenu objSystemUserMenu;
        public int EditUserMenu(SystemUserMenu systemUserMenu)
        {
            try
            {
                sqlListParam = new List<SqlParameter>();

                sqlListParam.Add(new SqlParameter("@SystemUserMenuID", systemUserMenu.SystemUserMenuID));
                sqlListParam.Add(new SqlParameter("@CompanyCode", systemUserMenu.CompanyCode));
                sqlListParam.Add(new SqlParameter("@RoleID", systemUserMenu.Role));
                sqlListParam.Add(new SqlParameter("@ParentID", systemUserMenu.ParentID));
                sqlListParam.Add(new SqlParameter("@ChildID ", systemUserMenu.ChildID));
                sqlListParam.Add(new SqlParameter("@SeqNo", systemUserMenu.SeqNo));
                sqlListParam.Add(new SqlParameter("@RowStatus", systemUserMenu.RowStatus));
                sqlListParam.Add(new SqlParameter("@CreatedBy", systemUserMenu.CreatedBy));
                DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
                int result = dataAccess.ProcessData(sqlListParam, "spSystemUserMenuEdit");
                strError = dataAccess.Error;

                return result;
            }
            catch (Exception ex)
            {
                strError = ex.Message;
                return -1;
            }
        }

        public DataTable RetrieveUserMenuToGrid()
        {
            DataTable dataTable = new DataTable();

            string strQuery = "WITH tbParent AS( SELECT dbo.systemusermenu.SystemUserMenuID, dbo.systemusermenu.ParentID,";
            strQuery += " dbo.systemobject.ObjectDesc FROM dbo.systemusermenu INNER JOIN dbo.systemobject ON dbo.systemusermenu.ParentID";
            strQuery += " = dbo.systemobject.SystemObjectID ), tbChild AS( SELECT dbo.systemusermenu.SystemUserMenuID,";
            strQuery += " dbo.systemusermenu.ChildID, dbo.systemobject.ObjectDesc FROM dbo.systemusermenu INNER JOIN dbo.systemobject";
            strQuery += " ON dbo.systemusermenu.ChildID = dbo.systemobject.SystemObjectID) SELECT dbo.systemusermenu.SystemUserMenuID, dbo.systemusermenu.CompanyCode,";
            strQuery += " dbo.systemusermenu.ParentID, tbParent.ObjectDesc as ParentMenu, dbo.systemusermenu.ChildID,";
            strQuery += " tbChild.ObjectDesc as ChildMenu, dbo.systemusermenu.RoleID, dbo.systemusermenu.SeqNo, ";
            strQuery += "CASE WHEN dbo.systemusermenu.RowStatus = 0 THEN 'Active' ELSE 'Inactive' END AS Status FROM dbo.systemusermenu";
            strQuery += " INNER JOIN tbParent ON dbo.systemusermenu.SystemUserMenuID = tbParent.SystemUserMenuID";
            strQuery += " INNER JOIN tbChild ON dbo.systemusermenu.SystemUserMenuID = tbChild.SystemUserMenuID";
            strQuery += " ORDER BY CompanyCode ASC";
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            return dataAccess.RetrieveDataTable(strQuery);
        }


        public SystemUserMenu GenerateUserMenuObject(SqlDataReader sqlDataReader)
        {
            objSystemUserMenu = new SystemUserMenu();

            objSystemUserMenu.SystemUserMenuID = Convert.ToInt32(sqlDataReader["SystemUserMenuID"].ToString());
            objSystemUserMenu.CompanyCode = sqlDataReader["CompanyCode"].ToString();
            objSystemUserMenu.Role = sqlDataReader["RoleID"].ToString();
            objSystemUserMenu.ParentID = sqlDataReader["ParentID"].ToString();
            objSystemUserMenu.ChildID = sqlDataReader["ChildID"].ToString();
            objSystemUserMenu.SeqNo = Convert.ToInt16(sqlDataReader["SeqNo"].ToString());
            objSystemUserMenu.RowStatus = Convert.ToInt16(sqlDataReader["RowStatus"].ToString());



            return objSystemUserMenu;
        }

        public SystemUserMenu RetrieveUserMenuByID(int Id)
        {
            DataAccess dataAccess = new DataAccess(Global.AllVisions_Sys);
            SqlDataReader sqlDataReader = dataAccess.RetrieveDataByString("SELECT * FROM [dbo].[systemusermenu] WHERE SystemUserMenuID = '" + Id + "' ");
            strError = dataAccess.Error;

            if (sqlDataReader.HasRows)
            {
                while (sqlDataReader.Read())
                {
                    //if (dbSecurity.ExpireDate(sqlDataReader["SecurityCheck"].ToString()) >  DateTime.Today.AddMonths(-6) )
                    return GenerateUserMenuObject(sqlDataReader);
                    //else
                    //    return new CompanyInformation();
                }
            }

            return new SystemUserMenu();
        }
        #endregion
    }
}
