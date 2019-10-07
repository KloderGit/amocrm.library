using amocrm.library.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface IAmoCrmAccount
    {
        AccountInfo Account { get; set; }
        Task<AccountInfo> GetCrmInfo();
        Task<CustomFieldInfo> GetCustomFieldsInfo();
        Task<Dictionary<int, int>> GetCustomFieldsType();
        Task<int> FindFieldTypeByFieldId(int id);
    }
}
