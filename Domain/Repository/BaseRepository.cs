using Domain.IRepository;
using Infrastructure;
using Org.BouncyCastle.Crypto.Engines;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class BaseRepository<TKey, T> : IBaseRepository<TKey, T>
        where TKey : IEquatable<TKey> where T : class
    {
        public IDbContext _db { get; }
        public string TableName { get; }
        public string KeyName { get; } = "Id";

        public BaseRepository(IDbContext db)
        {
            _db = db;
            Type type = typeof(T);
            TableName = type.Name;
        }

        public int Add(T entity)
        {
            //dbContext.Execute()
            throw new NotImplementedException();
        }

        public int Delete(TKey id)
        {
            var sql = $@" delete from {TableName} where {KeyName} = @id ";
            return _db.Execute(sql, new { id });
        }

        public T Get(TKey id)
        {
            var sql = $@" select * from  {TableName} where {KeyName} = @id";
            return _db.QueryFirstOrDefault<T>(sql, new { id });
        }

        public IQueryable<T> List()
        {
            var sql = $@" select * from  {TableName}";
            return _db.Query<T>(sql).AsQueryable();
        }

        public T Update(TKey id, object param)
        {
            throw new NotImplementedException();
        }

        public int Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
