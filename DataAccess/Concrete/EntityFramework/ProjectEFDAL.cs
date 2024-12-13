using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ProjectEFDAL : RepositoryBase<Project, MoozdDbContext>, IProjectDAL
    {
        private readonly MoozdDbContext _context;

        public ProjectEFDAL(MoozdDbContext context)
        {
            _context = context;
        }

        public List<Project> GetProjectsWithImages(Expression<Func<Project, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Project>().Include(x => x.ProjectImages).ToList()
                  :
                  _context.Set<Project>().Include(x => x.ProjectImages).Where(predicate).ToList();
        }
        public Project GetSingleProjectWithSteps(Expression<Func<Project, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Project>().Include(x => x.ProjectImages).FirstOrDefault()
                  :
                  _context.Set<Project>().Include(x => x.ProjectImages).Where(predicate).FirstOrDefault();
        }
    }
}
