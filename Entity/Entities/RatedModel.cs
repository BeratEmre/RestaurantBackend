using Core.Entities.concrete;

namespace Entity.Entities
{
    public class RatedModel : EntityBase
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public double Rated { get; set; }
    }
}
