using Core.Entities;

namespace Entity.Entities
{
    public class Sweet : IEntity
    {
        public int SweetId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
    }
}
