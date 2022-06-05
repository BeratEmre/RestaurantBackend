using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class FoodDal : EntityRepositoryBase<Food, Contexts>, IFoodDal
    {

    }
}
