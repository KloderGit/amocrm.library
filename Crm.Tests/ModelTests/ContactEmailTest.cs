using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class ContactEmailTest
    {
        [TestMethod]
        public void AddEmail()
        {
            var contact = new Contact();
            contact.Email("post@domain.com");
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[0].Value;

            Assert.AreEqual(value, "post@domain.com");
        }

        [TestMethod]
        public void AddEmailAndCertainType()
        {
            var contact = new Contact();
            contact.Email("post@domain.com", EmailTypeEnum.WORK);
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[0].Enum;

            Assert.AreEqual(value, (int)EmailTypeEnum.WORK);
        }

        [TestMethod]
        public void AddEmailAndNextType()
        {
            var contact = new Contact();
            contact.Email("post@domain.com");
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[0].Enum;

            Assert.AreEqual(value, (int)EmailTypeEnum.PRIV);
        }

        [TestMethod]
        public void AddTwoEmailAndNextType()
        {
            var contact = new Contact();
            contact.Email("post@domain.com");
            contact.Email("89995556633");

            var value1 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[0].Enum;
            var value2 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[1].Enum;

            Assert.AreEqual(value1, (int)EmailTypeEnum.PRIV);
            Assert.AreEqual(value2, (int)EmailTypeEnum.WORK);
        }

        [TestMethod]
        public void AddTwoEmailAndSameType()
        {
            var contact = new Contact();
            contact.Email("post@domain.com", EmailTypeEnum.PRIV);
            contact.Email("89995556633", EmailTypeEnum.PRIV);

            var value1 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[0].Enum;
            var value2 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email).Values[1].Enum;

            Assert.AreEqual(value1, (int)EmailTypeEnum.PRIV);
            Assert.AreEqual(value2, (int)EmailTypeEnum.PRIV);
        }

        [TestMethod]
        public void NullDoesntChangeArray()
        {
            var contact = new Contact();
            contact.Email(null, EmailTypeEnum.PRIV);
            contact.Email("", EmailTypeEnum.PRIV);

            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Email);

            Assert.IsNull(value);
        }
    }
}
