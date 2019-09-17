using amocrm.library.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Tools
{
    public class AmoCrmHttpException : Exception
    {
        public string Error { get; set; }
        public string ErrorCode { get; set; }
        public string Ip { get; set; }
        public string Domain { get; set; }
        public int ServerTime { get; set; }
        public bool AuthResult { get; set; }


        public AmoCrmHttpException(AuthResponse error)
             : base (error.Content.Error)
        {
            Error = error.Content.Error;
            ErrorCode = error.Content.ErrorCode;
            Ip = error.Content.Ip;
            Domain = error.Content.Domain;
            ServerTime = error.Content.ServerTime;
            AuthResult = error.Content.AuthResult;
        }
    }
}