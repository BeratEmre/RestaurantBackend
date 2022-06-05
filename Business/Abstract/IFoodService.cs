using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IFoodService
    {
        Result Add(Food food);
        DataResult<Food> Update(Food food);
        DataResult<List<Food>> GetAll();
        DataResult<Food> GetById(int id);
    }
}
