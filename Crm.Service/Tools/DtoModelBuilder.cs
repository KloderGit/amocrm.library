using amocrm.library.Extensions;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace amocrm.library.Tools
{
    internal class DtoModelBuilder<TEntity> where TEntity : EntityCore
    {
        private Type dtoType;
        private readonly Type listType = typeof(List<>);
        private Type genericListType;
        private IAmoCrmAccount provider;

        public DtoModelBuilder(IAmoCrmAccount provider)
        {
            this.provider = provider;
        }

        public async Task<Object> GetUpdateModel(IEnumerable<TEntity> entities)
        {
            var fieldTypes = await provider?.GetCustomFieldsType();
            if (fieldTypes != null) DetectFieldsType(entities, fieldTypes);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Update);

            return new { update = ConvertEntityCollectionToDto(entities) };
        }

        public async Task<Object> GetAddModel(IEnumerable<TEntity> entities)
        {
            var fieldTypes = await provider?.GetCustomFieldsType();
            if (fieldTypes != null) DetectFieldsType(entities, fieldTypes);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Add);

            return new { add = ConvertEntityCollectionToDto(entities) };
        }

        private void DetectFieldsType(IEnumerable<TEntity> entities, Dictionary<int, int> dictionary)
        {
            if (!(entities is IEnumerable<EntityMember>)) return;

            foreach (var item in (IEnumerable<EntityMember>)entities)
            {
                foreach (var fild in item.Fields)
                {
                    var res = dictionary.TryGetValue(fild.Id, out int value);
                    if (res) fild.FieldType = value;
                }
            }
        }

        private Object ConvertEntityCollectionToDto(object elements)
        {
            var type1 = elements.GetType();

            genericListType = listType.MakeGenericType(this.dtoType);

            var array = elements.Adapt(type1, this.genericListType);

            return array;
        }
    }
}
