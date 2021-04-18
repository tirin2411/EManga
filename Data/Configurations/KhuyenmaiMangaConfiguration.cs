using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class KhuyenmaiMangaConfiguration : IEntityTypeConfiguration<KhuyenmaiManga>
    {
        public void Configure(EntityTypeBuilder<KhuyenmaiManga> builder)
        {
            builder.ToTable("KhuyenmaiMangas");
            builder.HasKey(t => new { t.KhuyenmaiId, t.MangaId });
            builder.HasOne(t => t.Khuyenmai).WithMany(mt => mt.KhuyenmaiMangas).HasForeignKey(mt => mt.KhuyenmaiId);
            builder.HasOne(t => t.Manga).WithMany(mt => mt.KhuyenmaiMangas).HasForeignKey(mt=>mt.MangaId);
        }
    }
}
