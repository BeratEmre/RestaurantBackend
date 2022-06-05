using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICategoryService
    {
        Result Add(Category category);
        DataResult<Category> Update(Category category);
        DataResult<List<Category>> GetAll();
        DataResult<Category> GetById(int id);
    }
}
