using System.Collections.Generic;
using System.Linq;
using OrderService.DataAccess.Entities;

namespace OrderService.DataAccess.QueryableExtensionMethods
{
    public static class QueryableExtensions
    {
        public static IQueryable<Order> FilterByDuration(this IQueryable<Order> posts, int durationHours)
        {
            return posts.Where(p => p.duration <= durationHours);
        }

        [Expandable]
        public static IQueryable<Order> FilterByAuthor(this IEnumerable<Order> posts, int authorId)
        {
            return posts.AsQueryable()
                        .Where(p => p.id == authorId);
        }
    }
}