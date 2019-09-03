using Crm.Service;
using Crm.Service.Extensions;
using Crm.Service.Models;
using Microsoft.Extensions.Logging;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using System.Linq;

namespace Crm.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod2()
        {
            try
            {
                ILoggerFactory loggerFactory = new LoggerFactory().AddDebug(LogLevel.Debug);
                ILogger logger = loggerFactory.CreateLogger("TstLogger");

                var amoCrm = new CrmManager(logger, account: "fpatest", login: "kloder@fitness-pro.ru", pass: "73ae95ee19bddb98cad2906890cd8a950b87f68d");
                amoCrm.DirectAuthorization().Wait();

                var contact = new Contact()
                {
                    Name = "Test User " + new Random().Next(0, 100)
                };

                var ddd = amoCrm.Contacts.AddAsync(contact).Result;
                Debug.WriteLine($"Contact has created with Id = {ddd.FirstOrDefault()}");

                var contact1 = amoCrm.Contacts.Where(x => x.Id == ddd.FirstOrDefault()).ToList().Result.FirstOrDefault();
                Debug.WriteLine("Contact has gotten from Amo");

                contact1.Name = contact1.Name + " Updated";
                var result = amoCrm.Contacts.UpdateAsync(contact1).Result;
                Debug.WriteLine($"Contact with Id {result.FirstOrDefault()} has updated");

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
