using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ProjectValidator : AbstractValidator<Project>
    {
        public ProjectValidator()
        {
            RuleFor(entity => entity.Type).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Type"))
                                                .Length(1, 20).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Type", "20"));
            RuleFor(entity => entity.Name).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Name"))
                                                .Length(1, 30).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Name", "30"));
            RuleFor(entity => entity.Description).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Description"))
                                                .Length(1, 400).WithMessage(Core.Helpers.Constants.ConstantMessages.LengthMessage("Dexcription", "400"));
            RuleFor(entity => entity.ThumbNail).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Image"));
        }
    }
}
