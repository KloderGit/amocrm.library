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
using System.Text;

namespace Crm.Tests.Mappings
{
    [TestClass]
    public class CompanyToCompanyDtoTest
    {
        Company company;

        public CompanyToCompanyDtoTest()
        {
            new ContactMaps();

            company = CompanyMockData.GetCompany().First();
        }

        [TestMethod]
        public void MapEmptyCompanyToCompanyDto()
        {
            // Верное заполнение\инициализация отсутствующих свойств

            var companyDtoAdapt = new Company().Adapt<CompanyDTO>();
            var companyDtoNew = new CompanyDTO();

            var companyDto = JsonConvert.SerializeObject(companyDtoAdapt).ToString();
            var company = JsonConvert.SerializeObject(companyDtoNew).ToString();

            Assert.AreEqual(companyDto, company);
        }

        [TestMethod] public void Id() => Assert.AreEqual(company.Adapt<CompanyDTO>().Id, 8663699);
        [TestMethod] public void CreatedBy() => Assert.AreEqual(company.Adapt<CompanyDTO>().CreatedBy, 2081797);
        [TestMethod] public void AccountId() => Assert.AreEqual(company.Adapt<CompanyDTO>().AccountId, 17769199);
        [TestMethod] public void GroupId() => Assert.AreEqual(company.Adapt<CompanyDTO>().GroupId, 212704);
        [TestMethod] public void UpdatedBy() => Assert.AreEqual(company.Adapt<CompanyDTO>().UpdatedBy, 2997712);
        [TestMethod] public void ResponsibleUserId() => Assert.AreEqual(company.Adapt<CompanyDTO>().ResponsibleUserId, 2997712);


        [TestMethod] public void Name() => Assert.AreEqual(company.Adapt<CompanyDTO>().Name, "Company Name");
        [TestMethod] public void NameIsEmpty() => Assert.IsNull(new Company().Adapt<CompanyDTO>().Name);
        [TestMethod] public void NameIsNotNull() => Assert.IsNotNull(new CompanyDTO().Adapt<Company>().Name);

        [TestMethod] public void CreatedAt() => Assert.AreEqual(company.Adapt<CompanyDTO>().CreatedAt, 1527690442);
        [TestMethod] public void CreatedAtZero() => Assert.AreEqual(new CompanyDTO().Adapt<Company>().CreatedAt, DateTime.MinValue);

        [TestMethod] public void UpdatedAt() => Assert.AreEqual(company.Adapt<CompanyDTO>().UpdatedAt, 1567519347);
        [TestMethod] public void UpdatedAtZero() => Assert.AreEqual(new CompanyDTO().Adapt<Company>().UpdatedAt, DateTime.MinValue);

        [TestMethod] public void ClosestTaskAt() => Assert.AreEqual(company.Adapt<CompanyDTO>().ClosestTaskAt, 1567630740);
        [TestMethod] public void ClosestTaskAtZero() => Assert.AreEqual(new CompanyDTO().Adapt<Company>().ClosestTaskAt, DateTime.MinValue);


        [TestMethod] public void TagsIsNotNull() => Assert.AreNotEqual(company.Adapt<CompanyDTO>().Tags, null);
        [TestMethod] public void TagsHasValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Tags.Count, 2);
        [TestMethod] public void TagsFirstValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Tags[0].Id, 123);
        [TestMethod] public void TagsIsNull() => Assert.IsNull(new Company().Adapt<CompanyDTO>().Tags);

        [TestMethod] public void FieldsIsNotNull() => Assert.AreNotEqual(company.Adapt<CompanyDTO>().CustomFields, null);
        [TestMethod] public void FieldsHasValues() => Assert.AreEqual(company.Adapt<CompanyDTO>().CustomFields.Count, 3);
        [TestMethod] public void FieldsFirstValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().CustomFields[0].Id, 66339);
        [TestMethod] public void FieldsIsNull() => Assert.IsNull(new Company().Adapt<CompanyDTO>().CustomFields);

        [TestMethod] public void LeadsTypeIs() => Assert.IsInstanceOfType(company.Adapt<CompanyDTO>().Leads, typeof(LinkedDataList));
        [TestMethod] public void LeadsIsNotNull() => Assert.AreNotEqual(company.Adapt<CompanyDTO>().Leads, null);
        [TestMethod] public void LeadsHasValues() => Assert.AreEqual(company.Adapt<CompanyDTO>().Leads.Id.Count(), 3);
        [TestMethod] public void LeadsFirstValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Leads.Id.First(), 111);
        [TestMethod] public void LeadsIsNull() => Assert.IsNull(new Company().Adapt<CompanyDTO>().Leads);

        [TestMethod] public void ContactsTypeIs() => Assert.IsInstanceOfType(company.Adapt<CompanyDTO>().Contacts, typeof(LinkedDataList));
        [TestMethod] public void ContactsIsNotNull() => Assert.AreNotEqual(company.Adapt<CompanyDTO>().Contacts, null);
        [TestMethod] public void ContactsHasValues() => Assert.AreEqual(company.Adapt<CompanyDTO>().Contacts.Id.Count(), 3);
        [TestMethod] public void ContactsFirstValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Contacts.Id.First(), 888);
        [TestMethod] public void ContactsIsNull() => Assert.IsNull(new Company().Adapt<CompanyDTO>().Contacts);

        [TestMethod] public void CustomersTypeIs() => Assert.IsInstanceOfType(company.Adapt<CompanyDTO>().Customers, typeof(LinkedDataList));
        [TestMethod] public void CustomersIsNotNull() => Assert.AreNotEqual(company.Adapt<CompanyDTO>().Customers, null);
        [TestMethod] public void CustomersHasValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Customers.Id.Count(), 3);
        [TestMethod] public void CustomersFirstValue() => Assert.AreEqual(company.Adapt<CompanyDTO>().Customers.Id.First(), 444);
        [TestMethod] public void CustomersIsNull() => Assert.IsNull(new Company().Adapt<CompanyDTO>().Customers);
    }
}
