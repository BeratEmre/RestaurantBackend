using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IMenuService
    {
        Result Add(Menu menu);
        DataResult<Menu> Update(Menu menu);
        DataResult<List<Menu>> GetAll();
        DataResult<List<Menu>> GetMenus();
        DataResult<Menu> GetById(int id);
    }
}
