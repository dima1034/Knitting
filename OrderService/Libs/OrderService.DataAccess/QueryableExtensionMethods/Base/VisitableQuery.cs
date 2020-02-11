using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base
{
    internal class VisitableQuery<T> : IQueryable<T>, IOrderedQueryable<T>, IOrderedQueryable
    {
        readonly ExpressionVisitor[]       _visitors;
        readonly IQueryable<T>             _queryable;
        readonly VisitableQueryProvider<T> _provider;

        internal ExpressionVisitor[] Visitors   => _visitors;
        internal IQueryable<T>       InnerQuery => _queryable;

        public VisitableQuery(IQueryable<T> queryable, params ExpressionVisitor[] visitors)
        {
            _queryable = queryable;
            _visitors  = visitors;
            _provider  = new VisitableQueryProvider<T>(this);
        }

        Expression IQueryable.Expression => _queryable.Expression;

        Type IQueryable.ElementType => typeof(T);

        IQueryProvider IQueryable.Provider => _provider;

        public IEnumerator<T> GetEnumerator() { return _queryable.GetEnumerator(); }

        IEnumerator IEnumerable.GetEnumerator() { return _queryable.GetEnumerator(); }
    }
}