using System;
using System.Collections.Generic;
using System.Data;

namespace Infrastructure
{
    public interface IDbContext : IDisposable
    {
        int Execute(string sql, object param);
        IEnumerable<T> Query<T>(string sql, object param = null);
        T QueryFirstOrDefault<T>(string sql, object param = null);
    }
}