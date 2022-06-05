using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class CategoryDal : EntityRepositoryBase<Category, Contexts>, ICategoryDal
    {

    }
}
