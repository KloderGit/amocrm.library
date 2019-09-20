using amocrm.library.Interfaces;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Crm.Tests.ToolsTests
{
    [TestClass]
    public class ValidateRulesTest
    {

        IValidateRules<ChekedClass> GetRules()
        {
            IValidateRules<ChekedClass> rules = new ValidateRules<ChekedClass>();

            rules.AddRule(x => x.Id != 0, "Int should not be zero");
            rules.AddRule(x => x.Name != "", "String should not be empty");
            rules.AddRule(x => x.Name != null, "String should not be null");
            rules.AddRule(x => !String.IsNullOrEmpty(x.Name), "String cheked by lambda");
            rules.AddRule(x => x.isValue != false, "Bool should not be false");
            rules.AddRule(x => x.Reference != null, "Object should not be null");

            return rules;
        }

        [TestMethod]
        public void AddRulePredicatException()
        {
            IValidateRules<ChekedClass> rules = new ValidateRules<ChekedClass>();
            Assert.ThrowsException<ArgumentNullException>(() => rules.AddRule(null, "message"));
        }

        [TestMethod]
        public void AddRuleMessageException()
        {
            IValidateRules<ChekedClass> rules = new ValidateRules<ChekedClass>();
            Assert.ThrowsException<ArgumentNullException>(() => rules.AddRule(x=>x.Id==0, ""));
        }

        [TestMethod]
        public void ValidateBoolEmptyObject()
        {
            var obj = new ChekedClass();
            var validator = GetRules();

            Assert.AreEqual(validator.ValidateBool(obj), false);
        }

        [TestMethod]
        public void ValidateBoolRightObject()
        {
            var obj = new ChekedClass() { Id = 213, isValue = true, Name = "Name", Reference = new object() };
            var validator = GetRules();

            Assert.AreEqual(validator.ValidateBool(obj), true);
        }

        [TestMethod]
        public void ValidateBoolObjectWithOneWrongParam()
        {
            var obj = new ChekedClass() { Id = 213, isValue = true, Name = "Name" };
            var validator = GetRules();

            Assert.AreEqual(validator.ValidateBool(obj), false);
        }


        [TestMethod]
        public void ValidateResultsEmptyObject()
        {
            var obj = new ChekedClass();
            var validator = GetRules();

            var sdf = validator.ValidateResults(obj);

            Assert.AreEqual(validator.ValidateResults(obj).Count(), 5);
        }

        [TestMethod]
        public void ValidateResultsRightObject()
        {
            var obj = new ChekedClass() { Id = 123, isValue = true, Name = "Name", Reference = new object() };
            var validator = GetRules();

            var sdf = validator.ValidateResults(obj);

            Assert.AreEqual(validator.ValidateResults(obj).Count(), 0);
        }

        [TestMethod]
        public void ValidateResultsBinaryExpressionReturnsName()
        {
            IValidateRules<ChekedClass> validator = new ValidateRules<ChekedClass>();
            validator.AddRule(x => x.Id != 0, "Error");

            var obj = new ChekedClass() { isValue = true, Name = "Name", Reference = new object() };

            Assert.AreEqual(validator.ValidateResults(obj).First().MemberNames.First(), "Id");
        }

        [TestMethod]
        public void ValidateResultsBinaryExpressionHasText()
        {
            IValidateRules<ChekedClass> validator = new ValidateRules<ChekedClass>();
            validator.AddRule(x => x.Id != 0, "Error");

            var obj = new ChekedClass() { isValue = true, Name = "Name", Reference = new object() };

            Assert.AreEqual(validator.ValidateResults(obj).First().ErrorMessage, "Error");
        }

        [TestMethod]
        public void ValidateResultsLambdaExpressionDoesntReturnsName()
        {
            IValidateRules<ChekedClass> validator = new ValidateRules<ChekedClass>();
            validator.AddRule(x => !String.IsNullOrEmpty(x.Name), "Error");

            var obj = new ChekedClass() { Id =123, isValue = true, Name = "", Reference = new object() };

            Assert.IsNull(validator.ValidateResults(obj).First().MemberNames.FirstOrDefault());
        }

        [TestMethod]
        public void ValidateResultsLambdaExpressionHasText()
        {
            IValidateRules<ChekedClass> validator = new ValidateRules<ChekedClass>();
            validator.AddRule(x => !String.IsNullOrEmpty(x.Name), "Error");

            var obj = new ChekedClass() { Id = 123, isValue = true, Name = "", Reference = new object() };

            Assert.AreEqual(validator.ValidateResults(obj).First().ErrorMessage, "Error");
        }
    }

    class ChekedClass
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool isValue { get; set; }
        public object Reference { get; set; }
    }
}
