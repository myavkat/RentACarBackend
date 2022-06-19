using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;
using FluentValidation;

namespace Business.ValidationRules.FluentValidation
{
    public class ModelValidator : AbstractValidator<Model>
    {
        public ModelValidator()
        {
            RuleFor(m => m.BrandId).NotEmpty();
            RuleFor(m => m.Name).NotEmpty();
            RuleFor(m => m.Name).MinimumLength(2);
        }
    }
}
