using amocrm.library.DTO;
using Crm.Service.DTO;
using Crm.Service.Extensions;
using Crm.Service.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Service.Mappings
{
    public class ContactMaps
    {
        public ContactMaps()
        {
            TypeAdapterConfig<ContactDTO, Contact>
                .ForType()
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.Leads, src => src.Leads == null ? new List<Lead>() : src.Leads.id.Select(x => new Lead { Id = x }))
                .Map(dest => dest.Fields, src => src.CustomFields);

            TypeAdapterConfig<Contact, ContactDTO>
                .ForType()
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.Leads, src => src.Leads.Count() == 0 ? null : new LeadsDto { id = src.Leads.Select(x => x.Id).ToList() })
                .Map(dest => dest.CustomFields, src => src.Fields);


            TypeAdapterConfig<LeadDTO, Lead>
                .ForType()
                .Map(dest => dest.ClosestTaskAt, src => new DateTime().FromTimestamp(src.ClosestTaskAt))
                .Map(dest => dest.CreatedAt, src => new DateTime().FromTimestamp(src.CreatedAt))
                .Map(dest => dest.UpdatedAt, src => new DateTime().FromTimestamp(src.UpdatedAt))
                .Map(dest => dest.ClosedAt, src => new DateTime().FromTimestamp(src.ClosedAt))
                .Map(dest => dest.Fields, src => src.CustomFields);

            TypeAdapterConfig<Lead, LeadDTO>
                .ForType()
                .Map(dest => dest.ClosestTaskAt, src => src.ClosestTaskAt.ToTimestamp())
                .Map(dest => dest.CreatedAt, src => src.CreatedAt.ToTimestamp())
                .Map(dest => dest.UpdatedAt, src => src.UpdatedAt.ToTimestamp())
                .Map(dest => dest.ClosedAt, src => src.ClosedAt.ToTimestamp())
                .Map(dest => dest.CustomFields, src => src.Fields);

        }
    }
}