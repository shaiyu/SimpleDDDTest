using Domain.Entity;
using Domain.IRepository;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Repository
{
    public class RoleRepository : BaseRepository<long, Role>, IRoleRepositoty
    {
        public RoleRepository(IDbContext db) : base(db)
        {

        }

        public long Add(string name)
        {
            var sql = $@" insert into Role (Name) values(@Name); select last_insert_id(); ";
            return _db.QueryFirstOrDefault<long>(sql, new { Name = name });
        }

        public Role GetByName(string name)
        {
            var sql = $@" select * from Role where Name = @Name ";
            return _db.QueryFirstOrDefault<Role>(sql, new { Name = name });
        }
    }
}
