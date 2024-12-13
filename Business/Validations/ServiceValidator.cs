using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ServiceValidator : AbstractValidator<Service>
    {
        public ServiceValidator() 
        {
            RuleFor(entity => entity.Title).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Title"))
                                                .Length(1, 35).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Title", "35"));
            RuleFor(entity => entity.Description).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Description"))
                                                .Length(1, 50).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Description", "50"));
        }
    }
}
