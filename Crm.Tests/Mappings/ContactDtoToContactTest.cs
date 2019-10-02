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
    public class ContactDtoToContactTest
    {
        ContactGetDTO dto;

        public ContactDtoToContactTest()
        {
            new InitMappings();
            dto = new ContactMockData().GetDTOs().First();
        }

        [TestMethod]
        public void ContactDtoToContact()
        {
            var contactFromDto = new ContactGetDTO().Adapt<Contact>();
            var contactFromNew = new Contact();

            var leadDto = JsonConvert.SerializeObject(contactFromDto).ToString();
            var lead = JsonConvert.SerializeObject(contactFromNew).ToString();

            Assert.AreEqual(leadDto, lead);
        }

        [TestMethod] public void Id() => Assert.AreEqual(dto.Adapt<Contact>().Id, 29127849);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(dto.Adapt<Contact>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(dto.Adapt<Contact>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(dto.Adapt<Contact>().GroupId, 212704);
        [TestMethod] public void UpdatedBy() => Assert.AreEqual(dto.Adapt<Contact>().UpdatedBy, 2997712);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(dto.Adapt<Contact>().CreatedBy, 2997712);

        [TestMethod] public void Name() => Assert.AreEqual(dto.Adapt<Contact>().Name, "Иджян Илья");
        [TestMethod] public void NameIsEmpty() => Assert.AreEqual(new ContactGetDTO().Adapt<Contact>().Name, string.Empty);
        [TestMethod] public void NameIsNotNull() => Assert.IsNotNull(new ContactGetDTO().Adapt<Contact>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(dto.Adapt<Contact>().CreatedAt, new DateTime().FromTimestamp(1549370109));
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new ContactGetDTO().Adapt<Contact>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(dto.Adapt<Contact>().UpdatedAt, new DateTime().FromTimestamp(1563233551));
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new ContactGetDTO().Adapt<Contact>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(dto.Adapt<Contact>().ClosestTaskAt, new DateTime().FromTimestamp(1567630740));
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new ContactGetDTO().Adapt<Contact>().ClosestTaskAt, DateTime.MinValue);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Contact>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(dto.Adapt<Contact>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(dto.Adapt<Contact>().Tags[0].Id, 246241);
        [TestMethod] public void TagsIsNull() => Assert.IsNotNull(new ContactGetDTO().Adapt<Contact>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Contact>().Fields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(dto.Adapt<Contact>().Fields.Count, 12);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(dto.Adapt<Contact>().Fields[0].Id, 72337);
        [TestMethod] public void FieldsValue() => Assert.AreEqual(dto.Adapt<Contact>().Fields[0].Values[0].Value, "Москва");
        [TestMethod] public void FieldsIsNull() => Assert.IsNotNull(new ContactGetDTO().Adapt<Contact>().Fields);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(dto.Adapt<Contact>().Leads, typeof(IEnumerable<int>));
        [TestMethod] public void LeadsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Contact>().Leads, null);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(dto.Adapt<Contact>().Leads.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(dto.Adapt<Contact>().Leads.First(), 12927239);
        [TestMethod] public void LeadsIsNull() => Assert.IsNotNull(new ContactGetDTO().Adapt<Contact>().Leads);

        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(dto.Adapt<Contact>().Company, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(dto.Adapt<Contact>().Company.Id, 33478747);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(dto.Adapt<Contact>().Customers, typeof(IEnumerable<int>));
        [TestMethod] public void CustomersIsNotNull() => Assert.AreNotEqual(dto.Adapt<Contact>().Customers, null);
        [TestMethod] public void CustomersHasValue() => Assert.AreEqual(dto.Adapt<Contact>().Customers.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(dto.Adapt<Contact>().Customers.First(), 555555);
        [TestMethod] public void CustomersIsNull() => Assert.IsNotNull(new ContactGetDTO().Adapt<Contact>().Customers);
    }
}
