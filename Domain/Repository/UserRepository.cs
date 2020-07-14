using Domain.Entity;
using Domain.IRepository;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.Repository
{
    public class UserRepository : BaseRepository<Guid, User>, IUserRepository
    {
        public UserRepository(IDbContext db) : base(db)
        {
        }

        new public Guid Add(User user)
        {
            var sql = $@" insert into User (Id, Name) values(@Id, @Name) ";
            _db.Execute(sql, user);
            return user.Id;
        }

        public User GetByName(string name)
        {
            var sql = $@" select * from User where Name = @Name ";
            return _db.QueryFirstOrDefault<User>(sql, new { Name = name });
        }
    }
}
