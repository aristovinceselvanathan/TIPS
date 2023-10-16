using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment20
{
    /// <summary>
    /// Query Builder Class
    /// </summary>
    /// <typeparam name="T">Type of the List</typeparam>
    internal class QueryBuilder<T>
    {
        private IQueryable<T> _query;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">Query of the user from the source program</param>
        public QueryBuilder(IEnumerable<T> sourceQuery)
        {
            this._query = sourceQuery.AsQueryable();
        }

        /// <summary>
        /// Filter Query
        /// </summary>
        /// <param name="predicate">Lambda Function</param>
        /// <returns>Query</returns>
        public QueryBuilder<T> Filter(Func<T, bool> predicate)
        {
            _query = _query.Where(predicate).AsQueryable();
            return this;
        }

        /// <summary>
        /// SortBy Query
        /// </summary>
        /// <param name="predicate">Lambda Function</param>
        /// <returns>Query</returns>
        public QueryBuilder<T> SortBy(Func<T, bool> predicate)
        {
            _query = _query.OrderBy(predicate).AsQueryable();
            return this;
        }

        /// <summary>
        /// Join the Query
        /// </summary>
        /// <typeparam name="TInner">Type of the inner query</typeparam>
        /// <typeparam name="TKey">Type of the Key</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="inner">inner</param>
        /// <param name="outerKeySelector">outterkeyselector</param>
        /// <param name="innerKeySelector">innerkeyselector</param>
        /// <param name="resultSelector">resultselector</param>
        /// <returns>Query</returns>
        public QueryBuilder<TResult> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Func<T, TKey> outerKeySelector, Func<TInner, TKey> innerKeySelector, Func<T, TInner, TResult> resultSelector)
        {
            var joinedQuery = _query.Join(inner, outerKeySelector, innerKeySelector, resultSelector).AsQueryable();
            return new QueryBuilder<TResult>(this);
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        /// <param name="predicate">Lambda Function</param>
        /// <returns>Query</returns>
        public IEnumerable<T> Execute(Func<T, bool> predicate)
        {
            return _query.ToList();
        }
    }
}
