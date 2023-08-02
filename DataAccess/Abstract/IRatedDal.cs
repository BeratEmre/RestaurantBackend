using Core.DataAccess;
using Entity.Entities;

namespace DataAccess.Abstract
{
    public interface IRatedDal : IEntityRepository<RatedModel>
    {
        bool ProductRatedUpdated(RatedModel rated);
    }
}
