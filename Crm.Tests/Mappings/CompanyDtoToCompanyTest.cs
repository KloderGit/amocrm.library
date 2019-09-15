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
    public class CompanyDtoToCompanyTest
    {
        CompanyGetDTO companyDto;

        public CompanyDtoToCompanyTest()
        {
            new ContactMaps();

            companyDto = CompanyMockData.GetCompanyGetDTO().First();
        }

        [TestMethod]
        public void MapEmptyCompanyDtoToCompany()
        {
            // Верное отражение или инициализация отсутствующих свойств

            var companyFromDto = new CompanyGetDTO().Adapt<Company>();
            var companyFromNew = new Company();

            var leadDto = JsonConvert.SerializeObject(companyFromDto).ToString();
            var lead = JsonConvert.SerializeObject(companyFromNew).ToString();

            Assert.AreEqual(leadDto, lead);
        }

        [TestMethod] public void Id() => Assert.AreEqual(companyDto.Adapt<Company>().Id, 8663699);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(companyDto.Adapt<Company>().ResponsibleUserId, 2997712);
        [TestMethod] public void AccountId() => Assert.AreEqual(companyDto.Adapt<Company>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(companyDto.Adapt<Company>().GroupId, 212704);
        [TestMethod] public void UpdatedBy() => Assert.AreEqual(companyDto.Adapt<Company>().UpdatedBy, 2997712);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(companyDto.Adapt<Company>().CreatedBy, 2081797);

        [TestMethod] public void Name() => Assert.AreEqual(companyDto.Adapt<Company>().Name, "Company Name");
        [TestMethod] public void NameIsEmpty() => Assert.AreEqual(new CompanyGetDTO().Adapt<Company>().Name, string.Empty);
        [TestMethod] public void NameIsNotNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(companyDto.Adapt<Company>().CreatedAt, new DateTime().FromTimestamp(1527690442));
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new CompanyGetDTO().Adapt<Company>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(companyDto.Adapt<Company>().UpdatedAt, new DateTime().FromTimestamp(1567519347));
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new CompanyGetDTO().Adapt<Company>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(companyDto.Adapt<Company>().ClosestTaskAt, new DateTime().FromTimestamp(1567630740));
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new CompanyGetDTO().Adapt<Company>().ClosestTaskAt, DateTime.MinValue);

        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(companyDto.Adapt<Company>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(companyDto.Adapt<Company>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(companyDto.Adapt<Company>().Tags[0].Id, 123);
        [TestMethod] public void TagsIsNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(companyDto.Adapt<Company>().Fields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(companyDto.Adapt<Company>().Fields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(companyDto.Adapt<Company>().Fields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Fields);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(companyDto.Adapt<Company>().Leads, typeof(IEnumerable<int>));
        [TestMethod] public void LeadsIsNotNull() => Assert.AreNotEqual(companyDto.Adapt<Company>().Leads, null);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(companyDto.Adapt<Company>().Leads.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(companyDto.Adapt<Company>().Leads.First(), 111);
        [TestMethod] public void LeadsIsNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Fields);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(companyDto.Adapt<Company>().Contacts, typeof(IEnumerable<int>));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(companyDto.Adapt<Company>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(companyDto.Adapt<Company>().Contacts.Count(), 3);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(companyDto.Adapt<Company>().Contacts.First(), 888);
        [TestMethod] public void ContactsIsNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Contacts);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(companyDto.Adapt<Company>().Customers, typeof(IEnumerable<int>));
        [TestMethod] public void CustomersIsNotNull() => Assert.AreNotEqual(companyDto.Adapt<Company>().Customers, null);
        [TestMethod] public void CustomersHasValue() => Assert.AreEqual(companyDto.Adapt<Company>().Customers.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(companyDto.Adapt<Company>().Customers.First(), 444);
        [TestMethod] public void CustomersIsNull() => Assert.IsNotNull(new CompanyGetDTO().Adapt<Company>().Customers);
    }
}
