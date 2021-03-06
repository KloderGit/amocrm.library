﻿using amocrm.library.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;

namespace amocrm.library.Tools
{
    internal class ValidateRules<T> : IValidateRules<T>
    {
        IDictionary<Expression<Predicate<T>>, string> rules = new Dictionary<Expression<Predicate<T>>, string>();

        public void AddRule(Expression<Predicate<T>> predicate, string message)
        {
            if (predicate == null || string.IsNullOrEmpty(message)) throw new ArgumentNullException();
            rules.Add(predicate, message);
        }

        public bool ValidateBool(T element)
        {
            var expressions = rules.Select(x => x.Key);
            var results = new List<bool>();

            foreach (var item in expressions)
            {
                var lambda = item.Compile();
                results.Add(lambda.Invoke(element));
            }

            return results.Contains(false) ? false : true;
        }

        public IEnumerable<ValidationResult> ValidateResults(T element)
        {
            var result = new List<ValidationResult>();

            foreach (var rule in rules)
            {
                var expression = rule.Key;
                var message = rule.Value;

                if (!rule.Key.Compile().Invoke(element))
                {
                    var body = expression.Body as BinaryExpression;
                    if (body != null)
                    {
                        MemberExpression left;
                        if (body.Left is UnaryExpression) left = ((UnaryExpression)body.Left).Operand as MemberExpression;
                        else left = body.Left as MemberExpression;

                        if (left != null) result.Add(new ValidationResult(message, new List<string> { left.Member.Name }));
                    }
                    else
                    {
                        result.Add(new ValidationResult(message));
                    }
                }
            }

            return result;
        }
    }
}
