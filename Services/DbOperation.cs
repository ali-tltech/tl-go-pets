using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using System.Data;

namespace TLCAREERSCORE.Services
{
    public static class DbOperation
    {
        public static object ValueOrNull(object value)
        {
            return value ?? DBNull.Value;
        }


        public static DbDataReader GetData(DbContext dbContext, string procname, Dictionary<string, object> Parameters)
        {
            using (var cmd = dbContext.Database.GetDbConnection().CreateCommand())
            {
                cmd.CommandText = procname;
                cmd.CommandType = CommandType.StoredProcedure;
                if (cmd.Connection.State != ConnectionState.Open)
                    cmd.Connection.Open();

                foreach (KeyValuePair<string, object> param in Parameters)
                {
                    DbParameter dbParameter = cmd.CreateParameter();
                    dbParameter.ParameterName = param.Key;
                    dbParameter.Value = param.Value;
                    cmd.Parameters.Add(dbParameter);
                }


                return cmd.ExecuteReader(CommandBehavior.CloseConnection);
            }
        }


        public static DataTable GetDataTable(DbContext dbContext, string procname, Dictionary<string, object> Parameters)
        {
            DbCommand cmd = dbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procname;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> param in Parameters)
            {
                DbParameter dbParameter = cmd.CreateParameter();
                dbParameter.ParameterName = param.Key;
                dbParameter.Value = param.Value;
                cmd.Parameters.Add(dbParameter);
            }

            DataTable dt = new DataTable();
            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    dt.Load(reader);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();
                cmd.Dispose();
            }
            return dt;


        }


        public static DataSet GetDataSet(DbContext dbContext, string procname, Dictionary<string, object> Parameters)
        {
            DbCommand cmd = dbContext.Database.GetDbConnection().CreateCommand();
            cmd.CommandText = procname;
            cmd.CommandType = CommandType.StoredProcedure;
            foreach (KeyValuePair<string, object> param in Parameters)
            {
                DbParameter dbParameter = cmd.CreateParameter();
                dbParameter.ParameterName = param.Key;
                dbParameter.Value = param.Value;
                cmd.Parameters.Add(dbParameter);
            }

            DataSet ds = new DataSet();


            try
            {
                if (cmd.Connection.State != ConnectionState.Open) cmd.Connection.Open();
                DbDataAdapter adapter = DbProviderFactories.GetFactory(dbContext.Database.GetDbConnection()).CreateDataAdapter();
                adapter.SelectCommand = cmd;
                adapter.Fill(ds);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd.Connection.State != ConnectionState.Closed) cmd.Connection.Close();
                cmd.Dispose();
            }
            return ds;


        }


        public static Object ExecuteScalar(DbContext dbContext, string procname, Dictionary<string, object> Parameters)
        {


            var cmd = dbContext.Database.GetDbConnection().CreateCommand();

            cmd.CommandText = procname;
            cmd.CommandType = CommandType.StoredProcedure;


            foreach (KeyValuePair<string, object> param in Parameters)
            {
                DbParameter dbParameter = cmd.CreateParameter();
                dbParameter.ParameterName = param.Key;
                dbParameter.Value = param.Value;
                cmd.Parameters.Add(dbParameter);
            }
            try
            {
                if (cmd.Connection.State != ConnectionState.Open)
                {
                    cmd.Connection.Open();
                }
                return cmd.ExecuteScalar();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                if (cmd.Connection.State == ConnectionState.Open)
                {
                    cmd.Connection.Close();
                }
                cmd.Dispose();
            }

        }

    }
}
