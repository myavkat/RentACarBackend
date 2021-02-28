using System;
using System.Collections.Generic;
using System.Text;
using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;

namespace Business.Concrete
{
    public class UserManager:IUserManager
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public IResult Add(User entity)
        {
            _userDal.Add(entity);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Update(User entity)
        {
            _userDal.Update(entity);
            return new SuccessResult(Messages.ItemUpdated);
        }

        public IResult Delete(User entity)
        {
            _userDal.Delete(entity);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<User> GetById(int entityId)
        {
            return new SuccessDataResult<User>(_userDal.Get(c => c.UserId == entityId), Messages.ItemListed);
        }
    }
}
