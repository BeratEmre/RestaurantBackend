using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;

namespace DataAccess.Concrete.EntityFramework
{
    public class SweetDal : EntityRepositoryBase<Sweet, Contexts>, ISweetDal
    {

    }
}
