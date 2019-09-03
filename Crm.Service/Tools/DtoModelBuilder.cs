using Crm.Service.Extensions;
using Crm.Service.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Service.Tools
{
    internal class DtoModelBuilder<TEntity> where TEntity : EntityCore
    {
        private Type dtoType = typeof(TEntity).GetDtoType();
        private Type listType = typeof(List<>);
        private Type genericListType;

        public DtoModelBuilder()
        {
            genericListType = listType.MakeGenericType(this.dtoType);
        }

        public Object GetUpdateModel(IEnumerable<TEntity> entities)
        {
            entities.ToList().ForEach(x => x.UpdatedAt = DateTime.Now);
            return new { update = ConvertEntityCollectionToDto(entities) };
        }

        public Object GetAddModel(IEnumerable<TEntity> entities)
        {
            return new { add = ConvertEntityCollectionToDto(entities) };
        }

        private Object ConvertEntityCollectionToDto(object elements)
        {
            return elements.Adapt(elements.GetType(), this.genericListType);
        }
    }
}
