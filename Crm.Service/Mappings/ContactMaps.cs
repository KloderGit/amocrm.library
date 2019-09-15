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
            TypeAdapterConfig<ContactGetDTO, Contact>
                .NewConfig()
                .Map(dest => dest.Name, src => isNull(src.Name) ? string.Empty : src.Name)
                .Map(dest => dest.Fields, src => isNull(src.CustomFields) ? new List<CustomFieldsDto>() : src.CustomFields)
                .Map(dest => dest.Tags, src => isNull(src.Tags) ? new List<SimpleDtoObject>() : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.Leads, src => src.Leads == null ? new List<int>() : src.Leads.Id)
                .Map(dest => dest.Customers, src => src.Customers == null ? new List<int>() : src.Customers.Id);

            TypeAdapterConfig<Contact, ContactGetDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Leads, src => src.Leads.Count() == 0 ? null : new LinkedDataList { Id = src.Leads.ToList() })
                .Map(dest => dest.Customers, src => src.Customers == null || src.Customers.Count() == 0 ? null : new LinkedDataList { Id = new List<int>(src.Customers) });

            TypeAdapterConfig<Contact, ContactUpdateDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : String.Join(",", src.Tags.Select(x => x.Name)))
                .Map(dest => dest.CompanyName, src => src.Company == null || String.IsNullOrEmpty(src.Company.Name) ? null : src.Name)
                .Map(dest => dest.CompanyId, src => src.Company == null || src.Company.Id == 0 ? 0 : src.Company.Id)
                .Map(dest => dest.Leads, src => src.Leads == null || src.Leads.Count() == 0 ? null : src.Leads)
                .Map(dest => dest.Customers, src => src.Customers == null || src.Customers.Count() == 0 ? null : src.Customers)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields);


            TypeAdapterConfig<Contact, ContactAddDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : String.Join(",", src.Tags.Select(x => x.Name)))
                .Map(dest => dest.CompanyName, src => src.Company == null || String.IsNullOrEmpty(src.Company.Name) ? null : src.Name)
                .Map(dest => dest.CompanyId, src => src.Company == null || src.Company.Id == 0 ? 0 : src.Company.Id)
                .Map(dest => dest.Leads, src => src.Leads == null || src.Leads.Count() == 0 ? null : src.Leads)
                .Map(dest => dest.Customers, src => src.Customers == null || src.Customers.Count() == 0 ? null : src.Customers)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields);



            TypeAdapterConfig<LeadGetDTO, Lead>
                .NewConfig()
                .Map(dest => dest.Name, src => isNull(src.Name) ? string.Empty : src.Name)
                .Map(dest => dest.Fields, src => isNull(src.CustomFields) ? new List<CustomFieldsDto>() : src.CustomFields)
                .Map(dest => dest.Tags, src => isNull(src.Tags) ? new List<SimpleDtoObject>() : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.ClosedAt, src => new DateTime().FromTimestamp(src.ClosedAt))
                .Map(dest => dest.Contacts, src => src.Contacts == null ? new List<int>() : src.Contacts.Id)
                .Map(dest => dest.MainContact, src => src.MainContact == null ? 0 : src.MainContact.Id)
                .Map(dest => dest.Pipeline, src => src.Pipeline == null ? 0 : src.Pipeline.Id);

            TypeAdapterConfig<Lead, LeadGetDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags)
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.ClosedAt, src => src.ClosedAt.ToTimestamp())
                .Map(dest => dest.Contacts, src => src.Contacts == null || src.Contacts.Count == 0 ? null : new LinkedDataList { Id = src.Contacts })
                .Map(dest => dest.MainContact, src => src.MainContact == 0 ? null : new SimpleDtoObject { Id = src.MainContact })
                .Map(dest => dest.Pipeline, src => src.Pipeline == 0 ? null : new SimpleDtoObject { Id = src.Pipeline });



            TypeAdapterConfig<Lead, LeadUpdateDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags.Select(x => x.Name))
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Contacts, src => src.Contacts == null || src.Contacts.Count == 0 ? null : src.Contacts)
                .Map(dest => dest.Company, src => src.Company == null ? 0 : src.Company.Id);


            TypeAdapterConfig<Lead, LeadAddDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields)
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : src.Tags.Select(x => x.Name))
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Contacts, src => src.Contacts == null || src.Contacts.Count == 0 ? null : src.Contacts)
                .Map(dest => dest.Company, src => src.Company == null ? 0 : src.Company.Id);


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


            TypeAdapterConfig<CompanyGetDTO, Company>
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

            TypeAdapterConfig<Company, CompanyGetDTO>
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


            TypeAdapterConfig<Company, CompanyUpdateDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : String.Join(",", src.Tags.Select(x => x.Name)))
                .Map(dest => dest.Leads, src => src.Leads == null || src.Leads.Count() == 0 ? null : src.Leads)
                .Map(dest => dest.Contacts, src => src.Contacts == null || src.Contacts.Count() == 0 ? null : src.Contacts)
                .Map(dest => dest.Customers, src => src.Customers == null || src.Customers.Count() == 0 ? null : src.Customers)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields);


            TypeAdapterConfig<Company, CompanyAddDTO>
                .NewConfig()
                .Map(dest => dest.Name, src => String.IsNullOrEmpty(src.Name) ? null : src.Name)
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Tags, src => src.Tags == null || src.Tags.Count == 0 ? null : String.Join(",", src.Tags.Select(x => x.Name)))
                .Map(dest => dest.Leads, src => src.Leads == null || src.Leads.Count() == 0 ? null : src.Leads)
                .Map(dest => dest.Contacts, src => src.Contacts == null || src.Contacts.Count() == 0 ? null : src.Contacts)
                .Map(dest => dest.Customers, src => src.Customers == null || src.Customers.Count() == 0 ? null : src.Customers)
                .Map(dest => dest.CustomFields, src => src.Fields == null || src.Fields.Count == 0 ? null : src.Fields);
        }

        bool isNull(object item)
        {
            return item == null ? true : false;
        }
    }
}