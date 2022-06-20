using Core.DataAccess;
using Entity.Entities;
using System.Collections.Generic;

namespace DataAccess.Abstract
{
    public interface IMenuDal : IEntityRepository<Menu>
    {
        public List<Menu> GetMenus();
    }
}
