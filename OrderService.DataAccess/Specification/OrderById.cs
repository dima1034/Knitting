using System;
using OrderService.DataAccess.Entities;

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