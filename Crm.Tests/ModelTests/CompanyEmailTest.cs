using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class CompanyEmailTest
    {
        [TestMethod]
        public void AddEmail()
        {
            var item = new Company();
            item.Email("post@domain.com");
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[0].Value;

            Assert.AreEqual(value, "post@domain.com");
        }

        [TestMethod]
        public void AddEmailAndCertainType()
        {
            var item = new Company();
            item.Email("post@domain.com", EmailTypeEnum.WORK);
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[0].Enum;

            Assert.AreEqual(value, (int)EmailTypeEnum.WORK);
        }

        [TestMethod]
        public void AddEmailAndNextType()
        {
            var item = new Company();
            item.Email("post@domain.com");
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[0].Enum;

            Assert.AreEqual(value, (int)EmailTypeEnum.PRIV);
        }

        [TestMethod]
        public void AddTwoEmailDefaultType()
        {
            var item = new Company();
            item.AddEmail("post@domain.com");
            item.AddEmail("89995556633");

            var value1 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[0].Enum;
            var value2 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[1].Enum;

            Assert.AreEqual(value1, (int)EmailTypeEnum.PRIV);
            Assert.AreEqual(value2, (int)EmailTypeEnum.PRIV);
        }

        [TestMethod]
        public void AddTwoEmailAndSameType()
        {
            var item = new Company();
            item.AddEmail("post@domain.com", EmailTypeEnum.PRIV);
            item.AddEmail("89995556633", EmailTypeEnum.PRIV);

            var value1 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[0].Enum;
            var value2 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email).Values[1].Enum;

            Assert.AreEqual(value1, (int)EmailTypeEnum.PRIV);
            Assert.AreEqual(value2, (int)EmailTypeEnum.PRIV);
        }

        [TestMethod]
        public void NullDoesntChangeArray()
        {
            var item = new Company();
            item.AddEmail(null, EmailTypeEnum.PRIV);
            item.AddEmail("", EmailTypeEnum.PRIV);

            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Email);

            Assert.IsNull(value);
        }
    }
}
