using Core.DataAccess.EntityFramework;
using Core.Utilities.Enums;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using static Core.Utilities.Enums.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDetailDal : EntityRepositoryBase<OrderDetail, Contexts>, IOrderDetailDal
    {
        public List<BasketDto> GetBaskestWithUserId(int userId, byte status)
        {
            using (var context = new Contexts())
            {
                List<BasketDto> baskets = new List<BasketDto>();
                List<BasketDto> foods = context.Set<OrderDetail>().Where(o => o.FoodId > 0 && o.Status == status).Select(o =>
                        new BasketDto { Count = o.Count, Id = o.FoodId, OrderDetailId = o.Id, Name = o.Food.Name, Price = o.Food.Price, Type = (short)ProductType.food, ImgUrl = o.Food.ImgUrl }
                ).ToList();

                List<BasketDto> drinks = context.Set<OrderDetail>().Where(o => o.DrinkId > 0 && o.Status == status).Select(o =>
                              new BasketDto { Count = o.Count, Id = o.DrinkId, OrderDetailId = o.Id, Name = o.Drink.Name, Price = o.Drink.Price, Type = (short)ProductType.drink, ImgUrl = o.Drink.ImgUrl }
                  ).ToList();

                List<BasketDto> sweets = context.Set<OrderDetail>().Where(o => o.SweetId > 0 && o.Status == status).Select(o =>
                          new BasketDto { Count = o.Count, Id = o.SweetId, OrderDetailId = o.Id, Name = o.Sweet.Name, Price = o.Sweet.Price, Type = (short)ProductType.sweet, ImgUrl = o.Sweet.ImgUrl }
                  ).ToList();

                List<BasketDto> menus = context.Set<OrderDetail>().Where(o => o.MenuId > 0 && o.Status == status).Select(o =>
                          new BasketDto { Count = o.Count, Id = o.MenuId, OrderDetailId = o.Id, Name = o.Menu.Name, Price = o.Menu.Price, Type = (short)ProductType.menu, ImgUrl = o.Menu.ImgUrl }
                  ).ToList();

                baskets.AddRange(foods);
                baskets.AddRange(drinks);
                baskets.AddRange(sweets);
                baskets.AddRange(menus);

                return baskets;
            }
        }

        public BasketDto GetBasketDtoWithOrderDetailId(int orderDetailId)
        {
            using (var context = new Contexts())
            {
                BasketDto foods = context.Set<OrderDetail>().Where(o => o.Id == orderDetailId).Select(o =>

                o.ProductType == (byte)Enums.ProductType.food ?
                    new BasketDto { Count = o.Count, Id = o.FoodId, OrderDetailId = o.Id, Name = o.Food.Name, Price = o.Food.Price, Type = (short)ProductType.food, ImgUrl = o.Food.ImgUrl, Status=o.Status }
                    : o.ProductType == (byte)Enums.ProductType.drink ?
                    new BasketDto { Count = o.Count, Id = o.DrinkId, OrderDetailId = o.Id, Name = o.Drink.Name, Price = o.Drink.Price, Type = (short)ProductType.drink, ImgUrl = o.Drink.ImgUrl, Status = o.Status }
                    : o.ProductType == (byte)Enums.ProductType.sweet?
                    new BasketDto { Count = o.Count, Id = o.SweetId, OrderDetailId = o.Id, Name = o.Sweet.Name, Price = o.Sweet.Price, Type = (short)ProductType.sweet, ImgUrl = o.Sweet.ImgUrl, Status = o.Status }
                    : new BasketDto { Count = o.Count, Id = o.MenuId, OrderDetailId = o.Id, Name = o.Menu.Name, Price = o.Menu.Price, Type = (short)ProductType.menu, ImgUrl = o.Menu.ImgUrl, Status = o.Status }
                ).DefaultIfEmpty().First();
                return foods;
            }
        }
    }
}
