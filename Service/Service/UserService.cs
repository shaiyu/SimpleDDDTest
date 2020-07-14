using Domain;
using Domain.Entity;
using Domain.IRepository;
using Domain.Repository;
using Infrastructure;
using Service.IService;
using Service.Resp;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace Service.Service
{
    public class UserService : IUserService
    {
        public DbContext db = new DbContext();

        public IUnitOfWork _unitOfWork;

        public IUserRepository _userRepository;
        public IRoleRepositoty _roleRepositoty;
        public IUserRoleRepository _userRoleRepository;

        public UserService()
        {
            Debug.WriteLine("default create instance");

            _unitOfWork = db;
            _userRepository = new UserRepository(db);
            _roleRepositoty = new RoleRepository(db);
            _userRoleRepository = new UserRoleRepository(db);
        }

        public UserService(IUnitOfWork unitOfWork, IUserRepository userRepository, IRoleRepositoty roleRepositoty, IUserRoleRepository userRoleRepository)
        {
            Debug.WriteLine("autofac create instance");

            _unitOfWork = unitOfWork;
            _userRepository = userRepository;
            _roleRepositoty = roleRepositoty;
            _userRoleRepository = userRoleRepository;
        }

        public ApiResp<string> Register(string userName, string roleName)
        {
            _unitOfWork.BeginTransaction();

            //创建用户
            User user = _userRepository.GetByName(userName);
            if (user != null)
                return ApiResp.Failure("用户名重复");

            //添加用户
            user = new User()
            {
                Id = Guid.NewGuid(),
                Name = userName
            };
            _userRepository.Add(user);

            //添加角色
            Role role = _roleRepositoty.GetByName(roleName);
            long roleId = 0L;
            if (role == null)
                roleId = _roleRepositoty.Add(roleName);

            //添加用户角色关联
            var userRole = new UserRole()
            {
                UserId = user.Id,
                RoleId = roleId
            };
            _userRoleRepository.Add(userRole);

            _unitOfWork.Commit();
            return ApiResp.Success("注册成功");
        }
    }
}
