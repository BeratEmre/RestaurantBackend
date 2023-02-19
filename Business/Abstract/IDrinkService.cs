using Core.Utilities.Results;
using Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IDrinkService
    {
        DataResult<DrinkVM> Add(Drink drink);
        DataResult<Drink> Update(Drink drink);
        DataResult<List<DrinkVM>> GetAll();
        DataResult<Drink> GetById(int id);
        DataResult<Drink> RemoveDrink(int id);
        DataResult<List<KeyValue>> GetKeyValue();
    }
}
