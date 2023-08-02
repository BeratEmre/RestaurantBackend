using Core.Utilities.Results;
using Entity.Entities;

namespace Business.Abstract
{
    public interface IRatedService
    {
        DataResult<RatedModel> Add(RatedModel rated);
        DataResult<RatedModel> Update(RatedModel rated);
    }
}
