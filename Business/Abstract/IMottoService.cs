using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IMottoService
    {
        IDataResult<List<string>> Add(Motto entity);
        IDataResult<List<string>> Update(Motto entity);
        IResult Delete(int id);
        IDataResult<Motto> GetByID(int id);
        IDataResult<List<Motto>> GetAll();
    }
}
