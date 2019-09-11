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

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class LeadDtoToLeadTest
    {
        public LeadDtoToLeadTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void MapEmptyLeadDtoToLead()
        {
            var leadFromDto = new LeadDTO().Adapt<Lead>();
            var leadFromNew = new Lead();

            var leadDto = JsonConvert.SerializeObject(leadFromDto).ToString();
            var lead = JsonConvert.SerializeObject(leadFromNew).ToString();

            Assert.AreEqual(leadDto, lead);
        }


        [TestMethod]
        public void IntTest()
        {
            var lead = new LeadDTO { Id = 0 }.Adapt<Lead>();
            var leadValue = new LeadDTO { Id = 123 }.Adapt<Lead>();

            Assert.AreEqual(lead.Id, 0);
            Assert.AreEqual(leadValue.Id, 123);
        }

        [TestMethod]
        public void IntToDateTest()
        {
            var lead = new LeadDTO() { CreatedAt = 0 }.Adapt<Lead>();
            var leadValue = new LeadDTO() { CreatedAt = 1527690442 }.Adapt<Lead>();

            Assert.AreEqual(lead.CreatedAt, DateTime.MinValue);
            Assert.AreEqual(leadValue.CreatedAt, new DateTime().FromTimestamp(1527690442));
        }

        [TestMethod]
        public void StringTest()
        {
            var lead = new LeadDTO() { Name = null }.Adapt<Lead>();
            var leadValue = new LeadDTO() { Name = "Some Name" }.Adapt<Lead>();

            Assert.AreEqual(lead.Name, String.Empty);
            Assert.AreEqual(leadValue.Name, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var lead = new LeadDTO() { MainContact = null }.Adapt<Lead>();
            var leadValue = new LeadDTO() { MainContact = new SimpleDtoObject { Id = 123 } }.Adapt<Lead>();

            Assert.AreEqual(lead.MainContact, null);
            Assert.AreNotEqual(leadValue.MainContact, null);
            Assert.AreEqual(leadValue.MainContact.Id, 123);
        }

        [TestMethod]
        public void ListTest()
        {
            var lead = new LeadDTO() { Tags = null }.Adapt<Lead>();
            var leadValue = new LeadDTO() { Tags = new List<SimpleDtoObject> { new SimpleDtoObject { Id = 123 } } }.Adapt<Lead>();

            Assert.AreNotEqual(lead.Tags, null);
            Assert.AreEqual(leadValue.Tags[0].Id, 123);
        }

        [TestMethod]
        public void BoolTest()
        {
            var lead = new LeadDTO() { IsDeleted = null }.Adapt<Lead>();
            var leadValue = new LeadDTO() { IsDeleted = true }.Adapt<Lead>();

            Assert.AreEqual(lead.IsDeleted, null);
            Assert.AreEqual(leadValue.IsDeleted, true);
        }
    }
}
