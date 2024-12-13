using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;

namespace Entities.Concrete.ViewModel
{
    public class ServicesViewModel
    {
        public ServicesText ServicesText { get; set; }
        public List<Service> Services {  get; set; }
    }
}
