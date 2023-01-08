using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using static Core.Utilities.Enums.Enums;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        IOrderDetailDal _orderDetailDal;
        public OrderManager(IOrderDal orderDal, IOrderDetailDal orderDetailDal)
        {
            _orderDal = orderDal;
            _orderDetailDal= orderDetailDal;
        }
        public Result Add(int userId)
        {
           var orderDetails = _orderDetailDal.GetBaskestWithUserId(userId, (byte)Enums.OrderDetailStatus.basket);
            if (orderDetails==null || orderDetails.Count<1)            
                return new Result(false, Messages.NotWaitingErr("Sipariş eklenirken"));

            foreach (var orderDetail in orderDetails)
            {
                Order addingOrder = new Order() { 
                    MomentOfOrder=DateTime.Now,
                    OrderDetailId= orderDetail.OrderDetailId,
                    Status=(byte)Enums.OrderStatus.gettingReady,
                    TotalAmount= orderDetail.Price*orderDetail.Count,
                    UserId=userId
                };
                _orderDal.Add(addingOrder);
                var updatingOrder=_orderDetailDal.Get(o => o.Id == orderDetail.OrderDetailId);
                updatingOrder.Status = (byte)Enums.OrderDetailStatus.onOrder;
                _orderDetailDal.Update(updatingOrder);
            }
            return new Result(true, Messages.Add("Şipariş detayları"));
        }

        public DataResult<List<Order>> GetAll()
        {
            List<Order> orderDetails = _orderDal.GetAll();
            if (orderDetails == null)
                return new ErrorDataResult<List<Order>>(orderDetails);

            return new SuccessDataResult<List<Order>>(orderDetails, Messages.GetAll("Şipariş detayları"));
        }

        public DataResult<Order> GetById(int id)
        {
            Order order = _orderDal.Get(g => g.OrderDetailId == id);
            if (order != null)
                return new SuccessDataResult<Order>(order, Messages.GetById("Şipariş detayları"));
            return new ErrorDataResult<Order>(Messages.GetByIdErr("Şipariş"));
        }

        public DataResult<List<Order>> GetUserOrders(int userId)
        {
            var orders=_orderDal.GetAll(o=>o.UserId== userId);
            return new SuccessDataResult<List<Order>>(orders, Messages.GetAllOrder);
        }

        public DataResult<Order> Update(Order order)
        {
            _orderDal.Update(order);
            return new SuccessDataResult<Order>(order, Messages.Update("Şipariş detayları"));
        }

        public DataResult<List<BasketDto>> GetActiveOrdersWithUserId(int userId)
        {
            var orders=_orderDal.GetAll(o => o.Status == (byte)Enums.OrderStatus.gettingReady || o.Status == (byte)Enums.OrderStatus.completed);
            if (orders == null || orders.Count < 1)
                return new ErrorDataResult<List<BasketDto>>(null, Messages.DonotHaveAnOrder);
            List<BasketDto> basketDtos = new List<BasketDto>();
            foreach (var order in orders)
            {
                BasketDto basket = new BasketDto();
                basket=_orderDetailDal.GetBasketDtoWithOrderDetailId(order.OrderDetailId);
                if (basketDtos.Count>0)
                {
                    var obj =basketDtos.FirstOrDefault(b => b.Name == basket.Name && b.ImgUrl==basket.ImgUrl);
                    if (obj != null)
                        obj.Count++;
                    else
                        basketDtos.Add(basket);
                }
                else
                    basketDtos.Add(basket);
            }

            return new SuccessDataResult<List<BasketDto>>(basketDtos, Messages.GetAllOrders);
        }

        public DataResult<List<OrderDto>> GetOrderDto()
        {
            var orderDtos=_orderDal.GetOrderDto();
            if (orderDtos == null)
                return new ErrorDataResult<List<OrderDto>>(orderDtos, Messages.NotWaitingErr("Siparişler"));
            return new SuccessDataResult<List<OrderDto>>(orderDtos, Messages.GetAllOrderDtoList);
        }

        public DataResult<List<OrderDto>> GetOrderDtoWithFilter(Filter filter)
        {
            var orderDtos = _orderDal.GetOrderDtoWithFilter(filter);
            if (orderDtos == null)
                return new ErrorDataResult<List<OrderDto>>(orderDtos, Messages.NotWaitingErr("Siparişler"));
            return new SuccessDataResult<List<OrderDto>>(orderDtos, Messages.GetAllOrderDtoList);
        }
    }

}
