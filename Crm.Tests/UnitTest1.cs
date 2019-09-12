using amocrm.library.Converters;
using amocrm.library.DTO;
using amocrm.library;
using amocrm.library.Extensions;
using amocrm.library.Mappings;
using amocrm.library.Models;
using Crm.Tests.Data;
using Mapster;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics;
using System.Linq;
using System.Collections.Generic;

namespace Crm.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {

            new ContactMaps();

            ILoggerFactory loggerFactory = new LoggerFactory().AddDebug(LogLevel.Debug);
            ILogger logger = loggerFactory.CreateLogger("TstLogger");

            var amoCrm = new CrmManager(logger, account: "apfitness", login: "kloder@fitness-pro.ru", pass: "99aad176302f7ea9213c307e1e6ab8fc");
            amoCrm.DirectAuthorization().Wait();


            var lead = new Lead { Name = "TstLeadFor TstUser", Contacts = new List<int> { 34715691 } };

            var company = new Company
            {
                Name = "Tst Company new" + new Random().Next(1, 1000),
                Contacts = new List<int> { 34715691 },

            };

        }
    }
}
