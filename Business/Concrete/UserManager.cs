using Business.Abstract;
using Core.Entities.concrete;
using Core.Utilities.Messages;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        IUserDal _userDal;
        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }
        public IResult Add(User user)
        {
            if (user.FirstName.Length < 3)
            {
                return new ErrorResult();
            }
            else
            {
                _userDal.Add(user);
                return new SuccessResult(Messages.Add("Kullanıcı"));
            }
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.Deleting("Kullanıcı"));
        }

        public IDataResult<List<User>> All
        {
            get
            {
                var result = _userDal.GetAll();
                return new SuccessDataResult<List<User>>(result, Messages.GetAll("Kullanıcılar"));
            }
        }

        public IDataResult<User> GetUser(int UserId)
        {
            var result = _userDal.Get(r => r.Id == UserId);
            return new SuccessDataResult<User>(result, Messages.GetById("Kullanıcı"));
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessResult(Messages.Update("Kullanıcı"));
        }
        public User GetByMail(string email)
        {
            return _userDal.Get(u => u.Email == email);
        }
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }
    }
}


