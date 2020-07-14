using Google.Protobuf.WellKnownTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Service.Resp
{
    public class ApiResp<T>
    {

        public bool Status { get; set; }

        public string Msg { get; set; }

        public T Data { get; set; }
        public static ApiResp<T> Success(string msg)
        {
            return Success(msg, default);
        }
        public static ApiResp<T> Success(string msg, T data)
        {
            return new ApiResp<T>()
            {
                Status = true,
                Msg = msg,
                Data = data
            };
        }
        public static ApiResp<T> Failure(string msg)
        {
            return Failure(msg, default);
        }
        public static ApiResp<T> Failure(string msg, T data)
        {
            return new ApiResp<T>()
            {
                Status = false,
                Msg = msg,
                Data = data
            };
        }


    }

    public class ApiResp : ApiResp<string>
    {
    }
}
