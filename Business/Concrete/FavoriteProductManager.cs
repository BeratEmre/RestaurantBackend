using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class FavoriteProductManager : IFavoriteProductService
    {
        IFavoriteProductDal _favoriteProductDal;
        IFoodDal _foodDal;
        IMenuDal _menuDal;
        ISweetDal _sweetDal;
        IDrinkDal _drinkDal;

        public FavoriteProductManager(IFavoriteProductDal favoriteProductDal, IFoodDal foodDal, IMenuDal menuDal, ISweetDal sweetDal, IDrinkDal drinkDal)
        {
            _favoriteProductDal = favoriteProductDal;
            _foodDal = foodDal;
            _menuDal = menuDal;
            _sweetDal = sweetDal;
            _drinkDal = drinkDal;
        }

        public DataResult<FavoriteProduct> Add(FavoriteProduct favoriteProduct)
        {
            int id=_favoriteProductDal.Add(favoriteProduct);
            var reObj=_favoriteProductDal.Get(f=>f.Id==id);
            return new SuccessDataResult<FavoriteProduct>(reObj, Messages.Add("Favori"));

        }

        public DataResult<FavoriteProduct> Delete(FavoriteProduct favoriteProduct)
        {
            var reObj = _favoriteProductDal.Get(f => f.ProductType == favoriteProduct.ProductType && f.ProductId == favoriteProduct.ProductId);
            bool isDeleted = _favoriteProductDal.Delete(reObj);
            if(isDeleted)
                return new SuccessDataResult<FavoriteProduct>(reObj, Messages.Add("Favori"));
            return new ErrorDataResult<FavoriteProduct>(reObj, Messages.NotWaitingErr("Favori Ürün ilinirken"));

        }

        public DataResult<List<FavoriteProduct>> GetAll()
        {
            return new SuccessDataResult<List<FavoriteProduct>>( _favoriteProductDal.GetAll(),Messages.GetAll("Favori"));
        }

        public DataResult<List<ProductCard>> GetTopx(int x)
        {
            var topx = _favoriteProductDal.GetTopx(x);
            List<ProductCard> products = new List<ProductCard>();
            ProductCard product;
            foreach (var favProduct in topx)
            {
                product = new ProductCard();
                product.ProductType = favProduct.ProductType;
                switch (favProduct.ProductType)
                {
                    case (byte)Enums.ProductType.food:
                        var food=_foodDal.Get(f => f.Id == favProduct.ProductId);
                        product.ProductId = food.Id;
                        product.Name = food.Name;
                        product.Description = food.Description;
                        product.Price = food.Price;
                        product.ImgUrl = "/foods/"+food.ImgUrl;
                        break;

                    case (byte)Enums.ProductType.menu:
                        var menu = _menuDal.Get(f => f.Id == favProduct.ProductId);
                        product.ProductId = menu.Id;
                        product.Name = menu.Name;
                        product.Description = menu.Description;
                        product.Price = menu.Price;
                        product.ImgUrl = "/menus/" + menu.ImgUrl;
                        break;

                    case (byte)Enums.ProductType.drink:
                        var drink = _drinkDal.Get(f => f.Id == favProduct.ProductId);
                        product.ProductId = drink.Id;
                        product.Name = drink.Name;
                        product.Description = drink.Description;
                        product.Price = drink.Price;
                        product.ImgUrl = "/drinks/" + drink.ImgUrl;
                        break;

                    case (byte)Enums.ProductType.sweet:
                        var sweet = _sweetDal.Get(f => f.Id == favProduct.ProductId);
                        product.ProductId = sweet.Id;
                        product.Name = sweet.Name;
                        product.Description = sweet.Description;
                        product.Price = sweet.Price;
                        product.ImgUrl = "/sweets/" + sweet.ImgUrl;
                        break;
                }
                products.Add(product);
            }
            return new SuccessDataResult<List<ProductCard>>(products);
        }

        public DataResult<FavoriteProduct> Update(FavoriteProduct favoriteProduct)
        {
            _favoriteProductDal.Update(favoriteProduct);
            return new SuccessDataResult<FavoriteProduct>(favoriteProduct, Messages.Update("Favoriler") );
        }
    }
}
