using Domain.Entity;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.IRepository
{
    public interface IUserRoleRepository
    {
         bool Add(UserRole userRole);
    }
}
