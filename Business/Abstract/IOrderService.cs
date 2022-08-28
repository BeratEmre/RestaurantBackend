using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(Order order);
        Result AddToBasket(Order order);
        DataResult<Order> Update(Order order);
        DataResult<List<Order>> GetAll();
        DataResult<List<Order>> GetBaskests();
        DataResult<Order> GetById(int id);
    }
}
