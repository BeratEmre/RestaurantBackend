using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using static Core.Utilities.Enums.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EntityRepositoryBase<Order, Contexts>, IOrderDal
    {
        public List<BasketDto> GetBaskestWithUserId(int userId)
        {
            using (var context = new Contexts())
            {
                List<BasketDto> baskets = new List<BasketDto>();
                List<BasketDto> foods = context.Set<Order>().Where(o => o.FoodId > 0).Select(o =>
                        new BasketDto { Count = o.Count, Id = o.FoodId, Name = o.Food.Name, price = o.Food.Price, Type = (short)ProductType.food }
                ).ToList();

                List<BasketDto> drinks = context.Set<Order>().Where(o=>o.DrinkId>0).Select(o =>
                          new BasketDto { Count = o.Count, Id = o.DrinkId, Name = o.Drink.Name, price = o.Drink.Price, Type = (short)ProductType.drink }
                  ).ToList();

                List<BasketDto> sweets = context.Set<Order>().Where(o => o.SweetId > 0).Select(o =>
                          new BasketDto { Count = o.Count, Id = o.SweetId, Name = o.Sweet.Name, price = o.Sweet.Price, Type = (short)ProductType.sweet }
                  ).ToList();
                baskets.AddRange(foods);
                baskets.AddRange(drinks);
                baskets.AddRange(sweets);

                return baskets;
            }
        }
    }
}
