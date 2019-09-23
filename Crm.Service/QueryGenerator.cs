
using amocrm.library.Filters;
using amocrm.library.Interfaces;
using amocrm.library.Tools;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Net.Http;
using System.Threading.Tasks;

namespace amocrm.library
{
    internal class QueryGenerator : IQueryGenerator
    {
        List<Expression> Expressions { get; set; } = new List<Expression>();

        public void CreateQuery(Expression expression)
        {
            Expressions.Add(expression);
        }

        public async Task<string> Generate()
        {
            var visitor = new AmoCrmGetPairsVisitor();

            foreach (var exp in Expressions)
            {
                Expression modifiedExpr = visitor.Apply((Expression)exp);
            }

            visitor.Pairs.Distinct(new QueryKeyPairEqualityComparer());

            var queryString = await new FormUrlEncodedContent(visitor.Pairs).ReadAsStringAsync();

            return string.IsNullOrEmpty(queryString) ? "" : "?" + queryString;
        }
    }
}