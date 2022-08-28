﻿using Core.Entities;

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
        public byte Status { get; set; }
        public int Count { get; set; }

    }
}
