using amocrm.library;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Crm.Tests
{
    [TestClass]
    public class ValidationTest
    {

        [TestMethod]

        public void dsff()
        {

            var ddd = new ValidateRulesManager().GetFactory<Task>().CreateAdd();

            var lddd = new Task() { Text = "asdasd" };

            var rrr = lddd.Validate(ddd);

            var fggg = ddd.Validate(lddd);

        }

        [TestMethod]
        public void LeadValidations()
        {
            new LeadtMaps();

            Lead leadAddDTO = new Lead();

            try
            {
                var dtoToAdd = new DtoModelBuilder<Lead>().GetUpdateModel(new List<Lead> { leadAddDTO });
            }
            catch (Exception ex)
            {

            }


        }
    }
}
