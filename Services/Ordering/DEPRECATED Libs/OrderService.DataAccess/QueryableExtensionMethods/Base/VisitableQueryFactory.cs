using System;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base
{
    internal static class VisitableQueryFactory<T>
    {
        public static readonly Func<IQueryable<T>, ExpressionVisitor[], VisitableQuery<T>> Create;

        static VisitableQueryFactory()
        {
            if (!typeof(T).GetTypeInfo()
                          .IsClass)
            {
                Create = (query, visitors) => new VisitableQuery<T>(query, visitors);

                return;
            }

            var queryType    = typeof(IQueryable<T>);
            var visitorsType = typeof(ExpressionVisitor[]);

            var ctorInfo = typeof(VisitableQueryOfClass<>).MakeGenericType(typeof(T))
                                                          .GetConstructor(new[] { queryType, visitorsType });

            var queryParam    = Expression.Parameter(queryType);
            var visitorsParam = Expression.Parameter(visitorsType);
            var newExpr       = Expression.New(ctorInfo, queryParam, visitorsParam);

            var createExpr = Expression.Lambda<Func<IQueryable<T>, ExpressionVisitor[], VisitableQuery<T>>>(
                newExpr,
                queryParam,
                visitorsParam);

            Create = createExpr.Compile();
        }
    }
}