using Core.Entities;

namespace Entity.Entities
{
    public class ProductBase:IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
        public byte ProductType { get; set; }
    }
}
