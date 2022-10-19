using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMenuService
    {
        DataResult<Menu> Add(Menu menu);
        DataResult<Menu> Update(Menu menu);
        DataResult<List<Menu>> GetAll();
        DataResult<List<Menu>> GetMenus();
        DataResult<Menu> GetById(int id);
        DataResult<Menu> RemoveMenu(int id,string filePath);
        bool AddStar(int id);

    }
}
