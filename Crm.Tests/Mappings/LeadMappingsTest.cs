using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class LeadDtoToLeadTest
    {
        LeadGetDTO dto;

        public LeadDtoToLeadTest()
        {
            new LeadtMaps();

            dto = LeadMockData.GetLeadDTO().First();
        }

        [TestMethod]
        public void MapEmptyLeadDtoToLead()
        {
            var leadFromDto = new LeadGetDTO().Adapt<Lead>();
            var leadFromNew = new Lead();

            var leadDto = JsonConvert.SerializeObject(leadFromDto).ToString();
            var lead = JsonConvert.SerializeObject(leadFromNew).ToString();

            Assert.AreEqual(leadDto, lead);
        }


        [TestMethod] public void Id() => Assert.AreEqual(dto.Adapt<Lead>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(dto.Adapt<Lead>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(dto.Adapt<Lead>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(dto.Adapt<Lead>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(dto.Adapt<Lead>().CreatedBy, 2081797);

        [TestMethod] public void Name() => Assert.AreEqual(dto.Adapt<Lead>().Name, "Тестовая сделка");
        [TestMethod] public void NameIsEmpty() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().Name, string.Empty);
        [TestMethod] public void NameIsNotNull() => Assert.IsNotNull(new LeadGetDTO().Adapt<Lead>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(dto.Adapt<Lead>().CreatedAt, new DateTime().FromTimestamp(1527690442));
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(dto.Adapt<Lead>().UpdatedAt, new DateTime().FromTimestamp(1567519347));
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(dto.Adapt<Lead>().ClosestTaskAt, new DateTime().FromTimestamp(1567630740));
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().ClosestTaskAt, DateTime.MinValue);

        [TestMethod] public void ClosedAt() => Assert.AreEqual(dto.Adapt<Lead>().ClosedAt, new DateTime().FromTimestamp(1567514942));
        [TestMethod] public void ClosedAtZero() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().ClosedAt, DateTime.MinValue);

        [TestMethod] public void IsDeleted() => Assert.AreEqual(dto.Adapt<Lead>().IsDeleted, false);
        [TestMethod] public void IsDeletedNull() => Assert.IsNull(new LeadGetDTO().Adapt<Lead>().IsDeleted);

        [TestMethod] public void LossReason() => Assert.AreEqual(dto.Adapt<Lead>().LossReason, 955438);
        [TestMethod] public void PipelineId() => Assert.AreEqual(dto.Adapt<Lead>().PipelineId, 1020193);
        [TestMethod] public void Price() => Assert.AreEqual(dto.Adapt<Lead>().Price, 10000);
        [TestMethod] public void Status() => Assert.AreEqual(dto.Adapt<Lead>().Status, 143);

        [TestMethod] public void MainContactIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().MainContact, null);
        [TestMethod] public void MainContactHasValue() => Assert.AreEqual(dto.Adapt<Lead>().MainContact, 29127849);
        [TestMethod] public void MainContactIsNull() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().MainContact, 0);

        [TestMethod] public void CompanytIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().Company, null);
        [TestMethod] public void CompanyHasValue() => Assert.AreEqual(dto.Adapt<Lead>().Company.Id, 33478747);
        [TestMethod] public void CompanyIsNull() => Assert.IsNull(new LeadGetDTO().Adapt<Lead>().Company);

        [TestMethod] public void PipelineIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().Pipeline, null);
        [TestMethod] public void PipelineHasValue() => Assert.AreEqual(dto.Adapt<Lead>().Pipeline, 1020193);
        [TestMethod] public void PipelineIsNull() => Assert.AreEqual(new LeadGetDTO().Adapt<Lead>().Pipeline, 0);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(dto.Adapt<Lead>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(dto.Adapt<Lead>().Tags[0].Id, 266651);
        [TestMethod] public void TagsIsNull() => Assert.IsNotNull(new LeadGetDTO().Adapt<Lead>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().Fields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(dto.Adapt<Lead>().Fields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(dto.Adapt<Lead>().Fields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNotNull(new LeadGetDTO().Adapt<Lead>().Fields);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(dto.Adapt<Lead>().Contacts, typeof(IEnumerable<int>));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Lead>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(dto.Adapt<Lead>().Contacts.Count(), 2);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(dto.Adapt<Lead>().Contacts.First(), 29127849);
        [TestMethod] public void ContactsIsNull() => Assert.IsNotNull(new LeadGetDTO().Adapt<Lead>().Contacts);

    }
}
