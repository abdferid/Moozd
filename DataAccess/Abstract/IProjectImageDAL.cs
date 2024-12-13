using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IProjectImageDAL : IRepository<ProjectImage>
    {
        List<ProjectImage> GetProjectImagesWithProject(Expression<Func<ProjectImage, bool>> predicate = null);
    }
}
