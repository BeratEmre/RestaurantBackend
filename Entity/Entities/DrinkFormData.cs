using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class DrinkFormData: ProductBase
    {
        public IFormFile FormFile { get; set; }
    }
}
