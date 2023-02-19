using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFoodService
    {
        DataResult<FoodVM> Add(Food food);
        DataResult<Food> Update(Food food);
        DataResult<List<FoodVM>> GetAll();
        DataResult<Food> GetById(int id);
        DataResult<Food> RemoveFood(int id);
        DataResult<List<KeyValue>> GetKeyValue();
    }
}
