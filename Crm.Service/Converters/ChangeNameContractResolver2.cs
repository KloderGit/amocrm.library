using amocrm.library.DTO;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace amocrm.library.Converters
{
    internal class ZeroValuesAndNameContractResolver : DefaultContractResolver
    {
        bool useJsonPropertyName { get; }

        Dictionary<string, string> names = new Dictionary<string, string>() {
            { "leads", "leads_id" },
            { "company", "company_id" },
            { "contacts", "contacts_id" }
        };

        public ZeroValuesAndNameContractResolver(bool useResolver)
        {
            this.useJsonPropertyName = useResolver;
        }

        protected override JsonProperty CreateProperty(MemberInfo member, MemberSerialization memberSerialization)
        {
            var property = base.CreateProperty(member, memberSerialization);

            property.ShouldSerialize = instance =>
            {
                var value = this.GetValue(member, instance);

                if (value is int)
                    if ((int)value == 0) return false;

                if (value is string)
                    if (string.IsNullOrEmpty((string)value)) return false;

                return true;
            };

            if (member.DeclaringType == typeof(ContactGetDTO))
            {
                if (useJsonPropertyName) property.PropertyName = names.ContainsKey(property.PropertyName) ? names[property.PropertyName] : property.PropertyName;
            }

            return property;
        }

        object GetValue(MemberInfo memberInfo, object forObject)
        {
            switch (memberInfo.MemberType)
            {
                case MemberTypes.Field:
                    return ((FieldInfo)memberInfo).GetValue(forObject);
                case MemberTypes.Property:
                    return ((PropertyInfo)memberInfo).GetValue(forObject);
                default:
                    throw new NotImplementedException();
            }
        }
    }
}
