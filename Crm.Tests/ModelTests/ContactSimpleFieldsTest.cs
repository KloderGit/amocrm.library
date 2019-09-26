using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class ContactPositionTest
    {
        [TestMethod]
        public void AddPosition()
        {
            var contact = new Contact();
            contact.Position("Manager");
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Position).Values[0].Value;

            Assert.AreEqual(value, "Manager");
        }

        [TestMethod]
        public void NullPositionDoesntChangeArray()
        {
            var contact = new Contact();
            contact.Position(null);
            contact.Position("");

            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Position);

            Assert.IsNull(value);
        }

        [TestMethod]
        public void AddAgreement()
        {
            var contact = new Contact();
            contact.Agreement(true);
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Agreement).Values[0].Value;

            Assert.AreEqual(value, "1");
        }

        [TestMethod]
        public void NullAgreementChangeArray()
        {
            var contact = new Contact();
            contact.Agreement(false);

            var field = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Agreement);
            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Agreement).Values[0].Value; ;

            Assert.IsNotNull(field);
            Assert.IsNull(value);
        }

        [TestMethod]
        public void AddMessanger()
        {
            var contact = new Contact();
            contact.Messenger("acc", MessengerTypeEnum.SKYPE);

            var value = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Messenger).Values[0].Value;

            Assert.AreEqual(value, "acc");
        }

        [TestMethod]
        public void AddTwoMessanger()
        {
            var contact = new Contact();
            contact.Messenger("acc", MessengerTypeEnum.SKYPE);
            contact.Messenger("acct", MessengerTypeEnum.ICQ);

            var value1 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Messenger).Values[0].Value;
            var value2 = contact.Fields.Find(x => x.Id == (int)ContactSystemFields.Messenger).Values[1].Value;

            Assert.AreEqual(value1, "acc");
            Assert.AreEqual(value2, "acct");
        }
    }
}
