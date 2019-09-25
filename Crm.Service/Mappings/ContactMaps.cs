using amocrm.library.Configurations;
using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Models;
using Mapster;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace amocrm.library.Mappings
{
    internal class ContactMaps : CommonMaps
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

        }
    }
}