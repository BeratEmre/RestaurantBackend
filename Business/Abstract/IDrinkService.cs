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
        Result Add(Drink drink);
        DataResult<Drink> Update(Drink drink);
        DataResult<List<Drink>> GetAll();
        DataResult<Drink> GetById(int id);
    }
}
