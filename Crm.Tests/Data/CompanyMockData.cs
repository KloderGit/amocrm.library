using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Models;
using amocrm.library.Models.Fields;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.Data
{
    public static class CompanyMockData
    {
        internal static IEnumerable<CompanyGetDTO> GetCompanyGetDTO()
        {
            var dto = new CompanyGetDTO
            {
                Id = 8663699,
                AccountId = 17769199,
                ClosestTaskAt = 1567630740,
                CreatedAt = 1527690442,
                CreatedBy = 2081797,
                GroupId = 212704,
                Name = "Company Name",
                ResponsibleUserId = 2997712,
                UpdatedAt = 1567519347,
                UpdatedBy = 2997712,
                Contacts = new LinkedDataList { Id = new List<int> { 888, 999, 777 } },
                Customers = new LinkedDataList { Id = new List<int> { 444, 555, 666 } },
                Leads = new LinkedDataList { Id = new List<int> { 111, 222, 333 } },
                Tags = new List<SimpleDtoObject> { new SimpleDtoObject { Id = 123, Name = "tag1" }, new SimpleDtoObject { Id = 456, Name = "tag2" } },
                CustomFields = new List<CustomFieldsDto>
                {
                    new CustomFieldsDto { Id = 66339, Name = "Директор", IsSystem = false, Values = new List<Values> { new Values { Enum = 139517, Value = "Дмитрий" } } },
                    new CustomFieldsDto { Id = 66349, Name = "Адрес", IsSystem = false, Values = new List<Values> { new Values { Enum = 139967, Value = "Москва" } } },
                    new CustomFieldsDto { Id = 579887, Name = "БИК", IsSystem = false, Values = new List<Values> { new Values { Enum = 1203319, Value = "889977" } } }
                }                 
            };

            return new List<CompanyGetDTO> { dto };
        }

        public static IEnumerable<Company> GetCompany()
        {
            var company = new Company
            {
                Id = 8663699,
                AccountId = 17769199,
                ClosestTaskAt = new DateTime().FromTimestamp(1567630740),
                CreatedAt = new DateTime().FromTimestamp(1527690442),
                CreatedBy = 2081797,
                GroupId = 212704,
                Name = "Company Name",
                ResponsibleUserId = 2997712,
                UpdatedAt = new DateTime().FromTimestamp(1567519347),
                UpdatedBy = 2997712,
                Contacts = new List<int> { 888, 999, 777 },
                Customers = new List<int> { 444, 555, 666 } ,
                Leads = new List<int> { 111, 222, 333 },
                Tags = new List<SimpleObject> { new SimpleObject { Id = 123, Name = "tag1" }, new SimpleObject { Id = 456, Name = "tag2" } },
                Fields = new List<Field>
                {
                    new Field { Id = 66339, Name = "Директор", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 139517, Value = "Дмитрий" } } },
                    new Field { Id = 66349, Name = "Адрес", IsSystem = false, Values = new  List<FieldValue> { new FieldValue { Enum = 139967, Value = "Москва" } } },
                    new Field { Id = 579887, Name = "БИК", IsSystem = false, Values = new List<FieldValue> { new FieldValue { Enum = 1203319, Value = "889977" } } }
                }
            };

            return new List<Company> { company };
        }
    }
}
