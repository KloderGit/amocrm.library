using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Models.Fields;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class ContactToContactDtoTest
    {
        public ContactToContactDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.

            var contact = new Contact();

            var contactFromDto = contact.Adapt<ContactDTO>();
            var contactDtoFromNew = new ContactDTO();

            var ContactDTO1 = JsonConvert.SerializeObject(contactFromDto).ToString();
            var ContactDTO2 = JsonConvert.SerializeObject(contactDtoFromNew).ToString();

            Assert.AreEqual(ContactDTO1, ContactDTO2);
        }


        [TestMethod]
        public void IntTest()
        {
            var contact = new Contact() { Id = 0 };
            var dto = contact.Adapt<ContactDTO>();

            var contactValue = new Contact() { Id = 123 };
            var dtoValue = contactValue.Adapt<ContactDTO>();

            Assert.AreEqual(dto.Id, 0);
            Assert.AreEqual(dtoValue.Id, 123);
        }

        [TestMethod]
        public void DateToIntTest()
        {
            var contact = new Contact() { CreatedAt = DateTime.MinValue };
            var dto = contact.Adapt<ContactDTO>();

            var contactValue = new Contact() { CreatedAt = new DateTime(2019, 11, 10) };
            var dtoValue = contactValue.Adapt<ContactDTO>();

            Assert.AreEqual(dto.CreatedAt, 0);
            Assert.AreEqual(dtoValue.CreatedAt, new DateTime(2019, 11, 10).ToTimestamp());
        }

        [TestMethod]
        public void StringTest()
        {
            var contact = new Contact() { Name = String.Empty };
            var dto = contact.Adapt<ContactDTO>();

            var contactValue = new Contact() { Name = "Some Name" };
            var dtoValue = contactValue.Adapt<ContactDTO>();

            Assert.AreEqual(dto.Name, null);
            Assert.AreEqual(dtoValue.Name, "Some Name");
        }

        [TestMethod]
        public void ObjectTest()
        {
            var contact = new Contact() { Company = null };
            var dto = contact.Adapt<ContactDTO>();

            var contactValue = new Contact() { Company = new SimpleObject { Id = 123 } };
            var dtoValue = contactValue.Adapt<ContactDTO>();

            Assert.AreEqual(dto.Company, null);
            Assert.AreNotEqual(dtoValue.Company, null);
            Assert.AreEqual(dtoValue.Company.Id, 123);
        }

        [TestMethod]
        public void ListTest()
        {
            var contact = new Contact() { Tags = null };
            var dto = contact.Adapt<ContactDTO>();

            var contactValue = new Contact() { Tags = new List<SimpleObject> { new SimpleObject { Id = 123 } } };
            var dtoValue = contactValue.Adapt<ContactDTO>();

            var contactEmptyValue = new Contact() { Tags = new List<SimpleObject>() };
            var dtoEmptyValue = contactEmptyValue.Adapt<ContactDTO>();

            Assert.AreEqual(dto.Tags, null);
            Assert.AreEqual(dtoEmptyValue.Tags, null);
            Assert.AreEqual(dtoValue.Tags[0].Id, 123);
        }
    }

}

