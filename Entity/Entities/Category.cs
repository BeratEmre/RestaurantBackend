using Core.Entities;

namespace Entity.Entities
{
    public class Category:IEntity
    {
        public int Id { get; set; }
        public string CategoryName { get; set; }
    }
}
