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
    public class StepEFDAL : RepositoryBase<Step, MoozdDbContext>, IStepDAL
    {
        private readonly MoozdDbContext _context;

        public StepEFDAL(MoozdDbContext context)
        {
            _context = context;
        }

        public List<Step> GetStepsWithService(Expression<Func<Step, bool>> predicate = null)
        {

            return predicate is null
                  ?
                   _context.Set<Step>().Include(x => x.Service).ToList()
                  :
                  _context.Set<Step>().Include(x => x.Service).Where(predicate).ToList();
        }
    }
}
