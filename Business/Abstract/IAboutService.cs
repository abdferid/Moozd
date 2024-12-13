using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IAboutService
    {
        IDataResult<List<string>> Add(About entity, string fileName);
        IDataResult<List<string>> Update(About entity, string fileName);
        IResult Delete(int id);
        IDataResult<About> GetByID(int id);
        IDataResult<List<About>> GetAll();
    }
}
