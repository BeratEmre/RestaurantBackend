using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

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
            Food food = _foodDal.Get(g => g.FoodId == id);
            if (food != null)
                return new SuccessDataResult<Food>(food, Messages.GetById("Yiyecek"));
            return new ErrorDataResult<Food>(Messages.GetByIdErr("Yiyecek"));
        }

        public DataResult<Food> Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessDataResult<Food>(food, Messages.Update("Yiyecek"));
        }
    }

}
