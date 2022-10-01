using Core.DataAccess;
using Entity.Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IOrderDal : IEntityRepository<Order>
    {
        List<BasketDto> GetBaskestWithUserId(int userId);
    }
}
