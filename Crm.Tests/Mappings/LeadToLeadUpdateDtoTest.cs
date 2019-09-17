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
    public class LeadToLeadUpdateDtoTest
    {
        Lead array = LeadMockData.GetLeads().First();

        public LeadToLeadUpdateDtoTest()
        {
            new ContactMaps();
        }

        [TestMethod]
        public void TheSameResultFromAdaptedAndNew()
        {
            //Statement - All incoming data become defaul value even if data is null. 
            //    Equality ensures that all properties have been converted correctly.


            var leadDtoFromLead = new Lead().Adapt<LeadUpdateDTO>();
            var leadDtoFromNew = new LeadUpdateDTO();

            var leadDto1 = JsonConvert.SerializeObject(leadDtoFromLead).ToString();
            var leadDto2 = JsonConvert.SerializeObject(leadDtoFromNew).ToString();

            Assert.AreEqual(leadDto1, leadDto2);
        }


        [TestMethod] public void Id() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().ResponsibleUserId, 2997712);
        //[TestMethod] public void UpdatedBy() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().UpdatedBy, 2997712);
        [TestMethod] public void Name() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Name, "Тестовая сделка");
        [TestMethod] public void NameIsNotNull() => Assert.IsNull(new Lead().Adapt<LeadUpdateDTO>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().CreatedAt, new System.DateTime(2019, 9, 10).ToTimestamp());
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadUpdateDTO>().CreatedAt, 0);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().UpdatedAt, new System.DateTime(2019, 9, 12).ToTimestamp());
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new Lead().Adapt<LeadUpdateDTO>().UpdatedAt, 0);

        [TestMethod] public void Price() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Price, 10000);

        [TestMethod] public void Status() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Status, 143);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadAddDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(array.Adapt<LeadAddDTO>().Tags, "бартер,оплачено");
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Lead().Adapt<LeadAddDTO>().Tags);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(array.Adapt<LeadUpdateDTO>().Contacts, typeof(IEnumerable<int>));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadUpdateDTO>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Contacts.Count(), 2);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Contacts.First(), 29127849);
        [TestMethod] public void ContactsIsNull() => Assert.IsNull(new Lead().Adapt<LeadUpdateDTO>().Contacts);

        [TestMethod] public void CompanytIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadUpdateDTO>().Company, null);
        [TestMethod] public void CompanyHasValue() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().Company, 33478747);
        [TestMethod] public void CompanyIsNull() => Assert.AreEqual(new Lead().Adapt<LeadUpdateDTO>().Company, 0);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(array.Adapt<LeadUpdateDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(array.Adapt<LeadUpdateDTO>().CustomFields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Lead().Adapt<LeadUpdateDTO>().CustomFields);
    }
}
