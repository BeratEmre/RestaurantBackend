using Core.Entities;
using System;

namespace Entity.Entities
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }

        public int UserId { get; set; }

        public DateTime MomentOfOrder { get; set; }

        public byte Status { get; set; }

        public int OrderDetailId { get; set; }
        public OrderDetail OrderDetail { get; set; }

        public double TotalAmount { get; set; }
    }
}
