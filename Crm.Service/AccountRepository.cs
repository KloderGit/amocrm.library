using amocrm.library.Interfaces;
using amocrm.library.Models.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library
{
    public class AccountRepository
    {
        IAmoCrmProvider Provider { get; }

        public AccountRepository(IAmoCrmProvider provider)
        {
            Provider = provider;
        }

        private CustomFieldInfo customField;

        public CustomFieldInfo GetCustomField()
        {
            var client = Provider.GetClient();

            return customField;
        }

        public void SetCustomField(CustomFieldInfo value)
        {
            customField = value;
        }
    }
}
