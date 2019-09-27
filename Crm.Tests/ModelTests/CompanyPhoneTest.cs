using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class CompanyPhoneTest
    {
        [TestMethod]
        public void AddPhone()
        {
            var item = new Company();
            item.Phone("89995556644");
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[0].Value;

            Assert.AreEqual(value, "89995556644");
        }

        [TestMethod]
        public void AddPhoneAndCertainType()
        {
            var item = new Company();
            item.Phone("89995556644", PhoneTypeEnum.WORK);
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[0].Enum;

            Assert.AreEqual(value, (int)PhoneTypeEnum.WORK);
        }

        [TestMethod]
        public void AddPhoneAndNextType()
        {
            var item = new Company();
            item.Phone("89995556644");
            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[0].Enum;

            Assert.AreEqual(value, (int)PhoneTypeEnum.MOB);
        }

        [TestMethod]
        public void AddTwoPhoneDefaultType()
        {
            var item = new Company();
            item.AddPhone("89995556644");
            item.AddPhone("89995556633");

            var value1 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[0].Enum;
            var value2 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[1].Enum;

            Assert.AreEqual(value1, (int)PhoneTypeEnum.MOB);
            Assert.AreEqual(value2, (int)PhoneTypeEnum.MOB);
        }

        [TestMethod]
        public void AddTwoPhoneAndSameType()
        {
            var item = new Company();
            item.AddPhone("89995556644", PhoneTypeEnum.WORK);
            item.AddPhone("89995556633", PhoneTypeEnum.WORK);

            var value1 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[0].Enum;
            var value2 = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone).Values[1].Enum;

            Assert.AreEqual(value1, (int)PhoneTypeEnum.WORK);
            Assert.AreEqual(value2, (int)PhoneTypeEnum.WORK);
        }

        [TestMethod]
        public void NullDoesntChangeArray()
        {
            var item = new Company();
            item.AddPhone(null, PhoneTypeEnum.MOB);
            item.AddPhone("", PhoneTypeEnum.MOB);

            var value = item.Fields.Find(x => x.Id == (int)CompanySystemFields.Phone);

            Assert.IsNull(value);
        }
    }
}
