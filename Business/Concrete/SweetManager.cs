using AutoMapper;
using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class SweetManager : ISweetService
    {
        ISweetDal _sweetDal;
        IFavoriteProductDal _favoriteDal;
        private readonly IMapper _mapper;
        public SweetManager(ISweetDal sweetDal,IFavoriteProductDal favoriteProductDal, IMapper mapper)
        {
            _sweetDal = sweetDal;
            _favoriteDal= favoriteProductDal;
            _mapper = mapper;
        }
        public Result Add(Sweet sweet)
        {
            _sweetDal.Add(sweet);
            return new Result(true, Messages.Add("Tatlı"));
        }

        public DataResult<List<SweetVM>> GetAll()
        {
            List<SweetVM> sweetVMs= new List<SweetVM>();
            List<Sweet> sweets = _sweetDal.GetAll();
            if (sweets == null)
                return new ErrorDataResult<List<SweetVM>>(sweetVMs);

            var favorites = _favoriteDal.GetAll(x => x.ProductType == (byte)Enums.ProductType.sweet);
            if (favorites != null && favorites.Count > 0 && sweets.Count > 0)
            {
                foreach (var sweet in sweets)
                {
                    var sweetVM = _mapper.Map<SweetVM>(sweet);
                    sweetVM.IsHaveStar = favorites.Any(f => f.ProductId == sweet.Id);
                    sweetVMs.Add(sweetVM);

                }
            }
                    return new SuccessDataResult<List<SweetVM>>(sweetVMs, Messages.GetAll("Tatlı"));
        }

        public DataResult<Sweet> GetById(int id)
        {
            Sweet sweet = _sweetDal.Get(g => g.Id == id);
            if (sweet != null)
                return new SuccessDataResult<Sweet>(sweet, Messages.GetById("Tatlı"));
            return new ErrorDataResult<Sweet>(Messages.GetByIdErr("Tatlı"));
        }

        public DataResult<Sweet> Update(Sweet sweet)
        {
            _sweetDal.Update(sweet);
            return new SuccessDataResult<Sweet>(sweet, Messages.Update("Tatlı"));
        }

        public DataResult<Sweet> RemoveFood(int id)
        {
            Sweet removingSweet = _sweetDal.Get(d => d.Id == id);
            if (_sweetDal.Delete(removingSweet))
                return new SuccessDataResult<Sweet>(removingSweet, Messages.Deleting(removingSweet.Name));
            return new ErrorDataResult<Sweet>(removingSweet, Messages.NotWaitingErr(""));
        }
        public DataResult<Sweet> RemoveSweet(int id)
        {
            Sweet removingSweet = _sweetDal.Get(d => d.Id == id);
            if (_sweetDal.Delete(removingSweet))
                return new SuccessDataResult<Sweet>(removingSweet, Messages.Deleting(removingSweet.Name));
            return new ErrorDataResult<Sweet>(removingSweet, Messages.NotWaitingErr(""));
        }

        public DataResult<List<KeyValue>> GetKeyValue()
        {
            List<KeyValue> keyValues = _sweetDal.GetAll().Select(s => new KeyValue { Key = s.Id, Value = s.Name }).ToList();
            if (keyValues == null)
                return new ErrorDataResult<List<KeyValue>>(keyValues);

            return new SuccessDataResult<List<KeyValue>>(keyValues, Messages.GetAll("Tatlılar"));
        }
    }
}
