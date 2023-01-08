using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CategoryManager : ICategoryService
    {
        ICategoryDal _categoryDal;
        public CategoryManager(ICategoryDal categoryDal)
        {
            _categoryDal = categoryDal;
        }
        public Result Add(Category category)
        {
            _categoryDal.Add(category);
            return new Result(true, Messages.Add("İçecek"));
        }

        public DataResult<List<Category>> GetAll()
        {
            List<Category> categories = _categoryDal.GetAll();
            if (categories == null)
                return new ErrorDataResult<List<Category>>(categories);

            return new SuccessDataResult<List<Category>>(categories, Messages.GetAll("İçecek"));
        }

        public DataResult<Category> GetById(int id)
        {
            Category category = _categoryDal.Get(g => g.Id == id);
            if (category != null)
                return new SuccessDataResult<Category>(category, Messages.GetById("İçecek"));
            return new ErrorDataResult<Category>(Messages.GetByIdErr("İçecek"));
        }

        public DataResult<Category> Update(Category category)
        {
            _categoryDal.Update(category);
            return new SuccessDataResult<Category>(category, Messages.Update("İçecek"));
        }
    }
}
