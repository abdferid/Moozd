using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class StepValidator : AbstractValidator<Step>
    {
        public StepValidator() 
        {
            RuleFor(entity => entity.Title).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Title"))
                                                .Length(1, 30).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Title", "30"));
            RuleFor(entity => entity.Description).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Description"))
                                                .Length(1, 50).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Description", "50"));
        }
    }
}
