using System;
using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Entities
{
    public class Order
    {
        [Key] public int      id          { get; set; }
        public       DateTime created_at  { get; set; }
        public       DateTime delivery_at { get; set; }
        public       bool     delivered   { get; set; }
        public       int      customer_id { get; set; }
        public       int      worker_id   { get; set; }
        public       int      clothes_id  { get; set; }
        public       int      duration    { get; set; }
        public       bool     paid        { get; set; }
    }
}