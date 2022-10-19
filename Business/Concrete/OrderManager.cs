using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using static Core.Utilities.Enums.Enums;

namespace Business.Concrete
{
    public class OrderManager : IOrderService
    {
        IOrderDal _orderDal;
        public OrderManager(IOrderDal orderDal)
        {
            _orderDal = orderDal;
        }
        public Result Add(Order order)
        {
            _orderDal.Add(order);
            return new Result(true, Messages.Add("Şipariş"));
        }

        public DataResult<Order> AddToBasket(Order order)
        {
            Order oldOrder=_orderDal.Get(o => o.DrinkId == order.DrinkId && o.FoodId == order.FoodId && o.SweetId == order.SweetId && o.MenuId == order.MenuId && o.Status == (byte)OrderStatus.basket);
            if (oldOrder!=null)
            {
                oldOrder.Count++;
                _orderDal.Update(oldOrder);
                return new DataResult<Order>(oldOrder, true, Messages.Update("Sepet"));
            }
            order.Count = 1;
            order.Status = (byte)OrderStatus.basket;
            _orderDal.Add(order);
            return new DataResult<Order>(order, true, Messages.Add("Sepete"));
        }

        public DataResult<byte> Delete(Order order)
        {
            
            Order oldOrder = _orderDal.Get(o => o.DrinkId == order.DrinkId && o.FoodId == order.FoodId && o.SweetId == order.SweetId && o.Status == order.Status);
            if (oldOrder != null)
            {
                if (oldOrder.Count>1)
                {
                    oldOrder.Count--;
                    _orderDal.Update(oldOrder);
                    return new DataResult<byte>(oldOrder.Count, true, Messages.Update("Sepet"));
                }
                _orderDal.Delete(oldOrder);
            }

 
            return new DataResult<byte>(0, true, Messages.Deleting("Sepet"));
        }

        public DataResult<List<Order>> GetAll()
        {
            List<Order> orders = _orderDal.GetAll();
            if (orders == null)
                return new ErrorDataResult<List<Order>>(orders);

            return new SuccessDataResult<List<Order>>(orders, Messages.GetAll("Şiparişinizdeki"));
        }

        public DataResult<List<Order>> GetBaskests()
        {
            List<Order> orders = _orderDal.GetAll(p => p.Status == 10);
            if (orders == null)
                return new ErrorDataResult<List<Order>>(orders);

            return new SuccessDataResult<List<Order>>(orders, Messages.GetAll("Sepetinizdeki"));
        }

        public DataResult<List<BasketDto>> GetBaskestWithUserId(int userId)
        {
            List<BasketDto> orders = _orderDal.GetBaskestWithUserId(userId);

            return new SuccessDataResult<List<BasketDto>>(orders, Messages.GetAll("Sipariş "));
        }

        public DataResult<Order> GetById(int id)
        {
            Order order = _orderDal.Get(g => g.OrderId == id);
            if (order != null)
                return new SuccessDataResult<Order>(order, Messages.GetById("Şipariş"));
            return new ErrorDataResult<Order>(Messages.GetByIdErr("Şipariş"));
        }

        public DataResult<Order> Update(Order Order)
        {
            _orderDal.Update(Order);
            return new SuccessDataResult<Order>(Order, Messages.Update("Şipariş"));
        }
    }

}
