﻿using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class ContactPhoneTest
    {
        [TestMethod]
        public void AddPhone()
        {
            var contact = new Contact();
            contact.Phone("89995556644");
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[0].Value;

            Assert.AreEqual(value, "89995556644");
        }

        [TestMethod]
        public void AddPhoneAndCertainType()
        {
            var contact = new Contact();
            contact.Phone("89995556644", PhoneTypeEnum.WORK);
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[0].Enum;

            Assert.AreEqual(value, (int)PhoneTypeEnum.WORK);
        }

        [TestMethod]
        public void AddPhoneAndNextType()
        {
            var contact = new Contact();
            contact.Phone("89995556644");
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[0].Enum;

            Assert.AreEqual(value, (int)PhoneTypeEnum.MOB);
        }

        [TestMethod]
        public void AddTwoPhoneDefaultType()
        {
            var contact = new Contact();
            contact.AddPhone("89995556644");
            contact.AddPhone("89995556633");

            var value1 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[0].Enum;
            var value2 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[1].Enum;

            Assert.AreEqual(value1, (int)PhoneTypeEnum.MOB);
            Assert.AreEqual(value2, (int)PhoneTypeEnum.MOB);
        }

        [TestMethod]
        public void AddTwoPhoneAndSameType()
        {
            var contact = new Contact();
            contact.AddPhone("89995556644", PhoneTypeEnum.WORK);
            contact.AddPhone("89995556633", PhoneTypeEnum.WORK);

            var value1 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[0].Enum;
            var value2 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone).Values[1].Enum;

            Assert.AreEqual(value1, (int)PhoneTypeEnum.WORK);
            Assert.AreEqual(value2, (int)PhoneTypeEnum.WORK);
        }

        [TestMethod]
        public void NullDoesntChangeArray()
        {
            var contact = new Contact();
            contact.AddPhone(null, PhoneTypeEnum.MOB);
            contact.AddPhone("", PhoneTypeEnum.MOB);

            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Phone);

            Assert.IsNull(value);
        }
    }
}
