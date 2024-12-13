using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Helpers;
using Entities.Concrete.TableModels;

namespace Business.Abstract
{
    public interface IProjectImageService
    {
        IDataResult<List<string>> Add(ProjectImage entity, string fileName);
        IDataResult<List<string>> Update(ProjectImage entity, string fileName);
        IResult Delete(int id);
        IDataResult<ProjectImage> GetByID(int id);
        IDataResult<List<ProjectImage>> GetAll();
    }
}
