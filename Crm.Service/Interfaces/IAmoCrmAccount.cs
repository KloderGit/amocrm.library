using amocrm.library.Models.Account;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amocrm.library.Interfaces
{
    public interface ICrmData
    {
        AccountInfo Account { get; set; }
        Task<AccountInfo> GetCrmInfo();
        Task<CustomFieldInfo> GetCustomFieldsInfo();
        Task<Dictionary<int, int>> GetCustomFieldsType();
        Task<int> FindFieldTypeByFieldId(int id);
    }
}
