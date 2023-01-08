using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;
using System;
using Core.Utilities.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EntityRepositoryBase<Order, Contexts>, IOrderDal
    {

        public List<OrderDto> GetOrderDto()
        {
            using (var context = new Contexts())
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imgs";

                List<OrderDto> orderDtos = new List<OrderDto>();

                List<OrderDto> foodOrders = (from o in context.Orders
                                             join od in context.OrderDetails on o.OrderDetailId equals od.Id
                                             join f in context.Foods on od.FoodId equals f.Id
                                             where od.FoodId > 0
                                             select new OrderDto
                                             {
                                                 Count = od.Count,
                                                 MomentOfOrder = o.MomentOfOrder,
                                                 Name = f.Name,
                                                 OrderDetailId = od.Id,
                                                 Price = o.TotalAmount,
                                                 Status = o.Status,
                                                 TypeId = od.ProductType,
                                                 TypeStr = "Yiyecek",
                                                 UserId = od.UserId
                                             })?.ToList();

                List<OrderDto> drinkOrders = (from o in context.Orders
                                              join od in context.OrderDetails on o.OrderDetailId equals od.Id
                                              join d in context.Drinks on od.DrinkId equals d.Id
                                              where od.DrinkId > 0
                                              select new OrderDto
                                              {
                                                  Count = od.Count,
                                                  MomentOfOrder = o.MomentOfOrder,
                                                  Name = d.Name,
                                                  OrderDetailId = od.Id,
                                                  Price = o.TotalAmount,
                                                  Status = o.Status,
                                                  TypeId = od.ProductType,
                                                  TypeStr = "İçecek",
                                                  UserId = od.UserId
                                              })?.ToList();

                List<OrderDto> sweetOrders = (from o in context.Orders
                                              join od in context.OrderDetails on o.OrderDetailId equals od.Id
                                              join s in context.Sweets on od.SweetId equals s.Id
                                              where od.SweetId > 0
                                              select new OrderDto
                                              {
                                                  Count = od.Count,
                                                  MomentOfOrder = o.MomentOfOrder,
                                                  Name = s.Name,
                                                  OrderDetailId = od.Id,
                                                  Price = o.TotalAmount,
                                                  Status = o.Status,
                                                  TypeId = od.ProductType,
                                                  TypeStr = "Tatlı",
                                                  UserId = od.UserId
                                              })?.ToList();

                List<OrderDto> menuOrders = (from o in context.Orders
                                             join od in context.OrderDetails on o.OrderDetailId equals od.Id
                                             join m in context.Menus on od.MenuId equals m.Id
                                             where od.MenuId > 0
                                             select new OrderDto
                                             {
                                                 Count = od.Count,
                                                 MomentOfOrder = o.MomentOfOrder,
                                                 Name = m.Name,
                                                 OrderDetailId = od.Id,
                                                 Price = o.TotalAmount,
                                                 Status = o.Status,
                                                 TypeId = od.ProductType,
                                                 TypeStr = "Menü",
                                                 UserId = od.UserId
                                             })?.ToList();
                orderDtos.AddRange(foodOrders);
                orderDtos.AddRange(drinkOrders);
                orderDtos.AddRange(sweetOrders);
                orderDtos.AddRange(menuOrders);
                return orderDtos;
            }
        }

        public List<OrderDto> GetOrderDtoWithFilter(Filter filter)
        {

            using (var context = new Contexts())
            {
                var path = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location) + "\\imgs";
                List<OrderDto> dto;

                switch (filter.ProductType)
                {
                    case (byte)Enums.ProductType.food:
                        dto = GetrderDtoFoods(filter, context);
                        break;
                    case (byte)Enums.ProductType.sweet:
                        dto = GetrderDtoSweets(filter, context);
                        break;
                    case (byte)Enums.ProductType.drink:
                        dto = GetrderDtoDrinks(filter, context);
                        break;
                    case (byte)Enums.ProductType.menu:
                        dto = GetrderDtoMenus(filter, context);
                        break;
                    default:
                        dto = GetrderDtoFoods(filter, context);
                        dto.AddRange(GetrderDtoDrinks(filter, context));
                        dto.AddRange(GetrderDtoSweets(filter, context));
                        dto.AddRange(GetrderDtoMenus(filter, context));
                        break;
                }
                return dto;
            }
        }

        private List<OrderDto> GetrderDtoFoods(Filter filter, Contexts context)
        {
            return (from o in context.Orders
                    join od in context.OrderDetails on o.OrderDetailId equals od.Id
                    join f in context.Foods on od.FoodId equals f.Id
                    where od.FoodId > 0 && o.MomentOfOrder < filter.EndDate && o.MomentOfOrder > filter.StartDate
                       && o.TotalAmount < filter.MaxPrice && o.TotalAmount > filter.MinPrice
                    select new OrderDto
                    {
                        Count = od.Count,
                        MomentOfOrder = o.MomentOfOrder,
                        Name = f.Name,
                        OrderDetailId = od.Id,
                        Price = o.TotalAmount,
                        Status = o.Status,
                        TypeId = od.ProductType,
                        TypeStr = "Yiyecek",
                        UserId = od.UserId
                    })?.ToList();
        }

        private List<OrderDto> GetrderDtoDrinks(Filter filter, Contexts context)
        {
            return (from o in context.Orders
                    join od in context.OrderDetails on o.OrderDetailId equals od.Id
                    join f in context.Drinks on od.DrinkId equals f.Id
                    where od.DrinkId > 0 && o.MomentOfOrder < filter.EndDate && o.MomentOfOrder > filter.StartDate
                       && o.TotalAmount < filter.MaxPrice && o.TotalAmount > filter.MinPrice
                    select new OrderDto
                    {
                        Count = od.Count,
                        MomentOfOrder = o.MomentOfOrder,
                        Name = f.Name,
                        OrderDetailId = od.Id,
                        Price = o.TotalAmount,
                        Status = o.Status,
                        TypeId = od.ProductType,
                        TypeStr = "İçecek",
                        UserId = od.UserId
                    })?.ToList();
        }

        private List<OrderDto> GetrderDtoSweets(Filter filter, Contexts context)
        {
            return (from o in context.Orders
                    join od in context.OrderDetails on o.OrderDetailId equals od.Id
                    join f in context.Sweets on od.SweetId equals f.Id
                    where od.SweetId > 0 && o.MomentOfOrder < filter.EndDate && o.MomentOfOrder > filter.StartDate
                       && o.TotalAmount < filter.MaxPrice && o.TotalAmount > filter.MinPrice
                    select new OrderDto
                    {
                        Count = od.Count,
                        MomentOfOrder = o.MomentOfOrder,
                        Name = f.Name,
                        OrderDetailId = od.Id,
                        Price = o.TotalAmount,
                        Status = o.Status,
                        TypeId = od.ProductType,
                        TypeStr = "Tatlı",
                        UserId = od.UserId
                    })?.ToList();
        }

        private List<OrderDto> GetrderDtoMenus(Filter filter, Contexts context)
        {
            return (from o in context.Orders
                    join od in context.OrderDetails on o.OrderDetailId equals od.Id
                    join f in context.Menus on od.MenuId equals f.Id
                    where od.MenuId > 0 && o.MomentOfOrder < filter.EndDate && o.MomentOfOrder > filter.StartDate
                       && o.TotalAmount < filter.MaxPrice && o.TotalAmount > filter.MinPrice
                    select new OrderDto
                    {
                        Count = od.Count,
                        MomentOfOrder = o.MomentOfOrder,
                        Name = f.Name,
                        OrderDetailId = od.Id,
                        Price = o.TotalAmount,
                        Status = o.Status,
                        TypeId = od.ProductType,
                        TypeStr = "Menü",
                        UserId = od.UserId
                    })?.ToList();
        }
    }
}



