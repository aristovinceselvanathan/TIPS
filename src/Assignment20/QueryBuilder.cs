namespace Assignment20
{
    using System.Linq.Expressions;

    /// <summary>
    /// Query Builder Class
    /// </summary>
    /// <typeparam name="T">Type of the List</typeparam>
    internal class QueryBuilder<T>
    {
        private IQueryable<T> _query;
        private IQueryable<object> _query2;

        /// <summary>
        /// Initializes a new instance of the <see cref="QueryBuilder{T}"/> class.
        /// </summary>
        /// <param name="sourceQuery">Query of the user from the source program</param>
        public QueryBuilder(IEnumerable<T> sourceQuery)
        {
            this._query = sourceQuery.AsQueryable();
        }

        /// <summary>
        /// Filter Query based on lambda function
        /// </summary>
        /// <param name="predicate">Lambda Function</param>
        /// <returns>Query</returns>
        public QueryBuilder<T> Filter(Func<T, bool> predicate)
        {
            this._query = this._query.Where(predicate).AsQueryable();
            return this;
        }

        /// <summary>
        /// Sort By Query by the lambda fuction
        /// </summary>
        /// <typeparam name="TKey">Type of the </typeparam>
        /// <param name="predicate">Lambda Function</param>
        /// <returns>Query</returns>
        public QueryBuilder<T> SortBy<TKey>(Func<T, TKey> predicate)
        {
            this._query = this._query.OrderBy(predicate).AsQueryable();
            return this;
        }

        /// <summary>
        /// Join the Query by the lambda function
        /// </summary>
        /// <typeparam name="TInner">Type of the inner query</typeparam>
        /// <typeparam name="TKey">Type of the Key</typeparam>
        /// <typeparam name="TResult">Type of the result</typeparam>
        /// <param name="inner">inner</param>
        /// <param name="outerKeySelector">Outer key Selector</param>
        /// <param name="innerKeySelector">Inner Key Selector</param>
        /// <param name="resultSelector">Result Selector Lambda Function</param>
        /// <returns>Query</returns>
        public QueryBuilder<T> Join<TInner, TKey, TResult>(IEnumerable<TInner> inner, Expression<Func<T, TKey>> outerKeySelector, Expression<Func<TInner, TKey>> innerKeySelector, Expression<Func<T, TInner, TResult>> resultSelector)
        {
            this._query2 = (IQueryable<object>)this._query.Join(inner, outerKeySelector, innerKeySelector, resultSelector);
            return this;
        }

        /// <summary>
        /// Execute Query with Join
        /// </summary>
        /// <returns>Query</returns>
        public IEnumerable<object> ExecuteWithJoin()
        {
            return this._query2.ToList();
        }

        /// <summary>
        /// Execute Query
        /// </summary>
        /// <returns>Query</returns>
        public IEnumerable<T> Execute()
        {
            return this._query.ToList();
        }
    }
}
