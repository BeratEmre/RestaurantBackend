using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class MenuFormData : ProductBase
    {
        public IFormFile FormFile { get; set; }
        public int FoodId { get; set; }
        public Food Food { get; set; }
        public int DrinkId { get; set; }
        public Drink Drink { get; set; }
        public int SweetId { get; set; }
        public Sweet Sweet { get; set; }
        public bool Selected { get; set; }
        public bool IsHaveStar { get; set; }
        public short Order { get; set; }

    }
}
