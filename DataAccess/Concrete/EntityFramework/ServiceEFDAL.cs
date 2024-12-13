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
    public class ServiceEFDAL : RepositoryBase<Service, MoozdDbContext>, IServiceDAL
    {
        private readonly MoozdDbContext _context;

        public ServiceEFDAL(MoozdDbContext context)
        {
            _context = context;
        }

        public List<Service> GetServicesWithSteps(Expression<Func<Service, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Service>().Include(x => x.Steps).ToList()
                  :
                  _context.Set<Service>().Include(x => x.Steps).Where(predicate).ToList();
        }
        public Service GetSingleServiceWithSteps(Expression<Func<Service, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Service>().Include(x => x.Steps).FirstOrDefault()
                  :
                  _context.Set<Service>().Include(x => x.Steps).Where(predicate).FirstOrDefault();
        }
    }
}
