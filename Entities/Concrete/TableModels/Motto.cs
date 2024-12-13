using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.TableModels
{
    public class Motto:BaseEntity
    {
        public string MainMotto {  get; set; }
        public string Description { get; set; }
    }
}
