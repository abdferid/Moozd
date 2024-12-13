using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IProjectService
    {
        IDataResult<List<string>> Add(Project entity, string fileName);
        IDataResult<List<string>> Update(Project entity, string fileName);
        IResult Delete(int id);
        IDataResult<Project> GetByID(int id);
        IDataResult<List<Project>> GetAll();
    }
}
