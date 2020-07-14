using Domain.Entity;
using Domain.IRepository;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IUserRepository : IBaseRepository<Guid, User>
    {
        new Guid Add(User user);
        User GetByName(string name);
    }
}
