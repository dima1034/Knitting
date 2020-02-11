using System.Linq;
using System.Linq.Expressions;
using OrderService.DataAccess.QueryableExtensionMethods.Base.Extensions;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base
{
    internal class VisitableQueryProvider<T> : IQueryProvider
    {
        readonly VisitableQuery<T> _query;

        public VisitableQueryProvider(VisitableQuery<T> query)
        {
            _query = query;
        }

        IQueryable<TElement> IQueryProvider.CreateQuery<TElement>(Expression expression)
        {
            expression = _query.Visitors.Visit(expression);
            return _query.InnerQuery.Provider
                         .CreateQuery<TElement>(expression)
                         .AsVisitable(_query.Visitors);
        }

        IQueryable IQueryProvider.CreateQuery(Expression expression)
        {
            expression = _query.Visitors.Visit(expression);
            return _query.InnerQuery.Provider.CreateQuery(expression);
        }

        TResult IQueryProvider.Execute<TResult>(Expression expression)
        {
            expression = _query.Visitors.Visit(expression);
            return _query.InnerQuery.Provider.Execute<TResult>(expression);
        }

        object IQueryProvider.Execute(Expression expression)
        {
            expression = _query.Visitors.Visit(expression);
            return _query.InnerQuery.Provider.Execute(expression);
        }
    }
}