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
    public interface IProjectDAL : IRepository<Project>
    {
        List<Project> GetProjectsWithImages(Expression<Func<Project, bool>> predicate = null);
        Project GetSingleProjectWithSteps(Expression<Func<Project, bool>> predicate = null);
    }
}
