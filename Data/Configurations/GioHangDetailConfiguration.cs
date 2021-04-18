using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class GioHangDetailConfiguration : IEntityTypeConfiguration<GioHangDetail>
    {
        public void Configure(EntityTypeBuilder<GioHangDetail> builder)
        {
            builder.ToTable("GioHangDetails");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).UseIdentityColumn();
            builder.Property(x => x.CreatedOn).HasDefaultValueSql("getdate()");
            builder.HasOne(x => x.GioHang).WithMany(x => x.GioHangDetails).HasForeignKey(x => x.GioHangId);
            builder.HasOne(x => x.Manga).WithMany(x => x.GioHangDetails).HasForeignKey(x => x.MangaId);
        }
    }
}
