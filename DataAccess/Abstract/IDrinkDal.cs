using Core.DataAccess;
using Entity.Entities;
using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IDrinkDal : IEntityRepository<Drink>
    {
    }
}
