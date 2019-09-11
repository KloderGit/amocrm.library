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

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class LeadToLeadDtoTest
    {
        IEnumerable<Lead> array = LeadMockData.GetLeads();

        public LeadToLeadDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.

            var lead = new Lead();

            var leadDtoFromLead = lead.Adapt<LeadDTO>();
            var leadDtoFromNew = new LeadDTO();

            var leadDto1 = JsonConvert.SerializeObject(leadDtoFromLead).ToString();
            var leadDto2 = JsonConvert.SerializeObject(leadDtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }


        [TestMethod]
        public void IntTest()
        {
            var lead = new Lead() { Id = 0 };
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { Id = 123 };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.Id, 0);
            Assert.AreEqual(dtoValue.Id, 123);
        }

        [TestMethod]
        public void DateToIntTest()
        {
            var lead = new Lead() { CreatedAt = DateTime.MinValue };
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { CreatedAt = new DateTime( 2019, 11, 10) };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.CreatedAt, 0);
            Assert.AreEqual(dtoValue.CreatedAt, new DateTime(2019, 11, 10).ToTimestamp());
        }

        [TestMethod]
        public void StringTest()
        {
            var lead = new Lead() { Name = String.Empty };
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { Name = "Some Name" };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.Name, null);
            Assert.AreEqual(dtoValue.Name, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var lead = new Lead() { MainContact = null};
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { MainContact = new IdSingle { Id = 123 } };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.MainContact, null);
            Assert.AreNotEqual(dtoValue.MainContact, null);
            Assert.AreEqual(dtoValue.MainContact.Id, 123);
        }

        [TestMethod]
        public void ListTest()
        {
            var lead = new Lead() { Tags = null };
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { Tags = new List<SimpleObject> { new SimpleObject { Id = 123 } } };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            var leadEmptyValue = new Lead() { Tags = new List<SimpleObject>() };
            var dtoEmptyValue = leadEmptyValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.Tags, null);
            Assert.AreEqual(dtoEmptyValue.Tags, null);
            Assert.AreEqual(dtoValue.Tags[0].Id, 123);
        }

        [TestMethod]
        public void BoolTest()
        {
            var lead = new Lead() { IsDeleted = null };
            var dto = lead.Adapt<LeadDTO>();

            var leadValue = new Lead() { IsDeleted = true };
            var dtoValue = leadValue.Adapt<LeadDTO>();

            Assert.AreEqual(dto.IsDeleted, null);
            Assert.AreEqual(dtoValue.IsDeleted, true);
        }
    }
}
