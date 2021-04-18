using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class DonHangDetailConfiguration : IEntityTypeConfiguration<DonHangDetail>
    {
        public void Configure(EntityTypeBuilder<DonHangDetail> builder)
        {
            builder.ToTable("DonHangDetails");
            builder.HasKey(x => new { x.DonHangId, x.MangaId });
            builder.HasOne(x => x.DonHang).WithMany(x => x.DonHangDetails).HasForeignKey(x => x.DonHangId);
            builder.HasOne(x => x.Manga).WithMany(x => x.DonHangDetails).HasForeignKey(x => x.MangaId);
        }
    }
}