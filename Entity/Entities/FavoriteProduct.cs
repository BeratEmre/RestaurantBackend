using Core.Entities;

namespace Entity.Entities
{
    public class FavoriteProduct:IEntity
    {
        public int Id { get; set; }
        public byte ProductType { get; set; }
        public int ProductId { get; set; }
    }
}
