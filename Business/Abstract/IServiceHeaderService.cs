using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IServiceHeaderService
    {
        IDataResult<List<string>> Add(ServiceHeader entity, string fileName);
        IDataResult<List<string>> Update(ServiceHeader entity, string fileName);
        IResult Delete(int id);
        IDataResult<ServiceHeader> GetByID(int id);
        IDataResult<List<ServiceHeader>> GetAll();
    }
}
