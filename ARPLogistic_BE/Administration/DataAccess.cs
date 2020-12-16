using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Configuration;

namespace ARPLogistic_BE
{
    public class DataAccess : DbConnection
    {
        public DataAccess(string strConnection)
            : base(strConnection)
        {

        }

        public void OpenConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();

            sqlConnection.Open();
        }

        public int ProcessData(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                sqlConnection.Open();
                BuildParameter(sqlParam, spName);
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string ProcessDataWithNonQuery(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                sqlConnection.Open();
                BuildParameter(sqlParam, spName);
                sqlCommand.ExecuteReader();
                return string.Empty;
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }

        public string ProcessDataWithQueryParameter(string strQuery)
        {
            try
            {
                string sqlBatch = string.Empty;
                sqlConnection.Open();
                foreach (string line in strQuery.Split(new string[3] { "\n", "\r", "\t" }, StringSplitOptions.RemoveEmptyEntries))
                {
                    if (line.ToUpperInvariant().Trim() == "GO")
                    {
                        //sqlCommand.CommandText = sqlBatch;
                        BuildQueryParameter(sqlBatch);
                        sqlCommand.ExecuteNonQuery();
                        sqlBatch = string.Empty;
                    }
                    else
                    {
                        sqlBatch += line + " ";
                    }
                }

                //sqlCommand.ExecuteNonQuery();
                return string.Empty;
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return ex.Message;
            }
            finally
            {
                CloseConnection();
            }
        }

        public int ProcessDatas(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                BuildParameter(sqlParam, spName);
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return -1;
            }
        }

        public int ProcessDataReturnID(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                sqlConnection.Open();
                BuildParameter(sqlParam, spName);
                return (int)sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public object RetrieveDataReturnValue(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                sqlConnection.Open();
                BuildParameter(sqlParam, spName);
                return sqlCommand.ExecuteScalar();
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                return -1;
            }
            finally
            {
                CloseConnection();
            }
        }

        public SqlDataReader RetrieveDataByParameter(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                if (sqlConnection.State == ConnectionState.Open)
                    CloseConnection();
                sqlConnection.Open();
                BuildParameter(sqlParam, spName);
                return sqlCommand.ExecuteReader();
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                SqlDataReader sqlDataReader = null;
                return sqlDataReader;
            }
        }

        public IEnumerable<IDataRecord> RetriveDataRecord(string strQuery)
        {
            using (sqlConnection)
            using (SqlCommand cmd = new SqlCommand(strQuery, sqlConnection))
            {
                sqlConnection.Open();

                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        yield return reader;
                    }
                    yield return null;
                }
            }
        }

        //    public SqlDataReader RetrieveDataByString(string strQuery)
        //    {
        //        IEnumerable<IDataRecord> reader = RetriveDataRecord(strQuery);
        //        return reader;
        //}

        //public SqlDataReader RetrieveDataByString(string strQuery)
        //{
        //    using (sqlConnection)
        //    {
        //        SqlCommand command = new SqlCommand(strQuery,
        //          sqlConnection);
        //        sqlConnection.Open();

        //        SqlDataReader reader = command.ExecuteReader();

        //        if (reader.HasRows)
        //        {
        //            while (reader.Read())
        //            {
        //                return reader;
        //            }
        //        }
        //        else
        //        {
        //            Console.WriteLine("No rows found.");
        //        }
        //        reader.Close();
        //    }

        //    return null;
        //}

        public SqlDataReader RetrieveDataByString(string strQuery)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                try
                {
                    if (sqlConnection.State == ConnectionState.Open)
                        CloseConnection();
                    sqlConnection.Open();
                }
                catch (Exception e)
                {
                    System.IO.File.WriteAllText("D:\\'" + Global.CompanyCode + "'_ErrorLog'.TXT", e.ToString());
                    MessageBox.Show("Failed to open database connection!\n\rError log has been created in file D:\'" + Global.CompanyCode + "'_ErrorLog'.TXT",
                    "ERROR!",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Exclamation,
                    MessageBoxDefaultButton.Button1);

                    System.Windows.Forms.Application.Exit();
                }

                //using (SqlCommand cmd = new SqlCommand("Select ID,Name From Person", con))
                //{
                //    SqlDataAdapter da = new SqlDataAdapter(cmd);
                //    DataSet ds = new DataSet();
                //    da.Fill(ds);
                //    return ds;
                //}

                using (SqlCommand cmd = new SqlCommand(strQuery, sqlConnection))
                {
                    //sqlCommand = new SqlCommand(strQuery, sqlConnection);
                    sqlDataReader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    return sqlDataReader;
                }
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                sqlDataReader = null;
                return sqlDataReader;
            }

            //finally
            //{
            //    //// 3. close the reader
            //    if (sqlDataReader != null)
            //    {
            //        sqlDataReader.Close();
            //    }

            //    // close the connection
            //    //if (sqlConnection.State == ConnectionState.Open)
            //    //    CloseConnection();
            //}
        }

        public SqlDataReader RetrieveDataByString2(string strQuery)
        {
            try
            {
                sqlCommand = new SqlCommand(strQuery, sqlConnection);
                return sqlCommand.ExecuteReader(CommandBehavior.CloseConnection);
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                SqlDataReader sqlDataReader = null;
                return sqlDataReader;
            }
        }

        public DataTable RetrieveDataTable(string strQuery)
        {
            try
            {
                OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(strQuery, sqlConnection);
                DataTable dt = new DataTable();
                da.Fill(dt);
                return dt;
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                DataTable dt = new DataTable();
                return dt;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataTable PopulateInventory(string sQuery)
        {
            try
            {
                OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, sqlConnection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                return DS.Tables[0];
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                DataTable dt = new DataTable();
                return dt;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet RetrieveDatSet(string sQuery)
        {
            try
            {
                OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, sqlConnection);
                DataSet DS = new DataSet();
                da.Fill(DS);
                return DS;
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                DataSet DS = new DataSet();
                return DS;
            }
            finally
            {
                CloseConnection();
            }
        }

        public DataSet ReportDataSet(string sQuery)
        {
            try
            {
                OpenConnection();
                SqlDataAdapter da = new SqlDataAdapter(sQuery, sqlConnection);
                DataSet DS = new DataSet();
                da.Fill(DS, "dtReport");
                return DS;
            }
            catch (Exception ex)
            {
                _strError = ex.Message;
                DataSet DS = new DataSet();
                return DS;
            }
            finally
            {
                CloseConnection();
            }
        }

        public void FillDropDownList(string sQuery, System.Windows.Forms.ComboBox DropDownName)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);
            using (sqlCommand)
            {
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                dt.Load(myReader);

                DropDownName.DataSource = dt;
                DropDownName.ValueMember = dt.Columns[0].ColumnName;
                DropDownName.DisplayMember = dt.Columns[1].ColumnName;
            }
        }

        public void FillDGVCombo(string sQuery, System.Windows.Forms.DataGridViewComboBoxColumn DropDownName)
        {
            DataTable dt = new DataTable();
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);
            using (sqlCommand)
            {
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                dt.Load(myReader);

                DropDownName.DataSource = dt;
                DropDownName.ValueMember = dt.Columns[0].ColumnName;
                DropDownName.DisplayMember = dt.Columns[1].ColumnName;
            }
        }

        public void FillLabel(string sQuery, System.Windows.Forms.Label lb)
        {
            OpenConnection();
            SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);
            using (sqlCommand)
            {
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        lb.Text = myReader["NewLabel"].ToString();
                    }
                }

            }
        }

        public string LookUpData(string sQuery)
        {
            OpenConnection();
            string strResult = "";
            SqlCommand sqlCommand = new SqlCommand(sQuery, sqlConnection);
            using (sqlCommand)
            {
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        strResult = myReader["LookupCode"].ToString();
                    }
                }
                return strResult;
            }
        }

        public string CheckDateType(string strTableName, string strFieldName)
        {
            string strResult = "";
            OpenConnection();
            string strSQLString = "SELECT t.Name FROM sys.columns c INNER JOIN sys.types t ON c.user_type_id = t.user_type_id LEFT OUTER JOIN sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id LEFT OUTER JOIN sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id WHERE c.object_id = OBJECT_ID('" + strTableName + "') AND c.name = '" + strFieldName + "'";
            SqlCommand sqlCommand = new SqlCommand(strSQLString, sqlConnection);
            using (sqlCommand)
            {
                SqlDataReader myReader = sqlCommand.ExecuteReader();
                if (myReader.HasRows)
                {
                    while (myReader.Read())
                    {
                        strResult = myReader["Name"].ToString();
                    }
                }
            }
            return strResult;
        }

        //public static void DuckCopyShallow(object src)
        //{
        //    object dstT;
        //    var srcT = src.GetType();
        //    var dstT = src.GetType();
        //    foreach (var f in srcT.GetFields())
        //    {
        //        var dstF = dstT.GetField(f.Name);
        //        if (dstF == null)
        //            continue;
        //        dstF.SetValue(dst, f.GetValue(src));
        //    }

        //    foreach (var f in srcT.GetProperties())
        //    {
        //        var dstF = dstT.GetProperty(f.Name);
        //        if (dstF == null)
        //            continue;

        //        dstF.SetValue(dst, f.GetValue(src, null), null);
        //    }
        //}
    }

}


//SELECT 
//    c.name 'Column Name',
//    t.Name 'Data type',
//    c.max_length 'Max Length',
//    c.precision ,
//    c.scale ,
//    c.is_nullable,
//    ISNULL(i.is_primary_key, 0) 'Primary Key'
//FROM    
//    sys.columns c
//INNER JOIN 
//    sys.types t ON c.user_type_id = t.user_type_id
//LEFT OUTER JOIN 
//    sys.index_columns ic ON ic.object_id = c.object_id AND ic.column_id = c.column_id
//LEFT OUTER JOIN 
//    sys.indexes i ON ic.object_id = i.object_id AND ic.index_id = i.index_id
//WHERE
//    c.object_id = OBJECT_ID('YourTableName')
