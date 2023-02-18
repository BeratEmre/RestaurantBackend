using AutoMapper;
using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class DrinkManager : IDrinkService
    {
        IDrinkDal _drinkDal;
        IFavoriteProductDal _favoriteDal;
        private readonly IMapper _mapper;

        public DrinkManager(IDrinkDal drinkDal, IFavoriteProductDal favoriteProductDal, IMapper mapper)
        {
            _drinkDal = drinkDal;
            _favoriteDal= favoriteProductDal;
            _mapper = mapper;
        }
        public DataResult<Drink> Add(Drink drink)
        {
            _drinkDal.Add(drink);
            Drink result = _drinkDal.Get(d => d.Description == drink.Description && d.Name == drink.Name && d.Price == drink.Price);
            return new DataResult<Drink>(result, true, Messages.Add("İçecek"));
        }

        public DataResult<List<DrinkVM>> GetAll()
        {
            List<DrinkVM> drinkVMs= new List<DrinkVM>();
            List<Drink> drinks = _drinkDal.GetAll();
            if (drinks == null)
                return new ErrorDataResult<List<DrinkVM>>(drinkVMs);

            var favorites = _favoriteDal.GetAll(x => x.ProductType == (byte)Enums.ProductType.drink);
            if (favorites != null && favorites.Count > 0 && drinks.Count > 0)
            {
                foreach (var drink in drinks)
                {
                    var drinkVM = _mapper.Map<DrinkVM>(drink);
                    drinkVM.IsHaveStar = favorites.Any(f => f.ProductId == drink.Id);
                    drinkVMs.Add(drinkVM);
                }
            }

            return new SuccessDataResult<List<DrinkVM>>(drinkVMs, Messages.GetAll("İçecek"));
        }

        public DataResult<Drink> GetById(int id)
        {
            Drink drink = _drinkDal.Get(g => g.Id == id);
            if (drink != null)
                return new SuccessDataResult<Drink>(drink, Messages.GetById("İçecek"));
            return new ErrorDataResult<Drink>(Messages.GetByIdErr("İçecek"));
        }

        public DataResult<Drink> RemoveDrink(int id)
        {
            Drink removingDrink=_drinkDal.Get(d => d.Id == id);
            if (_drinkDal.Delete(removingDrink))
                return new SuccessDataResult<Drink>(removingDrink, Messages.Deleting(removingDrink.Name));
            return new ErrorDataResult<Drink>(removingDrink, Messages.NotWaitingErr(""));
        }

        public DataResult<Drink> Update(Drink drink)
        {
            _drinkDal.Update(drink);
            return new SuccessDataResult<Drink>(drink, Messages.Update("İçecek"));
        }

        public DataResult<List<KeyValue>> GetKeyValue()
        {
            List<KeyValue> keyValues = _drinkDal.GetAll().Select(s => new KeyValue { Key = s.Id, Value = s.Name }).ToList();
            if (keyValues == null)
                return new ErrorDataResult<List<KeyValue>>(keyValues);

            return new SuccessDataResult<List<KeyValue>>(keyValues, Messages.GetAll("İçecekler"));
        }
    }
}
