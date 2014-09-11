﻿using System;
using System.Collections.Generic;
using System.Linq;
using LinqToWiki.Internals;
using LinqToWiki.Parameters;

namespace LinqToWiki
{
    /// <summary>
    /// Represents a result of a “props” query.
    /// </summary>
    public class WikiQueryPageResult<TResult>
    {
        private readonly QueryPageProcessor m_queryProcessor;
        private readonly PageQueryParameters m_parameters;
        private readonly Func<PageData, TResult> m_selector;
        private readonly Dictionary<string, QueryTypeProperties> m_pageProperties;

        internal WikiQueryPageResult(
            QueryPageProcessor queryProcessor, PageQueryParameters parameters, Func<PageData, TResult> selector,
            Dictionary<string, QueryTypeProperties> pageProperties)
        {
            m_selector = selector;
            m_pageProperties = pageProperties;
            m_queryProcessor = queryProcessor;
            m_parameters = parameters;
        }

        /// <summary>
        /// Exectes the query as a <see cref="List{T}"/>.
        /// </summary>
        public List<TResult> ToList()
        {
            return ToEnumerable().ToList();
        }

        /// <summary>
        /// Executes the query as an <see cref="IEnumerable{T}"/>.
        /// </summary>
        public IEnumerable<TResult> ToEnumerable()
        {
            return m_queryProcessor.ExecuteList(m_parameters, m_selector, m_pageProperties);
        }
    }
}