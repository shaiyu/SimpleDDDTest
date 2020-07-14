using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Infrastructure;

namespace Domain.IRepository
{
    public interface IBaseRepository<TKey, T> : IRepository<TKey, T>
        where TKey : IEquatable<TKey> where T : class
    {
        IDbContext _db { get; }

        T Get(TKey id);
        IQueryable<T> List();
        T Update(TKey id, object param);
    }
}
