using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System.Collections.Generic;
using System.Reflection;

namespace amocrm.library.Converters
{
    internal class ChangeNameContractResolver : DefaultContractResolver
    {
        bool _useJsonPropertyName { get; }

        Dictionary<string, string> names = new Dictionary<string, string>() {
            { "leads", "leads_id" },
            { "company", "company_id" },
            { "contacts", "contacts_id" }
        };

        public ChangeNameContractResolver(bool useJsonPropertyName)
        {
            _useJsonPropertyName = useJsonPropertyName;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);
            if (_useJsonPropertyName)
            {
                property.PropertyName = names.ContainsKey(property.PropertyName) ? names[property.PropertyName] : property.PropertyName;
            }

            return property;
        }
    }
}
