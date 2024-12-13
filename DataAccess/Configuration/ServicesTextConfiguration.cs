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
    public class ServicesTextConfiguration : IEntityTypeConfiguration<ServicesText>
    {
        public void Configure(EntityTypeBuilder<ServicesText> builder)
        {
            builder.Property(x => x.LittleText).IsRequired().HasMaxLength(300);
            builder.Property(x => x.MainTitle).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Title).IsRequired().HasMaxLength(300);
            builder.Property(x => x.Deleted).HasDefaultValue<int>(0);
        }
    }
}
