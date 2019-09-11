using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace amocrm.library.Converters
{
    public class PostJsonSerializerSettings
    {
        public JsonSerializerSettings GetSerializeSetting()
        {
            var serializerSettings = new JsonSerializerSettings()
            {
                //ContractResolver = new ValueIsNotNullResolver(),
               // ContractResolver = new ZeroValuesAndNameContractResolver(true),
                NullValueHandling = NullValueHandling.Ignore,
                DefaultValueHandling = DefaultValueHandling.Ignore
            };

            return serializerSettings;
        }

        public JsonSerializer GetSerializer()
        {
            return JsonSerializer.Create(GetSerializeSetting());
        }
    }
}
