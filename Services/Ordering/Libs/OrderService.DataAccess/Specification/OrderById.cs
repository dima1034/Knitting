using OrderService.DataAccess.Entities;
using OrderService.DataAccess.Specification.Base;

namespace OrderService.DataAccess.Specification
{
    public class OrderById : Specification<Order>
    {
        public OrderById(int id)
        {
            Predicate = u => u.id == id;
        }
    }
}