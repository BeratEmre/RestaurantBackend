using Business.Abstract;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entity.Entities;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class CommentManager : ICommentService
    {
        ICommentDal _commentDal;

        public CommentManager(ICommentDal commentDal)
        {
            _commentDal = commentDal;
        }

        
        public DataResult<Comment> Add(Comment comment)
        {
            if (comment == null)
                return new ErrorDataResult<Comment>(Messages.NotWaitingErr("Yorum eklenirken"));

            comment.CreateDate= DateTime.Now;
            var id=_commentDal.Add(comment);

            var reObj=_commentDal.Get(x=> x.Id==id);
            if(reObj==null)
                return new ErrorDataResult<Comment>(Messages.NotWaitingErr("Yorum eklenirken"));

            return new SuccessDataResult<Comment>(reObj);
        }

        public DataResult<List<Comment>> ListByProduct(ProductBase product)
        {

            var reObjes = _commentDal.GetAll(x => x.ProductTypeId == product.ProductType && x.ProductId == product.Id);

            if (reObjes == null)
                return new ErrorDataResult<List<Comment>>(reObjes, Messages.NotWaitingErr("Yorumlar getirilirken"));
            return new SuccessDataResult<List<Comment>>(reObjes);

        }

        public DataResult<Comment> Update(Comment comment)
        {
            throw new NotImplementedException();
        }
    }
}
