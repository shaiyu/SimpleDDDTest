using Dapper;
using Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace Domain
{
    public class DbContext : IDbContext, IUnitOfWork
    {
        public string ConnectionString = "server=localhost;database=test;user=root;pwd=root;Allow User Variables=True;convert zero datetime=True;";

        public IDbConnection _db;
        public DbProviderFactory ProviderFactory = SqlClientFactory.Instance;


        public IDbTransaction Transaction { get; set; }

        public DbContext()
        {
            _db = new MySqlConnection(ConnectionString);
            _db.Open();
            if (_db.State != ConnectionState.Open)
                throw new InvalidOperationException("connection should be open !");
        }

        public int Execute(string sql, object param)
        {
            return _db.Execute(sql, param, Transaction);
        }

        public IEnumerable<T> Query<T>(string sql, object param)
        {
            return _db.Query<T>(sql, param, Transaction);
        }

        public T QueryFirstOrDefault<T>(string sql, object param)
        {
            return _db.QueryFirstOrDefault<T>(sql, param, Transaction);
        }

        public void BeginTransaction()
        {
            Transaction = _db.BeginTransaction();
        }

        public void Commit()
        {
            if (Transaction != null)
            {
                Transaction.Commit();
                Transaction = null;
            }
        }

        public void Rollback()
        {
            if (Transaction != null)
            {
                Transaction.Rollback();
                Transaction = null;
            }
        }

        public void Dispose()
        {

        }
    }
}
