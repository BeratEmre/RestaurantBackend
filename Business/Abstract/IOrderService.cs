using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(Order order);
        DataResult<Order> Update(Order order);
        DataResult<List<Order>> GetAll();
        DataResult<Order> GetById(int id);
    }
}
