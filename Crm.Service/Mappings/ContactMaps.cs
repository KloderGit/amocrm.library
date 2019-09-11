using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Mappings
{
    public class ContactMaps
    {
        public ContactMaps()
        {
            TypeAdapterConfig<ContactDTO, Contact>
                .NewConfig()
                .Map(dest => dest.Name, src => isNull(src.Name) ? string.Empty : src.Name)
                .Map(dest => dest.Fields, src => isNull(src.CustomFields) ? new List<CustomFieldsDto>() : src.CustomFields)
                .Map(dest => dest.Tags, src => isNull(src.Tags) ? new List<SimpleDtoObject>() : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.Leads, src => src.Leads == null ? new List<int>() : src.Leads.Id);

            TypeAdapterConfig<Contact, ContactDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Leads, src => src.Leads.Count() == 0 ? null : new LinkedDataList { Id = src.Leads.ToList() });


            TypeAdapterConfig<LeadDTO, Lead>
                .NewConfig()
                .Map(dest => dest.Name, src => isNull(src.Name) ? string.Empty : src.Name)
                .Map(dest => dest.Fields, src => isNull(src.CustomFields) ? new List<CustomFieldsDto>() : src.CustomFields)
                .Map(dest => dest.Tags, src => isNull(src.Tags) ? new List<SimpleDtoObject>() : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.ClosedAt, src => new DateTime().FromTimestamp(src.ClosedAt));

            TypeAdapterConfig<Lead, LeadDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.ClosedAt, src => src.ClosedAt.ToTimestamp());



            TypeAdapterConfig<TaskDTO, Task>
                .NewConfig()
                .Map(dest => dest.Text, src => isNull(src.Text) ? string.Empty : src.Text)
                .Map(dest => dest.CompleteTillAt, src => new DateTime().FromTimestamp(src.CompleteTillAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt));

            TypeAdapterConfig<Task, TaskDTO>
                .NewConfig()
                .Map(dest => dest.Text, src => String.IsNullOrEmpty(src.Text) ? null : src.Text)
                .Map(dest => dest.CompleteTillAt, src => src.CompleteTillAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp());



            TypeAdapterConfig<NoteDTO, Note>
                .NewConfig()
                .Map(dest => dest.Text, src => isNull(src.Text) ? string.Empty : src.Text)
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt));

            TypeAdapterConfig<Note, NoteDTO>
                .NewConfig()
                .Map(dest => dest.Text, src => String.IsNullOrEmpty(src.Text) ? null : src.Text)
                .Map(dest => dest.Attachment, src => String.IsNullOrEmpty(src.Attachment) ? null : src.Attachment)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp());


            TypeAdapterConfig<CompanyDTO, Company>
                .NewConfig()
                .Map(dest => dest.Fields, src => isNull(src.CustomFields) ? new List<CustomFieldsDto>() : src.CustomFields)
                .Map(dest => dest.Tags, src => isNull(src.Tags) ? new List<SimpleDtoObject>() : src.Tags)
                .Map(dest => dest.Name, src => isNull(src.Name) ? string.Empty : src.Name)
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.Leads, src => src.Leads == null ? new List<int>() : src.Leads.Id)
                .Map(dest => dest.Contacts, src => src.Contacts == null ? new List<int>() : src.Contacts.Id)
                .Map(dest => dest.Customers, src => src.Customers == null ? new List<int>() : src.Customers.Id);

            TypeAdapterConfig<Company, CompanyDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Leads, src => src.Leads.Count() == 0 ? null : new LinkedDataList { Id = src.Leads.ToList() })
                .Map(dest => dest.Contacts, src => src.Contacts.Count() == 0 ? null : new LinkedDataList { Id = src.Contacts.ToList() })
                .Map(dest => dest.Customers, src => src.Customers.Count() == 0 ? null : new LinkedDataList { Id = src.Customers.ToList() });

        }

        bool isNull(object item)
        {
            return item == null ? true : false;
        }
    }
}