using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IOrderDetailService
    {
        Result Add(OrderDetail orderDetail);
        DataResult<OrderDetail> Update(OrderDetail orderDetail);
        DataResult<List<OrderDetail>> GetAll();
        DataResult<OrderDetail> GetById(int id);
    }
}
