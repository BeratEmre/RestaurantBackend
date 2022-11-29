using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        Result Add(OrderDetail order);
        DataResult<OrderDetail> AddToBasket(OrderDetail order);
        DataResult<OrderDetail> Update(OrderDetail order);
        DataResult<List<OrderDetail>> GetAll();
        DataResult<List<OrderDetail>> GetBaskests();
        DataResult<List<BasketDto>> GetBaskestWithUserId(int userId);
        DataResult<OrderDetail> GetById(int id);
        DataResult<byte> Delete(OrderDetail order);
    }
}
