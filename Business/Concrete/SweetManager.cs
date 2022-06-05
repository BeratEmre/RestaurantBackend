using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class SweetManager : ISweetService
    {
        ISweetDal _sweetDal;
        public SweetManager(ISweetDal sweetDal)
        {
            _sweetDal = sweetDal;
        }
        public Result Add(Sweet sweet)
        {
            _sweetDal.Add(sweet);
            return new Result(true, Messages.Add("Tatlı"));
        }

        public DataResult<List<Sweet>> GetAll()
        {
            List<Sweet> sweet = _sweetDal.GetAll();
            if (sweet == null)
                return new ErrorDataResult<List<Sweet>>(sweet);

            return new SuccessDataResult<List<Sweet>>(sweet, Messages.GetAll("Tatlı"));
        }

        public DataResult<Sweet> GetById(int id)
        {
            Sweet sweet = _sweetDal.Get(g => g.SweetId == id);
            if (sweet != null)
                return new SuccessDataResult<Sweet>(sweet, Messages.GetById("Tatlı"));
            return new ErrorDataResult<Sweet>(Messages.GetByIdErr("Tatlı"));
        }

        public DataResult<Sweet> Update(Sweet sweet)
        {
            _sweetDal.Update(sweet);
            return new SuccessDataResult<Sweet>(sweet, Messages.Update("Tatlı"));
        }
    }

}
