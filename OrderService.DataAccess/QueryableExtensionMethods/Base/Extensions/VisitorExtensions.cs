using System.Linq;
using System.Linq.Expressions;

namespace OrderService.DataAccess.QueryableExtensionMethods.Base.Extensions
{
    public static class VisitorExtensions
    {
        public static Expression Visit(this ExpressionVisitor[] visitors, Expression node)
        {
            if (visitors != null)
            {
                foreach (var visitor in visitors)
                {
                    node = visitor.Visit(node);
                }
            }
            return node;
        }
        
        // Метод расширения AsExpandable(), который обернет IQueryable<T> в наш декоратор.
        public static IQueryable<T> AsExpandable<T>(this IQueryable<T> queryable)
        {
            return queryable.AsVisitable(new ExtensionExpander());
        }

        // Декоратор для IQueryable<T>, который вызовет наш ExpressionVisitor.
        public static IQueryable<T> AsVisitable<T>(this IQueryable<T> queryable, params ExpressionVisitor[] visitors)
        {
            return queryable as VisitableQuery<T> ?? VisitableQueryFactory<T>.Create(queryable, visitors);
        }
    }
}