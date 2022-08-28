using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

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

        public Result AddToBasket(Order order)
        {
            order.Status = (byte)Enums.OrderStatus.basket;
            _orderDal.Add(order);
            return new Result(true, Messages.Add("Sepete"));
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
            List<Order> orders = _orderDal.GetAll(p=>p.Status==10);
            if (orders == null)
                return new ErrorDataResult<List<Order>>(orders);

            return new SuccessDataResult<List<Order>>(orders, Messages.GetAll("Sepetinizdeki"));
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
