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
    public class ProjectImageEFDAL : RepositoryBase<ProjectImage, MoozdDbContext>, IProjectImageDAL
    {

        private readonly MoozdDbContext _context;

        public ProjectImageEFDAL(MoozdDbContext context)
        {
            _context = context;
        }

        public List<ProjectImage> GetProjectImagesWithProject(Expression<Func<ProjectImage, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<ProjectImage>().Include(x => x.Project).ToList()
                  :
                  _context.Set<ProjectImage>().Include(x => x.Project).Where(predicate).ToList();
        }
    }
}
