using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        IFoodDal _foodDal;
        public FoodManager(IFoodDal foodDal)
        {
            _foodDal = foodDal;
        }
        public Result Add(Food food)
        {
            _foodDal.Add(food);
            return new Result(true, Messages.Add("Yiyecek"));
        }

        public DataResult<List<Food>> GetAll()
        {
            List<Food> foods = _foodDal.GetAll();
            if (foods == null)
                return new ErrorDataResult<List<Food>>(foods);

            return new SuccessDataResult<List<Food>>(foods, Messages.GetAll("Yiyecek"));
        }

        public DataResult<Food> GetById(int id)
        {
            Food food = _foodDal.Get(g => g.Id == id);
            if (food != null)
                return new SuccessDataResult<Food>(food, Messages.GetById("Yiyecek"));
            return new ErrorDataResult<Food>(Messages.GetByIdErr("Yiyecek"));
        }

        public DataResult<Food> Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessDataResult<Food>(food, Messages.Update("Yiyecek"));
        }
        public DataResult<Food> RemoveFood(int id)
        {
            Food removingFood = _foodDal.Get(d => d.Id == id);
            if (_foodDal.Delete(removingFood))
                return new SuccessDataResult<Food>(removingFood, Messages.Deleting(removingFood.Name));
            return new ErrorDataResult<Food>(removingFood, Messages.NotWaitingErr(""));
        }
        public DataResult<List<KeyValue>> GetKeyValue()
        {
            List<KeyValue> keyValues = _foodDal.GetAll().Select(s => new KeyValue { Key = s.Id, Value = s.Name }).ToList();
            if (keyValues == null)
                return new ErrorDataResult<List<KeyValue>>(keyValues);

            return new SuccessDataResult<List<KeyValue>>(keyValues, Messages.GetAll("Yiyecekler"));
        }
    }

}
