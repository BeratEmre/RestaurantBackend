using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using static Core.Utilities.Enums.Enums;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {

        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDal)
        {
            _orderDetailDal = orderDal;
        }
        public Result Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new Result(true, Messages.Add("Şipariş"));
        }

        public DataResult<OrderDetail> AddToBasket(OrderDetail orderDetail)
        {
            OrderDetail oldOrderDetail = _orderDetailDal.Get(o => o.DrinkId == orderDetail.DrinkId && o.FoodId == orderDetail.FoodId && o.SweetId == orderDetail.SweetId && o.MenuId == orderDetail.MenuId && o.Status == (byte)OrderDetailStatus.basket);
            if (oldOrderDetail != null)
            {
                oldOrderDetail.Count++;
                _orderDetailDal.Update(oldOrderDetail);
                return new DataResult<OrderDetail>(oldOrderDetail, true, Messages.Update("Sepet"));
            }
            orderDetail.Count = 1;
            orderDetail.Status = (byte)OrderDetailStatus.basket;

            orderDetail.ProductType = GetProductType(orderDetail);
            _orderDetailDal.Add(orderDetail);
            return new DataResult<OrderDetail>(orderDetail, true, Messages.Add("Sepete"));
        }

        private byte GetProductType(OrderDetail orderDetail)
        {
            byte productType = 0;
            if (orderDetail.FoodId > 0)
                productType = (byte)Enums.ProductType.food;
            if (orderDetail.DrinkId > 0)
                productType = (byte)Enums.ProductType.drink;
            if (orderDetail.SweetId > 0)
                productType = (byte)Enums.ProductType.sweet;
            if (orderDetail.MenuId > 0)
                productType = (byte)Enums.ProductType.menu;
            return productType;
        }

        public DataResult<byte> Delete(OrderDetail orderDetail)
        {

            OrderDetail oldOrderDetail = _orderDetailDal.Get(o => o.MenuId == orderDetail.MenuId && o.DrinkId == orderDetail.DrinkId && o.FoodId == orderDetail.FoodId && o.SweetId == orderDetail.SweetId && o.Status == orderDetail.Status);
            if (oldOrderDetail != null)
            {
                if (oldOrderDetail.Count > 1)
                {
                    oldOrderDetail.Count--;
                    _orderDetailDal.Update(oldOrderDetail);
                    return new DataResult<byte>(oldOrderDetail.Count, true, Messages.Update("Sepet"));
                }
                _orderDetailDal.Delete(oldOrderDetail);
            }


            return new DataResult<byte>(0, true, Messages.Deleting("Sepet"));
        }

        public DataResult<List<OrderDetail>> GetAll()
        {
            List<OrderDetail> orders = _orderDetailDal.GetAll();
            if (orders == null)
                return new ErrorDataResult<List<OrderDetail>>(orders);

            return new SuccessDataResult<List<OrderDetail>>(orders, Messages.GetAll("Şiparişinizdeki"));
        }

        public DataResult<List<OrderDetail>> GetBaskests()
        {
            List<OrderDetail> orders = _orderDetailDal.GetAll(p => p.Status == (byte)Enums.OrderDetailStatus.basket);
            if (orders == null)
                return new ErrorDataResult<List<OrderDetail>>(orders);

            return new SuccessDataResult<List<OrderDetail>>(orders, Messages.GetAll("Sepetinizdeki"));
        }

        public DataResult<List<BasketDto>> GetBaskestWithUserId(int userId)
        {
            List<BasketDto> orders = _orderDetailDal.GetBaskestWithUserId(userId, (byte)Enums.OrderDetailStatus.basket);

            return new SuccessDataResult<List<BasketDto>>(orders, Messages.GetAll("Sipariş "));
        }

      

        public DataResult<OrderDetail> GetById(int id)
        {
            OrderDetail orderDetail = _orderDetailDal.Get(g => g.Id == id);
            if (orderDetail != null)
                return new SuccessDataResult<OrderDetail>(orderDetail, Messages.GetById("Şipariş"));
            return new ErrorDataResult<OrderDetail>(Messages.GetByIdErr("Şipariş"));
        }

        public DataResult<OrderDetail> Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessDataResult<OrderDetail>(orderDetail, Messages.Update("Şipariş"));
        }


    }

}
