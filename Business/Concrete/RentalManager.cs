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
    public class RentalManager:IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental entity)
        {
            if (_rentalDal.Get( r => r.Id == entity.Id).ReturnDate == null)
            {
                return new ErrorResult(Messages.NotReturned);
            }
            _rentalDal.Add(entity);
            return new SuccessResult(Messages.ItemAdded);
        }

        public IResult Delete(Rental entity)
        {
            _rentalDal.Delete(entity);
            return new SuccessResult(Messages.ItemDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.ItemsListed);
        }

        public IDataResult<Rental> GetById(int entityId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.Id == entityId), Messages.ItemListed);
        }

        public IResult Update(Rental entity)
        {
            _rentalDal.Update(entity);
            return new SuccessResult(Messages.ItemUpdated);
        }
    }
}
