using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entity.Entities
{
    public class SweetFormData : ProductBase
    {
        public IFormFile FormFile { get; set; }
    }
}
