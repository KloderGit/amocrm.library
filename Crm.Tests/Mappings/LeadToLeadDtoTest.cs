using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Models.Fields;
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
    public class LeadToLeadDtoTest
    {
        LeadDTO array = LeadMockData.GetLeadDTO().First();

        public LeadToLeadDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.


            var leadDtoFromLead = new Lead().Adapt<LeadDTO>();
            var leadDtoFromNew = new LeadDTO();

            var leadDto1 = JsonConvert.SerializeObject(leadDtoFromLead).ToString();
            var leadDto2 = JsonConvert.SerializeObject(leadDtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(array.Adapt<LeadDTO>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(array.Adapt<LeadDTO>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(array.Adapt<LeadDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(array.Adapt<LeadDTO>().GroupId, 212704);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(array.Adapt<LeadDTO>().CreatedBy, 2081797);

        [TestMethod] public void Name() => Assert.AreEqual(array.Adapt<LeadDTO>().Name, "Тестовая сделка");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(array.Adapt<LeadDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(array.Adapt<LeadDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadDTO>().UpdatedAt, 0);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(array.Adapt<LeadDTO>().ClosestTaskAt, 1567630740);
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new Lead().Adapt<LeadDTO>().ClosestTaskAt, 0);

        [TestMethod] public void ClosedAt() => Assert.AreEqual(array.Adapt<LeadDTO>().ClosedAt, 1567514942);
        [TestMethod] public void ClosedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadDTO>().ClosedAt, 0);

        [TestMethod] public void IsDeleted() => Assert.AreEqual(array.Adapt<LeadDTO>().IsDeleted, false);
        [TestMethod] public void IsDeletedNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().IsDeleted);

        [TestMethod] public void LossReason() => Assert.AreEqual(array.Adapt<LeadDTO>().LossReason, 955438);
        [TestMethod] public void PipelineId() => Assert.AreEqual(array.Adapt<LeadDTO>().PipelineId, 1020193);
        [TestMethod] public void Price() => Assert.AreEqual(array.Adapt<LeadDTO>().Price, 10000);
        [TestMethod] public void Status() => Assert.AreEqual(array.Adapt<LeadDTO>().Status, 143);

        [TestMethod] public void MainContactIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().MainContact, null);
        [TestMethod] public void MainContactHasValue() => Assert.AreEqual(array.Adapt<LeadDTO>().MainContact.Id, 29127849);
        [TestMethod] public void MainContactIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().MainContact);

        [TestMethod] public void CompanytIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().Company, null);
        [TestMethod] public void CompanyHasValue() => Assert.AreEqual(array.Adapt<LeadDTO>().Company.Id, 33478747);
        [TestMethod] public void CompanyIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().Company);

        [TestMethod] public void PipelineIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().Pipeline, null);
        [TestMethod] public void PipelineHasValue() => Assert.AreEqual(array.Adapt<LeadDTO>().Pipeline.Id, 1020193);
        [TestMethod] public void PipelineIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().Pipeline);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(array.Adapt<LeadDTO>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(array.Adapt<LeadDTO>().Tags[0].Id, 266651);
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(array.Adapt<LeadDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(array.Adapt<LeadDTO>().CustomFields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().CustomFields);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(array.Adapt<LeadDTO>().Contacts, typeof(LinkedDataList));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadDTO>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(array.Adapt<LeadDTO>().Contacts.Id.Count(), 2);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(array.Adapt<LeadDTO>().Contacts.Id.First(), 29127849);
        [TestMethod] public void ContactsIsNull() => Assert.IsNull(new Lead().Adapt<LeadDTO>().Contacts);
    }
}
