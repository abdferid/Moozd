using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.TableModels
{
    public class Step : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public Service Service { get; set; }
        public int ServiceID { get; set; }
    }
}
