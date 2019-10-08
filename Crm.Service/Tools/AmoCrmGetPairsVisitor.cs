﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace amocrm.library.Tools
{
    internal class AmoCrmGetPairsVisitor : ExpressionVisitor
    {
        public HashSet<KeyValuePair<string, string>> Pairs { get; } = new HashSet<KeyValuePair<string, string>>();

        public Expression Apply(Expression expression)
        {
            return Visit(expression);
        }

        protected override Expression VisitBinary(BinaryExpression node)
        {
            if (node.NodeType == ExpressionType.Equal)
            {
                MemberExpression left;

                if (node.Left is UnaryExpression) left = ((UnaryExpression)node.Left).Operand as MemberExpression;
                else if (node.Left is MemberExpression) left = (MemberExpression)node.Left;
                else throw new ArgumentException("First part of a condition must be a property");

                var title = left.Member.GetCustomAttributes(false).First() as FilterNameRepresentAttribute;

                var right = Expression.Lambda(node.Right).Compile().DynamicInvoke();

                Pairs.Add(new KeyValuePair<string, string>(title.Name, right.ToString()));
            }

            return base.VisitBinary(node);
        }
    }
}
