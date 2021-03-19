using System.Collections.Generic;
using Core.Business;
using Core.Utilities.Results;
using Entities.Concrete;

namespace Business.Abstract
{
    public interface ICarImageService : IEntityManager<CarImage>
    {
        IDataResult<List<CarImage>> GetAllByCarId(int carId);
    }
}
