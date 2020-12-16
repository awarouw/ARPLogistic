using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Transactions;

namespace ARPLogistic_BE
{
    public class TransactionManagers : DbConnection
    {
        public TransactionManagers(string strConnection)
            : base(strConnection)
        {
        }

        SqlTransaction sqlTrans;

        //public void DoTransaction(List<SqlCommand> sqlCommand)
        //{
        //    try
        //    {
        //        BeginTransaction();
        //        foreach (SqlCommand cmd in sqlCommand)
        //        {
        //            cmd.Transaction = sqlTrans;
        //            cmd.Connection = sqlConnection;
        //            cmd.CommandType = CommandType.StoredProcedure;
        //            cmd.ExecuteNonQuery();
        //        }
        //        CommitTransaction();
        //    }
        //    catch (Exception ex)
        //    {
        //        _strError = ex.Message;
        //        RollBackTransaction();
        //    }
        //}

        public void BeginTransaction()
        {
            sqlConnection.Open();
            sqlTrans = sqlConnection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            sqlTrans.Commit();
        }

        public void RollBackTransaction()
        {
            sqlTrans.Rollback();
        }

        public void EndTransaction()
        {
            if (sqlConnection.State == ConnectionState.Open)
                sqlConnection.Close();
        }

        public int DoTransaction(List<SqlParameter> sqlParam, string spName)
        {
            try
            {
                BuildParameter(sqlParam, spName);
                sqlCommand.Transaction = sqlTrans;
                return Convert.ToInt32(sqlCommand.ExecuteScalar());
            }
            catch (Exception ex)
            {
                sqlTrans.Rollback();
                _strError = ex.Message;
                EndTransaction();

                return -1;
            }
        }

        //public class TransactionUtils
        //{
        public static TransactionScope CreateTransactionScope()
        {
            var transactionOptions = new TransactionOptions();
            transactionOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
            transactionOptions.Timeout = System.Transactions.TransactionManager.MaximumTimeout;
            return new TransactionScope(TransactionScopeOption.Required, transactionOptions);
        }
        //}

    }
}
