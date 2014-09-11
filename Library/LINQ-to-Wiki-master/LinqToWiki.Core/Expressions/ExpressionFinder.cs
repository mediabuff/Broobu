﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

namespace LinqToWiki.Expressions
{
    /// <summary>
    /// Searches an <see cref="Expression"/> for a matching subexpression.
    /// </summary>
    public static class ExpressionFinder
    {
        /// <summary>
        /// Helper class that looks for a subexpression of type <see cref="T"/>
        /// that satisfies a condition.
        /// </summary>
        private class Finder<T> : ExpressionVisitor where T : Expression
        {
            private readonly Func<T, bool> m_condition;

            private readonly List<T> m_results = new List<T>();

            /// <summary>
            /// Matching expressions that were found.
            /// </summary>
            public IEnumerable<T> Results
            {
                get { return m_results; }
            }

            public Finder(Func<T, bool> condition)
            {
                m_condition = condition;
            }

            /// <summary>
            /// Searches for matching subexpressions in <see cref="node"/>.
            /// </summary>
            public override Expression Visit(Expression node)
            {
                var casted = node as T;

                if (casted != null && m_condition(casted))
                    m_results.Add(casted);

                return base.Visit(node);
            }
        }

        /// <summary>
        /// Searches <see cref="expression"/> for a single subexpression of type <see cref="T"/>
        /// that satisfies <see cref="condition"/>.
        /// Behaves similarly to <see cref="Enumerable.Single{TSource}(System.Collections.Generic.IEnumerable{TSource})"/>.
        /// </summary>
        public static T Single<T>(Expression expression, Func<T, bool> condition) where T : Expression
        {
            var finder = new Finder<T>(condition);
            finder.Visit(expression);
            return finder.Results.Single();
        }
    }
}