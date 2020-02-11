using System;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.EntityFrameworkCore;
using OrderService.DataAccess.QueryableExtensionMethods.Base.Extensions;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base
{
    internal class VisitableQueryOfClass<T> : VisitableQuery<T>
        where T : class
    {
        public VisitableQueryOfClass(IQueryable<T> queryable, ExpressionVisitor[] visitors)
            : base(queryable, visitors)
        {
        }

        public IQueryable<T> Include<TProperty>(Expression<Func<T, TProperty>> navigationPropertyPath)
        {
            return InnerQuery.Include(navigationPropertyPath).AsVisitable(Visitors);
        }
    }
}