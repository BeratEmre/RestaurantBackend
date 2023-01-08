using Core.DataAccess;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq.Expressions;
using System;

namespace DataAccess.Abstract
{
    public interface IFavoriteProductDal : IEntityRepository<FavoriteProduct>
    {
        List<FavoriteProduct> GetTopx(int x);
    }
}
