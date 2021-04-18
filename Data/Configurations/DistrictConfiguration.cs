using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DistrictConfiguration : IEntityTypeConfiguration<District>
    {
        public void Configure(EntityTypeBuilder<District> builder)
        {
            builder.ToTable("Districts");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.HasOne(x => x.Province).WithMany(x => x.Districts).HasForeignKey(x => x.ProvinceId);
        }
    }
}
