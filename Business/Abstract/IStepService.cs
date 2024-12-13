using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IStepService
    {
        IDataResult<List<string>> Add(Step entity);
        IDataResult<List<string>> Update(Step entity);
        IResult Delete(int id);
        IDataResult<Step> GetByID(int id);
        IDataResult<List<Step>> GetAll();
    }
}
