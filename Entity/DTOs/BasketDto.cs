using Core.Entities;

namespace Entity.Entities
{
    public class BasketDto : IDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public short Type { get; set; }
        public double price { get; set; }
        public int Count { get; set; }
    }
}
