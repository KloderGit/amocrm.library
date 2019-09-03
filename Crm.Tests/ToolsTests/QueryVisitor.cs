using Crm.Service;
using Crm.Service.Filters;
using Crm.Service.Tools;
using Microsoft.VisualStudio.TestTools.UnitTesting;
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
        public void GetResultKeysAndValues()
        {
            //var connect = new Connection("apfitness", "kloder@fitness-pro.ru", "99aad176302f7ea9213c307e1e6ab8fc");
            //ILoggerFactory loggerFactory = new LoggerFactory();

            ////ILogger logger = loggerFactory.CreateLogger<Contact>();

            //var amo = new CrmManager(connect, loggerFactory);

            //var pr = new AmoCrmQueryProvider<Contact, ContactDTO>(amo.Contacts);

            //var repo = new AmoCrmRepositoty<Contact>(pr);

            //var repos = new AmoCrmRepositoty<Contact>(null);

            //Expression<Func<Filter, bool>> lambda = x => x.Id == 12;


            //var repoWithExpression = repo.Where(x => x.Id == 12)
            //                             .Where(x => x.Id == 12)
            //                             .Where(x => x.Name == "First")
            //                             .Where(x => x.User == "Second")
            //                             .Where(x => x.Id == 11);


            //var visitor = new AmoCrmGetPairsVisitor();

            //foreach (var exp in repoWithExpression.Expressions)
            //{
            //    Expression modifiedExpr = visitor.Apply((Expression)exp);
            //}

            //var pairs = visitor.Pairs;

            //// Pairs doesn't have any doubles
            //Assert.AreEqual(pairs.Count, 4);
            //Assert.IsNotNull(pairs.FirstOrDefault(x=>x.Key == "id"));
            //Assert.AreEqual(pairs.Where(x => x.Key == "id" && x.Value == "12").Count(), 1);
            //Assert.AreEqual(pairs.Where(x => x.Key == "id").Count(), 2);



            var visitor = new AmoCrmGetPairsVisitor();


            Expression<Func<Filter, bool>> exp = x => x.User == "CheckName";
            Expression result = visitor.Apply((Expression)exp);

            // Replace FieldName to AttributeName - ex. User -> contact
            Assert.IsNotNull(visitor.Pairs.FirstOrDefault(x => x.Key == "contact"));
            Assert.AreEqual(visitor.Pairs.FirstOrDefault(x => x.Key == "contact").Value, "CheckName");
        }

        [TestMethod]
        public void DistinctKeysAndValues()
        {
            var visitor = new AmoCrmGetPairsVisitor();

            //var id = 123;
            //Expression<Func<Filter, bool>> exp1 = x => x.Id == id;
            //Expression<Func<Filter, bool>> exp2 = x => x.Id == (id + 444);

            Expression<Func<Filter, bool>> exp1 = x => x.Id == 12;
            Expression<Func<Filter, bool>> exp2 = x => x.Id == 12;

            var list = new List<Expression>() { exp1, exp2 };

            foreach (var exp in list)
            {
                Expression modifiedExpr = visitor.Apply((Expression)exp);
            }

            // There is just one value of id
            Assert.IsNotNull(visitor.Pairs.FirstOrDefault(x => x.Key == "id"));
            Assert.AreEqual(visitor.Pairs.Where(x => x.Key == "id").Count(), 1);
        }
    }
}
