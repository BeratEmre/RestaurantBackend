using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entity.Entities;
using Core.Entities.concrete;
using System.Collections.Generic;
using System.Linq;
using DataAccess.Migrations;
using static Core.Utilities.Enums.Enums;
using Core.Entities;
using Microsoft.EntityFrameworkCore;
using static Microsoft.AspNetCore.Hosting.Internal.HostingApplication;

namespace DataAccess.Concrete.EntityFramework
{
    public class RatedDal : EntityRepositoryBase<RatedModel, Contexts>, IRatedDal
    {
        public bool ProductRatedUpdated(RatedModel rated)
        {
            try
            {
                using (var context = new Contexts())
                {
                    Food food = context.Set<Food>().FirstOrDefault(o => o.ProductType == rated.ProductTypeId && o.Id == rated.ProductId);
                    if (food != null)
                    {
                        food.Rated = rated.Rated;
                        UpdateMethod(food, context); }

                    Drink drink = context.Set<Drink>().FirstOrDefault(o => o.ProductType == rated.ProductTypeId && o.Id == rated.ProductId);
                    if (drink != null)
                    {
                        drink.Rated = rated.Rated;
                        UpdateMethod(drink, context); }

                    Sweet sweet = context.Set<Sweet>().FirstOrDefault(o => o.ProductType == rated.ProductTypeId && o.Id == rated.ProductId);
                    if (sweet != null) {
                        sweet.Rated = rated.Rated;
                        UpdateMethod(sweet, context); }

                    Menu menu = context.Set<Menu>().FirstOrDefault(o => o.ProductType == rated.ProductTypeId && o.Id == rated.ProductId);
                    if (menu != null)
                    {
                        menu.Rated = rated.Rated;
                        UpdateMethod(menu, context); }
                }
                return true;
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        private void UpdateMethod<T>(T entity, Contexts context)
        {            
            var updatedEntity = context.Entry(entity);
            updatedEntity.State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
