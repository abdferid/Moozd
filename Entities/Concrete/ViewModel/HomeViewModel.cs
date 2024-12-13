using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;

namespace Entities.Concrete.ViewModel
{
    public class HomeViewModel
    {
        public Motto Motto { get; set; }
        public About About { get; set; }
        public ServiceHeader ServiceHeader { get; set; }
        public List<Service> Services { get; set; }
    }
}
