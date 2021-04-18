using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class LienHeConfiguration : IEntityTypeConfiguration<LienHe>
    {
        public void Configure(EntityTypeBuilder<LienHe> builder)
        {
            builder.ToTable("LienHes");
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.HoTen).IsRequired().HasMaxLength(100);
            builder.Property(x => x.DiaChi).IsRequired();
            builder.Property(x => x.SDT).IsRequired().HasMaxLength(20);
            builder.Property(x => x.NoiDung).IsRequired();
            builder.Property(x => x.NgayGui).HasDefaultValueSql("getdate()");
        }
    }
}