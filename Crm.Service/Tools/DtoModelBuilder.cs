using amocrm.library.Extensions;
using amocrm.library.Models;
using amocrm.library.Models.Account;
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
        private AccountInfo account;

        public DtoModelBuilder(AccountInfo account)
        {
            this.account = account;
        }

        public Object GetUpdateModel(IEnumerable<TEntity> entities)
        {
            if (account?.GetCustomFieldsType() != null) DetectFieldsType(entities);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Update);

            return new { update = ConvertEntityCollectionToDto(entities) };
        }

        public Object GetAddModel(IEnumerable<TEntity> entities)
        {
            if (account?.GetCustomFieldsType() != null) DetectFieldsType(entities);

            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Add);

            return new { add = ConvertEntityCollectionToDto(entities) };
        }

        private void DetectFieldsType(IEnumerable<TEntity> entities)
        {
            if (!(entities is IEnumerable<EntityMember>)) return;

            foreach (var item in (IEnumerable<EntityMember>)entities)
            {
                foreach (var fild in item.Fields)
                {
                    var res = account.GetCustomFieldsType().TryGetValue(fild.Id, out int value);
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
