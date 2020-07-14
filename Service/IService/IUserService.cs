using Service.Resp;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.IService
{
    public interface IUserService
    {
        ApiResp<string> Register(string userName, string roleName);
    }
}
