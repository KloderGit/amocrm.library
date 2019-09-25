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
    public class ContactToContactAddDtoTest
    {
        Contact array = new ContactMockData().GetContacts().First();

        public ContactToContactAddDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.


            var contact = new Contact();
            contact.Fields.Add(new Field
            {
                FieldType = 5,
                Id = 555,
                IsSystem = false,
                Name = "",
                Values = new List<FieldValue>
                {
                 new FieldValue { Enum = 654, Value = "OOO" },
                 new FieldValue { Enum = 345, Value = "GGG" },
                 new FieldValue { Enum = 678, Value = "EEE" }
                }
            });
            contact.Fields.Add(new Field
            {
                FieldType = 3,
                Id = 555,
                IsSystem = false,
                Name = "",
                Values = new List<FieldValue>
                {
                 new FieldValue { Enum = 654, Value = "OOO" },
                 new FieldValue { Enum = 345, Value = "GGG" },
                 new FieldValue { Enum = 678, Value = "EEE" }
                }
            });

            var onv = contact.Adapt<ContactAddDTO>();


            var dtoFromContact = new Contact().Adapt<ContactAddDTO>();
            var dtoFromNew = new ContactAddDTO();

            var leadDto1 = JsonConvert.SerializeObject(dtoFromContact).ToString();
            var leadDto2 = JsonConvert.SerializeObject(dtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }

        [TestMethod] public void Name() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Name, "TestUser1");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CreatedAt, new System.DateTime(2019, 10, 1).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactAddDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(array.Adapt<ContactAddDTO>().UpdatedAt, new System.DateTime(2019, 10, 2).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactAddDTO>().UpdatedAt, 0);

        [TestMethod] public void CreatedBy() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CreatedBy, 55555);

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(array.Adapt<ContactAddDTO>().ResponsibleUserId, 77777);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactAddDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Tags, "tag1,tag2");
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().Tags);

        [TestMethod] public void CompanyNameIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactAddDTO>().CompanyName, null);
        [TestMethod] public void CompanyNameHasValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CompanyName, "TestUser1");
        [TestMethod] public void CompanyNameIsNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().CompanyName);

        [TestMethod] public void CompanyIdtIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactAddDTO>().CompanyId, 0);
        [TestMethod] public void CompanyIdHasValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CompanyId, 95123);
        [TestMethod] public void CompanyIdIsNull() => Assert.AreEqual(new Contact().Adapt<ContactAddDTO>().CompanyId, 0);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(array.Adapt<ContactAddDTO>().Leads, typeof(IEnumerable<int>));
        [TestMethod] public void LeadsIsNotNull() => Assert.IsNotNull(array.Adapt<ContactAddDTO>().Leads);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Leads.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Leads.First(), 963369);
        [TestMethod] public void LeadsIsNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().Leads);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(array.Adapt<ContactAddDTO>().Customers, typeof(IEnumerable<int>));
        [TestMethod] public void CustomersIsNotNull() => Assert.IsNotNull(array.Adapt<ContactAddDTO>().Customers);
        [TestMethod] public void CustomersHasValues() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Customers.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().Customers.First(), 987654);
        [TestMethod] public void CustomersIsNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().Customers);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactAddDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(array.Adapt<ContactAddDTO>().CustomFields[0].Id, 112);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Contact().Adapt<ContactAddDTO>().CustomFields);


        [TestMethod]
        public void FieldsArrayValues()
        {
            Assert.IsNull(new Contact().Adapt<ContactAddDTO>().CustomFields);
        }
    }
}
