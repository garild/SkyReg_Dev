using DataLayer.Utils;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;

namespace DataLayer
{
    public class DatabaseAccess
    {
        private string _serverName;
        private string _databaseName;
        private string _user;
        private string _password;

        public string ServerName
        {
            get { return _serverName; }
            set { _serverName = value; }
        }
        public string DataBaseName
        {
            get { return _databaseName; }
            set { _databaseName = value; }
        }
        public string User
        {
            get { return _user; }
            set { _user = value; }
        }
        public string Password
        {
            get { return _password.DecryptString(); }
            set { _password = value.EncryptString(); }
        }

    }

    public sealed class DatabaseConfig
    {

        private static SqlConnection conn = null;
        private static SqlConnection updaterConn = null;
        private static SqlConnectionStringBuilder connBuilder = null;
        public static DatabaseAccess _databaseAccess { get; set; }
        public static SqlTransaction Transaction { get; private set; }

        public DatabaseConfig(DatabaseAccess DatabaseAccess)
        {
            _databaseAccess = DatabaseAccess;
        }

        public static SqlConnection Conn
        {
            get
            {
                if (conn == null)
                    conn = new SqlConnection(ConnectionString);
                return conn;
            }
            set
            {
                conn = value;
            }
        }


        public static SqlConnection SynchronizedConnection
        {
            get
            {
                if (updaterConn == null)
                    updaterConn = new SqlConnection(ConnectionString);
                return updaterConn;
            }
        }

        public static string ConnectionString
        {
            get
            {
                if (connBuilder == null)
                {
                    connBuilder = new SqlConnectionStringBuilder();
                    connBuilder.UserID = _databaseAccess.User;
                    connBuilder.Password = _databaseAccess.Password;
                    connBuilder.InitialCatalog = _databaseAccess.DataBaseName;
                    connBuilder.DataSource = _databaseAccess.ServerName;
                    return connBuilder.ConnectionString;
                }
                else
                    return connBuilder.ConnectionString;
            }
        }


        public static void BeginTransaction(string transactionName)
        {
            if (SynchronizedConnection.State == System.Data.ConnectionState.Closed)
                SynchronizedConnection.Open();
            Transaction = SynchronizedConnection.BeginTransaction(transactionName);
        }

        public static void CommitTransaction(string transactionName)
        {
            Transaction.Commit();
            SynchronizedConnection.Close();
            Transaction = null;
        }

        public static void RollbackTransaction(string transactionName)
        {
            if (Transaction != null)
            {
                Transaction.Rollback(transactionName);
                if (SynchronizedConnection.State == System.Data.ConnectionState.Open)
                    SynchronizedConnection.Close();
                Transaction = null;
            }
        }



    }

    public sealed class DatabaseManager
    {
        public static bool CreateDataBase(string script, string connectionString)
        {
            bool result = false;
            try
            {
                using (SqlCommand cmd = new SqlCommand())
                {
                    SqlConnection con = new SqlConnection();
                    con.ConnectionString = connectionString;
                    cmd.CommandTimeout = 0;
                    cmd.CommandType = System.Data.CommandType.Text;
                    cmd.CommandText = script;
                    cmd.Connection = con;

                    if (con.State != System.Data.ConnectionState.Open)
                        con.Open();
                    result = (bool)cmd.ExecuteScalar();

                }
            }
            catch (SqlException sqlex)
            {
                if ((sqlex.Class == 20) && (sqlex.Number == 53))
                {
                    throw new Exception("Nieprawidłowe parametry połączenia !", sqlex);
                }
                else
                {
                    throw new Exception(sqlex.Message, sqlex);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.InnerException.Message, ex);
            }

            return result;
        }

        public static void GenerateDatabase(string script, string connectionString)
        {
            using (SqlCommand cmd = new SqlCommand())
            {
                SqlConnection con = new SqlConnection();
                con.ConnectionString = connectionString;
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = script;
                cmd.Connection = con;

                if (con.State != System.Data.ConnectionState.Open)
                    con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
            }
        }

    }
}
