﻿using Core.Entities;
using System.IO;

namespace Entity.Entities
{
    public class Drink : IEntity
    {
        public int DrinkId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ImgUrl { get; set; }
        public double Price { get; set; }
    }
}
