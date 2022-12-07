using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class FoodFormData : IEntity
    {
        public IFormFile FormFile { get; set; }

        public int FoodId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public decimal Price { get; set; }
    }
}
