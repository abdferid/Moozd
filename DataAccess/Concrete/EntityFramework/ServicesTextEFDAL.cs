using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.DataAccess.Concrete;
using DataAccess.Abstract;
using Entities.Concrete.TableModels;

namespace DataAccess.Concrete.EntityFramework
{
    public class ServicesTextEFDAL : RepositoryBase<ServicesText, MoozdDbContext>, IServicesTextDAL
    {
    }
}
