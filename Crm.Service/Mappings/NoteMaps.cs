using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Mappings
{
    public class NoteMaps
    {
        public NoteMaps()
        {
             TypeAdapterConfig<NoteGetDTO, Note>
                .NewConfig()
                .Map(dest => dest.Text, src => isNull(src.Text) ? string.Empty : src.Text)
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt));

            TypeAdapterConfig<Note, NoteGetDTO>
                .NewConfig()
                .Map(dest => dest.Text, src => String.IsNullOrEmpty(src.Text) ? null : src.Text)
                .Map(dest => dest.Attachment, src => String.IsNullOrEmpty(src.Attachment) ? null : src.Attachment)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp());

            TypeAdapterConfig<Note, NoteUpdateDTO>
                .NewConfig()
                .Map(dest => dest.Text, src => String.IsNullOrEmpty(src.Text) ? null : src.Text)
                .Map(dest => dest.ElementType, src => Enum.GetName(typeof(ElementTypeEnum), src.ElementType))
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp());

            TypeAdapterConfig<Note, NoteAddDTO>
                .NewConfig()
                .Map(dest => dest.Text, src => String.IsNullOrEmpty(src.Text) ? null : src.Text)
                .Map(dest => dest.Attachment, src => String.IsNullOrEmpty(src.Attachment) ? null : src.Attachment)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp());
        }

        bool isNull(object item)
        {
            return item == null ? true : false;
        }
    }
}