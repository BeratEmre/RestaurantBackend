using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class MenuDal : EntityRepositoryBase<Menu, Contexts>, IMenuDal
    {
        public List<Menu> GetMenus()
        {
            using (var context =new Contexts())
            {
                var menus = context.Menus.Include(m=>m.Food).Include(m=>m.Drink).Include(m=>m.Sweet).ToList();
                return menus;
            }
        }
    }
}
