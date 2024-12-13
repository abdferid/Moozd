using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities.Concrete.TableModels;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DataAccess.Configuration
{
    public class ServiceHeaderConfiguration : IEntityTypeConfiguration<ServiceHeader>
    {
        public void Configure(EntityTypeBuilder<ServiceHeader> builder)
        {
            builder.Property(x => x.LittleHeader).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
        }
    }
}
