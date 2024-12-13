using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;

namespace Entities.Concrete.TableModels
{
    public class ServicesText : BaseEntity
    {
        public string MainTitle { get; set; }
        public string LittleText { get; set; }
        public string Title { get; set; }
    }
}
