using AutoMapper;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Helpers
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<DrinkFormData, Drink>().ReverseMap();
            CreateMap<MenuFormData, Menu>().ReverseMap();
            CreateMap<Food, FoodVM>().ReverseMap();
            CreateMap<Drink, DrinkVM>().ReverseMap();
            CreateMap<Sweet, SweetVM>().ReverseMap();
        }
    }
}
