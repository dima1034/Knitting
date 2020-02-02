using System;
using System.ComponentModel.DataAnnotations;

namespace OrderService.DataAccess.Entities
{
    public class Order
    {
        [Key] public int      id               { get; set; }
        public       DateTime created_at       { get; set; }
        public       DateTime will_finished_at { get; set; }
        public       DateTime finished_at      { get; set; }
        public       int      customer_id      { get; set; }
        public       int      worker_id        { get; set; }
        public       int      clothes_id       { get; set; }
        public       int      takes_time       { get; set; }
        public       int      paid             { get; set; }
    }
}