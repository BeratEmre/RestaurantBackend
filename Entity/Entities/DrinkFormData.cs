using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class DrinkFormData:IEntity
    {

        public IFormFile FormFile { get; set; }

        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
    }
}
