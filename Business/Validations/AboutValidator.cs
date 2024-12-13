using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class AboutValidator : AbstractValidator<About>
    {
        public AboutValidator() 
        {
            RuleFor(entity => entity.Text).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Text"))
                                                .Length(1, 400).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Text", "400"));
            RuleFor(entity => entity.AboutImg).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Image"));
        }
    }
}
