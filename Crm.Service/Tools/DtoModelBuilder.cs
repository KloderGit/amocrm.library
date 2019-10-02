using amocrm.library.Extensions;
using amocrm.library.Models;
using amocrm.library.Models.Account;
using Mapster;
using System;
using System.Collections.Generic;

namespace amocrm.library.Tools
{
    internal class DtoModelBuilder<TEntity> where TEntity : EntityCore
    {
        private Type dtoType;
        private Type listType = typeof(List<>);
        private Type genericListType;
        private CustomFieldInfo customFieldInfo;

        public DtoModelBuilder(CustomFieldInfo fieldsStore)
        {
            customFieldInfo = fieldsStore;
        }

        public Object GetUpdateModel(IEnumerable<TEntity> entities)
        {
            if (customFieldInfo != null) DetectFieldsType(entities);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Update);

            return new { update = ConvertEntityCollectionToDto(entities) };
        }

        public Object GetAddModel(IEnumerable<TEntity> entities)
        {
            if (customFieldInfo != null) DetectFieldsType(entities);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Add);

            return new { add = ConvertEntityCollectionToDto(entities) };
        }

        private Object ConvertEntityCollectionToDto(object elements)
        {
            var type1 = elements.GetType();

            genericListType = listType.MakeGenericType(this.dtoType);

            var array = elements.Adapt(type1, this.genericListType);

            return array;
        }

        private void DetectFieldsType(IEnumerable<TEntity> entities)
        {
            if (!(entities is IEnumerable<EntityMember>)) return;

            foreach (var item in (IEnumerable<EntityMember>)entities)
            {
                foreach (var fild in item.Fields)
                {
                    fild.FieldType = (int)customFieldInfo.FindFildType(fild.Id);
                }
            }
        }
    }
}
