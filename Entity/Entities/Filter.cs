using System;

namespace Entity.Entities
{
    public class Filter
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte ProductType { get; set; }
        public int TableNumber { get; set; }
        public decimal MinPrice { get; set; }
        public decimal MaxPrice { get; set; }
    }
}
