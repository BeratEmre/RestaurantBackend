using Core.Entities;

namespace Entity.Entities
{
    public class Menu : ProductBase
    {
        public int FoodId { get; set; }
        public virtual Food Food { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int SweetId { get; set; }
        public Sweet Sweet { get; set; }
        public bool Selected { get; set; }
        public bool IsHaveStar { get; set; }
        public short Order { get; set; }
    }
}
