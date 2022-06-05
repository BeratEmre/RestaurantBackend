using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class OrderDetailManager : IOrderDetailService
    {
        IOrderDetailDal _orderDetailDal;
        public OrderDetailManager(IOrderDetailDal orderDetailDal)
        {
            _orderDetailDal = orderDetailDal;
        }
        public Result Add(OrderDetail orderDetail)
        {
            _orderDetailDal.Add(orderDetail);
            return new Result(true, Messages.Add("Şipariş detayları"));
        }

        public DataResult<List<OrderDetail>> GetAll()
        {
            List<OrderDetail> orderDetails = _orderDetailDal.GetAll();
            if (orderDetails == null)
                return new ErrorDataResult<List<OrderDetail>>(orderDetails);

            return new SuccessDataResult<List<OrderDetail>>(orderDetails, Messages.GetAll("Şipariş detayları"));
        }

        public DataResult<OrderDetail> GetById(int id)
        {
            OrderDetail orderDetail = _orderDetailDal.Get(g => g.OrderDetailId == id);
            if (orderDetail != null)
                return new SuccessDataResult<OrderDetail>(orderDetail, Messages.GetById("Şipariş detayları"));
            return new ErrorDataResult<OrderDetail>(Messages.GetByIdErr("Şipariş"));
        }

        public DataResult<OrderDetail> Update(OrderDetail orderDetail)
        {
            _orderDetailDal.Update(orderDetail);
            return new SuccessDataResult<OrderDetail>(orderDetail, Messages.Update("Şipariş detayları"));
        }
    }

}
