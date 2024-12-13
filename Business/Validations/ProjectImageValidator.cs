using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class ProjectImageValidator : AbstractValidator<ProjectImage>
    {
        public ProjectImageValidator() 
        {
            RuleFor(entity => entity.ProjectImg).NotEmpty().WithMessage(Core.Helpers.Constants.ConstantMessages.RequiredMessage("Image"));
        }
    }
}
