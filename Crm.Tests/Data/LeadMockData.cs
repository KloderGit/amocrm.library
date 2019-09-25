using amocrm.library.DTO;
using amocrm.library.Models.Fields;
using amocrm.library.Models;
using System.Collections.Generic;
using System.Collections;

namespace Crm.Tests.Data
{
    internal static class LeadMockData
    {
        public static IEnumerable<Lead> GetLeads()
        {
            var lead = new Lead()
            {
                Id = 8663699,
                AccountId = 17769199,
                ClosedAt = new System.DateTime(2019,9,30),
                ClosestTaskAt = new System.DateTime(2019, 9, 11),
                CreatedAt = new System.DateTime(2019, 9, 10),
                CreatedBy = 2081797,
                GroupId = 212704,
                IsDeleted = false,
                LossReason = 955438,
                Name = "Тестовая сделка",
                PipelineId = 1020193,
                Price = 10000,
                ResponsibleUserId = 2997712,
                Status = 143,
                UpdatedAt = new System.DateTime(2019, 9, 12),

                MainContact = 29127849,
                Company = new SimpleObject { Id = 33478747, Name = "Какоето название компании" },
                Tags = new List<SimpleObject> { new SimpleObject { Id = 266651, Name = "бартер" }, new SimpleObject { Id = 288043, Name = "оплачено" } },
                Contacts = new List<int> { 29127849, 29127848 },
                Pipeline = 1020193,
                Fields = new List<Field> {
                    new Field{ Id = 66339, Name = "Источник", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 139517, Value = "Сайт" } } },
                    new Field{ Id = 66349, Name = "Интересующая услуга", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 139967, Value = "Восстановление двигательной активности" } } },
                    new Field{ Id = 579887, Name = "Группа обучения [ очное ]", IsSystem = false, Values = new List<FieldValue>{ new FieldValue { Enum = 1203319, Value = "№ 190 ПТ" } } }
                }
            };

            return new List<Lead> { lead };
        }

        public static IEnumerable<LeadGetDTO> GetLeadDTO()
        {
            var leadDto1 = new LeadGetDTO()
            {
                Id = 8663699,
                AccountId = 17769199,
                ClosedAt = 1567514942,
                ClosestTaskAt = 1567630740,
                CreatedAt = 1527690442,
                CreatedBy = 2081797,
                GroupId = 212704,
                IsDeleted = false,
                LossReason = 955438,
                Name = "Тестовая сделка",
                PipelineId = 1020193,
                Price = 10000,
                ResponsibleUserId = 2997712,
                Status = 143,
                UpdatedAt = 1567519347,                 

                MainContact = new SimpleDtoObject { Id = 29127849 },
                Company = new SimpleDtoObject { Id = 33478747, Name = "Какоето название компании" },
                Tags = new List<SimpleDtoObject> { new SimpleDtoObject { Id = 266651, Name = "бартер" }, new SimpleDtoObject { Id = 288043, Name = "оплачено" } },
                Contacts = new LinkedDataList { Id = new List<int> { 29127849, 29127848 } },
                Pipeline = new SimpleDtoObject { Id = 1020193 },
                CustomFields = new List<CustomFieldsDto> {
                    new CustomFieldsDto{ Id = 66339, Name = "Источник", IsSystem = false, Values = new List<Values>{ new Values { Enum = 139517, Value = "Сайт" } } },
                    new CustomFieldsDto{ Id = 66349, Name = "Интересующая услуга", IsSystem = false, Values = new List<Values>{ new Values { Enum = 139967, Value = "Восстановление двигательной активности" } } },
                    new CustomFieldsDto{ Id = 579887, Name = "Группа обучения [ очное ]", IsSystem = false, Values = new List<Values>{ new Values { Enum = 1203319, Value = "№ 190 ПТ" } } }
                }
            };

            return new List<LeadGetDTO> { leadDto1 };
        }
    }
}
