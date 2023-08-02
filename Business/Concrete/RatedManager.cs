using Business.Abstract;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Linq;

namespace Business.Concrete
{
    public class RatedManager : IRatedService
    {
        IRatedDal _ratedDal;

        public RatedManager(IRatedDal ratedDal)
        {
            _ratedDal = ratedDal;
        }

        public DataResult<RatedModel> Add(RatedModel rated)
        {
            _ratedDal.Add(rated);
            var rateds=_ratedDal.GetAll(x=>x.ProductTypeId==rated.ProductTypeId&& x.ProductId==rated.ProductId);
            var avarage=rateds.Average(x => x.Rated);
            rated.Rated = avarage;
            _ratedDal.ProductRatedUpdated(rated);
            return new SuccessDataResult<RatedModel>(rated);
        }

        public DataResult<RatedModel> Update(RatedModel rated)
        {
            _ratedDal.Update(rated);
            var rateds = _ratedDal.GetAll(x => x.ProductTypeId == rated.ProductTypeId && x.ProductId == rated.ProductId);
            var avarage = rateds.Average(x => x.Rated);
            rated.Rated = avarage;
            return new SuccessDataResult<RatedModel>(rated);
        }
    }
}
