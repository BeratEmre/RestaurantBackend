using AutoMapper;
using Business.Abstract;
using Core.Utilities.Enums;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using Microsoft.Data.SqlClient.Server;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class FoodManager : IFoodService
    {
        IFoodDal _foodDal;
        IFavoriteProductDal _favoriteDal;
        private readonly IMapper _mapper;

        public FoodManager(IFoodDal foodDal, IFavoriteProductDal favoriteDal, IMapper mapper)
        {
            _foodDal = foodDal;
            _favoriteDal = favoriteDal;
            _mapper = mapper;
        }
        public DataResult<FoodVM> Add(Food food)
        {
            try
            {
                int id = _foodDal.Add(food);
                var reObj = _foodDal.Get(x => x.Id == id);
                var foodVM = _mapper.Map<FoodVM>(reObj);
                return new SuccessDataResult<FoodVM>(foodVM, Messages.Add("Yiyecek"));
            }
            catch (System.Exception)
            {
                return new ErrorDataResult<FoodVM>(null, Messages.NotWaitingErr("Yiyecek eklenirken"));
            }

        }

        public DataResult<List<FoodVM>> GetAll()
        {
            List<FoodVM> foodsVMList = new List<FoodVM>();
            List<Food> foods = _foodDal.GetAll();
            var favorites = _favoriteDal.GetAll(x => x.ProductType == (byte)Enums.ProductType.food);

            foreach (var food in foods)
            {
                var foodsVM = _mapper.Map<FoodVM>(food);
                foodsVM.IsHaveStar = favorites.Any(f => f.ProductId == food.Id);
                foodsVMList.Add(foodsVM);
            }

            if (foods == null)
                return new ErrorDataResult<List<FoodVM>>(foodsVMList);

            return new SuccessDataResult<List<FoodVM>>(foodsVMList, Messages.GetAll("Yiyecek"));
        }

        public DataResult<Food> GetById(int id)
        {
            Food food = _foodDal.Get(g => g.Id == id);
            if (food != null)
                return new SuccessDataResult<Food>(food, Messages.GetById("Yiyecek"));
            return new ErrorDataResult<Food>(Messages.GetByIdErr("Yiyecek"));
        }

        public DataResult<Food> Update(Food food)
        {
            _foodDal.Update(food);
            return new SuccessDataResult<Food>(food, Messages.Update("Yiyecek"));
        }
        public DataResult<Food> RemoveFood(int id)
        {
            Food removingFood = _foodDal.Get(d => d.Id == id);
            if (_foodDal.Delete(removingFood))
                return new SuccessDataResult<Food>(removingFood, Messages.Deleting(removingFood.Name));
            return new ErrorDataResult<Food>(removingFood, Messages.NotWaitingErr(""));
        }
        public DataResult<List<KeyValue>> GetKeyValue()
        {
            List<KeyValue> keyValues = _foodDal.GetAll().Select(s => new KeyValue { Key = s.Id, Value = s.Name }).ToList();
            if (keyValues == null)
                return new ErrorDataResult<List<KeyValue>>(keyValues);

            return new SuccessDataResult<List<KeyValue>>(keyValues, Messages.GetAll("Yiyecekler"));
        }
    }

}
