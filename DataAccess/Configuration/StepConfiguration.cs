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
    public class StepConfiguration : IEntityTypeConfiguration<Step>
    {
        public void Configure(EntityTypeBuilder<Step> builder)
        {
            builder.Property(x => x.Title).IsRequired().HasMaxLength(30);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
        }
    }
}
