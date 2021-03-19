using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class CarImageValidator : AbstractValidator<CarImage>
    {
        public CarImageValidator()
        {
            RuleFor(i => i.CarId).NotEmpty();
            RuleFor(i => i.ImagePath).NotEmpty();
            RuleFor(i => i.Date).NotEmpty();
        }
    }
}
