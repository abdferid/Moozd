using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ServiceHeaderValidator : AbstractValidator<ServiceHeader>
    {
        public ServiceHeaderValidator() 
        {
            RuleFor(entity => entity.LittleHeader).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Text"))
                                                .Length(1, 300).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Text", "300"));
            RuleFor(entity => entity.Title).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Title"))
                                                .Length(1, 300).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Title", "300"));
            RuleFor(entity => entity.HeaderImg).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Image"));
        }
    }
}
