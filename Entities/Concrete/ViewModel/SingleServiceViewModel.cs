using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;

namespace Entities.Concrete.ViewModel
{
    public class SingleServiceViewModel
    {
        public List<Service> Top3Services { get; set; }
        public Service Service { get; set; }
    }
}
