using Core.Entities;

namespace Entity.Entities
{
    public class Order : IEntity
    {
        public int OrderId { get; set; }

        public int FoodId { get; set; }
        public Food Food { get; set; }

        public int DrinkId { get; set; }
        public Drink Drink { get; set; }

        public int SweetId { get; set; }
        public Sweet Sweet { get; set; }

        public int MenuId { get; set; }
        public Menu Menu { get; set; }
        public byte Status { get; set; }
        public byte Count { get; set; }
        public int UserId { get; set; }
    }
}
