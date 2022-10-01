using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(Order order);
        DataResult<Order> AddToBasket(Order order);
        DataResult<Order> Update(Order order);
        DataResult<List<Order>> GetAll();
        DataResult<List<Order>> GetBaskests();
        DataResult<List<BasketDto>> GetBaskestWithUserId(int userId);
        DataResult<Order> GetById(int id);
        DataResult<byte> Delete(Order order);
    }
}
