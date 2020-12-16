using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace ARPLogistic_BE
{
    public class DbConnection
    {

        public DbConnection(string strConnection)
        {
            sqlConnection = new SqlConnection(strConnection);

        }

        protected string _strError = string.Empty;
        protected SqlConnection sqlConnection;
        protected SqlCommand sqlCommand;

        public string Error
        {
            get
            {
                return _strError;
            }
        }

        protected void BuildParameter(List<SqlParameter> sqlParam, string spName)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.StoredProcedure;
            sqlCommand.CommandText = spName;
            sqlCommand.Parameters.Clear();
            foreach (SqlParameter param in sqlParam)
            {
                sqlCommand.Parameters.Add(param);
            }
        }

        protected void BuildQueryParameter(string strQuery)
        {
            sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandType = CommandType.Text;
            sqlCommand.CommandText = strQuery;
        }

        public void CloseConnection()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }



    }
}
