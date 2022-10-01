using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class DrinkDal : EntityRepositoryBase<Drink, Contexts>, IDrinkDal
    {

    }
}
