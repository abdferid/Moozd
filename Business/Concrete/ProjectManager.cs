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
    public class ProjectManager : IProjectService
    {
        private readonly IProjectDAL _eFDAL;
        private readonly IValidator<Project> _validator;

        public ProjectManager(IProjectDAL eFDAL, IValidator<Project> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(Project entity, string fileName)
        {
            entity.ThumbNail = fileName;
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
            Update(oldEntity, oldEntity.ThumbNail);
            return new SuccessResult(Core.Helpers.Constants.ConstantMessages.DeleteMessage);
        }

        public IDataResult<List<Project>> GetAll()
        {
            return new SuccessDataResult<List<Project>>(_eFDAL.GetProjectsWithImages(x => x.Deleted == 0));
        }

        public IDataResult<Project> GetByID(int id)
        {
            return new SuccessDataResult<Project>(_eFDAL.GetSingleProjectWithSteps(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Project entity, string fileName)
        {
            entity.ThumbNail = fileName;
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
