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
    public class Project : BaseEntity
    {
        public string Type { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string ThumbNail { get; set; }
        public string? WebsiteLink { get; set; }

        [NotMapped]
        [DisplayName("Upload File")]
        public IFormFile ThumbNailFile { get; set; }
        public List<ProjectImage> ProjectImages{ get; set; }
    }
}
