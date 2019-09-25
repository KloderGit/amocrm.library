using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Models;
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
                if (type == (int)FieldType.MULTISELECT) result.Add(item.Enum.ToString());
                else result.Add(item);
            }

            return result;
        }

        protected bool isNull(object item)
        {
            return item == null ? true : false;
        }
    }
}
