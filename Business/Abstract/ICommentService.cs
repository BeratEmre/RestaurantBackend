using Core.Utilities.Results;
using Entity.Entities;
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface ICommentService
    {
        DataResult<Comment> Add(Comment comment);
        DataResult<Comment> Update(Comment comment);

        DataResult<List<Comment>> ListByProduct(ProductBase product);

    }
}
