using Core.Entities.concrete;
using System;

namespace Entity.Entities
{
    public class Comment : EntityBase
    {        
        public string UserName { get; set; }
        public string Content { get; set; }
        public int ProductId { get; set; }
        public byte ProductTypeId { get; set; }
        public DateTime CreateDate { get; set; }
    }
}
