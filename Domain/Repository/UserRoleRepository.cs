using Domain.Entity;
using Domain.IRepository;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public class UserRoleRepository : IUserRoleRepository
    {
        public IDbContext _db;

        public UserRoleRepository(IDbContext db)
        {
            _db = db;
        }

        public bool Add(UserRole userRole)
        {
            var sql = " insert into UserRole (UserId, RoleId) values (@UserId, @RoleId) ";
            return _db.Execute(sql, userRole) > 0;
        }
    }
}
