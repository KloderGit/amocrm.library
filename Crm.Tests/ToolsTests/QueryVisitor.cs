using amocrm.library.Extensions;
using amocrm.library.Filters;
using amocrm.library.Interfaces;
using amocrm.library.Models;
using amocrm.library.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Crm.Tests.ToolsTests
{
    [TestClass]
    public class QueryVisitor
    {
        [TestMethod]
        public void Get()
        {
            var visitor = new AmoCrmGetPairsVisitor();

            Expression<Func<ContactFilter, bool>> exp1 = x => x.Id == 12;
            Expression<Func<ContactFilter, bool>> exp2 = x => x.Name == "Odod";

            var list = new List<Expression>() { exp1, exp2 };

            foreach (var exp in list)
            {
                Expression modifiedExpr = visitor.Apply((Expression)exp);
            }

            Assert.AreEqual(visitor.Pairs.Count(), 2);
        }

        [TestMethod]
        public void DistinctKeysAndValues()
        {
            var visitor = new AmoCrmGetPairsVisitor();

            Expression<Func<ContactFilter, bool>> exp1 = x => x.Id == 12;
            Expression<Func<ContactFilter, bool>> exp2 = x => x.Id == 12;
            Expression<Func<ContactFilter, bool>> exp3 = x => x.Id == 13;

            var list = new List<Expression>() { exp1, exp2, exp3 };

            foreach (var exp in list)
            {
                Expression modifiedExpr = visitor.Apply((Expression)exp);
            }

            // There is just one value of id
            Assert.IsNotNull(visitor.Pairs.FirstOrDefault(x => x.Key == "id[]"));
            Assert.AreEqual(visitor.Pairs.Where(x => x.Key == "id[]").Count(), 2);
        }
    }
}
