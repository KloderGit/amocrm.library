using amocrm.library.DTO;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class LeadToLeadAddDtoTest
    {
        Lead array = LeadMockData.GetLeads().First();

        public LeadToLeadAddDtoTest()
        {
            new LeadtMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.


            var leadDtoFromLead = new Lead().Adapt<LeadAddDTO>();
            var leadDtoFromNew = new LeadAddDTO();

            var leadDto1 = JsonConvert.SerializeObject(leadDtoFromLead).ToString();
            var leadDto2 = JsonConvert.SerializeObject(leadDtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }

        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(array.Adapt<LeadAddDTO>().ResponsibleUserId, 2997712);
        //[TestMethod] public void UpdatedBy() => Assert.AreEqual(array.Adapt<LeadAddDTO>().UpdatedBy, 2997712);
        [TestMethod] public void Name() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Name, "Тестовая сделка");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Lead().Adapt<LeadAddDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(array.Adapt<LeadAddDTO>().CreatedAt, new System.DateTime(2019, 9, 10).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadAddDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(array.Adapt<LeadAddDTO>().UpdatedAt, new System.DateTime(2019, 9, 12).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadAddDTO>().UpdatedAt, 0);

        [TestMethod] public void Price() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Price, 10000);

        [TestMethod] public void Status() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Status, 143);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadAddDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Tags, "бартер,оплачено");
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Lead().Adapt<LeadAddDTO>().Tags);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(array.Adapt<LeadAddDTO>().Contacts, typeof(IEnumerable<int>));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadAddDTO>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Contacts.Count(), 2);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Contacts.First(), 29127849);
        [TestMethod] public void ContactsIsNull() => Assert.IsNull(new Lead().Adapt<LeadAddDTO>().Contacts);

        [TestMethod] public void CompanytIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadAddDTO>().Company, null);
        [TestMethod] public void CompanyHasValue() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Company, 33478747);
        [TestMethod] public void CompanyIsNull() => Assert.AreEqual(new Lead().Adapt<LeadAddDTO>().Company, 0);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadAddDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(array.Adapt<LeadAddDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(array.Adapt<LeadAddDTO>().CustomFields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Lead().Adapt<LeadAddDTO>().CustomFields);

        [TestMethod]
        public void FieldsToArrayOfEnumsIfMultiselect()
        {
            var obj = new Lead();
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

            Assert.IsInstanceOfType(array.Adapt<LeadAddDTO>().CustomFields[0].Values, typeof(ArrayList));
            Assert.AreEqual(obj.Adapt<LeadAddDTO>().CustomFields[0].Values.Count, 3);
            Assert.AreEqual(obj.Adapt<LeadAddDTO>().CustomFields[0].Values.ToArray()[0], "654");
        }

        [TestMethod]
        public void FieldsToArrayOfObject()
        {
            var obj = new Lead();
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

            Assert.IsInstanceOfType(array.Adapt<LeadAddDTO>().CustomFields[0].Values, typeof(ArrayList));
            Assert.AreEqual(obj.Adapt<LeadAddDTO>().CustomFields[0].Values.Count, 3);
            Assert.AreEqual(((FieldValue)obj.Adapt<LeadAddDTO>().CustomFields[0].Values.ToArray()[0]).Value, "OOO");
        }
    }
}
