using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Business.Abstract;
using Core.Helpers;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using FluentValidation;

namespace Business.Concrete
{
    public class ProjectImageManager : IProjectImageService
    {
        private readonly IProjectImageDAL _eFDAL;
        private readonly IValidator<ProjectImage> _validator;

        public ProjectImageManager(IProjectImageDAL eFDAL, IValidator<ProjectImage> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(ProjectImage entity, string fileName)
        {
            entity.ProjectImg = fileName;
            var validationResult = _validator.Validate(entity);
            if (!validationResult.IsValid)
            {
                return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
            }

            _eFDAL.Add(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), Core.Helpers.Constants.ConstantMessages.AddMessage);
        }

        public IResult Delete(int id)
        {
            var oldEntity = _eFDAL.Get(x => x.ID == id && x.Deleted == 0);
            oldEntity.Deleted = oldEntity.ID;
            Update(oldEntity, oldEntity.ProjectImg);
            return new SuccessResult(Core.Helpers.Constants.ConstantMessages.DeleteMessage);
        }

        public IDataResult<List<ProjectImage>> GetAll()
        {
            return new SuccessDataResult<List<ProjectImage>>(_eFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<ProjectImage> GetByID(int id)
        {
            return new SuccessDataResult<ProjectImage>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(ProjectImage entity, string fileName)
        {
            entity.ProjectImg = fileName;
            if (entity.Deleted == 0)
            {
                var validationResult = _validator.Validate(entity);
                if (!validationResult.IsValid)
                {
                    return new ErrorDataResult<List<string>>(validationResult.Errors.Select(e => e.PropertyName).ToList(), validationResult.Errors.Select(e => e.ErrorMessage).ToList());
                }
            }

            _eFDAL.Update(entity);
            return new SuccessDataResult<List<string>>(new List<string>(), Core.Helpers.Constants.ConstantMessages.EditMessage);
        }
    }
}
