using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Reflection;

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
                                             join od in context.OrderDetails on o.OrderDetailId equals od.OrderDetailId
                                             join f in context.Foods on od.FoodId equals f.FoodId
                                             where od.FoodId > 0
                                             select new OrderDto
                                             {
                                                 Count = od.Count,
                                                 MomentOfOrder = o.MomentOfOrder,
                                                 Name = f.Name,
                                                 OrderDetailId = od.OrderDetailId,
                                                 Price = o.TotalAmount,
                                                 Status = o.Status,
                                                 TypeId = od.ProductType,
                                                 TypeStr="Yiyecek",
                                                 UserId = od.UserId
                                             })?.ToList();

                List<OrderDto> drinkOrders = (from o in context.Orders
                                              join od in context.OrderDetails on o.OrderDetailId equals od.OrderDetailId
                                              join d in context.Drinks on od.DrinkId equals d.DrinkId
                                              where od.DrinkId > 0
                                              select new OrderDto
                                              {
                                                  Count = od.Count,
                                                  MomentOfOrder = o.MomentOfOrder,
                                                  Name = d.Name,
                                                  OrderDetailId = od.OrderDetailId,
                                                  Price = o.TotalAmount,
                                                  Status = o.Status,
                                                  TypeId = od.ProductType,
                                                  TypeStr = "İçecek",
                                                  UserId = od.UserId
                                              })?.ToList();

                List<OrderDto> sweetOrders = (from o in context.Orders
                                              join od in context.OrderDetails on o.OrderDetailId equals od.OrderDetailId
                                              join s in context.Sweets on od.SweetId equals s.SweetId
                                              where od.SweetId > 0
                                              select new OrderDto
                                              {
                                                  Count = od.Count,
                                                  MomentOfOrder = o.MomentOfOrder,
                                                  Name = s.Name,
                                                  OrderDetailId = od.OrderDetailId,
                                                  Price = o.TotalAmount,
                                                  Status = o.Status,
                                                  TypeId = od.ProductType,
                                                  TypeStr = "Tatlı",
                                                  UserId = od.UserId
                                              })?.ToList();

                List<OrderDto> menuOrders = (from o in context.Orders
                                             join od in context.OrderDetails on o.OrderDetailId equals od.OrderDetailId
                                             join m in context.Menus on od.MenuId equals m.MenuId
                                             where od.MenuId > 0
                                             select new OrderDto
                                             {
                                                 Count = od.Count,
                                                 MomentOfOrder = o.MomentOfOrder,
                                                 Name = m.Name,
                                                 OrderDetailId = od.OrderDetailId,
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
    }
}

