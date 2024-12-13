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
    public class ProjectImage : BaseEntity
    {
        public string ProjectImg {  get; set; }
        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ProjectImgFile { get; set; }
        public int ProjectID { get; set; }
        public Project Project { get; set; }
    }
}
