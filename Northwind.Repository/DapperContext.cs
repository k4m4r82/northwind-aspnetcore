using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Npgsql;

namespace Northwind.Repository
{
    public interface IDapperContext : IDisposable
    {
        IDbConnection db { get; }
    }

    public class DapperContext : IDapperContext
    {
        private IDbConnection _db;

        private readonly string _connectionString;

        public DapperContext(string server, string port)
        {
            var dbName = "northwind"; // ConfigurationManager.AppSettings["dbName"];
            var appName = "NorthwindApp";
            var userId = "postgres";
            var userPassword = "masterkey";

            _connectionString = string.Format("Server={0};Port={1};User Id={2};Password={3};Database={4};ApplicationName={5}", server, port, userId, userPassword, dbName, appName);

            if (_db == null)
            {
                _db = GetOpenConnection(_connectionString);
            }
        }

        private IDbConnection GetOpenConnection(string connectionString)
        {
            DbConnection conn = null;

            //try
            //{
                conn = new NpgsqlConnection(connectionString);
                conn.Open();
            //}
            //catch
            //{
            //}

            return conn;
        }

        public IDbConnection db
        {
            get { return _db ?? (_db = GetOpenConnection(_connectionString)); }
        }

        public void Dispose()
        {
            if (_db != null)
            {
                try
                {
                    if (_db.State != ConnectionState.Closed)
                    {
                        _db.Close();
                    }
                }
                finally
                {
                    _db.Dispose();
                }
            }

            GC.SuppressFinalize(this);
        }
    }
}
