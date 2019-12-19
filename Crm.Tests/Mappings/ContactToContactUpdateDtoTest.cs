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
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class ContactToContactUpdateDtoTest
    {
        Contact array = new ContactMockData().GetContacts().First();

        public ContactToContactUpdateDtoTest()
        {
            new InitMappings();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.


            var dtoFromContact = new Contact().Adapt<ContactUpdateDTO>();
            var dtoFromNew = new ContactUpdateDTO();

            var leadDto1 = JsonConvert.SerializeObject(dtoFromContact).ToString();
            var leadDto2 = JsonConvert.SerializeObject(dtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Id, 654654);

        [TestMethod] public void Name() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Name, "TestUser1");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CreatedAt, new System.DateTime(2019, 10, 1).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactUpdateDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().UpdatedAt, new System.DateTime(2019, 10, 2).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Contact().Adapt<ContactUpdateDTO>().UpdatedAt, 0);

        [TestMethod] public void CreatedBy() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CreatedBy, 55555);

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().ResponsibleUserId, 77777);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactUpdateDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Tags, "tag1,tag2");
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().Tags);

        [TestMethod] public void CompanyNameIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactUpdateDTO>().CompanyName, null);
        [TestMethod] public void CompanyNameHasValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CompanyName, "TestUser1");
        [TestMethod] public void CompanyNameIsNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().CompanyName);

        [TestMethod] public void CompanyIdtIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactUpdateDTO>().CompanyId, 0);
        [TestMethod] public void CompanyIdHasValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CompanyId, 95123);
        [TestMethod] public void CompanyIdIsNull() => Assert.AreEqual(new Contact().Adapt<ContactUpdateDTO>().CompanyId, 0);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(array.Adapt<ContactUpdateDTO>().Leads, typeof(IEnumerable<int>));
        [TestMethod] public void LeadsIsNotNull() => Assert.IsNotNull(array.Adapt<ContactUpdateDTO>().Leads);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Leads.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Leads.First(), 963369);
        [TestMethod] public void LeadsIsNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().Leads);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(array.Adapt<ContactUpdateDTO>().Customers, typeof(IEnumerable<int>));
        [TestMethod] public void CustomersIsNotNull() => Assert.IsNotNull(array.Adapt<ContactUpdateDTO>().Customers);
        [TestMethod] public void CustomersHasValues() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Customers.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().Customers.First(), 987654);
        [TestMethod] public void CustomersIsNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().Customers);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(array.Adapt<ContactUpdateDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(array.Adapt<ContactUpdateDTO>().CustomFields[0].Id, 112);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Contact().Adapt<ContactUpdateDTO>().CustomFields);


        [TestMethod]
        public void FieldsToArrayOfEnumsIfMultiselect()
        {
            var obj = new Contact();
            obj.Fields.Add(new Field
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

            Assert.IsInstanceOfType(array.Adapt<ContactUpdateDTO>().CustomFields[0].Values, typeof(ArrayList));
            Assert.AreEqual(obj.Adapt<ContactUpdateDTO>().CustomFields[0].Values.Count, 3);
            Assert.AreEqual(obj.Adapt<ContactUpdateDTO>().CustomFields[0].Values.ToArray()[0], "654");
        }

        [TestMethod]
        public void FieldsToArrayOfObject()
        {
            var obj = new Contact();
            obj.Fields.Add(new Field
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

            Assert.IsInstanceOfType(array.Adapt<ContactUpdateDTO>().CustomFields[0].Values, typeof(ArrayList));
            Assert.AreEqual(obj.Adapt<ContactUpdateDTO>().CustomFields[0].Values.Count, 3);
            Assert.AreEqual(((dynamic)obj.Adapt<ContactUpdateDTO>().CustomFields[0].Values.ToArray()[0]).value, "OOO");
        }
    }
}
