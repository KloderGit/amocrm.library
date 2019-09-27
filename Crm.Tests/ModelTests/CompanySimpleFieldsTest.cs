using amocrm.library.Configurations;
using amocrm.library.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ModelTests
{
    [TestClass]
    public class CompanyPositionTest
    {
        [TestMethod]
        public void AddWeb()
        {
            var contact = new Company();
            contact.Web("www.url");
            var value = contact.Fields.Find(x => x.Id == (int)CompanySystemFields.Web).Values[0].Value;

            Assert.AreEqual(value, "www.url");
        }

        [TestMethod]
        public void NullWebDoesntChangeArray()
        {
            var contact = new Company();
            contact.Web(null);
            contact.Web("");

            var value = contact.Fields.Find(x => x.Id == (int)CompanySystemFields.Web);

            Assert.IsNull(value);
        }

        [TestMethod]
        public void AddLocation()
        {
            var contact = new Company();
            contact.Location("place");
            var value = contact.Fields.Find(x => x.Id == (int)CompanySystemFields.Location).Values[0].Value;

            Assert.AreEqual(value, "place");
        }

        [TestMethod]
        public void NullLocationDoesntChangeArray()
        {
            var contact = new Company();
            contact.Location("");
            contact.Location(null);

            var value = contact.Fields.Find(x => x.Id == (int)CompanySystemFields.Location);

            Assert.IsNull(value);
        }
    }
}
