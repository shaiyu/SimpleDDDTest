using Autofac;
using Domain;
using Domain.IRepository;
using Domain.Repository;
using Infrastructure;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Service.IService;
using Service.Service;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace UnitTestService
{
    [TestClass]
    public class TestUserService
    {
        public IContainer _container;
        public IUserService _userService;

        public TestUserService()
        {
            var container = new ContainerBuilder();
            container.RegisterType(typeof(DbContext)).As<IDbContext>().As<IUnitOfWork>().InstancePerLifetimeScope();

            container.RegisterType<UserRepository>().As<IUserRepository>().InstancePerLifetimeScope();
            container.RegisterType<RoleRepository>().As<IRoleRepositoty>().InstancePerLifetimeScope();
            container.RegisterType<UserRoleRepository>().As<IUserRoleRepository>().InstancePerLifetimeScope();

            container.RegisterType(typeof(UserService)).As<IUserService>().InstancePerLifetimeScope();


            _container = container.Build();


            _userService = _container.Resolve<IUserService>();
            //_userService = new UserService();
        }


        [TestMethod]
        [DataRow("李老师", "语文老师")]
        [DataRow("小明", "小学生")]
        [DataRow("小明", "大学生")]
        [DataRow("小康", "中学生")]
        [DataRow("小丽", "高中生")]
        [DataRow("小刚", "大学生")]
        public void Add(string userName, string roleName)
        {
            var resp = _userService.Register(userName, roleName);
            if (!resp.Status)
                Debug.WriteLine(resp.Msg);

            Assert.IsTrue(resp.Status);
        }

    }
}
