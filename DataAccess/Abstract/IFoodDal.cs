﻿using Core.DataAccess;
using Entity.Entities;

namespace DataAccess.Abstract
{
    public interface IFoodDal : IEntityRepository<Food>
    {
    }
}
