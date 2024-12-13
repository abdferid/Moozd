using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Entities;
using Microsoft.AspNetCore.Http;

namespace Entities.Concrete.TableModels
{
    public class ServiceHeader : BaseEntity
    {
        public string LittleHeader { get; set; }
        public string Title { get; set; }
        public string HeaderImg { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile HeaderImgFile { get; set; }
    }
}
