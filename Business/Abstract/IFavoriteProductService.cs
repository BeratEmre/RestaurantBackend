using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFavoriteProductService
    {
        DataResult<FavoriteProduct> Add(FavoriteProduct favoriteProduct);
        DataResult<FavoriteProduct> Update(FavoriteProduct favoriteProduct);
        DataResult<List<FavoriteProduct>> GetAll();
        DataResult<List<ProductCard>> GetTopx(int x);        
    }
}
