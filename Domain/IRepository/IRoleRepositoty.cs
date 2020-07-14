using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IRoleRepositoty : IBaseRepository<long, Role>
    {
        long Add(string name);

        Role GetByName(string name);
    }
}
