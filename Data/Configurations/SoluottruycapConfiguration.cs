using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class SoluottruycapConfiguration : IEntityTypeConfiguration<Soluottruycap>
    {
        public void Configure(EntityTypeBuilder<Soluottruycap> builder)
        {
            builder.ToTable("SoLuotTruyCaps");
            builder.HasKey(x => x.Dem);
            builder.Property(x => x.Dem).IsRequired().HasDefaultValue(0);
        }
    }
}
