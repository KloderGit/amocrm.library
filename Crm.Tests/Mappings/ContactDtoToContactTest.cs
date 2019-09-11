using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class ContactDtoToContactTest
    {
        public ContactDtoToContactTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void ContactDtoToContact()
        {
            var contactFromDto = new ContactDTO().Adapt<Contact>();
            var contactFromNew = new Contact();

            var leadDto = JsonConvert.SerializeObject(contactFromDto).ToString();
            var lead = JsonConvert.SerializeObject(contactFromNew).ToString();

            Assert.AreEqual(leadDto, lead);
        }


        [TestMethod]
        public void IntTest()
        {
            var contact = new ContactDTO { Id = 0 }.Adapt<Contact>();
            var contactValue = new ContactDTO { Id = 123 }.Adapt<Contact>();

            Assert.AreEqual(contact.Id, 0);
            Assert.AreEqual(contactValue.Id, 123);
        }

        [TestMethod]
        public void IntToDateTest()
        {
            var contact = new ContactDTO() { CreatedAt = 0 }.Adapt<Contact>();
            var contactValue = new ContactDTO() { CreatedAt = 1527690442 }.Adapt<Contact>();

            Assert.AreEqual(contact.CreatedAt, DateTime.MinValue);
            Assert.AreEqual(contactValue.CreatedAt, new DateTime().FromTimestamp(1527690442));
        }

        [TestMethod]
        public void StringTest()
        {
            var contact = new ContactDTO() { Name = null }.Adapt<Contact>();
            var contactValue = new ContactDTO() { Name = "Some Name" }.Adapt<Contact>();

            Assert.AreEqual(contact.Name, String.Empty);
            Assert.AreEqual(contactValue.Name, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var contact = new ContactDTO() { Company = null }.Adapt<Contact>();
            var contactValue = new ContactDTO() { Company = new SimpleDtoObject { Id = 123 } }.Adapt<Contact>();

            Assert.AreEqual(contact.Company, null);
            Assert.AreNotEqual(contactValue.Company, null);
            Assert.AreEqual(contactValue.Company.Id, 123);
        }

        [TestMethod]
        public void ListTest()
        {
            var contact = new ContactDTO() { Tags = null }.Adapt<Contact>();
            var contactValue = new ContactDTO() { Tags = new List<SimpleDtoObject> { new SimpleDtoObject { Id = 123 } } }.Adapt<Contact>();

            Assert.AreNotEqual(contact.Tags, null);
            Assert.AreEqual(contactValue.Tags[0].Id, 123);
        }
    }
}
