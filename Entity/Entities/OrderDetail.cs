using Core.Entities;

namespace Entity.Entities
{
    public class OrderDetail:IEntity
    {
        public int OrderDetailId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }

        public double TotalPrice { get; set; }
    }
}
