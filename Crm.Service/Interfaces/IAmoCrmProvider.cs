using amocrm.library.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface IAmoCrmProvider : ICrmProvider
    {
        Task Auth();
        bool AuthCookiesLifeTime();
        TimeSpan ServerTimeDiff { get; set; }
    }
}
