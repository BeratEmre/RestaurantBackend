using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class FavoriteProductDal : EntityRepositoryBase<FavoriteProduct, Contexts>, IFavoriteProductDal
    {
        public List<FavoriteProduct> GetTopx(int x)
        {
            using (var context = new Contexts())
            {
                var list = context.FavoriteProducts.OrderByDescending(u => u.Id).Take(x)?.ToList();
                return list;
            }
        }

        public List<FavoriteProduct> GetRandomx(int x)
        {
            using (var context = new Contexts())
            {
                var list = context.FavoriteProducts.OrderByDescending(u => Guid.NewGuid()).Take(x)?.ToList();
                return list;
            }
        }
    }
}
