using Business.Abstract;
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
        public DrinkManager(IDrinkDal drinkDal)
        {
            _drinkDal = drinkDal;
        }
        public DataResult<Drink> Add(Drink drink)
        {
            _drinkDal.Add(drink);
            Drink result = _drinkDal.Get(d => d.Description == drink.Description && d.Name == drink.Name && d.Price == drink.Price);
            return new DataResult<Drink>(result, true, Messages.Add("İçecek"));
        }

        public DataResult<List<Drink>> GetAll()
        {
            List<Drink> drinks = _drinkDal.GetAll();
            if (drinks == null)
                return new ErrorDataResult<List<Drink>>(drinks);

            return new SuccessDataResult<List<Drink>>(drinks, Messages.GetAll("İçecek"));
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
