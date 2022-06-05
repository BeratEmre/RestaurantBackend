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
        public Result Add(Drink drink)
        {
            _drinkDal.Add(drink);
            return new Result(true, Messages.Add("İçecek"));
        }

        public DataResult<List<Drink>> GetAll()
        {
            List<Drink> drinks=_drinkDal.GetAll();
            if (drinks == null)
                return new ErrorDataResult<List<Drink>>(drinks);

            return new SuccessDataResult<List<Drink>>(drinks, Messages.GetAll("İçecek"));
        }

        public DataResult<Drink> GetById(int id)
        {
            Drink drink = _drinkDal.Get(g => g.DrinkId == id);
            if (drink != null)
                return new SuccessDataResult<Drink>(drink,Messages.GetById("İçecek"));
            return new ErrorDataResult<Drink>(Messages.GetByIdErr("İçecek"));
        }

        public DataResult<Drink> Update(Drink drink)
        {
            _drinkDal.Update(drink);
            return new SuccessDataResult<Drink>(drink, Messages.Update("İçecek"));
        }
    }
}
