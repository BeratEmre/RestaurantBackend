namespace Entity.Entities
{
    public class ProductCard
    {
        public int ProductId { get; set; }
        public byte ProductType { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string ImgUrl { get; set; }
    }
}
