using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ISweetService
    {
        DataResult<SweetVM> Add(Sweet sweet);
        DataResult<Sweet> Update(Sweet sweet);
        DataResult<List<SweetVM>> GetAll();
        DataResult<Sweet> GetById(int id);
        DataResult<Sweet> RemoveSweet(int id);
        DataResult<List<KeyValue>> GetKeyValue();
    }
}
