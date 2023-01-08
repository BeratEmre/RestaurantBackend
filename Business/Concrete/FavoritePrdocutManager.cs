using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FavoritePrdocutManager : IFavoriteProductService
    {
        IFavoriteProductDal _favoriteProductDal;

        public FavoritePrdocutManager(IFavoriteProductDal favoriteProductDal)
        {
            _favoriteProductDal = favoriteProductDal;
        }

        public DataResult<FavoriteProduct> Add(FavoriteProduct favoriteProduct)
        {
            int id=_favoriteProductDal.Add(favoriteProduct);
            var reObj=_favoriteProductDal.Get(f=>f.Id==id);
            return new SuccessDataResult<FavoriteProduct>(reObj, Messages.Add("Favori"));

        }

        public DataResult<List<FavoriteProduct>> GetAll()
        {
            return new SuccessDataResult<List<FavoriteProduct>>( _favoriteProductDal.GetAll(),Messages.GetAll("Favori"));
        }

        public DataResult<List<FavoriteProduct>> GetTopx(int x)
        {
            return new SuccessDataResult<List<FavoriteProduct>>(_favoriteProductDal.GetTopx(x));
        }

        public DataResult<FavoriteProduct> Update(FavoriteProduct favoriteProduct)
        {
            _favoriteProductDal.Update(favoriteProduct);
            return new SuccessDataResult<FavoriteProduct>(favoriteProduct, Messages.Update("Favoriler") );
        }
    }
}
