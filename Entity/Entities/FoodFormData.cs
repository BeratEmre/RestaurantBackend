using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class FoodFormData : ProductBase
    {
        public IFormFile FormFile { get; set; }
    }
}
