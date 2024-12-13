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
    public interface IServiceDAL : IRepository<Service>
    {
        List<Service> GetServicesWithSteps(Expression<Func<Service, bool>> predicate = null);
        Service GetSingleServiceWithSteps(Expression<Func<Service, bool>> predicate = null);
    }
}
