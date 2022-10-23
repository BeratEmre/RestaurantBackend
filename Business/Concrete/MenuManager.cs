using Business.Abstract;
using Core.Helpers.FileHelper;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class MenuManager : IMenuService
    {
        IMenuDal _menuDal;
        public MenuManager(IMenuDal menuDal)
        {
            _menuDal = menuDal;
        }
        public DataResult<Menu> Add(Menu Menu)
        {
            _menuDal.Add(Menu);
            return new DataResult<Menu>(Menu,true, Messages.Add("İçecek"));
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

        public DataResult<Menu> RemoveMenu(int id, string filePath)
        {
            Menu removingMenu = _menuDal.Get(d => d.MenuId == id);
            bool fileIsRemoved = true;
            if (!string.IsNullOrEmpty(removingMenu.ImgUrl))
                fileIsRemoved = File.FileRemove(filePath + removingMenu.ImgUrl);

            if (_menuDal.Delete(removingMenu)&& fileIsRemoved)
                return new SuccessDataResult<Menu>(removingMenu, Messages.Deleting(removingMenu.Name));
            return new ErrorDataResult<Menu>(removingMenu, Messages.NotWaitingErr(""));
        }

        public bool AddStar(int id)
        {
            var menu=_menuDal.Get(m => m.MenuId == id);
            if (menu == null || menu.MenuId < 1)
                return false;
            menu.IsHaveStar = true;
            _menuDal.Update(menu);
            return true;
        }

        public DataResult<List<Menu>> GetStarMenus()
        {
            var starMenus=_menuDal.GetAll(m => m.IsHaveStar);
            return new DataResult<List<Menu>>(starMenus,true, Messages.GetAll("Yıldızlı menü"));
        }
    }
}
