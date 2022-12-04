using Core.Utilities.Results;
using DataAccess.Migrations;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderService
    {
        Result Add(int userId);
        DataResult<Order> Update(Order orderDetail);
        DataResult<List<Order>> GetAll();
        DataResult<Order> GetById(int id);
        DataResult<List<Order>> GetUserOrders(int userId); 
        DataResult<List<BasketDto>> GetActiveOrdersWithUserId(int userId);
        DataResult<List<OrderDto>> GetOrderDto();
    }
}
