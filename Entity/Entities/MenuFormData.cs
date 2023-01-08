using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class MenuFormData : IEntity
    {
        public IFormFile FormFile { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
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
