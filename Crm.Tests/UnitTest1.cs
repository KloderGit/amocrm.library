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


            //var lead = amoCrm.Leads.FindByIdAsync(17553803).Result;

            

            var contt = amoCrm.Contacts.Where(x => x.Contains == "89031453412").ToList().Result;

        }
    }
}
