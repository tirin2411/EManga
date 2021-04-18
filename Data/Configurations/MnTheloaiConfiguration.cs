using Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configurations
{
    public class MnTheloaiConfiguration : IEntityTypeConfiguration<MnTheloai>
    {
        public void Configure(EntityTypeBuilder<MnTheloai> builder)
        {
            builder.ToTable("MnTheloais");
            builder.HasKey(t => new { t.MangaId, t.TheLoaiId });
            builder.HasOne(t => t.Manga).WithMany(mt => mt.MnTheloais).HasForeignKey(mt=>mt.MangaId);
            builder.HasOne(t => t.Theloai).WithMany(mt => mt.MnTheloais).HasForeignKey(mt => mt.TheLoaiId);
        }
    }
}
