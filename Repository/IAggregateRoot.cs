using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public interface IAggregateRoot<TKey> where TKey : IEquatable<TKey>
    {

        TKey Id { get; set; }
    }
}
