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
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class ContactToContactDTOTest
    {
        Contact contact;

        public ContactToContactDTOTest()
        {
            new InitMappings();

            contact = new ContactMockData().GetContacts().First();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.

            var contact = new Contact();

            var contactFromDto = contact.Adapt<ContactGetDTO>();
            var contactDtoFromNew = new ContactGetDTO();

            var ContactDTODTO1 = JsonConvert.SerializeObject(contactFromDto).ToString();
            var ContactDTODTO2 = JsonConvert.SerializeObject(contactDtoFromNew).ToString();

            Assert.AreEqual(ContactDTODTO1, ContactDTODTO2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Id, 654654);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().ResponsibleUserId, 77777);
        [TestMethod] public void AccountId() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().AccountId, 987987);
        [TestMethod] public void GroupId() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().GroupId, 8888);
        [TestMethod] public void UpdatedBy() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().UpdatedBy, 88888);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().CreatedBy, 55555);

        [TestMethod] public void Name() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Name, "TestUser1");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().CreatedAt, new DateTime(2019, 10, 1).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactGetDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().UpdatedAt, new DateTime(2019, 10, 2).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactGetDTO>().UpdatedAt, 0);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().ClosestTaskAt, new DateTime(2019, 10, 30).ToTimestamp());
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new Contact().Adapt<ContactGetDTO>().ClosestTaskAt, 0);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(contact.Adapt<ContactGetDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Tags[0].Id, 123);
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(contact.Adapt<ContactGetDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().CustomFields[0].Id, 112);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().CustomFields);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(contact.Adapt<ContactGetDTO>().Leads, typeof(LinkedDataList));
        [TestMethod] public void LeadsIsNotNull() => Assert.AreNotEqual(contact.Adapt<ContactGetDTO>().Leads, null);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Leads.Id.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Leads.Id.First(), 963369);
        [TestMethod] public void LeadsIsNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().Leads);

        [TestMethod] public void ContactDTOsIsNotNull() => Assert.AreNotEqual(contact.Adapt<ContactGetDTO>().Company, null);
        [TestMethod] public void ContactDTOsHasValues() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Company.Id, 95123);
        [TestMethod] public void ContactIsNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().Company);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(contact.Adapt<ContactGetDTO>().Customers, typeof(LinkedDataList));
        [TestMethod] public void CustomersIsNotNull() => Assert.AreNotEqual(contact.Adapt<ContactGetDTO>().Customers, null);
        [TestMethod] public void CustomersHasValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Customers.Id.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(contact.Adapt<ContactGetDTO>().Customers.Id.First(), 987654);
        [TestMethod] public void CustomersIsNull() => Assert.IsNull(new Contact().Adapt<ContactGetDTO>().Customers);
    }
}

