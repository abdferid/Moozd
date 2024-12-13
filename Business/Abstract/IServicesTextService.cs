using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IServicesTextService
    {
        IDataResult<List<string>> Add(ServicesText entity);
        IDataResult<List<string>> Update(ServicesText entity);
        IResult Delete(int id);
        IDataResult<ServicesText> GetByID(int id);
        IDataResult<List<ServicesText>> GetAll();
    }
}
