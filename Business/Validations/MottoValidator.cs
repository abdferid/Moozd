using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class MottoValidator : AbstractValidator<Motto>
    {
        public MottoValidator() 
        { 
            RuleFor(entity => entity.MainMotto).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Motto"))
                                                .Length(1,35).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Motto", "35"));
            RuleFor(entity => entity.Description).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Description"))
                                                .Length(1, 50).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Description", "50"));
        }
    }
}
