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
    public class AboutManager : IAboutService
    {
        private readonly IAboutDAL _eFDAL;
        private readonly IValidator<About> _validator;

        public AboutManager(IAboutDAL eFDAL, IValidator<About> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(About entity, string fileName)
        {
            entity.AboutImg = fileName;
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
            Update(oldEntity, oldEntity.AboutImg);
            return new SuccessResult(Core.Helpers.Constants.ConstantMessages.DeleteMessage);
        }

        public IDataResult<List<About>> GetAll()
        {
            return new SuccessDataResult<List<About>>(_eFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<About> GetByID(int id)
        {
            return new SuccessDataResult<About>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(About entity, string fileName)
        {
            entity.AboutImg = fileName;
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
