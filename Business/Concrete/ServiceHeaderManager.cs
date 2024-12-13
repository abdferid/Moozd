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
    public class ServiceHeaderManager :IServiceHeaderService
    {
        private readonly IServiceHeaderDAL _eFDAL;
        private readonly IValidator<ServiceHeader> _validator;

        public ServiceHeaderManager(IServiceHeaderDAL eFDAL, IValidator<ServiceHeader> validator)
        {
            _eFDAL = eFDAL;
            _validator = validator;
        }

        public IDataResult<List<string>> Add(ServiceHeader entity, string fileName)
        {
            entity.HeaderImg = fileName;
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
            Update(oldEntity, oldEntity.HeaderImg);
            return new SuccessResult(Core.Helpers.Constants.ConstantMessages.DeleteMessage);
        }

        public IDataResult<List<ServiceHeader>> GetAll()
        {
            return new SuccessDataResult<List<ServiceHeader>>(_eFDAL.GetAll(x => x.Deleted == 0).ToList());
        }

        public IDataResult<ServiceHeader> GetByID(int id)
        {
            return new SuccessDataResult<ServiceHeader>(_eFDAL.Get(x => x.ID == id && x.Deleted == 0));
        }

        public IDataResult<List<string>> Update(ServiceHeader entity, string fileName)
        {
            entity.HeaderImg = fileName;
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
