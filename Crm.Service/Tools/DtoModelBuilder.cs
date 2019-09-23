using amocrm.library.Extensions;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using Mapster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace amocrm.library.Tools
{
    internal class DtoModelBuilder<TEntity> where TEntity : EntityCore
    {
        private Type dtoType;
        private Type listType = typeof(List<>);
        private Type genericListType;

        public Object GetUpdateModel(IEnumerable<TEntity> entities)
        {
            dtoType = typeof(TEntity).GetDtoType(ActionEnum.Update);

            return new { update = ConvertEntityCollectionToDto(entities) };
        }

        public Object GetAddModel(IEnumerable<TEntity> entities)
        {
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
    }
}
