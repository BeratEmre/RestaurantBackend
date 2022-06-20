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
            Category category = _categoryDal.Get(g => g.CategoryId == id);
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
    public class MenuManager : IMenuService
    {
        IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public Result Add(Menu Menu)
        {
            _menuDal.Add(Menu);
            return new Result(true, Messages.Add("İçecek"));
        }

        public DataResult<List<Menu>> GetAll()
        {
            List<Menu> menus = _menuDal.GetAll();
            if (menus == null)
                return new ErrorDataResult<List<Menu>>(menus);

            return new SuccessDataResult<List<Menu>>(menus, Messages.GetAll("Menu"));
        }
        public DataResult<List<Menu>> GetMenus()
        {
            List<Menu> menus = _menuDal.GetMenus();
            if (menus == null)
                return new ErrorDataResult<List<Menu>>(menus);
            return new SuccessDataResult<List<Menu>>(menus, Messages.GetAll("Menu"));
        }
        public DataResult<Menu> GetById(int id)
        {
            Menu Menu = _menuDal.Get(g => g.MenuId == id);
            if (Menu != null)
                return new SuccessDataResult<Menu>(Menu, Messages.GetById("Menu"));
            return new ErrorDataResult<Menu>(Messages.GetByIdErr("Menu"));
        }

     

        public DataResult<Menu> Update(Menu Menu)
        {
            _menuDal.Update(Menu);
            return new SuccessDataResult<Menu>(Menu, Messages.Update("Menu"));
        }
    }
}
