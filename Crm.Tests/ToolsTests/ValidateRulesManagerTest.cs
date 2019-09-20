using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Crm.Tests.ToolsTests
{
    [TestClass]
    public class ValidateRulesManagerTest
    {
        [TestMethod]
        public void GetEmptyFactoryForMissingTypes()
        {
            var manager = new ValidateRulesManager();
            var factory = manager.GetFactory<EntityCore>();

            Assert.AreEqual(factory.CreateUpdate().ValidateBool(new EntityCore()), true);
        }

    }
}
