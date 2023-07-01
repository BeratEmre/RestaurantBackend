using Core.DataAccess;
using Entity.Entities;

namespace DataAccess.Abstract
{
    public interface ICommentDal : IEntityRepository<Comment>
    {
    }
}
