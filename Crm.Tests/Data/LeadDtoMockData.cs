using amocrm.library.DTO;
using System.Collections.Generic;

namespace Crm.Tests.Data
{
    internal static class LeadDtoMockData
    {
        public static IEnumerable<LeadDTO> GetLeadDTO()
        {
            var leadDto1 = new LeadDTO()
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

                MainContact = new MainContactField { Id = 29127849 },
                Company = new CompanyField { Id = 33478747, Name = "Какоето название компании" },
                Tags = new List<TagDto> { new TagDto { Id = 266651, Name = "бартер" }, new TagDto { Id = 288043, Name = "оплачено" } },
                Contacts = new ContactsField { Id = new List<int> { 29127849, 29127848 } },
                Pipeline = new PipelineField { Id = 1020193 },
                CustomFields = new List<CustomFieldsDto> {
                    new CustomFieldsDto{ Id = 66339, Name = "Источник", IsSystem = false, Values = new List<Values>{ new Values { Enum = 139517, Value = "Сайт" } } },
                    new CustomFieldsDto{ Id = 66349, Name = "Интересующая услуга", IsSystem = false, Values = new List<Values>{ new Values { Enum = 139967, Value = "Восстановление двигательной активности" } } },
                    new CustomFieldsDto{ Id = 579887, Name = "Группа обучения [ очное ]", IsSystem = false, Values = new List<Values>{ new Values { Enum = 1203319, Value = "№ 190 ПТ" } } }
                }
            };

            return new List<LeadDTO> { leadDto1 };

        }
    }
}
