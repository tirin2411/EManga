using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class NgonnguMnConfiguration : IEntityTypeConfiguration<NgonnguMn>
    {
        public void Configure(EntityTypeBuilder<NgonnguMn> builder)
        {
            builder.ToTable("NgonnguMns");

            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.Name).IsRequired();
        }
    }
}
