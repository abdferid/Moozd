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
    public class About : BaseEntity
    {
        public string Text { get; set; }
        public string AboutImg { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile AboutImgFile { get; set; }
    }
}
