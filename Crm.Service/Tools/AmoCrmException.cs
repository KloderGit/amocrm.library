using amocrm.library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Tools
{
    public class AmoCrmException : Exception
    {
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public string Ip { get; set; }
        public string Domain { get; set; }
        public int ServerTime { get; set; }
        public bool AuthResult { get; set; }


        public AmoCrmException(Error error)
             : base (error.Response.Error)
        {
            Error = error.Response.Error;
            ErrorCode = error.Response.ErrorCode;
            Ip = error.Response.Ip;
            Domain = error.Response.Domain;
            ServerTime = error.Response.ServerTime;
            AuthResult = error.Response.AuthResult;
        }
    }
}