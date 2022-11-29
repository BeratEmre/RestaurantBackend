using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;
using static Core.Utilities.Enums.Enums;

namespace DataAccess.Concrete.EntityFramework
{
    public class OrderDal : EntityRepositoryBase<Order, Contexts>, IOrderDal
    {
    }
}

