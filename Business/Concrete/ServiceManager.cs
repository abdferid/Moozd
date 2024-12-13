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
    public class ServiceManager :IServiceService
    {
        private readonly IServiceDAL _eFDAL;
        private readonly IValidator<Service> _validator;

        public ServiceManager(IServiceDAL eFDAL, IValidator<Service> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(Service entity)
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

        public IDataResult<List<Service>> GetAll()
        {
            return new SuccessDataResult<List<Service>>(_eFDAL.GetServicesWithSteps(x => x.Deleted == 0));
        }

        public IDataResult<Service> GetByID(int id)
        {
            return new SuccessDataResult<Service>(_eFDAL.GetSingleServiceWithSteps(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(Service entity)
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
