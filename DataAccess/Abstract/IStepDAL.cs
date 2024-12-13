using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using Entities.Concrete.TableModels;

namespace DataAccess.Abstract
{
    public interface IStepDAL : IRepository<Step>
    {
        List<Step> GetStepsWithService(Expression<Func<Step, bool>> predicate = null);
    }
}
