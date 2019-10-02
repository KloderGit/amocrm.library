using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Models;
using amocrm.library.Models.Account;
using Mapster;
using System.Collections;
using System.Collections.Generic;

namespace amocrm.library.Mappings
{
    public class CommonMaps
    {
        public CommonMaps()
        {
            TypeAdapterConfig<Field, CustomFieldPostDto>
                .NewConfig()
                .Map(dest => dest.Values, src => ConvertCustomFieldValuesByType(src.Values, src.FieldType));
        }

        protected ArrayList ConvertCustomFieldValuesByType(List<FieldValue> array, int type)
        {
            var result = new ArrayList();

            foreach (var item in array)
            {
                switch (type)
                {
                    case (int)FieldType.SELECT:
                        result.Add(new { value = item.Enum.ToString() });
                        break;
                    case (int)FieldType.MULTISELECT:
                        result.Add(item.Enum.ToString());
                        break;
                    default:
                        result.Add(new { @enum = item.Enum, value = item.Value });
                        break;
                }
            }

            return result;
        }

        protected bool isNull(object item)
        {
            return item == null ? true : false;
        }
    }
}
