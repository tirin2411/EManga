using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class TinTucConfiguration : IEntityTypeConfiguration<TinTuc>
    {
        public void Configure(EntityTypeBuilder<TinTuc> builder)
        {
            builder.ToTable("TinTucs");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.TieuDe).IsRequired();
            builder.Property(x => x.HinhAnhtintuc).IsRequired(true);
            builder.Property(x => x.NoiDungTomTat).IsRequired();
            builder.Property(x => x.NoiDung).IsRequired();
            builder.Property(x => x.NgayCapNhat).HasDefaultValueSql("getdate()");
            builder.Property(x => x.AnHien).HasDefaultValue(true);
        }
    }
}