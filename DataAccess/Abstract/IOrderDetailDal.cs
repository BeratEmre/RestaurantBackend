using Core.DataAccess;
using Entity.Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IOrderDetailDal : IEntityRepository<OrderDetail>
    {
        List<BasketDto> GetBaskestWithUserId(int userId, byte status);
        BasketDto GetBasketDtoWithOrderDetailId(int orderDetailId);
    }
}
