using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ServicesTextValidator : AbstractValidator<ServicesText>
    {
        public ServicesTextValidator()
        {
            RuleFor(entity => entity.Title).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Title"))
                                                .Length(1, 300).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Title", "300"));
            RuleFor(entity => entity.MainTitle).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Main title"))
                                                .Length(1, 300).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Main title", "300"));
            RuleFor(entity => entity.LittleText).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Text"))
                                                .Length(1, 300).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Text", "300"));
        }
    }
}
