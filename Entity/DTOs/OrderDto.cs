using Core.Entities;
using System;

namespace Entity.Entities
{
    public class OrderDto : IDto
    {
        public int OrderDetailId { get; set; }
        public int UserId { get; set; }
        public string Name { get; set; }
        public string TypeStr { get; set; }
        public short TypeId { get; set; }
        public double Price { get; set; }
        public int Count { get; set; }
        public DateTime MomentOfOrder { get; set; }
        public byte Status { get; set; }
    }
}
