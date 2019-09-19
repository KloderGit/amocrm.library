using amocrm.library;
using amocrm.library.Mappings;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Crm.Tests
{
    [TestClass]
    public class ValidationTest
    {


        [TestMethod]
        public void dsfssssssf()
        {

            var ruls = new ValidateRules<Task>();
            ruls.AddRule(x => x.Id != 0, "Zero is wrong");
            ruls.AddRule(x => x.Id != 5, "Five is wrong as well");
            ruls.AddRule(x => !String.IsNullOrEmpty(x.Text), "Text is wrong");

            var task = new Task();
            var task2 = new Task { Id =5, Text ="asd" };
            var task3 = new Task { Id = 3, Text = "asd" };

            var errors = ruls.ValidateResults(task);
            var errors2 = ruls.ValidateResults(task2);
            var errors3 = ruls.ValidateResults(task3);

            var rrr = ruls.ValidateBool(task);
            var rrr2 = ruls.ValidateBool(task2);
            var rrr3 = ruls.ValidateBool(task3);
        }



        [TestMethod]

        public void dsff()
        {

            var ddd = new ValidateRulesManager().GetFactory<Task>().CreateAdd();

            var lddd = new Task() { Text = "asdasd" };

            var rrr = lddd.Validate(ddd);

            var fggg = ddd.ValidateBool(lddd);

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
