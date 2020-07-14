using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IRepository<TKey, Entity>
        where TKey : IEquatable<TKey> where Entity : class
    {
        int Add(Entity entity);
        int Delete(TKey id);
        int Update(Entity entity);
    }
}
