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
    public class StepManager : IStepService
    {
        private readonly IStepDAL _eFDAL;
        private readonly IValidator<Step> _validator;

        public StepManager(IStepDAL eFDAL, IValidator<Step> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(Step entity)
        {
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
            Update(oldEntity);
            return new SuccessResult(Core.Helpers.Constants.ConstantMessages.DeleteMessage);
        }

        public IDataResult<List<Step>> GetAll()
        {
            return new SuccessDataResult<List<Step>>(_eFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<Step> GetByID(int id)
        {
            return new SuccessDataResult<Step>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Step entity)
        {
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
